using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriWotW.UI {
    public partial class BackupsaveUI : Form {
        public Manager Manager;
        public List<Backupsave> Backupsaves = new List<Backupsave>();
        private int BackupSaveCount = 0;
        public BackupsaveUI(Manager manager) {
            Manager = manager;
            InitializeComponent();
            this.Manager.InjectCommunication.AddCall("CALL30");
        }

        private void butRefresh_Click(object sender, EventArgs e) {
            this.Manager.InjectCommunication.AddCall("CALL30");
        }

        public void RefreshSaves() {
            this.backupsavesList.Controls.Clear();

            Backupsaves = Backupsaves.OrderByDescending(x => x.Order).ThenByDescending(x => x.Hours).ThenByDescending(x => x.Minutes).ThenByDescending(x => x.Seconds).ThenByDescending(x => x.BackupIndex).ToList();

            foreach (Backupsave backupsave in Backupsaves) {
                BackupSaveSlot backupSaveSlot = new BackupSaveSlot(backupsave.BackupIndex, backupsave.AreaName, backupsave.Completion, backupsave.Hours, backupsave.Minutes, backupsave.Seconds, backupsave.Health.ToString() + "/" + backupsave.MaxHealth.ToString(), backupsave.Energy.ToString() + "/" + backupsave.MaxEnergy.ToString());
                backupSaveSlot.BackupsaveUI = this;

                this.backupsavesList.Controls.Add(backupSaveSlot);
            }

            BackupSaveCount = this.backupsavesList.Controls.Count;
            this.butCreateBackupsave.Visible = BackupSaveCount < 10;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (BackupSaveCount < 10) {
                this.Manager.InjectCommunication.AddCall("CALL29PAR" + (this.backupsavesList.Controls.Count).ToString());
                BackupSaveCount++;
                this.Manager.InjectCommunication.AddCall("CALL30");
            } else {
                this.butCreateBackupsave.Visible = false;
            }
        }
    }

    public enum DifficultyMode {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        OneLife = 3
    }

    public class Backupsave {
        public string AreaName = "";
        public int Completion = 0;
        public int Health = 0;
        public int MaxHealth = 0;
        public int Energy = 0;
        public int MaxEnergy = 0;
        public int Order = 0;
        public DifficultyMode Difficulty = DifficultyMode.Easy;
        public int Hours = 0;
        public int Minutes = 0;
        public int Seconds = 0;
        public int DebugOn = 0;
        public bool WasKilled = false;
        public int BackupIndex = 0;
    }
}
