using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Numerics;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Drawing;
using System.Xml.Schema;
using OriWotW;
using OriWotW.UI;
using System.Runtime.CompilerServices;
using OriWotW.Memory;

public enum ControllerType : int {
    Keyboard = 0,
    KeyboardMouse = 1,
    Controller = 2
}

public class ComboSettings {
    public ManagerSettings Manager { get; set; } = new ManagerSettings();
    public IList<Combo> Combos { get; set; } = new List<Combo>();
}

public class ManagerSettings {
    public bool VisibilityHealth { get; set; } = true;
    public bool VisibilityEnergy { get; set; } = true;
    public bool VisibilityArea { get; set; } = true;
    public bool VisibilityScene { get; set; } = true;
    public bool VisibilityOre { get; set; } = true;
    public bool VisibilityKeys { get; set; } = true;
    public bool VisibilitySave { get; set; } = true;
    public bool VisibilityTotal { get; set; } = true;
    public bool VisibilityFPS { get; set; } = true;
    public bool VisibilityDebug { get; set; } = true;
    public bool VisibilityPosition { get; set; } = true;
    public bool VisibilitySpeed { get; set; } = true;
    public bool VisibilitySpeedLocal { get; set; } = true;
    public bool VisibilityAdditiveLocalSpeed { get; set; } = true;
    public bool VisibilityAirNoDeceleration { get; set; } = true;
    public bool VisibilitySpeedFactor { get; set; } = true;
    public bool VisibilityDash { get; set; } = true;
    public bool VisibilityJump { get; set; } = true;
    public bool VisibilityWalljump { get; set; } = true;
    public bool VisibilityIsOnWall { get; set; } = true;
    public bool VisibilityCeiling { get; set; } = true;
    public bool VisibilityGround { get; set; } = true;
    public bool VisibilityWallLeft { get; set; } = true;
    public bool VisibilityWallRight { get; set; } = true;
    public bool VisibilityBash { get; set; } = true;
    public bool VisibilityLeash { get; set; } = true;
    public bool VisibilityOnEdge { get; set; } = true;
    public bool VisibilityVGrenadeBash { get; set; } = true;
    public bool VisibilityWallLeftAngle { get; set; } = true;
    public bool VisibilityWallRightAngle { get; set; } = true;
    public bool ManagerAlwaysOnTop { get; set; } = true;

    public void SetSetting(string name, bool vis) {
        if (this.GetType().GetProperty(name) != null)
            this.GetType().GetProperty(name).SetValue(this, vis);
    }
}

public class Combo {
    public string Name { get; set; } = "Combo";
    public Settings Settings { get; set; } = new Settings();
    public IList<Inputs> Inputs { get; set; } = new List<Inputs>();
    public IList<UberStateT> UberStates { get; set; } = new List<UberStateT>();
}

public class Inputs {
    public IList<string> Keys { get; set; } = new List<string>();
    public IList<int> Timing { get; set; } = new List<int>();

    public int FindClosestTiming(int timing) {
        int closest = 999999;
        foreach (int time in Timing) {
            if (Math.Abs(time - timing) < Math.Abs(closest)) {
                closest = time - timing;
            }
        }

        return closest;
    }
}

public class Settings {
    public bool Enabled { get; set; } = true;
    public bool ShowFrameTimings { get; set; } = false;
    public bool ShowMSTimings { get; set; } = false;
    public bool LogData { get; set; } = false;
    public bool ShowFrameDifference { get; set; } = false;
    public float X { get; set; } = 0;
    public float Y { get; set; } = 0;
}

public class UberStateT {
    public string Type { get; set; } = "bool";
    public int ID { get; set; } = 0;
    public string Name { get; set; } = "UberName";
    public int GroupID { get; set; } = 0;
    public string GroupName { get; set; } = "UberGroupName";
    public string Value { get; set; } = "0";

    public void ConvertUberState(UberState uberState) {
        switch (uberState.Type) {
            case UberStateType.SerializedBooleanUberState:
                this.Type = "bool";
                this.Value = uberState.Value.Bool == true ? "true" : "false";
                break;

            case UberStateType.SerializedByteUberState:
                this.Type = "byte";
                this.Value = uberState.Value.Byte.ToString();
                break;

            case UberStateType.SerializedFloatUberState:
                this.Type = "float";
                this.Value = uberState.Value.Byte.ToString();
                break;

            case UberStateType.SerializedIntUberState:
                this.Type = "int";
                this.Value = uberState.Value.Byte.ToString();
                break;
        }

        this.ID = uberState.ID;
        this.Name = uberState.Name;
        this.GroupID = uberState.GroupID;
        this.GroupName = uberState.GroupName;
    }
}

public class WOTWTransform {
    public System.Numerics.Vector2 Position = new System.Numerics.Vector2();
    public System.Numerics.Vector2 Speed = new System.Numerics.Vector2();
    public int Frame = -1;

    public WOTWTransform(System.Numerics.Vector2 position, System.Numerics.Vector2 speed, int frame) {
        this.Position = position;
        this.Speed = speed;
        this.Frame = frame;
    }

    public override string ToString() {
        return "Frame: " + this.Frame.ToString() + " Position X:" + this.Position.X.ToString() + " Y:" + this.Position.Y.ToString() + " Speed X:" + this.Speed.X.ToString() + " Y:" + this.Speed.Y.ToString() + " ";
    }
}

namespace WMKeyToChar {
    static public class GWMKeyToChar {
        static public string KeyToChar(int key) {
            switch (key) {
                case 0x30:
                    return "0";
                case 0x31:
                    return "1";
                case 0x32:
                    return "2";
                case 0x33:
                    return "3";
                case 0x34:
                    return "4";
                case 0x35:
                    return "5";
                case 0x36:
                    return "6";
                case 0x37:
                    return "7";
                case 0x38:
                    return "8";
                case 0x39:
                    return "9";

                case 0x41:
                    return "A";
                case 0x42:
                    return "B";
                case 0x43:
                    return "C";
                case 0x44:
                    return "D";
                case 0x45:
                    return "E";
                case 0x46:
                    return "F";
                case 0x47:
                    return "G";
                case 0x48:
                    return "H";
                case 0x49:
                    return "I";
                case 0x4A:
                    return "J";
                case 0x4B:
                    return "K";
                case 0x4C:
                    return "L";
                case 0x4D:
                    return "M";
                case 0x4E:
                    return "N";
                case 0x4F:
                    return "O";
                case 0x50:
                    return "P";
                case 0x51:
                    return "Q";
                case 0x52:
                    return "R";
                case 0x53:
                    return "S";
                case 0x54:
                    return "T";
                case 0x55:
                    return "U";
                case 0x56:
                    return "V";
                case 0x57:
                    return "W";
                case 0x58:
                    return "X";
                case 0x59:
                    return "Y";
                case 0x5A:
                    return "Z";


                case 0xA0:
                    return "Left Shift";
                case 0xA1:
                    return "Right Shift";
                case 0xA2:
                    return "Left Control";
                case 0xA3:
                    return "Right Control";
                case 0x09:
                    return "TAB";

                default:
                    return "NULL";
            }
        }

        static public string WOTWBindingsToReal(string bind) {
            switch (bind) {
                //case "LeftArrow": return "LEFT";
                //case "RightArrow": return "RIGHT";
                //case "UpArrow": return "UP";
                //case "DownArrow": return "DOWN";
                //case "LeftShift": return "LSHIFT";
                //case "RightShift": return "RSHIFT";
                //case "Mouse0": return "Left Mouse";
                //case "Mouse1": return "Right Mouse";
                //case "Mouse2": return "Middle Mouse";
                //case "LeftControl": return "LCONTROL";
                //case "RightControl": return "RCONTROL";
                //case "Return": return "ENTER";
                //default: return bind.ToUpper();
                default: return bind;
            }
        }
    }

    public class WOTWKeyBindings {
        public List<WOTWKeyBinding> AllKeyBindings = new List<WOTWKeyBinding>();
        public Dictionary<string, WOTWKeyBinding> AllKeyBindingsNamedMap = new Dictionary<string, WOTWKeyBinding>();
        public Dictionary<string, List<int>> AllKeyBindingsMap = new Dictionary<string, List<int>>();
        public Dictionary<string, int> AllInputBindingsMap = new Dictionary<string, int>();
        static public Dictionary<string, string> KeyBindingsName = new Dictionary<string, string>() {
            ["SaveCopy"] = "Save Copy",
            ["SaveDelete"] = "Save Delete",
            ["Ability1"] = "Ability 1",
            ["Ability2"] = "Ability 2",
            ["Ability3"] = "Ability 3",
            ["DialogueAdvance"] = "Dialogue Advance",
            ["DialogueOption1"] = "Dialogue Option 1",
            ["DialogueOption2"] = "Dialogue Option 2",
            ["DialogueOption3"] = "Dialogue Option 3",
            ["DialogueExit"] = "Dialogue Exit",
            ["OpenMapsShardsInventory"] = "Open Maps Shards Inventory",
            ["OpenInventory"] = "Open Inventory",
            ["OpenWorldMap"] = "Open World Map",
            ["OpenAreaMap"] = "Open Area Map",
            ["OpenShardsScreen"] = "Open Shards Screen",
            ["OpenWeaponWheel"] = "Open Weapon Wheel",
            ["OpenPauseScreen"] = "Open Pause Screen",
            ["OpenLiveSignIn"] = "Open Live Sign In",
            ["MapZoomIn"] = "Map Zoom In",
            ["MapZoomOut"] = "Map Zoom Out",
            ["MenuSelect"] = "Menu Select",
            ["MenuBack"] = "Menu Back",
            ["MenuClose"] = "Menu Close",
            ["MenuDown"] = "Menu Down",
            ["MenuUp"] = "Menu Up",
            ["MenuLeft"] = "Menu Left",
            ["MenuRight"] = "Menu Right",
            ["MenuPageLeft"] = "Menu Page Left",
            ["MenuPageRight"] = "Menu Page Right",
            ["LeaderboardCycleFilter"] = "Leaderboard Cycle Filter",
            ["MapFilter"] = "Map Filter",
            ["MapDetails"] = "Map Details",
            ["MapFocusOri"] = "Map Focus Ori",
            ["MapFocusObjective"] = "Map Focus Objective"
        };
        static public Dictionary<int, string> InputMap = new Dictionary<int, string>() {
            [-1] = "Movement Left",
            [-1] = "Movement Right",
            [-1] = "Movement Down",
            [-1] = "Movement Up",
            [-1] = "Save Copy",
            [-1] = "Save Delete",
            [17] = "Interact",
            [20] = "Jump",
            [23] = "Ability 1",
            [26] = "Ability 2",
            [29] = "Ability 3",
            [32] = "Glide",
            [35] = "Grab",
            [38] = "Dash",
            [41] = "Burrow",
            [44] = "Bash",
            [47] = "Grapple",
            [-1] = "Dialogue Advance",
            [53] = "Dialogue Option 1",
            //[17] = "Dialogue Option 2",
            [8] = "Dialogue Option 3",
            [59] = "DialogueExit",
            [62] = "Open Maps Shards Inventory",
            [65] = "Open Inventory",
            [68] = "Open World Map",
            [71] = "Open Area Map",
            [74] = "Open Shards Screen",
            [77] = "Open Weapon Wheel",
            [59] = "Open Pause Screen",
            [-1] = "Open Live SignIn",
            [-1] = "MapZoomIn",
            [-1] = "MapZoomOut",
            [-1] = "MenuSelect",
            [-1] = "MenuBack",
            [-1] = "MenuClose",
            [-1] = "MenuDown",
            [-1] = "MenuUp",
            [-1] = "MenuLeft",
            [-1] = "MenuRight",
            [-1] = "MenuPageLeft",
            [-1] = "MenuPageRight",
            [-1] = "LeaderboardCycleFilter",
            [-1] = "MapFilter",
            [-1] = "MapDetails",
            [80] = "MapFocusOri",
            [-1] = "MapFocusObjective"
        };
        static public List<Tuple<string, string>> AxisMap = new List<Tuple<string, string>>() {
            new Tuple<string, string>("Movement Left", "JoypadLeftStickLeft"),
            new Tuple<string, string>("Movement Left", "JoypadRightStickLeft"),
            new Tuple<string, string>("Movement Left", "JoypadDpadLeft"),
            new Tuple<string, string>("Movement Right", "JoypadLeftStickRight"),
            new Tuple<string, string>("Movement Right", "JoypadRightStickRight"),
            new Tuple<string, string>("Movement Right", "JoypadDpadRight"),
            new Tuple<string, string>("Movement Up", "JoypadLeftStickUp"),
            new Tuple<string, string>("Movement Up", "JoypadRightStickUp"),
            new Tuple<string, string>("Movement Up", "JoypadDpadUp"),
            new Tuple<string, string>("Movement Down", "JoypadLeftStickDown"),
            new Tuple<string, string>("Movement Down", "JoypadRightStickDown"),
            new Tuple<string, string>("Movement Down", "JoypadDpadDown")
        };
        public PlayerAbilities PlayerAbilities = new PlayerAbilities();

        public WOTWKeyBindings() {
            this.LoadKeyBindings();
        }

        private void LoadKeyBindings() {
            string[] lines = new string[] { };
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Ori and the Will of The Wisps")) {
                lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Ori and the Will of The Wisps\\KeyRebindings.txt");
            } else if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Packages\\Microsoft.Patagonia_8wekyb3d8bbwe\\LocalCache\\Local\\Ori and the Will of The Wisps")) {
                lines = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Packages\\Microsoft.Patagonia_8wekyb3d8bbwe\\LocalCache\\Local\\Ori and the Will of The Wisps\\KeyRebindings.txt");
            }

            string[] temp;
            string[] bindings;
            string key;
            foreach (string line in lines) {
                temp = line.Split(':');
                if (temp.Length == 1) continue;
                bindings = temp[1].Split(',');
                if (bindings.Length < 3) continue;
                key = temp[0];

                if (WOTWKeyBindings.KeyBindingsName.ContainsKey(key.Trim())) {
                    key = WOTWKeyBindings.KeyBindingsName[key.Trim()];
                }

                this.AllInputBindingsMap.Add(key.Trim(), this.AllKeyBindings.Count());
                this.AllKeyBindings.Add(new WOTWKeyBinding(key.Trim(), bindings[0].Trim(), bindings[1].Trim(), bindings[2].Trim(), bindings[3].Trim()));
            }
            this.GenerateKeyBindindMap();
        }

        public void GenerateKeyBindindMap() {
            for (int i = 0; i < this.AllKeyBindings.Count; i++) {
                var bind = this.AllKeyBindings[i];
                int totalBinds = 0;

                if (bind.Bind1 != "NONE" && bind.Bind1 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind1)) {
                        this.AllKeyBindingsMap[bind.Bind1].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind1, new List<int> { i });
                    }
                }
                if (bind.Bind2 != "NONE" && bind.Bind2 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind2)) {
                        this.AllKeyBindingsMap[bind.Bind2].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind2, new List<int> { i });
                    }
                }
                if (bind.Bind3 != "NONE" && bind.Bind3 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind3)) {
                        this.AllKeyBindingsMap[bind.Bind3].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind3, new List<int> { i });
                    }
                }
                if (bind.Bind4 != "NONE" && bind.Bind4 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind4)) {
                        this.AllKeyBindingsMap[bind.Bind4].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind4, new List<int> { i });
                    }
                }
                if (bind.Bind5 != "NONE" && bind.Bind5 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind5)) {
                        this.AllKeyBindingsMap[bind.Bind5].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind5, new List<int> { i });
                    }
                }
                if (bind.Bind6 != "NONE" && bind.Bind6 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind6)) {
                        this.AllKeyBindingsMap[bind.Bind6].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind6, new List<int> { i });
                    }
                }
                if (bind.Bind7 != "NONE" && bind.Bind7 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind7)) {
                        this.AllKeyBindingsMap[bind.Bind7].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind7, new List<int> { i });
                    }
                }
                if (bind.Bind8 != "NONE" && bind.Bind8 != "NULL") {
                    totalBinds++;
                    if (this.AllKeyBindingsMap.ContainsKey(bind.Bind8)) {
                        this.AllKeyBindingsMap[bind.Bind8].Add(i);
                    } else {
                        this.AllKeyBindingsMap.Add(bind.Bind8, new List<int> { i });
                    }
                }
                bind.TotalBinds = totalBinds;
            }

            /*var lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\ControllerMap.txt");
            string[] temp;
            string[] bindings;
            foreach (string line in lines) {
                temp = line.Split(':');
                bindings = temp[1].Split(',');*/

            foreach (var t in WOTWKeyBindings.InputMap) {
                if (t.Key != -1) {
                    WOTWKeyBinding newKey = new WOTWKeyBinding(t.Value, t.Key.ToString(), "None", "None", "None", "None", "None", "None", "None");
                    if (this.AllKeyBindingsMap.ContainsKey(newKey.Bind1)) {
                        this.AllKeyBindingsMap[newKey.Bind1].Add(this.AllKeyBindings.Count);
                    } else {
                        this.AllKeyBindingsMap.Add(newKey.Bind1, new List<int> { this.AllKeyBindings.Count });
                    }
                    this.AllKeyBindings.Add(newKey);
                }
            }

            foreach (var t in WOTWKeyBindings.AxisMap) {
                WOTWKeyBinding newKey = new WOTWKeyBinding(t.Item1, t.Item2, "None", "None", "None", "None", "None", "None", "None", true);
                if (this.AllKeyBindingsMap.ContainsKey(newKey.Bind1)) {
                    this.AllKeyBindingsMap[newKey.Bind1].Add(this.AllKeyBindings.Count);
                } else {
                    this.AllKeyBindingsMap.Add(newKey.Bind1, new List<int> { this.AllKeyBindings.Count });
                }
                this.AllKeyBindings.Add(newKey);
            }
        }

        public List<WOTWKeyBinding> GetKeyBindings() {
            return this.AllKeyBindings;
        }

        public List<WOTWKeyBinding> GetKeyBind(string key) {
            List<WOTWKeyBinding> possibleKeys = new List<WOTWKeyBinding>();
            if (this.AllKeyBindingsMap.ContainsKey(key) || this.AllKeyBindingsMap.ContainsKey(key.Replace(" ", ""))) {

                foreach (int i in this.AllKeyBindingsMap[key]) {
                    possibleKeys.Add(this.AllKeyBindings[i]);
                }
                return possibleKeys;
            } else if (this.AllInputBindingsMap.ContainsKey(key) || this.AllInputBindingsMap.ContainsKey(key.Replace(" ", ""))) {
                possibleKeys.Add(this.AllKeyBindings[this.AllInputBindingsMap[key]]);
                return possibleKeys;
            } else if (this.AllKeyBindingsNamedMap.ContainsKey(key)) {
                possibleKeys.Add(this.AllKeyBindingsNamedMap[key]);
                return possibleKeys;
            }
            return possibleKeys;
        }
    }

    public class WOTWKeyBinding {
        public string ActualBind { get; set; }
        public string Bind1 { get; set; }
        public string Bind2 { get; set; }
        public string Bind3 { get; set; }
        public string Bind4 { get; set; }
        public string Bind5 { get; set; }
        public string Bind6 { get; set; }
        public string Bind7 { get; set; }
        public string Bind8 { get; set; }
        public int TotalBinds { get; set; }

        public WOTWKeyBinding(string B, string B1, string B2, string B3, string B4, string B5 = "NONE", string B6 = "NONE", string B7 = "NONE", string B8 = "NONE", bool noFormat = false) {
            this.ActualBind = B;
            this.Bind1 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B1) : B1;
            this.Bind2 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B2) : B2;
            this.Bind3 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B3) : B3;
            this.Bind4 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B4) : B4;
            this.Bind5 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B5) : B5;
            this.Bind6 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B6) : B6;
            this.Bind7 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B7) : B7;
            this.Bind8 = noFormat == false ? GWMKeyToChar.WOTWBindingsToReal(B8) : B8;
        }

        public bool IsAbility() {
            if (this.ActualBind == "Ability 1" || this.ActualBind == "Ability 2" || this.ActualBind == "Ability 3" || this.ActualBind == "Ability1" || this.ActualBind == "Ability2" || this.ActualBind == "Ability3") {
                return true;
            } else {
                return false;
            }
        }

        public void AddBind(string bind) {
            if (this.Bind1 == "NONE") {
                this.Bind1 = bind;
            } else if (this.Bind2 == "NONE") {
                this.Bind2 = bind;
            } else if (this.Bind3 == "NONE") {
                this.Bind3 = bind;
            } else if (this.Bind4 == "NONE") {
                this.Bind4 = bind;
            } else if (this.Bind5 == "NONE") {
                this.Bind5 = bind;
            } else if (this.Bind6 == "NONE") {
                this.Bind6 = bind;
            } else if (this.Bind7 == "NONE") {
                this.Bind7 = bind;
            } else if (this.Bind8 == "NONE") {
                this.Bind8 = bind;
            }
        }

        public string Bind(string Bind) {
            switch (Bind) {
                default:
                    return this.ActualBind;

                case "B1":
                    return this.Bind1;

                case "B2":
                    return this.Bind2;

                case "B3":
                    return this.Bind3;

                case "B4":
                    return this.Bind4;

                case "B5":
                    return this.Bind5;

                case "B6":
                    return this.Bind6;

                case "B7":
                    return this.Bind7;

                case "B8":
                    return this.Bind8;
            }
        }

        public string BindToString() {
            return this.ActualBind + " " + this.Bind1 + " " + this.Bind2 + " " + this.Bind3 + " " + this.Bind4 + " " + this.Bind5 + " " + this.Bind6 + " " + this.Bind7 + " " + this.Bind8;
        }
    }

    public class ComboManager {
        private List<WOTWCombination> Combos = new List<WOTWCombination>();
        private Dictionary<string, int> ComboIndex = new Dictionary<string, int>();
        private Manager Parent;
        private ManagerSettings Settings;
        private List<WOTWTransform> TransformValues = new List<WOTWTransform>();

        public ComboManager() {
        }

        public void ReloadConfiguration() {
            Combos = new List<WOTWCombination>();
            this.ComboIndex.Clear();
            this.GenerateCombos();
        }

        public void SetForm(Manager form) {
            this.Parent = form;
            this.GenerateCombos();
        }

        public Form GetForm() {
            return this.Parent;
        }

        public void AddTransform(WOTWTransform transform) {
            if (this.TransformValues.Count > 50) {
                this.TransformValues.RemoveAt(0);
            }
            this.TransformValues.Add(transform);

            foreach (WOTWCombination combo in this.Combos) {
                combo.LogResults(transform.Frame);
            }
        }

        public List<WOTWTransform> GetTransforms(List<Tuple<int, long>> frameTimings) {
            foreach (var frame in frameTimings) {
                if (frame.Item1 >= this.TransformValues[0].Frame && frame.Item1 <= this.TransformValues.Last().Frame) {
                    return this.TransformValues;
                }
            }
            return new List<WOTWTransform>();
        }

        public ToolStripMenuItem NewCombo(EventHandler eventHandler) {
            Settings settings = new Settings();
            List<UberState> uberStates = new List<UberState>();
            WOTWCombination newCombo = new WOTWCombination("Combo", new List<Inputs>(), settings, uberStates, this, false);
            this.Combos.Add(newCombo);
            this.ComboIndex.Add(newCombo.Combination, this.Combos.Count - 1);
            return newCombo.generateContextMenu(eventHandler);
        }

        private void GenerateCombos() {
            //string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Combos.txt");
            string jsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Combos.json");
            ComboSettings settings = JsonSerializer.Deserialize<ComboSettings>(jsonString);
            int index = 0;
            this.Settings = settings.Manager;

            foreach (var combo in settings.Combos) {
                WOTWCombination newCombo = new WOTWCombination(combo.Name, combo.Inputs, combo.Settings, this.ConvertUberStateT(combo.UberStates), this, false);
                this.Combos.Add(newCombo);
                this.ComboIndex.Add(combo.Name, index);
                index++;
            }
        }

        public void ApplySettings() {
            this.Parent.SetManagerVisiblity("Area", this.Settings.VisibilityArea);
            this.Parent.SetManagerVisiblity("Debug", this.Settings.VisibilityDebug);
            this.Parent.SetManagerVisiblity("Energy", this.Settings.VisibilityEnergy);
            this.Parent.SetManagerVisiblity("FPS", this.Settings.VisibilityFPS);
            this.Parent.SetManagerVisiblity("Health", this.Settings.VisibilityHealth);
            this.Parent.SetManagerVisiblity("Keys", this.Settings.VisibilityKeys);
            this.Parent.SetManagerVisiblity("Ore", this.Settings.VisibilityOre);
            this.Parent.SetManagerVisiblity("Position", this.Settings.VisibilityPosition);
            this.Parent.SetManagerVisiblity("Save", this.Settings.VisibilitySave);
            this.Parent.SetManagerVisiblity("Scene", this.Settings.VisibilityScene);
            this.Parent.SetManagerVisiblity("Speed", this.Settings.VisibilitySpeed);
            this.Parent.SetManagerVisiblity("SpeedLocal", this.Settings.VisibilitySpeedLocal);
            this.Parent.SetManagerVisiblity("AdditiveLocalSpeed", this.Settings.VisibilityAdditiveLocalSpeed);
            this.Parent.SetManagerVisiblity("AirNoDeceleration", this.Settings.VisibilityAirNoDeceleration);
            this.Parent.SetManagerVisiblity("SpeedFactor", this.Settings.VisibilitySpeedFactor);
            this.Parent.SetManagerVisiblity("Dash", this.Settings.VisibilityDash);
            this.Parent.SetManagerVisiblity("Jump", this.Settings.VisibilityJump);
            this.Parent.SetManagerVisiblity("Walljump", this.Settings.VisibilityWalljump);
            this.Parent.SetManagerVisiblity("IsOnWall", this.Settings.VisibilityIsOnWall);
            this.Parent.SetManagerVisiblity("Ceiling", this.Settings.VisibilityCeiling);
            this.Parent.SetManagerVisiblity("Ground", this.Settings.VisibilityGround);
            this.Parent.SetManagerVisiblity("WallLeft", this.Settings.VisibilityWallLeft);
            this.Parent.SetManagerVisiblity("WallRight", this.Settings.VisibilityWallRight);
            this.Parent.SetManagerVisiblity("Bash", this.Settings.VisibilityBash);
            this.Parent.SetManagerVisiblity("Leash", this.Settings.VisibilityLeash);
            this.Parent.SetManagerVisiblity("ManagerAlwaysOnTop", this.Settings.ManagerAlwaysOnTop);
        }

        public List<UberState> GetComboUberStates(int index) {
            return this.Combos[index].UberStates;
        }

        public List<UberState> ConvertUberStateT(IList<UberStateT> uberStatesT) {
            List<UberState> uberStates = new List<UberState>();

            foreach (UberStateT uber in uberStatesT) {
                UberState newUber = new UberState() { Name = uber.Name, ID = uber.ID, GroupName = uber.GroupName, GroupID = uber.GroupID, Type = UberStateType.SerializedBooleanUberState };

                switch (uber.Type) {
                    case "bool":
                        newUber = new UberState() { Name = uber.Name, ID = uber.ID, GroupName = uber.GroupName, GroupID = uber.GroupID, Type = UberStateType.SerializedBooleanUberState };
                        newUber.Value.Bool = uber.Value == "true" ? true : false;
                        break;

                    case "float":
                        newUber = new UberState() { Name = uber.Name, ID = uber.ID, GroupName = uber.GroupName, GroupID = uber.GroupID, Type = UberStateType.SerializedFloatUberState };
                        newUber.Value.Float = float.Parse(uber.Value, CultureInfo.InvariantCulture.NumberFormat);
                        break;

                    case "int":
                        newUber = new UberState() { Name = uber.Name, ID = uber.ID, GroupName = uber.GroupName, GroupID = uber.GroupID, Type = UberStateType.SerializedIntUberState };
                        try {
                            newUber.Value.Int = Int32.Parse(uber.Value);
                        } catch {
                            newUber.Value.Int = 0;
                        }
                        break;

                    case "byte":
                        newUber = new UberState() { Name = uber.Name, ID = uber.ID, GroupName = uber.GroupName, GroupID = uber.GroupID, Type = UberStateType.SerializedByteUberState };
                        try {
                            newUber.Value.Byte = (byte)Int32.Parse(uber.Value);
                        } catch {
                            newUber.Value.Byte = 0;
                        }
                        break;
                }

                uberStates.Add(newUber);
            }

            return uberStates;
        }

        public void RemoveCombo(string name) {
            int index = this.getComboIndexByName(name);

            if (index != -1) {
                this.Combos[index].Cleanup();
                this.ComboIndex.Remove(name);
                this.Combos.RemoveAt(index);
            }
        }

        public void UpdateComboConfiguration() {
            ComboSettings settings = new ComboSettings();

            for (int i = 0; i < this.Combos.Count; i++) {
                Combo newCombo = new Combo();

                newCombo.Name = this.Combos[i].Combination;
                newCombo.Inputs = this.Combos[i].Inputs;
                newCombo.Settings = this.Combos[i].Settings;

                foreach (UberState uber in this.Combos[i].UberStates) {
                    UberStateT uberT = new UberStateT();
                    uberT.ConvertUberState(uber);
                    newCombo.UberStates.Add(uberT);
                }
                settings.Combos.Add(newCombo);
            }
            settings.Manager = this.Parent.visibilitySettings;

            string jsonString = JsonSerializer.Serialize(settings);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Combos.json", jsonString);
        }

        public int getComboIndexByName(string name) {
            if (this.ComboIndex.ContainsKey(name)) {
                return this.ComboIndex[name];
            } else {
                return -1;
            }
        }

        public List<ToolStripMenuItem> generateContextMenus(EventHandler eventHandler) {
            List<ToolStripMenuItem> menus = new List<ToolStripMenuItem>();

            foreach (var combo in Combos) {
                menus.Add(combo.generateContextMenu(eventHandler));
            }

            return menus;
        }

        public Tuple<string, bool> ValidateCombos(List<Tuple<String, int, long>> inputs, ref WOTWKeyBindings Bindings) {
            string possibleCombos = "";
            bool comboFound = false;

            foreach (var combo in this.Combos) {
                if (combo.Settings.Enabled == true) {
                    combo.ValidateInputTimings(inputs, ref Bindings);

                    if (combo.ComboFound == true) {
                        possibleCombos += combo.GetCombination() + " " + combo.GetStates() + " " + combo.GetFrameTiming() + Environment.NewLine;
                        comboFound = true;
                    }
                }
            }

            return new Tuple<string, bool>(possibleCombos, comboFound);
        }

        public System.Numerics.Vector2 getComboPosition(int index = 0) {
            return new System.Numerics.Vector2(Combos[index].Settings.X, Combos[index].Settings.Y);
        }

        public void ChangeSetting(string name, string setting, bool state) {
            int index = this.getComboIndexByName(name);

            if (index != -1) {
                switch (setting) {
                    case "Enabled":
                        this.Combos[index].Settings.Enabled = state;
                        break;

                    case "ShowFrameTimings":
                        this.Combos[index].Settings.ShowFrameTimings = state;
                        break;

                    case "ShowMSTimings":
                        this.Combos[index].Settings.ShowMSTimings = state;
                        break;

                    case "LogData":
                        this.Combos[index].Settings.LogData = state;
                        break;

                    case "ShowFrameDifference":
                        this.Combos[index].Settings.ShowFrameDifference = state;
                        break;

                    case "EditKeys":
                        this.Combos[index].ShowEditableKeys();
                        break;

                    case "EditUberstates":
                        this.Combos[index].ShowEditableUberstates();
                        break;
                }
            }
        }

        public void ChangeSetting(string name, string setting, string text) {
            int index = this.getComboIndexByName(name);

            if (index != -1) {
                switch (setting) {
                    case "Position":
                        string[] pos = text.Split(',');
                        float x = this.Combos[index].Settings.X;
                        float y = this.Combos[index].Settings.Y;

                        try {
                            x = float.Parse(pos[0].Trim(), CultureInfo.InvariantCulture.NumberFormat);
                        } catch (FormatException) {
                            x = this.Combos[index].Settings.X;
                        }
                        try {
                            if (pos.Length >= 2) {
                                y = float.Parse(pos[1].Trim(), CultureInfo.InvariantCulture.NumberFormat);
                            }
                        } catch (FormatException) {
                            y = this.Combos[index].Settings.Y;
                        }
                        this.Combos[index].Settings.X = x;
                        this.Combos[index].Settings.Y = y;
                        break;

                    case "Name":
                        this.ComboIndex.Remove(name);
                        this.Combos[index].SetName(text);
                        this.ComboIndex.Add(text, index);
                        break;
                }
            }
        }

        public WOTWCombination GetCombo(int index) {
            return this.Combos[index];
        }

        public WOTWCombination GetCombo(string name) {
            return this.Combos[this.ComboIndex[name]];
        }

    }

    public class WOTWCombination {
        public string Combination;
        private List<int> Timings;
        private List<int> KeyTimings = new List<int>();
        private List<List<string>> Keys = new List<List<string>>();
        private List<Tuple<int, long>> FrameTiming = new List<Tuple<int, long>>();
        private List<string> States;
        private bool LoggingEnabled;
        private string OldLogg = "";
        private ComboManager Parent;
        private bool ShouldLoggSpeed;
        public bool ComboFound = false;
        public List<Inputs> Inputs = new List<Inputs>();
        public Settings Settings;
        public List<UberState> UberStates = new List<UberState>();
        private ToolStripMenuItem menuItem;
        private ToolStripTextBox menuName;
        private int LastFrameLog = 0;

        public WOTWCombination(string name, IList<Inputs> inputs, Settings settings, List<UberState> uberStates, ComboManager parent, /*List<int> timings = null, List<List<string>> keys = null,*/ bool logging = false) {
            Combination = name;
            this.Parent = parent;
            //KeyTimings = timings;
            //Keys = keys;
            Inputs = inputs as List<Inputs>;
            Settings = settings;
            UberStates = uberStates;
            States = new List<string>();
            LoggingEnabled = logging;
            FillData(inputs);
        }

        private void FillData(IList<Inputs> inputs) {
            foreach (var input in inputs) {
                if (input.Timing.Count > 0) {
                    KeyTimings.Concat(input.Timing);
                }
                Keys.Add(new List<string>(input.Keys));
            }
        }

        public void Cleanup() {
            this.menuItem.Dispose();
        }

        public void SetName(string name) {
            this.Combination = name;
            this.menuItem.Text = name;
            this.menuName.Name = "Name" + name;
        }

        public List<int> GetTiming() {
            return Timings;
        }

        public string GetStates() {
            string sState = "";
            foreach (var state in States) {
                sState += state + " ";
            }
            return sState;
        }

        public string GetCombination() {
            return Combination;
        }

        public ComboManager GetParent() {
            return this.Parent;
        }

        public string GetFrameTiming() {
            string frameTimings = "";
            for (int i = 0; i < FrameTiming.Count; i++) {
                var frame = FrameTiming[i];
                var frameDiff = Timings[i];
                int textCounter = 0;

                if (Settings.ShowFrameTimings == true) {
                    frameTimings += "F:" + (Math.Round(frame.Item2 / 16.6666666)).ToString();
                    textCounter++;
                }

                if (Settings.ShowFrameDifference == true) {
                    if (textCounter > 0) {
                        frameTimings += "|FD:" + frameDiff.ToString();
                    } else {
                        frameTimings += "FD:" + frameDiff.ToString();
                    }
                    textCounter++;
                }

                if (Settings.ShowMSTimings == true) {
                    if (textCounter > 0) {
                        frameTimings += "|" + frame.Item2.ToString() + "ms ";
                    } else {
                        frameTimings += frame.Item2.ToString() + "ms ";
                    }
                }
            }
            return frameTimings;
        }

        private void SetState() {
            States.Clear();
            foreach (var Timing in Timings) {
                if (Timing == 0) {
                    States.Add("Good");
                } else if (Timing > 0) {
                    States.Add("Early");
                } else if (Timing < 0) {
                    States.Add("Late");
                }
            }
        }

        public void Reset() {
            Timings.Clear();
            FrameTiming.Clear();
            States.Clear();
        }

        public float GetTotalDistance(List<WOTWTransform> transforms, int frame) {
            float distance = 0.0f;

            foreach (WOTWTransform transform in transforms) {
                if (transform.Frame >= frame && transform.Frame <= frame + 10) {
                    distance += Math.Abs(transform.Speed.X) + Math.Abs(transform.Speed.Y);
                }
            }

            return distance;
        }

        public void LogResults(int currentFrame) {
            if (this.FrameTiming.Count > 0 && currentFrame - 24 >= this.FrameTiming.Last().Item1) {
                List<WOTWTransform> transforms = this.Parent.GetTransforms(this.FrameTiming);
                if (transforms.Count > 0) {

                    using (StreamWriter w = File.AppendText(Combination + ".txt")) {
                        string newLogg = Combination + " " + GetFrameTiming() + " " + GetStates();

                        if (this.ShouldLoggSpeed == true) {
                            float distance = this.GetTotalDistance(transforms, this.FrameTiming[0].Item1);

                            if (distance > 100) {
                                newLogg += Environment.NewLine + "Success, Transforms: ";
                            } else {
                                newLogg += Environment.NewLine + "Failed, Transforms: ";
                            }
                            foreach (WOTWTransform transform in transforms) {
                                newLogg += transform.ToString();
                            }
                            newLogg += Environment.NewLine;
                        }

                        if (this.FrameTiming.Last().Item1 > this.LastFrameLog) {
                            if (!OldLogg.Equals(newLogg)) {
                                w.WriteLine(newLogg);
                                OldLogg = newLogg;
                                ShouldLoggSpeed = true;
                            }
                            this.LastFrameLog = this.FrameTiming.Last().Item1;
                        }
                        w.Close();
                    }
                }
            }
        }

        private string KeysAsString() {
            string keys = "";

            foreach (List<string> tKeys in this.Keys) {
                foreach (string key in tKeys) {
                    keys += key + ", ";
                }
                keys += System.Environment.NewLine;
            }

            return keys;
        }

        public void ShowEditableKeys() {
            InputEditor editor = new InputEditor(this, this.Inputs);
            editor.ShowDialog(this.Parent.GetForm());
        }

        public void ShowEditableUberstates() {
            UberstateEditor editor = new UberstateEditor(this, this.UberStates);
            editor.ShowDialog(this.Parent.GetForm());
        }

        public void UpdateInputs(List<List<string>> keys, List<List<int>> timings) {
            this.Keys = keys;

            for (int i = 0; i < keys.Count; i++) {
                if (this.Inputs.Count > i) {
                    this.Inputs[i].Keys = keys[i];
                    this.Inputs[i].Timing = timings[i];
                } else {
                    Inputs newInputs = new Inputs();
                    newInputs.Keys = keys[i];
                    newInputs.Timing = timings[i];
                    this.Inputs.Add(newInputs);
                }
            }
            if (keys.Count < this.Inputs.Count) {
                this.Inputs.RemoveRange(keys.Count, this.Inputs.Count - keys.Count);
            }

            this.Parent.UpdateComboConfiguration();
        }

        public void UpdateUberstates(List<UberState> uberStates) {
            this.UberStates = uberStates;
            this.Parent.UpdateComboConfiguration();
        }

        public ToolStripMenuItem generateContextMenu(EventHandler eventHandler) {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(Combination);
            ToolStripTextBox menuName = new ToolStripTextBox("Name");
            ToolStripMenuItem menuEnable = new ToolStripMenuItem("Enabled");
            ToolStripMenuItem menuInputTrainer = new ToolStripMenuItem("Input Trainer");
            ToolStripMenuItem menuTeleport = new ToolStripMenuItem("Teleport");
            ToolStripMenuItem menuReset = new ToolStripMenuItem("Reset Uberstates and Teleport");
            ToolStripMenuItem menuShowFrameTimings = new ToolStripMenuItem("Show Frame Timings");
            ToolStripMenuItem menuShowMSTimings = new ToolStripMenuItem("Show MS Timings");
            ToolStripMenuItem menuLogData = new ToolStripMenuItem("Log Data");
            ToolStripMenuItem menuShowFrameDifference = new ToolStripMenuItem("Show Frame Difference");
            ToolStripMenuItem menuKeysButton = new ToolStripMenuItem("Edit Keys");
            ToolStripTextBox menuPosition = new ToolStripTextBox("Position");
            ToolStripTextBox menuKeys = new ToolStripTextBox("Keys");
            ToolStripMenuItem menuRemove = new ToolStripMenuItem("Remove Validator");
            ToolStripMenuItem menuEditUberstates = new ToolStripMenuItem("Edit Uberstates");

            menuName.Name = "Name" + Combination;
            menuEnable.Name = "Enabled" + Combination;
            menuInputTrainer.Name = "InputTrainer";
            menuTeleport.Name = "Teleport" + Combination;
            menuReset.Name = "Reset" + Combination;
            menuShowFrameTimings.Name = "ShowFrameTimings" + Combination;
            menuShowMSTimings.Name = "ShowMSTimings" + Combination;
            menuLogData.Name = "LogData" + Combination;
            menuShowFrameDifference.Name = "ShowFrameDifference" + Combination;
            menuPosition.Name = "Position" + Combination;
            menuKeys.Name = "Keys" + Combination;
            menuKeysButton.Name = "EditKeys" + Combination;
            menuRemove.Name = "RemoveValidator" + Combination;
            menuEditUberstates.Name = "EditUberstates" + Combination;

            menuEnable.CheckOnClick = true;
            menuEnable.Checked = Settings.Enabled;
            menuEnable.Click += new EventHandler(eventHandler);
            menuInputTrainer.Click += new EventHandler(eventHandler);
            menuTeleport.Click += new EventHandler(eventHandler);
            menuReset.Click += new EventHandler(eventHandler);
            menuShowFrameTimings.CheckOnClick = true;
            menuShowFrameTimings.Checked = Settings.ShowFrameTimings;
            menuShowFrameTimings.Click += new EventHandler(eventHandler);
            menuShowMSTimings.CheckOnClick = true;
            menuShowMSTimings.Checked = Settings.ShowMSTimings;
            menuShowMSTimings.Click += new EventHandler(eventHandler);
            menuLogData.CheckOnClick = true;
            menuLogData.Checked = Settings.LogData;
            menuLogData.Click += new EventHandler(eventHandler);
            menuShowFrameDifference.CheckOnClick = true;
            menuShowFrameDifference.Checked = Settings.ShowFrameDifference;
            menuShowFrameDifference.Click += new EventHandler(eventHandler);
            menuKeysButton.Click += new EventHandler(eventHandler);
            menuRemove.Click += new EventHandler(eventHandler);
            menuEditUberstates.Click += new EventHandler(eventHandler);

            menuName.KeyUp += new KeyEventHandler(eventHandler);
            menuName.ReadOnly = false;
            menuName.Text = Combination;
            menuPosition.KeyUp += new KeyEventHandler(eventHandler);
            menuPosition.ReadOnly = false;
            menuPosition.Text = Settings.X.ToString() + ", " + Settings.Y.ToString();
            menuKeys.KeyUp += new KeyEventHandler(eventHandler);
            menuKeys.ReadOnly = false;
            menuKeys.AcceptsReturn = true;
            menuKeys.AcceptsTab = true;
            menuKeys.AutoSize = true;
            menuKeys.Text = this.KeysAsString();

            menuItem.DropDownItems.Add(menuName);
            menuItem.DropDownItems.Add(menuEnable);
            menuItem.DropDownItems.Add(menuInputTrainer);
            menuItem.DropDownItems.Add("-");
            menuItem.DropDownItems.Add(menuTeleport);
            menuItem.DropDownItems.Add(menuPosition);
            menuItem.DropDownItems.Add("-");
            menuItem.DropDownItems.Add(menuShowFrameTimings);
            menuItem.DropDownItems.Add(menuShowMSTimings);
            menuItem.DropDownItems.Add(menuShowFrameDifference);
            menuItem.DropDownItems.Add(menuLogData);
            menuItem.DropDownItems.Add("-");
            menuItem.DropDownItems.Add(menuKeysButton);
            menuItem.DropDownItems.Add("-");
            menuItem.DropDownItems.Add(menuEditUberstates);
            menuItem.DropDownItems.Add(menuReset);
            menuItem.DropDownItems.Add("-");
            menuItem.DropDownItems.Add(menuRemove);

            this.menuItem = menuItem;
            this.menuName = menuName;

            return menuItem;
        }

        public void ValidateInputTimings(List<Tuple<String, int, long>> inputs, ref WOTWKeyBindings Bindings) {
            if (this.Inputs.Count > 0) {
                int timingIndex = 0;
                int keyIndex = 0;
                List<WOTWKeyBinding> currentBind = null;
                List<WOTWKeyBinding> previousBind = null;
                int currentTiming = 0;
                int previousTiming = 0;
                long currentMS = 0;
                long previousMS = 0;
                WOTWKeyBinding previousKey = null;
                List<int> timings = new List<int>();
                List<Tuple<int, long>> frameTimings = new List<Tuple<int, long>>();
                List<int> bestTimings = new List<int>();
                List<Tuple<int, long>> bestFrameTimings = new List<Tuple<int, long>>();
                List<string> keysToFind = new List<string>(this.Inputs[keyIndex].Keys);

                this.ComboFound = false;

                if (inputs.Count > 0) {
                    for (var i = 0; i < inputs.Count; i++) {
                        var input = inputs[i];
                        bool nextBindFound = false;
                        int nextKeyFound = -1;

                        currentBind = Bindings.GetKeyBind(input.Item1);
                        currentTiming = input.Item2;
                        currentMS = input.Item3;

                        foreach (var currentKey in currentBind) {

                            if (this.Inputs.Count > keyIndex) {
                                for (var i2 = 0; i2 < this.Inputs[keyIndex].Keys.Count; i2++) {
                                    var key = this.Inputs[keyIndex].Keys[i2];

                                    if (currentKey.ActualBind == key || (currentKey.IsAbility() == true && Bindings.PlayerAbilities.AbilityBindings.ContainsKey(key) == true)) {
                                        nextKeyFound = 1;

                                        var indexFound = keysToFind.IndexOf(key);
                                        if (indexFound != -1) {
                                            keysToFind.RemoveAt(indexFound);
                                        }
                                    }
                                }

                                if (nextKeyFound == 1) {
                                    if (previousBind != null && previousKey != null) {
                                        if (previousKey.ActualBind != currentKey.ActualBind) {
                                            int closestTiming = this.Inputs[keyIndex].FindClosestTiming(currentTiming - previousTiming);
                                            timings.Add(closestTiming);
                                            frameTimings.Add(new Tuple<int, long>(Math.Abs(currentTiming), currentMS - previousMS));

                                            if (keysToFind.Count == 0) {
                                                timingIndex++;
                                            }
                                        }
                                    }
                                    nextBindFound = true;
                                    nextKeyFound = -1;

                                    if (keysToFind.Count == 0) {
                                        keyIndex++;

                                        if (this.Inputs.Count > keyIndex) {
                                            keysToFind = new List<string>(this.Inputs[keyIndex].Keys);
                                        }
                                    }

                                    previousBind = currentBind;
                                    previousKey = currentKey;
                                    previousTiming = currentTiming;
                                    previousMS = currentMS;
                                }
                            }
                        }

                        if (keyIndex >= this.Keys.Count) {
                            keyIndex = 0;
                            timingIndex = 0;
                            previousBind = null;
                            previousKey = null;
                            previousTiming = 0;
                            previousMS = 0;
                            this.ComboFound = true;
                            bestTimings = new List<int>(timings);
                            bestFrameTimings = new List<Tuple<int, long>>(frameTimings);
                            keysToFind = new List<string>(this.Inputs[keyIndex].Keys);
                            timings.Clear();
                            frameTimings.Clear();
                        }

                        if (inputs.Count > i + 1 && currentTiming == inputs[i + 1].Item2 || previousTiming == currentTiming) {
                            nextBindFound = true;
                        }

                        if (nextBindFound == false) {
                            keyIndex = 0;
                            timingIndex = 0;
                            previousBind = null;
                            previousKey = null;
                            previousTiming = 0;
                            previousMS = 0;
                            timings.Clear();
                            frameTimings.Clear();
                            keysToFind = new List<string>(this.Inputs[keyIndex].Keys);
                        }
                    }

                    Timings = bestTimings;
                    SetState();
                    FrameTiming = bestFrameTimings;
                }

                /*if (Settings.LogData == true) {
                    LoggResults();
                }*/
            }
        }

        public void IsBetter(List<Tuple<int, long>> timings) {
            List<int> newTimings = null;
            switch (Combination) {
                case "Air Sjump":
                    newTimings = WOTWCombinationValidator.ValidateAirSjump(timings);
                    break;

                case "Ground Sjump":
                    newTimings = WOTWCombinationValidator.ValidateGroundSjump(timings);
                    break;

                case "Bow Lift":
                    newTimings = WOTWCombinationValidator.ValidateBowLift(timings);
                    break;

                case "Sdash":
                    newTimings = WOTWCombinationValidator.ValidateSdash(timings);
                    break;

                case "SdashNoJank":
                    newTimings = WOTWCombinationValidator.ValidateSdashNoJank(timings);
                    break;

                case "Sdash Ku":
                    newTimings = WOTWCombinationValidator.ValidateSdashKu(timings);
                    break;

                case "Clip 2F":
                    newTimings = WOTWCombinationValidator.ValidateClip2F(timings);
                    break;

                case "Clip 3F":
                    newTimings = WOTWCombinationValidator.ValidateClip3F(timings);
                    break;

                case "Clip 4F":
                    newTimings = WOTWCombinationValidator.ValidateClip4F(timings);
                    break;

                case "Clip 5F":
                    newTimings = WOTWCombinationValidator.ValidateClip5F(timings);
                    break;

                case "Clip 1F":
                default:
                    newTimings = WOTWCombinationValidator.ValidateClip1F(timings);
                    break;
            }

            Timings = newTimings;
            SetState();
            FrameTiming = timings;
        }
    }

    public class WOTWCombinationValidator {
        public static List<int> ValidateAirSjump(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 3 };
            }
            return null;
        }

        public static List<int> ValidateGroundSjump(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 1 };
            }
            return null;
        }

        public static List<int> ValidateClip1F(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 1 };
            }
            return null;
        }

        public static List<int> ValidateClip2F(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 2 };
            }
            return null;
        }

        public static List<int> ValidateClip3F(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 3 };
            }
            return null;
        }

        public static List<int> ValidateClip4F(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 4 };
            }
            return null;
        }

        public static List<int> ValidateClip5F(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 5 };
            }
            return null;
        }

        public static List<int> ValidateBowLift(List<Tuple<int, long>> timings) {
            foreach (var timing in timings) {
                return new List<int> { timing.Item1 - 9 };
            }
            return null;
        }

        public static List<int> ValidateSdash(List<Tuple<int, long>> timings) {
            List<int> newTimings = new List<int>();

            if (timings[0].Item1 < -1) {
                newTimings.Add(timings[0].Item1 - -1);
            } else if (timings[0].Item1 > 9) {
                newTimings.Add(timings[0].Item1 - 9);
            } else {
                newTimings.Add(0);
            }

            if (timings[1].Item1 < -1) {
                newTimings.Add(timings[1].Item1 - -1);
            } else if (timings[1].Item1 > 3) {
                newTimings.Add(timings[1].Item1 - 3);
            } else {
                newTimings.Add(0);
            }

            if (timings[2].Item1 < 0) {
                newTimings.Add(timings[2].Item1 - 0);
            } else if (timings[2].Item1 > 14) {
                newTimings.Add(timings[2].Item1 - 14);
            } else {
                newTimings.Add(0);
            }

            return newTimings;
        }

        public static List<int> ValidateSdashNoJank(List<Tuple<int, long>> timings) {
            List<int> newTimings = new List<int>();
            bool FastSentry = false;

            switch (timings[0].Item1) {
                case -1:
                case 0:
                case 1:
                case 2:
                case 3:
                    newTimings.Add(3);
                    FastSentry = true;
                    break;
                case 4:
                    newTimings.Add(2);
                    break;
                case 5:
                    newTimings.Add(1);
                    break;
                case 6:
                case 7:
                    newTimings.Add(3);
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                    newTimings.Add(3);
                    break;

                default:
                    newTimings.Add(0);
                    break;
            }

            switch (timings[1].Item1) {
                case 2:
                case 3:
                    newTimings.Add(0);
                    break;
                case 4:
                    newTimings.Add(1);
                    break;
                case 5:
                    newTimings.Add(2);
                    break;
                case 6:
                case 7:
                case 8:
                    if (FastSentry) {
                        newTimings.Add(3);
                    } else {
                        newTimings.Add(1);
                    }
                    break;
                case 9:
                    newTimings.Add(2);
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    newTimings.Add(3);
                    break;
                case 15:
                    newTimings.Add(2);
                    break;
                case 16:
                    newTimings.Add(1);
                    break;
                case 17:
                default:
                    newTimings.Add(0);
                    break;
            }

            return newTimings;
        }

        public static List<int> ValidateSdashKu(List<Tuple<int, long>> timings) {
            List<int> newTimings = new List<int>();

            if (timings[0].Item1 < 1) {
                newTimings.Add(timings[0].Item1 - 1);
            } else if (timings[0].Item1 > 2) {
                newTimings.Add(timings[0].Item1 - 2);
            } else {
                newTimings.Add(0);
            }

            if (timings[1].Item1 < -1) {
                newTimings.Add(timings[1].Item1 - -1);
            } else if (timings[1].Item1 > 0) {
                newTimings.Add(timings[1].Item1 - 0);
            } else {
                newTimings.Add(0);
            }

            if (timings[2].Item1 < 0) {
                newTimings.Add(timings[2].Item1 - 0);
            } else if (timings[2].Item1 > 10) {
                newTimings.Add(timings[2].Item1 - 10);
            } else {
                newTimings.Add(0);
            }

            if (timings[3].Item1 > 0) {
                if (timings[3].Item1 < 0) {
                    newTimings.Add(timings[3].Item1 - 0);
                } else if (timings[3].Item1 > 10) {
                    newTimings.Add(timings[3].Item1 - 10);
                } else {
                    newTimings.Add(0);
                }
            }

            return newTimings;
        }
    }
}