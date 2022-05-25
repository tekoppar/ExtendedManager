using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication.Inject;

namespace OriWotW.UI {
    public partial class BackupSaveSlot : UserControl {
        public BackupsaveUI BackupsaveUI;
        public BackupSaveSlot(int index = 0, string areaName = "Inkwater Marsh", int completion = 0, int hours = 0, int minutes = 0, int seconds = 0, string health = "3/3", string energy = "3/3") {
            InitializeComponent();
            this.Index.Text = index.ToString() + ".";
            this.AreaName.Text = areaName;
            this.Completion.Text = completion.ToString() + "%";
            this.Time.Text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
            this.Health.Text = health;
            this.Energy.Text = energy;
        }

        private void button1_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL29PAR" + this.Index.Text);
        }
    }
}
