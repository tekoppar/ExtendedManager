using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;
using System.Globalization;
using OriWotW.RaceStuff;
using OriWotW.UI;
using System.Security.Principal;
using System.Security.AccessControl;
using Tem.Utility;

namespace OriWotW.Logic.Inject {
    public enum MessageType {
        EndThread = 0,
        GameCompletion = 1,
        CreateCheckpoint = 2,
        CreateObject = 3,
        StopRecorder = 4,
        WriteRecorder = 5,
        GhostPlayerRun = 6,
        GhostPlayerStop = 7,
        CreateScene = 8,
        FrameStep = 9,
        FrameStepStop = 10,
        NextAnimation = 11,
        GetShriekData = 12,
        CreateRaceCheckpoint = 13,
        RunRace = 14,
        RemoveCheckpoint = 15,
        LoadRace = 16,
        KuDash = 17,
        UpdateRaceCheckpoint = 18,
        SetManagerPath = 19,
        ToggleDebugObjects = 20,
        GetSeinFaces = 21,
        UpdateHitbox = 22,
        RemoveHitbox = 23,
        RestartRace = 24,
        StopRace = 25,
        SaveUberStates = 26,
        LoadUberStates = 27,
        SetSeinPosition = 28,
        CreateBackupSave = 29,
        GetSaveInfo = 30,
        RefreshBackups = 31,
        SetOriVisuals = 32,
        FinishedRace = 33,
        StartedRace = 34,
        ResetOriVisuals = 35,
        GetSceneHierarchy = 36,
        SetSelectedGameObject = 37,
        CreateGameObject = 38,
        MoveGameObjectHierarchy = 39,
        CloneGameObject = 40,
        ExpandSceneHierarchy = 41,
        GetFieldsProperties = 42,
        SetFieldsProperties = 43,
        SaveEditorWorld = 44,
        LoadEditorWorld = 45,
        AddCollisionPosition = 46,
        GetFieldsPropertiesGameObject = 47,
        StoppedRace = 48,
        ManagerInitialized = 49,
        PlaybackInputs = 50,
        ShowInfo = 51,
    };

    public class InjectCommunication {
        static public InjectCommunication _Instance = null;

        public NamedPipeServerStream NamedPipeServer;
        public NamedPipeServerStream NamedPipeServerDLL;
        public StreamReader StreamReader;
        public StreamWriter StreamWriter;
        private ToolStripStatusLabel StatusLabel;
        public IAsyncResult DLLResult;
        public IAsyncResult ManagerResult;
        public List<string> Messages = new List<string>();
        private bool ConnectionIsEstablished = false;
        private bool isWriting = false;

        public InjectCommunication(ToolStripStatusLabel statusLabel) {
            InjectCommunication._Instance = this;
            this.StatusLabel = statusLabel;

            Task serverTask = RunServerAsync("wotw-manager-pipe");
            Task serverTask1 = ReadServerAsync("injectdll-manager-pipe");
            //Task.WaitAll(serverTask);
            //Task clientTask = RunClientAsync("my-very-cool-pipe-example");
            //this.NamedPipeServer = new NamedPipeServerStream("my-very-cool-pipe-example", PipeDirection.InOut, 1, PipeTransmissionMode.Byte);
            //this.StreamReader = new StreamReader(this.NamedPipeServer);
        }

        private PipeSecurity CreateSystemIOPipeSecurity() {
            PipeSecurity pipeSecurity = new PipeSecurity();

            var id = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

            // Allow Everyone read and write access to the pipe. 
            pipeSecurity.SetAccessRule(new PipeAccessRule(id, PipeAccessRights.FullControl, AccessControlType.Allow));

            return pipeSecurity;
        }

        public void StopCommunication() {
            if (StreamReader != null)
                StreamReader.Close();

            if (StreamWriter != null)
                StreamWriter.Close();

            ConnectionIsEstablished = false;

            if (NamedPipeServerDLL != null) {
                NamedPipeServerDLL.Close();
            }

            if (NamedPipeServer != null) {
                NamedPipeServer.Close();
            }
        }

        private async Task ReadServerAsync(string pipeName) {
            PipeSecurity pipeSecurity = CreateSystemIOPipeSecurity();
            this.NamedPipeServerDLL = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 2048, 2048, pipeSecurity);
            File.AppendAllText("C:\\moon\\manager_error.log", "Starting pipe reader\r\n");

            try {
                await Task.Factory.FromAsync(
                    (cb, state) => this.NamedPipeServerDLL.BeginWaitForConnection(cb, state),
                    ar => this.NamedPipeServerDLL.EndWaitForConnection(ar),
                    null);
            } catch (Exception e) { this.StatusLabel.Text = e.Message; return; }
            this.StreamReader = new StreamReader(this.NamedPipeServerDLL);
            this.ConnectionIsEstablished = true;
            this.StatusLabel.Text = "Piped DLL server connected";
            File.AppendAllText("C:\\moon\\manager_error.log", "Pipe reader started\r\n");

            this.Read();
        }

        private async Task RunServerAsync(string pipeName) {
            PipeSecurity pipeSecurity = CreateSystemIOPipeSecurity();
            this.NamedPipeServer = new NamedPipeServerStream(pipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 2048, 2048, pipeSecurity);
            File.AppendAllText("C:\\moon\\manager_error.log", "Starting pipe writer\r\n");

            try {
                await Task.Factory.FromAsync(
                    (cb, state) => this.NamedPipeServer.BeginWaitForConnection(cb, state),
                    ar => this.NamedPipeServer.EndWaitForConnection(ar),
                    null);
            } catch (Exception e) { this.StatusLabel.Text = e.Message; return; }

            this.StreamWriter = new StreamWriter(this.NamedPipeServer);
            this.StreamWriter.AutoFlush = true;

            this.StatusLabel.Text = "Piped Manager server connected";
            File.AppendAllText("C:\\moon\\manager_error.log", "Pipe writer started\r\n");

            this.Send();
        }

        public void CallMessage(MessageType messageType, string message = "") {
            if (message == "") {
                this.AddCall("CALL" + (int)messageType);
            } else {
                this.AddCall("CALL" + (int)messageType + "PAR" + message);
            }
        }

        private async void Read() {
            do {
                if (this.StreamReader != null && this.NamedPipeServerDLL.IsConnected == true && this.ConnectionIsEstablished == true) {
                    string line = await this.StreamReader.ReadLineAsync();

                    if (line == "BYE" || line == null) {
                        break;
                    } else {
                        string[] messages = line.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in messages) {
                            MessageType type;
                            string values = "";
                            if (s.Contains("|") == true) {
                                int index = s.IndexOf("|");
                                type = (MessageType)int.Parse(s.Substring(0, index));
                                values = s.Remove(0, index + 1);
                            } else
                                type = (MessageType)int.Parse(s);

                            switch (type) {
#if _WOTW_MANAGER
                                case MessageType.GameCompletion: Manager._Instance.SetGameCompletion(float.Parse(values, CultureInfo.InvariantCulture.NumberFormat)); break;
                                case MessageType.GetSeinFaces: Manager._Instance.SetSeinFacesDirection(int.Parse(values)); break;
                                case MessageType.FinishedRace: Manager._Instance.IsRacing = RaceState.FinishedRacing; break;
                                case MessageType.StartedRace: Manager._Instance.IsRacing = RaceState.IsRacing; break;
                                case MessageType.StoppedRace: Manager._Instance.WindowState = FormWindowState.Normal; Manager._Instance.IsRacing = RaceState.Waiting; break;
                                case MessageType.ManagerInitialized: Manager._Instance.ManagerInitialized(); break;
                                case MessageType.GetSceneHierarchy: Manager._Instance.transformEditor.SetSceneHierarchy(values); break;
                                case MessageType.ExpandSceneHierarchy: Manager._Instance.transformEditor.AddStringToSceneHierarchy(values); break;
                                case MessageType.GetFieldsProperties: Manager._Instance.transformEditor.LoadFieldsProperties(values); break;
                                case MessageType.GetFieldsPropertiesGameObject: {
                                        string[] splitValues = values.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                        Manager._Instance.transformEditor.LoadFieldsProperties(splitValues[0], TE.StringToIntVector(splitValues[1], ","));
                                    }
                                    break;
                                case MessageType.CloneGameObject: Manager._Instance.transformEditor.AddStringToSceneHierarchy(values); break;
                                case MessageType.SetSelectedGameObject: Manager._Instance.transformEditor.SetSelectedGameObject(values); break;
                                case MessageType.GetSaveInfo: {
                                        var backupsaves = values.Split(';');
                                        Manager._Instance.backupsaveUI.Backupsaves.Clear();

                                        for (int i = 0; i < backupsaves.Length; i += 10) {
                                            if (backupsaves[i] != "") {
                                                Backupsave backupsave = new Backupsave();
                                                backupsave.AreaName = backupsaves[i];
                                                backupsave.Completion = int.Parse(backupsaves[i + 1]);

                                                var health = backupsaves[i + 2].Split('/');
                                                backupsave.Health = int.Parse(health[0]);
                                                backupsave.MaxHealth = int.Parse(health[1]);

                                                var energy = backupsaves[i + 3].Split('/');
                                                backupsave.Energy = int.Parse(energy[0]);
                                                backupsave.MaxEnergy = int.Parse(energy[1]);

                                                backupsave.Order = int.Parse(backupsaves[i + 4]);
                                                backupsave.Difficulty = (DifficultyMode)int.Parse(backupsaves[i + 5]);

                                                var time = backupsaves[i + 6].Split(':');
                                                backupsave.Hours = int.Parse(time[0]);
                                                backupsave.Minutes = int.Parse(time[1]);
                                                backupsave.Seconds = int.Parse(time[2]);

                                                backupsave.DebugOn = int.Parse(backupsaves[i + 7]);
                                                int killed = int.Parse(backupsaves[i + 8]);
                                                backupsave.WasKilled = killed == 0 ? false : true;
                                                backupsave.BackupIndex = int.Parse(backupsaves[i + 9]);
                                                Manager._Instance.backupsaveUI.Backupsaves.Add(backupsave);
                                            }
                                        }

                                        Manager._Instance.backupsaveUI.RefreshSaves();
                                    }
                                    break;

                                case MessageType.ShowInfo: Manager._Instance.randomInfo.Text = values;  break;
#endif
                            }
                        }

                    }
                }
            } while (ConnectionIsEstablished);
        }

        public async void Send() {
            if (this.StreamWriter != null && this.ConnectionIsEstablished == true) {
                string message = "";

                for (int i = 0; i < this.Messages.Count; i++) {
                    if (i == 0) {
                        message += this.Messages[i];
                        //File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "message_error_manager.log", "Manager:" + this.Messages[i] + "\n");
                    } else {
                        message += "||" + this.Messages[i];
                        //File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "message_error_manager.log", "Manager:" + this.Messages[i] + "\n");
                    }
                }
                if (message != "" && this.Messages.Count > 0)
                    //this.Manager.lblInputInts.Text = message;

                    if (this.StreamWriter.BaseStream.CanWrite && this.NamedPipeServer.IsConnected == true && this.Messages.Count > 0 && this.isWriting == false) {
                        this.isWriting = true;
                        await this.StreamWriter.WriteAsync(message + (char)0);
                        this.Messages.Clear();
                        this.isWriting = false;
                    }
            }
        }

        public void AddCall(string message = "CALL1") {
            if (this.Messages.Count < 250) {
                if (message == "CALL0") {
                    if (this.StreamWriter != null) {
                        this.StreamWriter.Flush();
                        this.StreamWriter.Write(message + (char)0);
                    }
                } else if (this.Messages.IndexOf(message) == -1) {
                    this.Messages.Add(message);
                }
            }
        }
    }
}