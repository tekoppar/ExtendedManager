using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WMKeyToChar;
using OriWotW.UI.Playback;

namespace OriWotW.UI {
    public partial class PlaybackEditor : Form {
        private List<PlaybackInputDesigner> InputDesigners = new List<PlaybackInputDesigner>();
        private Manager Manager;

        public PlaybackEditor() {
            InitializeComponent();
            this.ReadPlaybackFile();
        }

        public PlaybackEditor(List<PlaybackInput> inputs) {
            InitializeComponent();
            this.AddContent(inputs);
        }

        private void ReadPlaybackFile() {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\playbackInputs.txt")) {
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\playbackInputs.txt");

                foreach (string line in lines) {
                    List<string> values = new List<string>(line.Split(';'));

                    if (values.Count == 4) {
                        PlaybackInputDesigner inputDesigner = new PlaybackInputDesigner();
                        inputDesigner.SetParent(this);
                        inputDesigner.SetKey(values[0]);
                        inputDesigner.SetStartFrame(int.Parse(values[1]));
                        inputDesigner.SetLength(int.Parse(values[2]));
                        inputDesigner.SetWaitAfter(int.Parse(values[3]));
                        this.InputDesigners.Add(inputDesigner);

                        this.tableLayoutPanel1.RowCount++;
                        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
                        this.tableLayoutPanel1.Controls.Add(inputDesigner, 0, this.tableLayoutPanel1.RowCount - 1);
                    }
                }
            }
        }
		
		public void AddContent(List<PlaybackInput> inputs) {
            foreach (PlaybackInput input in inputs) {
                PlaybackInputDesigner inputDesigner = new PlaybackInputDesigner();
                inputDesigner.SetParent(this);
                inputDesigner.SetKey(input.InputCode.ToString());
                inputDesigner.SetStartFrame(input.StartFrame);
                inputDesigner.SetLength(input.Length);
                inputDesigner.SetWaitAfter(input.WaitAfter);
                this.InputDesigners.Add(inputDesigner);

                this.tableLayoutPanel1.RowCount++;
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
                this.tableLayoutPanel1.Controls.Add(inputDesigner, 0, this.tableLayoutPanel1.RowCount - 1);
            }
        }

        public void RemoveInputDesigner(PlaybackInputDesigner inputDesigner) {
            int index = this.InputDesigners.IndexOf(inputDesigner);

            if (index != -1) {
                this.InputDesigners.RemoveAt(index);
            }
        }

        private void addInput_Click(object sender, EventArgs e) {
            PlaybackInputDesigner inputDesigner = new PlaybackInputDesigner();
            inputDesigner.SetParent(this);
            this.InputDesigners.Add(inputDesigner);

            this.tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
            this.tableLayoutPanel1.Controls.Add(inputDesigner, 0, this.tableLayoutPanel1.RowCount - 1);
        }

        public void SetManager(Manager manager) {
            this.Manager = manager;
        }

        private void PlaybackEditor_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void PlaybackEditor_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        private void confirmChanges_Click(object sender, EventArgs e) {
            string playbackInputs = "";

            foreach (PlaybackInputDesigner inputDesigner in this.InputDesigners) {
                PlaybackKeyCode keyValue;
                Enum.TryParse<PlaybackKeyCode>(inputDesigner.GetKey(), out keyValue);
                playbackInputs += ((int)keyValue).ToString() + ";";
                playbackInputs += inputDesigner.GetStartFrame().ToString() + ";";
                playbackInputs += inputDesigner.GetLength().ToString() + ";";
                playbackInputs += inputDesigner.GetWaitAfter().ToString() + "\r\n";
            }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\playbackInputs.txt", playbackInputs);
            //this.WOTWCombination.UpdateInputs(keys, timings);
            this.Close();
        }

        private void cancelChanges_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
