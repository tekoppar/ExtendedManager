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

namespace OriWotW.UI {
    public partial class HitboxSplit : Form {
        public Vector2 Position = new Vector2();
        public Vector2 HitboxScale = new Vector2();
        public Manager Manager;
        public bool UserChangedValue = false;

        public HitboxSplit(Manager manager) {
            this.Manager = manager;
            InitializeComponent();
            Vector3 position = Manager.Memory.Position();
            HitboxScale.Y = HitboxScale.X = 1.0f;
            Position.Y = position.Y;
            Position.X = position.X;

            UserChangedValue = false;
            startX.Value = (decimal)position.X;
            startY.Value = (decimal)position.Y;
            scaleX.Value = 1;
            scaleY.Value = 1;

            if (this.Visible == true) {
                Manager.InjectCommunication.AddCall("CALL22PAR" + Position.X.ToString() + ";" + Position.Y.ToString() + "|" + HitboxScale.X.ToString() + ";" + HitboxScale.Y.ToString());
            }
        }

        private void setStart_Click(object sender, EventArgs e) {
            Vector3 position = Manager.Memory.Position();
            Position.X = position.X;
            Position.Y = position.Y;

            UserChangedValue = false;
            startX.Value = (decimal)position.X;
            startY.Value = (decimal)position.Y;

            hitboxSplitCopy.Text = Position.X.ToString() + ", " + Position.Y.ToString() + ", " + HitboxScale.X.ToString() + ", " + HitboxScale.Y.ToString();
            Manager.InjectCommunication.AddCall("CALL22PAR" + Position.X.ToString() + ";" + Position.Y.ToString() + "|" + HitboxScale.X.ToString() + ";" + HitboxScale.Y.ToString());
        }

        private void createHitbox_Click(object sender, EventArgs e) {
            Manager.InjectCommunication.AddCall("CALL22PAR" + Position.X.ToString() + ";" + Position.Y.ToString() + "|" + HitboxScale.X.ToString() + ";" + HitboxScale.Y.ToString());
        }

        private void start_ValueChanged(object sender, EventArgs e) {
            if (UserChangedValue == true) {
                Position.X = (float)startX.Value;
                Position.Y = (float)startY.Value;
                hitboxSplitCopy.Text = Position.X.ToString() + ", " + Position.Y.ToString() + ", " + HitboxScale.X.ToString() + ", " + HitboxScale.Y.ToString();
                Manager.InjectCommunication.AddCall("CALL22PAR" + Position.X.ToString() + ";" + Position.Y.ToString() + "|" + HitboxScale.X.ToString() + ";" + HitboxScale.Y.ToString());
            }
        }

        private void scale_ValueChanged(object sender, EventArgs e) {
            if (UserChangedValue == true) {
                HitboxScale.X = (float)scaleX.Value;
                HitboxScale.Y = (float)scaleY.Value;
                hitboxSplitCopy.Text = Position.X.ToString() + ", " + Position.Y.ToString() + ", " + HitboxScale.X.ToString() + ", " + HitboxScale.Y.ToString();
                Manager.InjectCommunication.AddCall("CALL22PAR" + Position.X.ToString() + ";" + Position.Y.ToString() + "|" + HitboxScale.X.ToString() + ";" + HitboxScale.Y.ToString());
            }
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
            Clipboard.SetText(Position.X.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + Position.Y.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + HitboxScale.X.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + HitboxScale.Y.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
