using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.UI.Playback;

namespace OriWotW.UI {
    public partial class PlaybackInputDesigner : UserControl {
        private PlaybackEditor playbackEditor;

        public PlaybackInputDesigner() {
            InitializeComponent();
        }

        public void SetParent(PlaybackEditor playbackEditor) {
            this.playbackEditor = playbackEditor;
        }

        public string GetKey() {
            return this.inputSelector1.GetInput();
        }

        public void SetKey(string key) {
            int intValue = 0;
            if (key.StartsWith("0x")) {
                intValue = Convert.ToInt32(key, 16);
            } else {
                intValue = Convert.ToInt32(key);
            }
            string valueKey = Enum.GetName(typeof(PlaybackKeyCode), intValue);
            this.inputSelector1.SetInput(valueKey);
        }

        public int GetStartFrame() {
            return int.Parse(this.startFrame.Text);
        }

        public void SetStartFrame(int frame) {
            this.startFrame.Text = frame.ToString();
        }

        public int GetLength() {
            return int.Parse(this.length.Text);
        }

        public void SetLength(int length) {
            this.length.Text = length.ToString();
        }

        public int GetWaitAfter() {
            return int.Parse(this.waitAfter.Text);
        }

        public void SetWaitAfter(int waitAfter) {
            this.waitAfter.Text = waitAfter.ToString();
        }

        private void _Enter(object sender, EventArgs e) {
            Manager._Instance.rawInput.RemoveMessageFilter();
        }

        private void _Leave(object sender, EventArgs e) {
            Manager._Instance.rawInput.AddMessageFilter();
        }

        private void removeInput_Click(object sender, EventArgs e) {
            this.playbackEditor.RemoveInputDesigner(this);
            this.Dispose();
        }
    }
}
