using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OriWotW.UI.Input {
    public class InputTrainer {
        private string[] InputImages;
        private Form Parent;
        private InputTrainerUI ActiveTrainerUI;
        public Dictionary<string, Input> Inputs = new Dictionary<string, Input>();

        public InputTrainer(Form parent) {
            this.Parent = parent;
            this.InputImages = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\InputImages", "*.png");
            this.GenerateInputs();
        }

        private void GenerateInputs() {
            foreach (string input in this.InputImages) {
                if (input.EndsWith("P.png") == false) {
                    string inputName = "";

                    if (input.IndexOf("button") != -1) {
                        inputName = Path.GetFileName(input).Replace("button", "");
                    } else if (input.IndexOf("keyboardButton") != -1) {
                        inputName = Path.GetFileName(input).Replace("keyboardButton", "");
                    } else if (input.IndexOf("analogue") != -1) {
                        inputName = Path.GetFileName(input).Replace("analogue", "");
                    } else if (input.IndexOf("Mouse") != -1) {
                        inputName = Path.GetFileName(input);
                    } else if (input.IndexOf("Joypad") != -1) {
                        inputName = Path.GetFileName(input);
                    } else if (input.IndexOf("ability") != -1) {
                        inputName = Path.GetFileName(input).Replace("ability", "");
                    }
                    inputName = inputName.Replace(".png", "");

                    if (inputName != "" && this.Inputs.ContainsKey(inputName) == false) {

                        if (File.Exists(input.Replace(".png", "P.png"))) {
                            this.Inputs.Add(inputName, new Input(inputName, input, input.Replace(".png", "P.png")));
                        } else {
                            this.Inputs.Add(inputName, new Input(inputName, input));
                        }
                    }
                }
            }
        }

        public PictureBox GetInputImage(string key, int maxSize = 32) {
            UI.Input.Input imgInput = this.GetInput(key);

            if (imgInput != null) {
                PictureBox picture = new PictureBox();
                Image image = Image.FromFile(imgInput.Key);
                Size imageSize = image.Size;

                if (image.Size.Height > maxSize) {
                    float newRatio = (float)imageSize.Height / maxSize;
                    imageSize.Height = maxSize;
                    imageSize.Width = (int)(imageSize.Width / newRatio);
                }

                picture.Image = image;
                picture.Size = imageSize;
                picture.SizeMode = PictureBoxSizeMode.Zoom;

                return picture;
            }

            return null;
        }

        public void KeyPressed(string key, long ms) {
            if (this.ActiveTrainerUI != null) {
                this.ActiveTrainerUI.CheckInput(key, ms);
            }
        }

        public List<Input> GetInputs(List<string> getInputs) {
            List<Input> inputs = new List<Input>();

            foreach (string s in getInputs) {
                if (this.Inputs.ContainsKey(s.Replace(" ", "")) == true) {
                    inputs.Add(this.Inputs[s.Replace(" ", "")]);
                }
            }

            return inputs;
        }

        public Input GetInput(string input) {
            if (this.Inputs.ContainsKey(input.Replace(" ", "")) == true) {
                return this.Inputs[input.Replace(" ", "")];
            }
            return null;
        }

        public void NewInputTrainer(List<Inputs> inputs) {
            List<string> keys = new List<string>();
            List<int> timings = new List<int>();

            for (int i = 0; i < inputs.Count; i++) {
                Inputs input = inputs[i];
                for (int i2 = 0; i2 < input.Keys.Count; i2++) {
                    keys.Add(input.Keys[i2]);
                }
                if (i > 0) {
                    timings.Add(input.Timing[0]);
                }
            }

            InputTrainerUI trainer = new InputTrainerUI(this);
            var result = trainer.SetInputs(this.GetInputs(keys), timings, inputs);
            if (result == true) {
                this.ActiveTrainerUI = trainer;
                this.ActiveTrainerUI.Show(this.Parent);
            }
        }

        public void CheckTimer(long ms) {
            if (this.ActiveTrainerUI != null) {
                this.ActiveTrainerUI.CheckTimer(ms);
            }
        }

        public void DestroyTrainer() {
            this.ActiveTrainerUI = null;
        }
    }

    public class Input {
        public string KeyName;
        public string Key;
        public string KeyPressed;

        public Input(string keyName, string key, string keyPressed = null) {
            this.KeyName = keyName;
            this.Key = key;
            if (keyPressed == null) {
                this.KeyPressed = key;
            } else {
                this.KeyPressed = keyPressed;
            }
        }
    }
}
