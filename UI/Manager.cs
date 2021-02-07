#define IL2CPP

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using Hotkeys;
using WMKeyToChar;
using RawInput_dll;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using OriWotW;
using OriWotW.UI;
using System.Windows.Forms.VisualStyles;
using OriWotW.Memory;
using System.Security.Cryptography.X509Certificates;
using OriWotW.UI.Input;
using System.Diagnostics.Eventing.Reader;
using OriWotW.UberController;
using GijSoft.DllInjection;
using OriWotW.Logic;
using OriWotW.GameWorld;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OriWotW.RaceStuff;
using TemAutoUpdater;
using OriWotW.UI.Teleporter;
using Microsoft.WindowsAPICodePack.Dialogs;
using Tem.TemClass;
using Tem.Utility;

namespace OriWotW {
    public partial class Manager : Form {
        public static bool IsDisposingNow = false;
        private static int AverageFPSLength = 25;
        public MemoryManager Memory { get; set; }
        private TemAutoUpdater.ManagerAutoUpdater ManagerAutoUpdater;
        private Thread timerLoop;
        private Thread DLLCommunication;
        private bool useLivesplitColors = true;
        public Vector3 currentPosition, lastPosition, lastSpeed;
        private bool noPause = false;
        public long currentFrameCount, lastFrameCount;
        private Hotkeys.GlobalHotkey ghk;
        private List<Tuple<String, int>> newKeysDown = new List<Tuple<String, int>>();
        private List<Tuple<String, int, long>> keyCombos = new List<Tuple<String, int, long>>();
        private int currentFrame = 0;
        public RawInput rawInput;
        private WOTWKeyBindings Bindings = new WOTWKeyBindings();
        private Stopwatch sw = new Stopwatch();
        public ComboManager comboManager = new ComboManager();
        public bool EditKeys = false;
        public PlayerUberStateStats oriStats = new PlayerUberStateStats();
        public ManagerSettings visibilitySettings = new ManagerSettings();
        public InputTrainer inputTrainer;
        public List<int> oldPlayerInputs = new List<int>();
        public PlayerInput SeinInput = new PlayerInput();
        private int LoopTimer = 0;
        private int InputLockTimer = 0;
        public bool IsUsingController = false;
        public List<ToolStripMenuItem> menuVisibilityItems = new List<ToolStripMenuItem>();
        public SeinStateUI SeinStateUI;
        public RaceTimer RaceTimer;
        public UberStateController UberStateController;
        public DllInjector DllInjector;
        public InjectCommunication InjectCommunication;
        public bool canStart = false;
        public float GameCompletion = 0.0f;
        public RaceEditor RaceEditor;
        public HitboxSplit HitboxSplit;
        public RaceState IsRacing = RaceState.Waiting;
        public ControlScheme LastControlScheme { get; private set; } = ControlScheme.KeyboardAndMouse;
        public List<float> AverageFPS = new List<float>();
        public BackupsaveUI backupsaveUI;
        public SeinVisualEditor visualEditor;
        public WotwEditor transformEditor;

        [STAThread]
        public static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Manager managerWindow = new Manager();
            TemAutoUpdater.ManagerAutoUpdater ManagerAutoUpdater = new TemAutoUpdater.ManagerAutoUpdater(true);
            if (ManagerAutoUpdater.IsDisposed == false)
                Application.Run(ManagerAutoUpdater);

            Application.Run(managerWindow);
        }
        public Manager() {
            this.DoubleBuffered = true;
            this.TopLevel = true;
            InitializeComponent();

            string pathTemp = Path.GetTempPath();
            File.WriteAllText(pathTemp + "\\extendedmanager.tmp", AppDomain.CurrentDomain.BaseDirectory);

            comboManager.SetForm(this);
            managerStatus.Text = "Initializing the manager";

            this.SeinStateUI = new SeinStateUI(this.flowStateList, new List<Tuple<string, string>>() { new Tuple<string, string>("Dash", "Dash"),
            new Tuple<string, string>("Djump", "Jump"),
            new Tuple<string, string>("Walljump", "Walljump"),
            new Tuple<string, string>("IsOnWall", "Is On Wall"),
            new Tuple<string, string>("OnCeiling", "Ceiling"),
            new Tuple<string, string>("OnGround", "Ground"),
            new Tuple<string, string>("OnWallLeft", "Wall Left"),
            new Tuple<string, string>("OnWallRight", "Wall Right"),
            new Tuple<string, string>("Bash", "Bash"),
            new Tuple<string, string>("Leash", "Leash"),
            new Tuple<string, string>("VGrenadeBash", "VGrenadeBash"),
            new Tuple<string, string>("StandingOnEdge", "On Edge"),
            new Tuple<string, string>("WallLeftAngle", "WL Angle"),
            new Tuple<string, string>("WallRightAngle", "WR Angle")
            }, new Dictionary<string, Label>() {{"AirNoDeceleration", lblAirNoDeceleration },
                { "SpeedFactor", lblSpeedFactor } }, menuItem_Click, ref this.visibilitySettings);

            CreateContextMenu();
            comboManager.ApplySettings();

            var test1 = Application.VisualStyleState;

            ghk = new Hotkeys.GlobalHotkey(Constants.ALT + Constants.SHIFT, Keys.O, this);
            if (ghk.Register()) { }

            rawInput = new RawInput(this.Handle, false);
            rawInput.AddMessageFilter();
            Win32.DeviceAudit();
            rawInput.KeyPressed += OnKeyPressed;

            sw.Start();

            Memory = new MemoryManager();
            this.InjectCommunication = new InjectCommunication(this);
            StartUpdateLoop();
            StartDLLCommunicationLoop();

            Text = "Ori WotW " + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            RaceEditor = new RaceEditor(this);
            HitboxSplit = new HitboxSplit(this);
            inputTrainer = new InputTrainer(this);
            managerStatus.Text = "Manager has been initialized";
        }

        public void StartUpdateLoop() {
            if (timerLoop != null) { return; }

            timerLoop = new Thread(UpdateLoop);
            timerLoop.IsBackground = true;
            timerLoop.Priority = ThreadPriority.AboveNormal;
            timerLoop.Start();
        }

        private void UpdateLoop() {
            bool lastHooked = false;

            while (IsDisposingNow == false && timerLoop != null) {
                try {
                    bool hooked = Memory.HookProcess();
                    if (hooked && IsDisposingNow == false) {
                        UpdateValues();
                    }
                    if (lastHooked != hooked) {
                        lastHooked = hooked;
                        this.BeginInvoke((Action)delegate () { lblNote.Visible = !hooked; });
                    }
                } catch { }
                if (Thread.CurrentThread.IsAlive == false) { return; }
                if (IsDisposingNow == true) { return; }
                if (timerLoop == null || IsDisposingNow == true || timerLoop.IsAlive == false) { return; }
                if (IsDisposingNow == true || this.Disposing == true) { timerLoop.Abort(); return; }
                LoopTimer++;
                InputLockTimer++;
                Thread.Sleep(7);
            }
        }

        public void StartDLLCommunicationLoop() {
            this.DLLCommunication = new Thread(DLLCommunicationLoop);
            this.DLLCommunication.IsBackground = true;
            this.DLLCommunication.Priority = ThreadPriority.AboveNormal;
            this.DLLCommunication.Start();
        }

        private void DLLCommunicationLoop() {
            while (IsDisposingNow == false && this.DLLCommunication != null && Thread.CurrentThread.IsAlive) {
                try {
                    if (IsDisposingNow == false && this.InjectCommunication != null && this.InjectCommunication.StreamWriter != null) {
                        UpdateDLLValues();
                    }
                } catch { }
                if (Thread.CurrentThread.IsAlive == false) { return; }
                if (IsDisposingNow == true) { return; }
                Thread.Sleep(16);
            }
        }

        public void UpdateDLLValues() {
            if (Thread.CurrentThread.IsAlive == false) { return; }
            if (DLLCommunication == null) { Thread.CurrentThread.Abort(); return; }
            if (DLLCommunication.IsAlive == false) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == true) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == false && InvokeRequired) {
                if (IsDisposingNow == true) {
                    Thread.CurrentThread.Abort();
                    return;
                } else {
                    this.BeginInvoke((Action)UpdateDLLValues);
                    return;
                }
            }

            this.InjectCommunication.Send();
        }

        public void CheckGameInputs() {
            if (IsUsingController == true) {
                Memory.ReadPlayerInputs(ref SeinInput);

                AxisInputs axisInputs = SeinInput.AxisInputs;
                if (axisInputs.DPadDirection1.StateRight == InputState.InputWasPressed) {
                    KeyPressed("JoypadDpadRight");
                    AddInputIcon("JoypadDpadRight");
                } else if (axisInputs.DPadDirection1.StateRight == InputState.InputWasReleased) {
                    KeyReleased("JoypadDpadRight");
                    RemoveInputIcon("JoypadDpadRight");
                }
                if (axisInputs.DPadDirection1.StateLeft == InputState.InputWasPressed) {
                    KeyPressed("JoypadDpadLeft");
                    AddInputIcon("JoypadDpadLeft");
                } else if (axisInputs.DPadDirection1.StateLeft == InputState.InputWasReleased) {
                    KeyReleased("JoypadDpadLeft");
                    RemoveInputIcon("JoypadDpadLeft");
                }

                if (axisInputs.DPadDirection1.StateUp == InputState.InputWasPressed) {
                    KeyPressed("JoypadDpadUp");
                    AddInputIcon("JoypadDpadUp");
                } else if (axisInputs.DPadDirection1.StateUp == InputState.InputWasReleased) {
                    KeyReleased("JoypadDpadUp");
                    RemoveInputIcon("JoypadDpadUp");
                }
                if (axisInputs.DPadDirection1.StateDown == InputState.InputWasPressed) {
                    KeyPressed("JoypadDpadDown");
                    AddInputIcon("JoypadDpadDown");
                } else if (axisInputs.DPadDirection1.StateDown == InputState.InputWasReleased) {
                    KeyReleased("JoypadDpadDown");
                    RemoveInputIcon("JoypadDpadDown");
                }

                if (axisInputs.Axis4.StateRight == InputState.InputWasPressed) {
                    KeyPressed("JoypadRightStickRight");
                    AddInputIcon("JoypadRightStickRight");
                } else if (axisInputs.Axis4.StateRight == InputState.InputWasReleased) {
                    KeyReleased("JoypadRightStickRight");
                    RemoveInputIcon("JoypadRightStickRight");
                }
                if (axisInputs.Axis4.StateLeft == InputState.InputWasPressed) {
                    KeyPressed("JoypadRightStickLeft");
                    AddInputIcon("JoypadRightStickLeft");
                } else if (axisInputs.Axis4.StateLeft == InputState.InputWasReleased) {
                    KeyReleased("JoypadRightStickLeft");
                    RemoveInputIcon("JoypadRightStickLeft");
                }

                if (axisInputs.Axis4.StateUp == InputState.InputWasPressed) {
                    KeyPressed("JoypadRightStickUp");
                    AddInputIcon("JoypadRightStickUp");
                } else if (axisInputs.Axis4.StateUp == InputState.InputWasReleased) {
                    KeyReleased("JoypadRightStickUp");
                    RemoveInputIcon("JoypadRightStickUp");
                }
                if (axisInputs.Axis4.StateDown == InputState.InputWasPressed) {
                    KeyPressed("JoypadRightStickDown");
                    AddInputIcon("JoypadRightStickDown");
                } else if (axisInputs.Axis4.StateDown == InputState.InputWasReleased) {
                    KeyReleased("JoypadRightStickDown");
                    RemoveInputIcon("JoypadRightStickDown");
                }

                if (axisInputs.Axis3.StateRight == InputState.InputWasPressed) {
                    KeyPressed("JoypadLeftStickRight");
                    AddInputIcon("JoypadLeftStickRight");
                } else if (axisInputs.Axis3.StateRight == InputState.InputWasReleased) {
                    KeyReleased("JoypadLeftStickRight");
                    RemoveInputIcon("JoypadLeftStickRight");
                }
                if (axisInputs.Axis3.StateLeft == InputState.InputWasPressed) {
                    KeyPressed("JoypadLeftStickLeft");
                    AddInputIcon("JoypadLeftStickLeft");
                } else if (axisInputs.Axis3.StateLeft == InputState.InputWasReleased) {
                    KeyReleased("JoypadLeftStickLeft");
                    RemoveInputIcon("JoypadLeftStickLeft");
                }

                if (axisInputs.Axis3.StateUp == InputState.InputWasPressed) {
                    KeyPressed("JoypadLeftStickUp");
                    AddInputIcon("JoypadLeftStickUp");
                } else if (axisInputs.Axis3.StateUp == InputState.InputWasReleased) {
                    KeyReleased("JoypadLeftStickUp");
                    RemoveInputIcon("JoypadLeftStickUp");
                }
                if (axisInputs.Axis3.StateDown == InputState.InputWasPressed) {
                    KeyPressed("JoypadLeftStickDown");
                    AddInputIcon("JoypadLeftStickDown");
                } else if (axisInputs.Axis3.StateDown == InputState.InputWasReleased) {
                    KeyReleased("JoypadLeftStickDown");
                    RemoveInputIcon("JoypadLeftStickDown");
                }

                List<string> newText1 = new List<string>();
                foreach (var input in SeinInput.SeinInputs) {
                    switch (input.Value.State) {
                        case InputState.InputWasPressed:
                            if (SeinInput.SeinButtons.ContainsKey(input.Value.Key) == true) {
                                if (SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex < SeinInput.SeinButtons[input.Value.Key].Buttons.Count) {
                                    string keyName = SeinInput.SeinButtons[input.Value.Key].Buttons[SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex];
                                    if (newText1.IndexOf(keyName) == -1) {
                                        newText1.Add(keyName);
                                    }
                                    if (input.Value.IsControllerInput || PlayerInput.ControllerInputNamesToJoypad.ContainsKey(keyName) == true || PlayerInput.ControllerInputNames.IndexOf(keyName) != -1)
                                        AddInputIcon(keyName);
                                }
                            }
                            if (input.Value.IsControllerInput)
                                KeyPressed(input.Value.Key);
                            break;

                        case InputState.InputIsPressed:
                            if (SeinInput.SeinButtons.ContainsKey(input.Value.Key) == true) {
                                if (SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex < SeinInput.SeinButtons[input.Value.Key].Buttons.Count) {
                                    string keyName = SeinInput.SeinButtons[input.Value.Key].Buttons[SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex];
                                    if (newText1.IndexOf(keyName) == -1) {
                                        newText1.Add(keyName);
                                    }
                                }
                            }
                            break;

                        case InputState.InputWasReleased:
                            if (SeinInput.SeinButtons.ContainsKey(input.Value.Key) == true) {
                                if (SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex < SeinInput.SeinButtons[input.Value.Key].Buttons.Count) {
                                    string keyName = SeinInput.SeinButtons[input.Value.Key].Buttons[SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex];
                                    RemoveInputIcon(keyName);
                                }
                            }

                            if (input.Value.IsControllerInput)
                                KeyReleased(input.Value.Key);
                            break;

                        case InputState.InputIsReleased: {
                                if (this.flowInputIcons.Controls.Count > 0 && SeinInput.SeinButtons.ContainsKey(input.Value.Key) == true) {
                                    if (SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex < SeinInput.SeinButtons[input.Value.Key].Buttons.Count) {
                                        string keyName = SeinInput.SeinButtons[input.Value.Key].Buttons[SeinInput.SeinButtons[input.Value.Key].m_lastPressedIndex];
                                        //RemoveInputIcon(keyName);
                                    }
                                }
                            }

                            if (input.Value.IsControllerInput && flowInputIcons.Controls.Count > 0)
                                KeyReleased(input.Value.Key);
                            break;
                    }
                }

                CheckInputs();
            }
            inputTrainer.CheckTimer(sw.ElapsedMilliseconds);
        }

        public void AddInputIcon(string keyName) {
            PictureBox image = inputTrainer.GetInputImage(keyName, 64);

            if (image != null) {
                bool controlIconFound = false;
                foreach (PictureBox tIcon in flowInputIcons.Controls) {
                    if (tIcon.Name.Equals(keyName) == true) {
                        controlIconFound = true;
                    }
                }
                if (controlIconFound == false) {
                    image.Name = keyName;
                    flowInputIcons.Controls.Add(image);
                }
            }
        }

        public void RemoveInputIcon(string keyName) {
            foreach (PictureBox tIcon in flowInputIcons.Controls) {
                if (tIcon.Name.Equals(keyName) == true) {
                    tIcon.Dispose();
                }
            }
        }

        public void ManagerInitialized() {
            visualEditor = new SeinVisualEditor(this, false);
            this.managerStatus.Text = "DLL has initialized";
            this.statusStrip1.Visible = false;
        }

        public void UpdateValues() {
            if (Thread.CurrentThread.IsAlive == false) { return; }
            if (this.timerLoop == null) { Thread.CurrentThread.Abort(); return; }
            if (this.timerLoop.IsAlive == false) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == true) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == true) { Thread.CurrentThread.Abort(); return; }
            if (this.Disposing == true) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == true) { Thread.CurrentThread.Abort(); return; }
            if (this.Disposing == true) { Thread.CurrentThread.Abort(); return; }
            if (IsDisposingNow == false && InvokeRequired) {
                if (IsDisposingNow == true) {
                    Thread.CurrentThread.Abort();
                    return;
                } else {
                    this.BeginInvoke((Action)UpdateValues);
                    return;
                }
            }

            this.CheckGameInputs();

            if (this.LoopTimer < 5) {
                return;
            }

            GameState gameState = Memory.GameState();
            bool isLoading = Memory.IsLoadingGame(gameState);

            ControlScheme scheme = Memory.GetControlScheme();
            if (scheme == ControlScheme.Controller)
                IsUsingController = true;
            else
                IsUsingController = false;

            if (this.canStart == true && this.DllInjector == null) { //&& gameState != GameState.TitleScreen
                this.DllInjector = DllInjector.GetInstance;
                Memory.PatchNoPause(true);
                DllInjectionResult result = this.DllInjector.Inject("oriwotw", AppDomain.CurrentDomain.BaseDirectory + "\\injectdll.dll");

                if (result == DllInjectionResult.GameProcessNotFound)
                    result = this.DllInjector.Inject("oriandthewillofthewisps-pc", AppDomain.CurrentDomain.BaseDirectory + "\\injectdll.dll");

                File.AppendAllText("C:\\moon\\manager_error.log", "DLL Handle intptr: " + DllInjector.DllHandle.ToString() + " DLL adress1: " + DllInjector.DllPtr.ToString() + " DLL adress2: " + DllInjector.DllPtr2.ToString() + " Injection result: " + result.ToString() + "\r\n");

                if (result != DllInjectionResult.Success)
                    managerStatus.Text = "Injection failed, reason: " + result.ToString();
                else
                    managerStatus.Text = "Injection was successful";

                this.InjectCommunication.AddCall("CALL19PAR" + AppDomain.CurrentDomain.BaseDirectory);

                if (gameState != GameState.Logos && gameState != GameState.StartScreen && isLoading == false) {
                    Memory.ReadPlayerInputs(ref SeinInput);
                    List<CompoundButtonInput> allBinds = Memory.GenerateBindingsMap(); //this.Bindings.AllKeyBindings <- replace
                    WOTWKeyBindings.InputMap.Clear();
                    this.Bindings.AllKeyBindingsMap.Clear();
                    this.Bindings.AllKeyBindings.Clear();

                    foreach (CompoundButtonInput button in allBinds) {
                        WOTWKeyBinding keyBind = new WOTWKeyBinding(button.BindName.Trim(), "NONE", "NONE", "NONE", "NONE");

                        foreach (string keyName in button.Buttons) {
                            keyBind.AddBind(keyName.Trim());
                            //this.Bindings.AllInputBindingsMap.Add(keyName.Trim(), this.Bindings.AllKeyBindings.Count);
                        }

                        this.Bindings.AllKeyBindings.Add(keyBind);

                        if (this.Bindings.AllKeyBindingsMap.ContainsKey(keyBind.ActualBind) == false)
                            this.Bindings.AllKeyBindingsNamedMap.Add(keyBind.ActualBind, keyBind);
                    }
                    this.Bindings.GenerateKeyBindindMap();
                }
            }

            float FPS = Memory.FPS();

            if (AverageFPS.Count <= AverageFPSLength - 1)
                AverageFPS.Add(FPS);
            else if (AverageFPS.Count == AverageFPSLength) {
                AverageFPS.RemoveAt(AverageFPSLength - 1);
                AverageFPS.Insert(0, FPS);
            }

            lastPosition = currentPosition;
            currentPosition = Memory.Position();
            currentFrameCount = (long)Math.Floor(Memory.FrameCount() / 16.666666f);
            if (currentFrameCount != lastFrameCount || lastPosition != currentPosition) {
                lastSpeed = (currentPosition - lastPosition) * FPS;
                lastFrameCount = currentFrameCount;
                currentFrame = (int)currentFrameCount;
                comboManager.AddTransform(new WOTWTransform(new System.Numerics.Vector2(currentPosition.X, currentPosition.Y), new System.Numerics.Vector2(lastSpeed.X, lastSpeed.Y), (int)currentFrameCount));
            }

            bool isDeadTest = Memory.Dead();
            PlayerUberStateStats stats = Memory.PlayerStats();
            oriStats = stats;
            AreaType area = Memory.PlayerArea();
            RuntimeGameWorldAreaPtr runtimeArea = Memory.GetRuntimeGameArea();// Memory.MapCompletion();
            float areaCompletion = Memory.MapCompletion(area);
            string scene = Memory.CurrentScene();
            if (string.IsNullOrEmpty(scene)) { scene = "N/A"; }

            SeinEnergy energy = new SeinEnergy();
            SeinHealthControllerPtr health = new SeinHealthControllerPtr();
            SeinCharacter seinCharacter = new SeinCharacter();
            seinCharacter = Memory.ReadCharacter();
            energy = Memory.ReadEnergy();
            health = Memory.ReadHealth();
            Bindings.PlayerAbilities = seinCharacter.PlayerAbilities;
            this.SeinStateUI.UpdateStates(seinCharacter);

            lblAirNoDeceleration.Text = "AirNoDeceleration: " + seinCharacter.SeinPlatformBehaviour.AirNoDeceleration.m_noDeceleration.ToString();
            lblSpeedFactor.Text = "SpeedFactor: " + seinCharacter.SeinPlatformBehaviour.ApplyFrictionToSpeed.SpeedFactor.ToString();
            lblSpeedLocal.Text = "SpeedLocal: " + seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.m_localSpeed.X.ToString("G20", CultureInfo.CreateSpecificCulture("en-US")) + ", " + seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.m_localSpeed.Y.ToString("G20", CultureInfo.CreateSpecificCulture("en-US"));
            lblAdditiveLocalSpeed.Text = "AdditiveLocalSpeed: " + seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.AdditiveLocalSpeed.X.ToString("G20", CultureInfo.CreateSpecificCulture("en-US")) + ", " + seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.AdditiveLocalSpeed.Y.ToString("G20", CultureInfo.CreateSpecificCulture("en-US"));

            //string lblInputS = "";

            if (this.InputLockTimer > 1000) {
                //Memory.LockPlayer();
            }
            if (this.InputLockTimer > 3000) {
                //Memory.UnlockPlayer();
                this.InputLockTimer = 0;
            }

            lblMap.Text = $"Total: {runtimeArea.m_completionAmount:0.00}%";
            lblArea.Text = $"Area: {area} - {areaCompletion:0.00}%";
            lblScene.Text = $"Scene: {scene}";
            lblPos.Text = $"Pos: {currentPosition.X}, {currentPosition.Y}";
            lblPos.Text = "Pos: " + currentPosition.X.ToString("G20", CultureInfo.CreateSpecificCulture("en-US")) + ", " + currentPosition.Y.ToString("G20", CultureInfo.CreateSpecificCulture("en-US"));
            lblSpeed.Text = $"Speed: {lastSpeed.X:0.000}, {lastSpeed.Y:0.000} ({!lastSpeed:0.000})";
            lblSpeed.Text = "Speed: " + lastSpeed.X.ToString("G20", CultureInfo.CreateSpecificCulture("en-US")) + ", " + lastSpeed.Y.ToString("G20", CultureInfo.CreateSpecificCulture("en-US"));
            string debugEnabled = Memory.DebugEnabled() ? "On" : "Off";
            noPause = Memory.NoPauseEnabled();
            string noPuaseEnabled = noPause ? "On" : "Off";
            lblExtra.Text = $"Debug: {debugEnabled}  NoPause: {noPuaseEnabled}";


            float averageFPS = 0.0f;
            foreach (float ff in AverageFPS) {
                averageFPS += ff;
            }
            averageFPS = averageFPS / AverageFPS.Count;

            lblFPS.Text = $"FPS: {averageFPS:0.0}";

            if (gameState == GameState.Game) {
                lblHP.Text = $"HP: {health.m_amountCached:0} / {health.m_maxHealthCached}";
                lblEN.Text = $"EN: {energy.m_energyCached:0.0} / {energy.m_maxEnergyCached:0}";
                lblOre.Text = $"Ore: {seinCharacter.SeinInventory.Ore}";
                lblKeys.Text = $"Keys: {seinCharacter.SeinInventory.Keystones}";
                lblSaved.Text = $"Save: {stats.Hours:00}:{stats.Minutes:00}:{stats.Seconds:00}";
            } else {
                lblHP.Text = "HP: N/A";
                lblEN.Text = "EN: N/A";
                lblOre.Text = "Ore: N/A";
                lblKeys.Text = "Keys: N/A";
                lblSaved.Text = "Save: N/A";
            }
        }

        private void CreateContextMenu() {

            ContextMenuStrip menuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Settings");
            ToolStripMenuItem menuSaveConfiguration = new ToolStripMenuItem("Save Configuration");
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Reload Configuration");
            ToolStripMenuItem menuVisibility = new ToolStripMenuItem("Visibility");
            ToolStripMenuItem menuTeleport = new ToolStripMenuItem("Open Teleport Menu");
            ToolStripMenuItem menuBackupSave = new ToolStripMenuItem("Backup Save");
            ToolStripMenuItem menuNewValidator = new ToolStripMenuItem("New Validator");
            ToolStripMenuItem menuCopyPosition = new ToolStripMenuItem("Copy Position");
            ToolStripMenuItem menuCopySpeed = new ToolStripMenuItem("Copy Speed");
            ToolStripMenuItem menuCopyBoth = new ToolStripMenuItem("Copy Both");
            ToolStripMenuItem menuDebugActions = new ToolStripMenuItem("Debug Actions");
            ToolStripMenuItem menuCreateCheckpoint = new ToolStripMenuItem("Create Checkpoint");
            ToolStripMenuItem menuSeinVisualEditor = new ToolStripMenuItem("Sein Visual Editor");
            ToolStripMenuItem menuTransformEditor = new ToolStripMenuItem("Transform Editor");

            List<string> visibilityMenuItemsNames = new List<string> { "Visibility Health", "Visibility Energy", "Visibility Area", "Visibility Scene", "Visibility Ore", "Visibility Keys", "Visibility Save",
            "Visibility Total", "Visibility FPS", "Visibility Debug", "Visibility Position", "Visibility Speed", "Visibility SpeedLocal", "Visibility AdditiveLocalSpeed", "Visibility AirNoDeceleration", "Visibility SpeedFactor", "ManagerAlwaysOnTop"};

#if IL2CPP
            List<string> debugMenuItemsNames = new List<string> { "Complete Quests", "Create Object", "Stop Recorder",
                "Write Recorder", "Finalize Recorder", "Ghost Run", "Toggle Focus Pause", "Get Quest" };
            List<ToolStripMenuItem> debugMenuItems = new List<ToolStripMenuItem>();

            ToolStripMenuItem hitboxSplit = new ToolStripMenuItem("Hitbox Split");

            ToolStripMenuItem raceCreationMenu = new ToolStripMenuItem("Race Creation");
            ToolStripMenuItem raceEditor = new ToolStripMenuItem("Race Editor");
            List<string> raceMenuItemsNames = new List<string> { "Run Race", "Load Race", "Load And Run", "Stop Race", "Restart Race" };
            List<ToolStripMenuItem> raceMenuItems = new List<ToolStripMenuItem>();

            foreach (var name in raceMenuItemsNames) {
                ToolStripMenuItem newItem = new ToolStripMenuItem(name);

                newItem.Name = name;
                newItem.Click += menuItem_Click;
                raceMenuItems.Add(newItem);
            }

            raceEditor.Name = "Race Editor";
            raceEditor.Click += menuItem_Click;

            raceCreationMenu.DropDownItems.Add(raceEditor);
            raceCreationMenu.DropDownItems.AddRange(raceMenuItems.ToArray());

            hitboxSplit.Name = "Hitbox Split";
            hitboxSplit.Click += menuItem_Click;
#endif

            menuStrip.ShowItemToolTips = true;

            menuSaveConfiguration.Name = "Save Configuration";
            menuItem1.Name = "Reload Configuration";
            menuTeleport.Name = "Teleport";
            menuBackupSave.Name = "Backup Save";
            menuNewValidator.Name = "New Validator";
            menuCopyPosition.Name = "Copy Position";
            menuCopySpeed.Name = "Copy Speed";
            menuCopyBoth.Name = "Copy Both";
            menuCreateCheckpoint.Name = "Create Checkpoint";
            menuSeinVisualEditor.Name = "Sein Visual Editor";
            menuTransformEditor.Name = "Transform Editor";

#if IL2CPP
            foreach (var name in debugMenuItemsNames) {
                ToolStripMenuItem newItem = new ToolStripMenuItem(name);

                newItem.Name = name;
                newItem.Click += menuItem_Click;
                debugMenuItems.Add(newItem);
            }
#endif
            menuSaveConfiguration.Click += menuItem_Click;
            menuItem1.Click += menuItem_Click;
            menuTeleport.Click += menuItem_Click;
            menuBackupSave.Click += menuItem_Click;
            menuNewValidator.Click += menuItem_Click;
            menuCopyPosition.Click += menuItem_Click;
            menuCopySpeed.Click += menuItem_Click;
            menuCopyBoth.Click += menuItem_Click;
            menuCreateCheckpoint.Click += menuItem_Click;
            menuSeinVisualEditor.Click += menuItem_Click;
            menuTransformEditor.Click += menuItem_Click;

            menuCopyPosition.ToolTipText = "Copies the position values to the clipboard, bound to F1.";
            menuCopySpeed.ToolTipText = "Copies the position values to the clipboard, bound to F2.";
            menuCopyBoth.ToolTipText = "Copies the position values to the clipboard, bound to F3.";

            menuDebugActions.DropDownItems.AddRange(new List<ToolStripMenuItem> { menuCreateCheckpoint }.ToArray());

#if IL2CPP
            menuDebugActions.DropDownItems.AddRange(debugMenuItems.ToArray());
#endif

            foreach (string name in visibilityMenuItemsNames) {
                ToolStripMenuItem item = new ToolStripMenuItem(name);
                item.CheckOnClick = true;
                item.Checked = true;
                item.Click += menuItem_Click;
                item.Text = name;
                item.Name = name;
                menuVisibilityItems.Add(item);
            }

            menuVisibility.DropDownItems.AddRange(menuVisibilityItems.ToArray());
            menuVisibility.DropDownItems.AddRange(this.SeinStateUI.GetMenuItems().ToArray());

            menuItem.DropDownItems.Add(menuSaveConfiguration);
            menuItem.DropDownItems.Add(menuItem1);
            menuItem.DropDownItems.Add(menuVisibility);
            menuItem.Name = "Settings";
            menuStrip.Items.Add(menuCopyPosition);
            menuStrip.Items.Add(menuCopySpeed);
            menuStrip.Items.Add(menuCopyBoth);
            menuStrip.Items.Add("-");
            menuStrip.Items.Add(hitboxSplit);
            menuStrip.Items.Add(raceCreationMenu);
            menuStrip.Items.Add(menuTeleport);
            menuStrip.Items.Add(menuBackupSave);
            menuStrip.Items.Add(menuSeinVisualEditor);
            menuStrip.Items.Add(menuTransformEditor);
            menuStrip.Items.Add("-");
            menuStrip.Items.Add(menuItem);
            menuStrip.Items.Add(menuDebugActions);
            menuStrip.Items.Add("-");
            menuStrip.Items.Add(menuNewValidator);

            var menus = comboManager.generateContextMenus(menuItem_Click);

            foreach (var menu in menus) {
                menuStrip.Items.Add(menu);
            }

            menuStrip.Opening += new System.ComponentModel.CancelEventHandler(cms_Opening);
            menuStrip.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(cms_Closing);
            menuVisibility.DropDown.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(cms_Closing);

            this.ContextMenuStrip = menuStrip;
        }

        public void cms_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (rawInput != null) {
                rawInput.RemoveMessageFilter();
            }
        }

        public void cms_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) {
                e.Cancel = true;
            }
            if (rawInput != null) {
                rawInput.AddMessageFilter();
            }
        }

        public void SetManagerVisiblity(string name, bool vis) {
            switch (name) {
                case "Health":
                    if (vis == true) {
                        this.panelHPEN.Visible = true;
                    }
                    this.lblHP.Visible = vis;
                    visibilitySettings.VisibilityHealth = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Health").Checked = vis;
                    break;

                case "Energy":
                    if (vis == true) {
                        this.panelHPEN.Visible = true;
                    }
                    this.lblEN.Visible = vis;
                    visibilitySettings.VisibilityEnergy = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Energy").Checked = vis;
                    break;

                case "Area":
                    this.lblArea.Visible = vis;
                    visibilitySettings.VisibilityArea = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Area").Checked = vis;
                    break;

                case "Scene":
                    this.lblScene.Visible = vis;
                    visibilitySettings.VisibilityScene = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Scene").Checked = vis;
                    break;

                case "Ore":
                    if (vis == true) {
                        this.panelOreKeys.Visible = true;
                    }
                    this.lblOre.Visible = vis;
                    visibilitySettings.VisibilityOre = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Ore").Checked = vis;
                    break;

                case "Keys":
                    if (vis == true) {
                        this.panelOreKeys.Visible = true;
                    }
                    this.lblKeys.Visible = vis;
                    visibilitySettings.VisibilityKeys = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Keys").Checked = vis;
                    break;

                case "Save":
                    this.lblSaved.Visible = vis;
                    visibilitySettings.VisibilitySave = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Save").Checked = vis;
                    break;

                case "Total":
                    if (vis == true) {
                        this.panelTotalFPS.Visible = true;
                    }
                    this.lblMap.Visible = vis;
                    visibilitySettings.VisibilityTotal = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Total").Checked = vis;
                    break;

                case "FPS":
                    if (vis == true) {
                        this.panelTotalFPS.Visible = true;
                    }
                    this.lblFPS.Visible = vis;
                    visibilitySettings.VisibilityFPS = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility FPS").Checked = vis;
                    break;

                case "Position":
                    this.lblPos.Visible = vis;
                    visibilitySettings.VisibilityPosition = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Position").Checked = vis;
                    break;

                case "Speed":
                    this.lblSpeed.Visible = vis;
                    visibilitySettings.VisibilitySpeed = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Speed").Checked = vis;
                    break;

                case "Debug":
                    this.lblExtra.Visible = vis;
                    visibilitySettings.VisibilityDebug = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility Debug").Checked = vis;
                    break;

                case "SpeedLocal":
                    this.lblSpeedLocal.Visible = vis;
                    visibilitySettings.VisibilitySpeedLocal = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility SpeedLocal").Checked = vis;
                    break;

                case "AdditiveLocalSpeed":
                    this.lblAdditiveLocalSpeed.Visible = vis;
                    visibilitySettings.VisibilityAdditiveLocalSpeed = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility AdditiveLocalSpeed").Checked = vis;
                    break;

                case "AirNoDeceleration":
                    this.lblAirNoDeceleration.Visible = vis;
                    visibilitySettings.VisibilityAirNoDeceleration = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility AirNoDeceleration").Checked = vis;
                    break;
                case "SpeedFactor":
                    this.lblSpeedFactor.Visible = vis;
                    visibilitySettings.VisibilitySpeedFactor = vis;
                    menuVisibilityItems.Find(x => x.Name == "Visibility SpeedFactor").Checked = vis;
                    break;
                case "Dash":
                    this.SeinStateUI.SetVisibility("Dash", vis);
                    break;
                case "Jump":
                    this.SeinStateUI.SetVisibility("Djump", vis);
                    break;
                case "Walljump":
                    this.SeinStateUI.SetVisibility("Walljump", vis);
                    break;
                case "IsOnWall":
                    this.SeinStateUI.SetVisibility("IsOnWall", vis);
                    break;
                case "Ceiling":
                    this.SeinStateUI.SetVisibility("OnCeiling", vis);
                    break;
                case "Ground":
                    this.SeinStateUI.SetVisibility("OnGround", vis);
                    break;
                case "WallLeft":
                    this.SeinStateUI.SetVisibility("OnWallLeft", vis);
                    break;
                case "WallRight":
                    this.SeinStateUI.SetVisibility("OnWallRight", vis);
                    break;
                case "Bash":
                    this.SeinStateUI.SetVisibility("Bash", vis);
                    break;
                case "Leash":
                    this.SeinStateUI.SetVisibility("Leash", vis);
                    break;
                case "VGrenadeBash":
                    this.SeinStateUI.SetVisibility("VGrenadeBash", vis);
                    break;
                case "WLAngle":
                    this.SeinStateUI.SetVisibility("WallLeftAngle", vis);
                    break;
                case "WRAngle":
                    this.SeinStateUI.SetVisibility("WallRightAngle", vis);
                    break;
                case "ManagerAlwaysOnTop":
                    this.TopMost = vis;
                    visibilitySettings.ManagerAlwaysOnTop = vis;
                    menuVisibilityItems.Find(x => x.Name == "ManagerAlwaysOnTop").Checked = vis;
                    break;
            }

            if (this.visibilitySettings.VisibilityHealth == false && this.visibilitySettings.VisibilityEnergy == false) {
                this.panelHPEN.Visible = false;
            }
            if (this.visibilitySettings.VisibilityOre == false && this.visibilitySettings.VisibilityKeys == false) {
                this.panelOreKeys.Visible = false;
            }
            if (this.visibilitySettings.VisibilityTotal == false && this.visibilitySettings.VisibilityFPS == false) {
                this.panelTotalFPS.Visible = false;
            }
        }

        void menuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (menuItem != null) {
                string menuItemName = menuItem.Name;

                switch (menuItemName) {
                    case "Race Editor":
                        rawInput.RemoveMessageFilter();
                        if (RaceEditor.IsDisposed == true)
                            RaceEditor = new RaceEditor(this);

                        if (RaceEditor.Visible == false) {
                            RaceEditor.Show(this);
                        }
                        rawInput.AddMessageFilter();
                        break;

                    case "Load Race":
                        RaceEditor.LoadRace();
                        break;

                    case "Load And Run":
                        RaceEditor.LoadAndRun();
                        break;

                    case "Run Race":
                        RaceEditor.StartRace();
                        break;

                    case "Restart Race":
                        this.InjectCommunication.AddCall("CALL24");
                        break;

                    case "Stop Race":
                        this.InjectCommunication.AddCall("CALL25");
                        break;

                    case "ManagerAlwaysOnTop":
                        this.SetManagerVisiblity("ManagerAlwaysOnTop", menuItem.Checked);
                        break;

                    case "Hitbox Split":
                        if (HitboxSplit.IsDisposed == true)
                            HitboxSplit = new HitboxSplit(this);

                        rawInput.RemoveMessageFilter();

                        if (HitboxSplit.Visible == false)
                            HitboxSplit.Show(this);

                        rawInput.AddMessageFilter();
                        break;

                    case "Backup Save":
                        backupsaveUI = new BackupsaveUI(this);

                        if (backupsaveUI.Visible == false)
                            backupsaveUI.Show(this);
                        break;

                    case "Toggle Focus Pause":
                        noPause = !noPause;
                        Memory.PatchNoPause(noPause);
                        break;

                    case "Sein Visual Editor":
                        rawInput.RemoveMessageFilter();
                        if (visualEditor == null || visualEditor.IsDisposed == true)
                            visualEditor = new SeinVisualEditor(this);

                        if (visualEditor.Visible == false) {
                            visualEditor.Show(this);
                            visualEditor.LoadVisualSettings();
                        }

                        rawInput.AddMessageFilter();
                        break;

                    case "Transform Editor":
                        rawInput.RemoveMessageFilter();
                        transformEditor = new WotwEditor(this);
                        transformEditor.Show(this);
                        break;
                };

                if (menuItem.Name.Equals("Reload Configuration") == true) {
                    comboManager.ReloadConfiguration();
                } else if (menuItem.Name.Equals("Teleport") == true) {
                    rawInput.RemoveMessageFilter();
                    TeleportUI teleportUI = new TeleportUI();
                    teleportUI.SetMemoryManager(Memory, this);
                    teleportUI.SetDefaultPosition(lastPosition.X, lastPosition.Y);
                    teleportUI.Show(this);
                    rawInput.AddMessageFilter();
                } else if (menuItem.Name.Equals("Save Configuration") == true) {
                    comboManager.UpdateComboConfiguration();
                } else if (menuItem.Name.Equals("Create Checkpoint") == true) {
                    this.InjectCommunication.AddCall("CALL2");
                } else if (menuItem.Name.Equals("Stop Recorder") == true) {
                    this.InjectCommunication.AddCall("CALL4");
                } else if (menuItem.Name.Equals("Write Recorder") == true) {
                    this.InjectCommunication.AddCall("CALL5");
                } else if (menuItem.Name.Equals("Ghost Run") == true) {
                    this.InjectCommunication.AddCall("CALL6");
                } else if (menuItem.Name.Equals("Finalize Frame") == true) {
                    this.InjectCommunication.AddCall("CALL13");
                } else if (menuItem.Name.Equals("Create Object") == true) {
                    this.InjectCommunication.AddCall("CALL3");
                } else if (menuItem.Name.Equals("Complete Quests") == true) {
                    //this.RaceTimer = new RaceTimer();
                    //this.RaceTimer.Show(this);
                    QuestsController questsController = Memory.GetQuests();
                    questsController.FillMasterQuests();
                    //string guid = questsController.ProgressQuestLinear();

                    foreach (string guid in questsController.MasterQuestsGuid) {
                        if (guid != null) {
                            int groupIndex = UberStateController.GetUberGroupIndex(questsController.MasterQuests[guid].UberGroupID);
                            UberStateGroup uberGroup = UberStateController.GetUberStateGroup(questsController.MasterQuests[guid].UberGroupID);

                            if (uberGroup != null) {
                                int uberIndex = uberGroup.GetUberIndex(questsController.MasterQuests[guid].UberID, UberController.UberStateType.Int);

                                if (uberIndex != -1) {
                                    Memory.SetUberState(groupIndex, uberIndex, questsController.MasterQuests[guid].TotalQuestState + 1);
                                }
                            }
                        }
                    }
                } else if (menuItem.Name.Equals("Copy Position") == true) {
                    Clipboard.SetText(lblPos.Text.Replace("Pos: ", ""));
                } else if (menuItem.Name.Equals("Copy Speed") == true) {
                    Clipboard.SetText(lblSpeed.Text.Replace("Speed: ", ""));
                } else if (menuItem.Name.Equals("Copy Both") == true) {
                    Clipboard.SetText(lblPos.Text.Replace("Pos: ", "") + " - " + lblSpeed.Text.Replace("Speed: ", ""));
                } else if (menuItem.Name.StartsWith("Visibility")) {
                    string name = menuItem.Name.Replace("Visibility", "").Replace(" ", "");

                    this.SetManagerVisiblity(name, menuItem.Checked);
                } else if (menuItem.Name.Equals("New Validator") == true) {
                    var menu = comboManager.NewCombo(menuItem_Click);
                    this.ContextMenuStrip.Items.Add(menu);
                } else if (menuItem.Name.StartsWith("Teleport")) {
                    string name = menuItem.OwnerItem.Text;
                    int index = comboManager.getComboIndexByName(name);
                    if (index != -1) {
                        var pos = comboManager.getComboPosition(index);
                        InjectCommunication.AddCall("CALL28PAR" + pos.X.ToString() + ";" + pos.Y.ToString());
                    }
                } else if (menuItem.Name.StartsWith("Enabled")) {
                    string name = menuItem.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "Enabled", menuItem.Checked);
                } else if (menuItem.Name.StartsWith("InputTrainer")) {
                    string name = menuItem.OwnerItem.Text;
                    WOTWCombination combo = comboManager.GetCombo(name);
                    inputTrainer.NewInputTrainer(combo.Inputs);
                } else if (menuItem.Name.StartsWith("ShowFrameTimings")) {
                    string name = menuItem.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "ShowFrameTimings", menuItem.Checked);
                } else if (menuItem.Name.StartsWith("ShowMSTimings")) {
                    string name = menuItem.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "ShowMSTimings", menuItem.Checked);
                } else if (menuItem.Name.StartsWith("LogData")) {
                    string name = menuItem.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "LogData", menuItem.Checked);
                } else if (menuItem.Name.StartsWith("ShowFrameDifference")) {
                    string name = menuItem.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "ShowFrameDifference", menuItem.Checked);
                } else if (menuItem.Name.StartsWith("EditKeys")) {
                    string name = menuItem.OwnerItem.Text;
                    rawInput.RemoveMessageFilter();
                    comboManager.ChangeSetting(name, "EditKeys", false);
                    rawInput.AddMessageFilter();
                } else if (menuItem.Name.StartsWith("RemoveValidator")) {
                    var confirmResult = MessageBox.Show("Are you sure to remove this item?", "Remove", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes) {
                        string name = menuItem.OwnerItem.Text;
                        comboManager.RemoveCombo(name);
                    }
                } else if (menuItem.Name.StartsWith("Reset")) {
                    string name = menuItem.OwnerItem.Text;
                    int index = comboManager.getComboIndexByName(name);
                    if (index != -1) {
                        List<UberState> uberStates = comboManager.GetComboUberStates(index);
                        bool oriStatsChanged = false;

                        foreach (UberState uber in uberStates) {
                            if (uber.ID == 1) {
                                Memory.SetKeystones(uber.Value.Int);
                            } else if (uber.ID == 2) {
                                oriStats.Energy = uber.Value.Int;
                                oriStatsChanged = true;
                            } else if (uber.ID == 3) {
                                oriStats.MaxEnergy = uber.Value.Int;
                                oriStatsChanged = true;
                            } else if (uber.ID == 4) {
                                oriStats.Health = uber.Value.Int;
                                oriStatsChanged = true;
                            } else if (uber.ID == 5) {
                                oriStats.MaxHealth = uber.Value.Int;
                                oriStatsChanged = true;
                            } else {
                                Memory.SetUberState(uber);
                                Memory.UpdateUberState(uber);
                            }
                        }
                        if (oriStatsChanged == true) {
                            Memory.SetPlayerStats(oriStats);
                        }

                        var pos = comboManager.getComboPosition(index);
                        InjectCommunication.AddCall("CALL28PAR" + pos.X.ToString() + ";" + pos.Y.ToString());
                    }
                } else if (menuItem.Name.StartsWith("EditUberstates")) {
                    string name = menuItem.OwnerItem.Text;
                    rawInput.RemoveMessageFilter();
                    comboManager.ChangeSetting(name, "EditUberstates", false);
                    rawInput.AddMessageFilter();
                }
            }

            if (menuItem == null) {
                ToolStripTextBox menuTextbox = sender as ToolStripTextBox;
                if (menuTextbox.Name.StartsWith("Position")) {
                    string name = menuTextbox.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "Position", menuTextbox.Text);
                } else if (menuTextbox.Name.StartsWith("Name")) {
                    string name = menuTextbox.OwnerItem.Text;
                    comboManager.ChangeSetting(name, "Name", menuTextbox.Text);
                }
            }
        }

        private void Manager_KeyDown(object sender, KeyEventArgs e) {
            if (!e.Control) { return; }

            if (e.KeyCode == Keys.L) {
                useLivesplitColors = !useLivesplitColors;
                if (useLivesplitColors) {
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                } else {
                    this.BackColor = Color.Black;
                    this.ForeColor = Color.White;
                }
            } else if (e.KeyCode == Keys.D) {
                Memory.EnableDebug(!Memory.DebugEnabled());
            } else if (e.KeyCode == Keys.N) {
                Memory.PatchNoPause(!noPause);
            }
        }

        private void KeyPressed(string keyString) {
            string keyString1 = keyString.Replace(" ", "");//string keyString = GWMKeyToChar.KeyToChar((int)m.WParam);
            if (keyString1 != "NULL" && newKeysDown.FindIndex(x => x.Item1 == keyString1) == -1) {
                newKeysDown.Add(new Tuple<string, int>(keyString1, currentFrame));
                keyCombos.Add(new Tuple<String, int, long>(keyString1, currentFrame, sw.ElapsedMilliseconds));

                switch (keyString1) {
                    case "F4": this.InjectCommunication.AddCall("CALL46"); break;
                    case "F5": this.InjectCommunication.AddCall("CALL9"); break;
                    case "F6": this.InjectCommunication.AddCall("CALL10"); break;
                    case "F9": this.RaceEditor.StartRace(); break;
                    case "F10": this.InjectCommunication.AddCall("CALL24"); break;
                    case "F11": {
                            this.InjectCommunication.AddCall("CALL25");
                            this.Show();
                            this.IsRacing = RaceState.Waiting;
                            this.Invalidate();
                        }
                        break;
                        //case "LSHIFT": this.InjectCommunication.AddCall("CALL17"); break;
                }
            }

            var bindings = Bindings.GetKeyBind(keyString1);
            foreach (var bind in bindings) {
                inputTrainer.KeyPressed(bind.ActualBind, sw.ElapsedMilliseconds);
                if (bind.IsAbility() == true) {
                    if ((bind.ActualBind == "Ability 1" || bind.ActualBind == "Ability1") && Bindings.PlayerAbilities.AbilityList.Count > 0) {
                        inputTrainer.KeyPressed(Bindings.PlayerAbilities.AbilityList[0].Name, sw.ElapsedMilliseconds);
                    } else if ((bind.ActualBind == "Ability 2" || bind.ActualBind == "Ability2") && Bindings.PlayerAbilities.AbilityList.Count > 1) {
                        inputTrainer.KeyPressed(Bindings.PlayerAbilities.AbilityList[1].Name, sw.ElapsedMilliseconds);
                    } else if ((bind.ActualBind == "Ability 3" || bind.ActualBind == "Ability3") && Bindings.PlayerAbilities.AbilityList.Count > 2) {
                        inputTrainer.KeyPressed(Bindings.PlayerAbilities.AbilityList[2].Name, sw.ElapsedMilliseconds);
                    }
                }
            }

            keyString1 = "";
            foreach (var key in newKeysDown) {
                keyString1 += key.Item1 + " F:" + key.Item2.ToString() + " ";
            }
            inputsDown.Text = keyString1;
        }

        private void KeyReleased(string keyString) {
            string keyString1 = keyString.Replace(" ", "");
            int keyIndex = newKeysDown.FindIndex(x => x.Item1 == keyString1);
            if (keyIndex != -1) {
                newKeysDown.RemoveAt(keyIndex);
            }

            keyString1 = "";
            foreach (var key in newKeysDown) {
                keyString1 += key.Item1 + " F:" + key.Item2.ToString() + " ";
            }
            inputsDown.Text = keyString1;
        }

        private void OnKeyPressed(object sender, RawInputEventArg e) {
            if (e.KeyPressEvent.VKeyName == "F1") {
                Clipboard.SetText(lblPos.Text.Replace("Pos: ", ""));
            } else if (e.KeyPressEvent.VKeyName == "F2") {
                Clipboard.SetText(lblSpeed.Text.Replace("Speed: ", ""));
            } else if (e.KeyPressEvent.VKeyName == "F3") {
                Clipboard.SetText(lblPos.Text.Replace("Pos: ", "") + " - " + lblSpeed.Text.Replace("Speed: ", ""));
            }

            if (e.KeyPressEvent.VKeyName != "Mouse Move") {
                if (e.KeyPressEvent.KeyPressState == "MAKE") {
                    KeyPressed(e.KeyPressEvent.VKeyName);
                } else if (e.KeyPressEvent.KeyPressState == "BREAK") {
                    KeyReleased(e.KeyPressEvent.VKeyName);
                }
            }
            CheckInputs();
        }

        private void CheckInputs() {
            var result = comboManager.ValidateCombos(keyCombos, ref Bindings);

            if (result.Item2) {
                possibleCombos.Text = result.Item1;
            } else {
                possibleCombos.Text = "";
            }
            while (keyCombos.Count > 10) {
                keyCombos.RemoveAt(0);
            }
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
        }
    }
};