using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.UI.Input;

namespace OriWotW.UI {
    public partial class InputTrainerUI : Form {
        private InputTrainer InputTrainer;
        private List<UI.Input.Input> Inputs = new List<UI.Input.Input>();
        private List<Inputs> NewInputs = new List<Inputs>();
        private List<int> Timings = new List<int>();
        private UI.Input.Input ActiveInput;
        private int ActiveInputIndex = 0;
        private long LastMS = 0;
        private long Timer = 0;
        private int TimingMethod = 0;

        public InputTrainerUI(InputTrainer inputTrainer) {
            this.InputTrainer = inputTrainer;
            InitializeComponent();
        }

        private void GenerateInputs() {
            int index = 0;
            int totalTime = 0;

            for (int i = 0; i < this.NewInputs.Count; i++) {
                foreach (string input in this.NewInputs[i].Keys) {
                    UI.Input.Input imgInput = this.InputTrainer.GetInput(input);

                    PictureBox picture = new PictureBox();
                    Image image = Image.FromFile(imgInput.Key);
                    Size imageSize = image.Size;

                    if (image.Size.Height > 64) {
                        float newRatio = (float)imageSize.Height / 64;
                        imageSize.Height = 64;
                        imageSize.Width = (int)(imageSize.Width / newRatio);
                    }

                    if (this.NewInputs[i].Timing.Count > 0) {
                        Label timing = new Label();
                        timing.ForeColor = SystemColors.ButtonHighlight;
                        timing.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        timing.Size = new Size(imageSize.Width, 28);
                        timing.Text = ((this.NewInputs[i].Timing[0] + totalTime) * 16).ToString();
                        timing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        if (this.TimingMethod == 0) {
                            totalTime += this.NewInputs[i].Timing[0];
                        }

                        this.timingList.Controls.Add(timing);
                    } else {
                        this.lblCountdown.Size = new Size(imageSize.Width, 28);
                    }

                    picture.Image = image;
                    picture.Size = imageSize;
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    this.inputList.Controls.Add(picture);
                }
            } 
        }

        private void ResetInputs() {
            int index = 0;
            int totalTime = 0;

            this.ActiveInput = this.Inputs[0];
            this.ActiveInputIndex = 0;

            for (int i = 0; i < this.NewInputs.Count; i++) {
                foreach (string input in this.NewInputs[i].Keys) {
                    UI.Input.Input imgInput = this.InputTrainer.GetInput(input);

                    PictureBox picture = this.inputList.Controls[index] as PictureBox;
                    Image image = Image.FromFile(imgInput.Key);
                    Size imageSize = image.Size;

                    if (image.Size.Height > 64) {
                        float newRatio = (float)imageSize.Height / 64;
                        imageSize.Height = 64;
                        imageSize.Width = (int)(imageSize.Width / newRatio);
                    }

                    if (this.NewInputs[i].Timing.Count > 0 && index > 0) {
                        Label label = this.timingList.Controls[index] as Label;

                        if (label != null) {
                            label.Text = ((this.NewInputs[i].Timing[0] + totalTime) * 16).ToString();
                            if (this.TimingMethod == 0) {
                                totalTime += this.NewInputs[i].Timing[0];
                            }
                        }
                    }

                    picture.Image = image;
                    picture.Size = imageSize;
                    index++;
                }
            }
        }
        
        private void NextInput() {
            if (this.ActiveInputIndex < this.Inputs.Count) {
                PictureBox picture = this.inputList.Controls[this.ActiveInputIndex] as PictureBox;

                if (picture != null) {
                    Image image = Image.FromFile(this.ActiveInput.KeyPressed);
                    Size imageSize = image.Size;

                    if (image.Size.Height > 64) {
                        float newRatio = (float)imageSize.Height / 64;
                        imageSize.Height = 64;
                        imageSize.Width = (int)(imageSize.Width / newRatio);
                    }

                    picture.Image = image;
                    picture.Size = imageSize;
                }

                this.ActiveInputIndex++;
                if (this.ActiveInputIndex > 0) {
                    if (this.ActiveInputIndex - 1 < this.Timings.Count) {
                        this.Timer = this.Timings[this.ActiveInputIndex - 1] * 16;
                        this.lblCountdown.Text = this.Timer.ToString() + "ms";
                    }
                }

                if (this.ActiveInputIndex < this.Inputs.Count) {
                    this.ActiveInput = this.Inputs[this.ActiveInputIndex];
                } else if (this.ActiveInputIndex >= this.Inputs.Count) {
                    this.ResetInputs();
                }
            }
        }

        public bool SetInputs(List<UI.Input.Input> inputs, List<int> timings, List<Inputs> newInputs) {
            if (inputs.Count > 0) {
                this.NewInputs = newInputs;
                this.Inputs = inputs;
                this.Timings = timings;
                this.ActiveInput = inputs[0];
                this.ActiveInputIndex = 0;
                this.GenerateInputs();
                return true;
            } else {
                return false;
            }
        }

        public void CheckInput(string key, long ms) {
            if (this.ActiveInput.KeyName.ToLower().Replace(" ", "") == key.ToLower().Replace(" ", "") && this.LastMS != ms) {
                this.LastMS = ms;
                this.NextInput();
            }
        }

        public void CheckTimer(long ms) {
            if (this.ActiveInputIndex > 0) {
                this.Timer -= ms - this.LastMS;
                this.lblCountdown.Text = this.Timer.ToString() + "ms";

                if (this.TimingMethod == 0) {
                    for (int i = 1; i < this.timingList.Controls.Count; i++) {
                        Label label = this.timingList.Controls[i] as Label;

                        if (label != null) {
                            label.Text = (float.Parse(label.Text) - (ms - this.LastMS)).ToString();
                        }
                    }
                } else if (this.ActiveInputIndex > 0) {
                    Label label = this.timingList.Controls[this.ActiveInputIndex] as Label;

                    if (label != null) {
                        label.Text = (float.Parse(label.Text) - (ms - this.LastMS)).ToString();
                    }
                }

                this.LastMS = ms;
            }
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.TimingMethod = 0;
        }

        private void singleToolStripMenuItem_Click(object sender, EventArgs e) {
            this.TimingMethod = 1;
        }

        private void InputTrainerUI_FormClosing(object sender, FormClosingEventArgs e) {
            this.Inputs.Clear();
            this.Timings.Clear();
            this.InputTrainer.DestroyTrainer();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            this.ResetInputs();
        }
    }
}
