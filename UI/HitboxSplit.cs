using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Tem.TemClass;
using Communication.Inject;

namespace OriWotW.UI {
    public partial class HitboxSplit : Form {
        public Tem.TemClass.TColor Rect = new Tem.TemClass.TColor();
        public Manager Manager;
        public bool UserChangedValue = false;

        public HitboxSplit(Manager manager) {
            this.Manager = manager;
            InitializeComponent();
            Tem.TemClass.Vector3 position = Manager.Memory.Position();
            this.Rect.r = position.X;
            this.Rect.g = position.Y;
            this.Rect.b = this.Rect.a = 1.0f;

            UserChangedValue = false;
            hitboxSplitValues.SetValue(this.Rect);

            if (this.Visible == true) {
                InjectCommunication._Instance.AddCall("CALL22PAR" + this.Rect.ToString());
            }
        }

        private void setStart_Click(object sender, EventArgs e) {
            Vector3 position = Manager.Memory.Position();
            this.Rect.r = position.X;
            this.Rect.g = position.Y;

            UserChangedValue = false;
            hitboxSplitValues.SetValue(this.Rect);

            hitboxSplitCopy.Text = this.Rect.ToString();
            InjectCommunication._Instance.AddCall("CALL22PAR" + this.Rect.ToString());
        }

        private void createHitbox_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL22PAR" + this.Rect.ToString());
        }

        private void input_Enter(object sender, EventArgs e) {
            UserChangedValue = true;
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            UserChangedValue = false;
            this.Manager.rawInput.AddMessageFilter();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e) {
            Clipboard.SetText(this.Rect.ToString().ToString());
        }

        private void hitboxSplitValues_OnValueChangedNoArgs(object sender, EventArgs e) {
            hitboxSplitCopy.Text = this.Rect.ToString();
            InjectCommunication._Instance.AddCall("CALL22PAR" + this.Rect.ToString());
        }
    }
}
