using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.UI.VisualEditor;

namespace OriWotW.UI {
    public partial class WotwEditor : Form {
        private Manager Manager;
        public WotwEditor(Manager manager) {
            InitializeComponent();
            this.Manager = manager;
            this.Manager.InjectCommunication.AddCall("CALL34");
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Manager.InjectCommunication.AddCall("CALL33PAR" + this.position.GetValue().ToString() + "|" + this.localPosition.GetValue().ToString() + "|" + this.scale.GetValue().ToString() + "|" + this.rotation.GetValue().ToString() + "|" + this.matSortingOrder.Value.ToString() + "|" + this.moonZOffset.Value.ToString() + "|" + this.matRenderQueue.Value.ToString() + "|" + this.layerMaskValue.Value.ToString());
        }

        private void input_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }
    }
}
