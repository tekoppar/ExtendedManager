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
    public partial class KeyInput : UserControl {
        public string KeyName = "Key";

        public KeyInput() {
            InitializeComponent();

            this.KeyName = "Key";
            this.key.Text = "Key";
        }

        public void SetKey(string key) {
            this.KeyName = key;
            this.key.Text = this.KeyName;
        }

        private void key_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {

            } else if (e.Button == MouseButtons.Right) {
                this.Dispose();
            }
        }
    }
}
