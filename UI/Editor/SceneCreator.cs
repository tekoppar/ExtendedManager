using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriWotW.UI.Editor {
    public partial class SceneCreator : Form {
        private Manager Manager;
        public string ReturnName { get; set; }
        public Tem.TemClass.Vector3 ReturnPosition { get; set; }
        public Tem.TemClass.Vector2 ReturnSize { get; set; }
        public Tem.TemClass.TColor ReturnLoadingRect { get; set; }
        public SceneCreator(Manager manager) {
            InitializeComponent();
            this.Manager = manager;
            ScenePosition.SetValue(Manager.Memory.Position());
        }

        private void input_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        private void btnCreateScene_Click(object sender, EventArgs e) {
            this.ReturnName = this.tbxSceneName.Text;
            this.ReturnPosition = this.ScenePosition.GetValue();
            this.ReturnSize = this.SceneSize.GetValue();
            this.ReturnLoadingRect = this.SceneLoadingRect.GetValue();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
