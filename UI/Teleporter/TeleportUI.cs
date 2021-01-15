using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.UI.Teleporter;
using OriWotW.Memory;
using System.Globalization;
using System.IO;
using Tem.Utility;

namespace OriWotW.UI.Teleporter {
    public partial class TeleportUI : Form {
        private MemoryManager MemoryManager;
        private Manager Manager;
        private float X, Y;
        private double previousX, previousY;
        private List<string> ExistingAreas = new List<string>();
        private List<string> ExistingScenes = new List<string>();

        public TeleportUI() {
            Application.EnableVisualStyles();
            InitializeComponent();
            this.ReadTeleportFile();
        }

        private void teleport_Click(object sender, EventArgs e) {
            this.Teleport();// this.Manager.InjectCommunication.AddCall("CALL28PAR" + ((float)this.positionX.Value).ToString() + ";" + ((float)this.positionY.Value).ToString());
        }

        private void ReadTeleportFile() {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\teleporters.data") == true) {
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\teleporters.data");

                foreach (string line in lines) {
                    string[] values = line.Split('|');
                    AddTeleporterToMenuStrip(values[0], values[1], float.Parse(values[2], CultureInfo.CreateSpecificCulture("en-US")), float.Parse(values[3], CultureInfo.CreateSpecificCulture("en-US")));
                }
            }
        }

        private ToolStripMenuItem GetAreaMenu(string name) {
            foreach (ToolStripMenuItem item in this.teleportsToolStripMenuItem.DropDownItems) {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        private ToolStripMenuItem GetSceneMenu(ToolStripMenuItem area, string name) {
            foreach (ToolStripMenuItem item in area.DropDownItems) {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        private void AddTeleporterToMenuStrip(string area, string scene, float x, float y) {
            ToolStripMenuItem areaMenu, sceneMenu;

            if (ExistingAreas.Contains(area) == false) {
                ToolStripMenuItem toolStripItem = new ToolStripMenuItem(area);
                toolStripItem.Text = area;
                toolStripItem.Name = area;
                areaMenu = toolStripItem;
                this.ExistingAreas.Add(area);
                this.teleportsToolStripMenuItem.DropDownItems.Add(toolStripItem);
            } else
                areaMenu = GetAreaMenu(area);

            if (ExistingScenes.Contains(scene) == false) {
                ToolStripMenuItem toolStripItem = new ToolStripMenuItem(scene);
                toolStripItem.Text = scene;
                toolStripItem.Name = scene;
                sceneMenu = toolStripItem;
                this.ExistingScenes.Add(scene);
                areaMenu.DropDownItems.Add(toolStripItem);
            } else
                sceneMenu = GetSceneMenu(areaMenu, scene);

            ToolStripMenuItem teleporter = new ToolStripMenuItem("X: " + x.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", Y: " + y.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            teleporter.Name = sceneMenu.DropDownItems.Count.ToString();
            teleporter.Click += menuItem_Click;
            sceneMenu.DropDownItems.Add(teleporter);
        }

        public void AddTeleportToFile(string area, string scene, float x, float y) {
            this.AddTeleporterToMenuStrip(area, scene, x, y);
            string teleporter = area + "|" + scene + "|" + x.ToString(CultureInfo.CreateSpecificCulture("en-US")) + "|" + y.ToString(CultureInfo.CreateSpecificCulture("en-US")) + Environment.NewLine;
            System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\teleporters.data", teleporter);
        }

        private void cancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        public void SetMemoryManager(MemoryManager memory, Manager manager) {
            this.MemoryManager = memory;
            this.Manager = manager;
        }

        public void SetDefaultPosition(float x, float y) {
            this.X = x;
            this.Y = y;
            this.positionX.Value = (decimal)this.X;
            this.positionY.Value = (decimal)this.Y;
        }

        private void positionX_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void positionX_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        private void Teleport(bool createUI = true) {
            this.Manager.InjectCommunication.AddCall("CALL28PAR" + ((float)this.positionX.Value).ToString() + ";" + ((float)this.positionY.Value).ToString());

            if (createUI == true && (this.previousX.IsEqualTo(double.Parse(this.positionX.Value.ToString()), 0.001) == false || this.previousY.IsEqualTo(double.Parse(this.positionY.Value.ToString()), 0.001) == false)) {
                TeleportLocation teleport = new TeleportLocation(this);
                AreaType area = this.MemoryManager.PlayerArea();
                string scene = this.MemoryManager.CurrentScene();
                teleport.SetInfo(area.ToString(), scene, (float)this.positionX.Value, (float)this.positionY.Value);

                if (this.previousTeleports.Controls.Count >= 10)
                    this.previousTeleports.Controls.Remove(this.previousTeleports.Controls[0]);

                this.previousTeleports.Controls.Add(teleport);
                this.previousX = double.Parse(this.positionX.Value.ToString());
                this.previousY = double.Parse(this.positionY.Value.ToString());
            }
        }

        public void TeleportTo(float x, float y) {
            this.X = x;
            this.Y = y;
            this.positionX.Value = (decimal)this.X;
            this.positionY.Value = (decimal)this.Y;
            this.Teleport(false);
        }

        void menuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string[] datas = item.Text.Replace("X: ", "").Replace("Y: ", "").Split(',');
            this.TeleportTo(float.Parse(datas[0], CultureInfo.CreateSpecificCulture("en-US")), float.Parse(datas[1], CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}