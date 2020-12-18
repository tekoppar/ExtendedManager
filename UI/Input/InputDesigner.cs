using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriWotW.UI {
    public partial class InputDesigner : UserControl {
        private InputEditor InputEditor;

        public InputDesigner() {
            InitializeComponent();
            this.inputSelector1.KeyInputsPanel = this.keyList;
        }

        public void SetParent(InputEditor inputEditor) {
            this.InputEditor = inputEditor;
        }

        public void FillKeys(List<string> keys) {
            foreach (string key in keys) {
                KeyInput keyInput = new KeyInput();
                keyInput.SetKey(key);
                this.keyList.Controls.Add(keyInput);
            }
        }

        public void AddKey(string key) {
            KeyInput keyInput = new KeyInput();
            keyInput.SetKey(key);
            this.keyList.Controls.Add(keyInput);
        }

        public void SetTimings(List<int> timings) {
            string time = "";

            foreach (int timing in timings) {
                time += timing.ToString() + ", ";
            }
            this.timings.Text = time;
        }

        public List<int> GetTimings() {
            List<int> timings = new List<int>();
            var time = this.timings.Text.Split(',');

            foreach (string s in time) {
                if (s.Trim().Length > 0) {
                    timings.Add(Int32.Parse(s.Trim()));
                }
            }

            return timings;
        }

        public List<string> GetKeys() {
            List<string> keys = new List<string>();

            foreach (KeyInput container in this.keyList.Controls) {
                Label key = container.Controls[0].Controls[0] as Label;

                if (key != null) {
                    keys.Add(key.Text);
                }
            }

            return keys;
        }

        private void removeInput_Click(object sender, EventArgs e) {
            this.InputEditor.RemoveInputDesigner(this);
            this.Dispose();
        }
    }
}
