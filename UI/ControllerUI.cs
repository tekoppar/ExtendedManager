using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace OriWotW.UI {
    public partial class ControllerUI : UserControl {
        public ControllerUI() {
            InitializeComponent();
        }

        private void joypad_Paint(object sender, PaintEventArgs e) {
            Image img = OriWotW.Properties.Resources.JoypadA;
            e.Graphics.DrawImage(img, 1340, 954, 190, 190);

            img = OriWotW.Properties.Resources.JoypadB;
            e.Graphics.DrawImage(img, 1452, 848, 190, 190);

            img = OriWotW.Properties.Resources.JoypadX;
            e.Graphics.DrawImage(img, 1231, 848, 190, 190);

            img = OriWotW.Properties.Resources.JoypadY;
            e.Graphics.DrawImage(img, 1340, 745, 190, 190);
        }
    }
}
