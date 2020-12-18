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

namespace OriWotW.UI.Teleporter {
    public partial class TeleportLocation : UserControl {
        private TeleportUI teleportUI;
        public TeleportLocation(TeleportUI teleportUI) {
            InitializeComponent();
            this.teleportUI = teleportUI;
        }

        public void SetInfo(string area, string scene, float x, float y) {
            this.lblAreaName.Text = area;
            this.lblSubArea.Text = scene;
            this.lblCoordinates.Text = "X: " + x.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", Y: " + y.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void Teleport_Click(object sender, EventArgs e) {
            string coordinates = this.lblCoordinates.Text;
            coordinates = coordinates.Replace("X:", "").Replace("Y:", "");
            string[] values = coordinates.Split(',');
            this.teleportUI.TeleportTo(float.Parse(values[0], CultureInfo.CreateSpecificCulture("en-US")), float.Parse(values[1], CultureInfo.CreateSpecificCulture("en-US")));
        }

        private void SaveTeleport_Click(object sender, EventArgs e) {
            string coordinates = this.lblCoordinates.Text;
            coordinates = coordinates.Replace("X:", "").Replace("Y:", "");
            string[] values = coordinates.Split(',');
            this.teleportUI.AddTeleportToFile(this.lblAreaName.Text, this.lblSubArea.Text, float.Parse(values[0], CultureInfo.CreateSpecificCulture("en-US")), float.Parse(values[1], CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}
