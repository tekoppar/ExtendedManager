using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using OriWotW.RaceStuff;
using OriWotW.UI;
using System.Security.Principal;
using System.Security.AccessControl;

namespace OriWotW.Logic {
    public class InjectCommunication {
        public NamedPipeServerStream NamedPipeServer;
        public NamedPipeServerStream NamedPipeServerDLL;
        public StreamReader StreamReader;
        public StreamWriter StreamWriter;
        private Manager Manager;
        public IAsyncResult DLLResult;
        public IAsyncResult ManagerResult;
        public List<string> Messages = new List<string>();
        private bool ConnectionIsEstablished = false;
        private bool isWriting = false;

        public InjectCommunication(Manager manager) {
            this.Manager = manager;

            this.Manager.managerStatus.Text = "Starting Pipes";
            Task serverTask = RunServerAsync("wotw-manager-pipe");
            Task serverTask1 = ReadServerAsync("injectdll-manager-pipe");
            this.Manager.canStart = true;
            //Task.WaitAll(serverTask);
            //Task clientTask = RunClientAsync("my-very-cool-pipe-example");
            //this.NamedPipeServer = new NamedPipeServerStream("my-very-cool-pipe-example", PipeDirection.InOut, 1, PipeTransmissionMode.Byte);
            //this.StreamReader = new StreamReader(this.NamedPipeServer);
        }

        private PipeSecurity CreateSystemIOPipeSecurity() {
            PipeSecurity pipeSecurity = new PipeSecurity();

            var id = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

            // Allow Everyone read and write access to the pipe. 
            pipeSecurity.SetAccessRule(new PipeAccessRule(id, PipeAccessRights.ReadWrite, AccessControlType.Allow));

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

            try {
                await Task.Factory.FromAsync(
                    (cb, state) => this.NamedPipeServerDLL.BeginWaitForConnection(cb, state),
                    ar => this.NamedPipeServerDLL.EndWaitForConnection(ar),
                    null);
            } catch (Exception e) { this.Manager.managerStatus.Text = e.Message; return; }
            this.StreamReader = new StreamReader(this.NamedPipeServerDLL);
            this.ConnectionIsEstablished = true;
            this.Manager.managerStatus.Text = "Piped DLL server connected";

            this.Read();
        }

        private async Task RunServerAsync(string pipeName) {
            PipeSecurity pipeSecurity = CreateSystemIOPipeSecurity();
            this.NamedPipeServer = new NamedPipeServerStream(pipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 2048, 2048, pipeSecurity);

            try {
                await Task.Factory.FromAsync(
                    (cb, state) => this.NamedPipeServer.BeginWaitForConnection(cb, state),
                    ar => this.NamedPipeServer.EndWaitForConnection(ar),
                    null);
            } catch (Exception e) { this.Manager.managerStatus.Text = e.Message; return; }

            this.StreamWriter = new StreamWriter(this.NamedPipeServer);
            this.StreamWriter.AutoFlush = true;

            this.Manager.managerStatus.Text = "Piped Manager server connected";

            this.Send();
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
                            if (s.Contains("GAMECOMPLETION:") == true) {
                                this.Manager.GameCompletion = float.Parse(s.Replace("GAMECOMPLETION:", ""), CultureInfo.InvariantCulture.NumberFormat);
                            }
                            if (s.Contains("SHRIEKDATA:") == true) {
                                string shriekData = s.Replace("SHRIEKDATA:", "");
                                shriekData = shriekData.Replace("POSITION:", "\nPosition:");
                                //this.Manager.lblInputInts.Text = shriekData;
                            }
                            if (s.Contains("SEINFACES:") == true) {
                                string seinFaces = s.Replace("SEINFACES:", "");
                                this.Manager.RaceEditor.SeinFacesDirection = int.Parse(seinFaces);
                            }
                            if (s.Contains("FINISHEDRACE") == true) {
                                this.Manager.IsRacing = RaceState.FinishedRacing;
                            }
                            if (s.Contains("STARTEDRACE") == true) {
                                this.Manager.IsRacing = RaceState.IsRacing;
                            }
                            if (s.Contains("STOPPEDRACE") == true) {
                                this.Manager.WindowState = FormWindowState.Normal;
                                this.Manager.IsRacing = RaceState.Waiting;
                            }
                            if (s.Contains("MANAGERINITIALIZED") == true) {
                                this.Manager.ManagerInitialized();
                            }
                            if (s.Contains("GETSCENEHIERARCHY") == true) {
                                string data = s.Replace("GETSCENEHIERARCHY", "");
                                this.Manager.transformEditor.SetSceneHierarchy(data);
                            }
                            if (s.Contains("SELECTEDGAMEOBJECT") == true) {
                                string data = s.Replace("SELECTEDGAMEOBJECT", "");
                                this.Manager.transformEditor.SetSelectedGameObject(data);
                            }
                            if (s.Contains("SAVEINFO") == true) {
                                string data = s.Replace("SAVEINFO", "");
                                var backupsaves = data.Split(';');
                                this.Manager.backupsaveUI.Backupsaves.Clear();

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
                                        this.Manager.backupsaveUI.Backupsaves.Add(backupsave);
                                    }
                                }

                                this.Manager.backupsaveUI.RefreshSaves();
                            }
                            if (s.Contains("GETTRANSFORM") == true) {
                                string data = s.Replace("GETTRANSFORM", "");
                                var values = data.Split('|');
                                this.Manager.transformEditor.position.SetValue(new TColor(values[0]));
                                this.Manager.transformEditor.localPosition.SetValue(new TColor(values[1]));
                                this.Manager.transformEditor.rotation.SetValue(new TColor(values[2]));
                                this.Manager.transformEditor.scale.SetValue(new TColor(values[3]));
                                this.Manager.transformEditor.matSortingOrder.Value = decimal.Parse(values[4]);
                                this.Manager.transformEditor.moonZOffset.Value = decimal.Parse(values[5], CultureInfo.InvariantCulture.NumberFormat);
                                this.Manager.transformEditor.matRenderQueue.Value = decimal.Parse(values[6]);
                                this.Manager.transformEditor.layerMaskValue.Value = decimal.Parse(values[7]);
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
            if (this.Messages.Count < 10) {
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