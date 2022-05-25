using System.Windows.Forms;

namespace OriWotW {
    partial class Manager {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            IsDisposingNow = true;
            if (this.InjectCommunication != null) {
                this.InjectCommunication.AddCall("CALL0");
                this.InjectCommunication.StopCommunication();
            }
            this.timerLoop.Join();
            this.DLLCommunication.Join();

            if (disposing && (components != null)) {
                //this.DllInjector.Unload("oriwotw", "C:\\Users\\Tekoppar\\Desktop\\LiveSplit.OriWotW-master\\bin\\injectdll.dll");
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblKeys = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblOre = new System.Windows.Forms.Label();
            this.lblEN = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblScene = new System.Windows.Forms.Label();
            this.lblSaved = new System.Windows.Forms.Label();
            this.lblFPS = new System.Windows.Forms.Label();
            this.lblExtra = new System.Windows.Forms.Label();
            this.tooltips = new System.Windows.Forms.ToolTip(this.components);
            this.inputsDown = new System.Windows.Forms.Label();
            this.possibleCombos = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTotalFPS = new System.Windows.Forms.Panel();
            this.lblSpeedLocal = new System.Windows.Forms.Label();
            this.lblAdditiveLocalSpeed = new System.Windows.Forms.Label();
            this.lblAirNoDeceleration = new System.Windows.Forms.Label();
            this.lblSpeedFactor = new System.Windows.Forms.Label();
            this.panelHPEN = new System.Windows.Forms.Panel();
            this.panelOreKeys = new System.Windows.Forms.Panel();
            this.flowStateList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowInputIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInputInts = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.managerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.randomInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTotalFPS.SuspendLayout();
            this.panelHPEN.SuspendLayout();
            this.panelOreKeys.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(0, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(459, 339);
            this.lblNote.TabIndex = 15;
            this.lblNote.Text = "Not available";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeys
            // 
            this.lblKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeys.Location = new System.Drawing.Point(161, 0);
            this.lblKeys.Margin = new System.Windows.Forms.Padding(0);
            this.lblKeys.Name = "lblKeys";
            this.lblKeys.Size = new System.Drawing.Size(136, 20);
            this.lblKeys.TabIndex = 25;
            this.lblKeys.Text = "Keys: N/A";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(3, 80);
            this.lblSpeed.MinimumSize = new System.Drawing.Size(350, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(398, 20);
            this.lblSpeed.TabIndex = 24;
            this.lblSpeed.Text = "Speed:";
            // 
            // lblOre
            // 
            this.lblOre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOre.Location = new System.Drawing.Point(0, 0);
            this.lblOre.Margin = new System.Windows.Forms.Padding(0);
            this.lblOre.Name = "lblOre";
            this.lblOre.Size = new System.Drawing.Size(129, 20);
            this.lblOre.TabIndex = 22;
            this.lblOre.Text = "Ore: N/A";
            // 
            // lblEN
            // 
            this.lblEN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEN.Location = new System.Drawing.Point(159, 2);
            this.lblEN.Margin = new System.Windows.Forms.Padding(0);
            this.lblEN.Name = "lblEN";
            this.lblEN.Size = new System.Drawing.Size(138, 20);
            this.lblEN.TabIndex = 21;
            this.lblEN.Text = "EN: N/A";
            // 
            // lblHP
            // 
            this.lblHP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP.Location = new System.Drawing.Point(0, 2);
            this.lblHP.Margin = new System.Windows.Forms.Padding(0);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(129, 20);
            this.lblHP.TabIndex = 20;
            this.lblHP.Text = "HP: N/A";
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(3, 20);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(398, 20);
            this.lblArea.TabIndex = 19;
            this.lblArea.Text = "Area:";
            // 
            // lblPos
            // 
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPos.Location = new System.Drawing.Point(3, 60);
            this.lblPos.MinimumSize = new System.Drawing.Size(350, 0);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(398, 20);
            this.lblPos.TabIndex = 17;
            this.lblPos.Text = "Position:";
            // 
            // lblMap
            // 
            this.lblMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(0, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(183, 20);
            this.lblMap.TabIndex = 16;
            this.lblMap.Text = "Total: ";
            // 
            // lblScene
            // 
            this.lblScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScene.Location = new System.Drawing.Point(3, 40);
            this.lblScene.Name = "lblScene";
            this.lblScene.Size = new System.Drawing.Size(416, 20);
            this.lblScene.TabIndex = 26;
            this.lblScene.Text = "Scene:";
            // 
            // lblSaved
            // 
            this.lblSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaved.Location = new System.Drawing.Point(3, 192);
            this.lblSaved.Name = "lblSaved";
            this.lblSaved.Size = new System.Drawing.Size(416, 20);
            this.lblSaved.TabIndex = 27;
            this.lblSaved.Text = "Save: N/A";
            // 
            // lblFPS
            // 
            this.lblFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPS.Location = new System.Drawing.Point(247, 0);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(133, 20);
            this.lblFPS.TabIndex = 28;
            this.lblFPS.Text = "FPS: 0.0";
            // 
            // lblExtra
            // 
            this.lblExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtra.Location = new System.Drawing.Point(3, 212);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(398, 20);
            this.lblExtra.TabIndex = 29;
            this.lblExtra.Text = "Debug: Off   No Pause: Off   FPS Lock: Off";
            this.tooltips.SetToolTip(this.lblExtra, "Ctrl+D Debug\r\nCtrl+N NoPause\r\nCtrl+F Lock FPS");
            // 
            // inputsDown
            // 
            this.inputsDown.AutoSize = true;
            this.inputsDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputsDown.Location = new System.Drawing.Point(3, 244);
            this.inputsDown.MinimumSize = new System.Drawing.Size(50, 0);
            this.inputsDown.Name = "inputsDown";
            this.inputsDown.Size = new System.Drawing.Size(50, 20);
            this.inputsDown.TabIndex = 30;
            // 
            // possibleCombos
            // 
            this.possibleCombos.AutoSize = true;
            this.possibleCombos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.possibleCombos.Location = new System.Drawing.Point(3, 277);
            this.possibleCombos.MinimumSize = new System.Drawing.Size(50, 0);
            this.possibleCombos.Name = "possibleCombos";
            this.possibleCombos.Size = new System.Drawing.Size(50, 17);
            this.possibleCombos.TabIndex = 31;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelTotalFPS);
            this.flowLayoutPanel1.Controls.Add(this.lblArea);
            this.flowLayoutPanel1.Controls.Add(this.lblScene);
            this.flowLayoutPanel1.Controls.Add(this.lblPos);
            this.flowLayoutPanel1.Controls.Add(this.lblSpeed);
            this.flowLayoutPanel1.Controls.Add(this.lblSpeedLocal);
            this.flowLayoutPanel1.Controls.Add(this.lblAdditiveLocalSpeed);
            this.flowLayoutPanel1.Controls.Add(this.lblAirNoDeceleration);
            this.flowLayoutPanel1.Controls.Add(this.lblSpeedFactor);
            this.flowLayoutPanel1.Controls.Add(this.panelHPEN);
            this.flowLayoutPanel1.Controls.Add(this.panelOreKeys);
            this.flowLayoutPanel1.Controls.Add(this.lblSaved);
            this.flowLayoutPanel1.Controls.Add(this.lblExtra);
            this.flowLayoutPanel1.Controls.Add(this.flowStateList);
            this.flowLayoutPanel1.Controls.Add(this.flowInputIcons);
            this.flowLayoutPanel1.Controls.Add(this.inputsDown);
            this.flowLayoutPanel1.Controls.Add(this.lblInputInts);
            this.flowLayoutPanel1.Controls.Add(this.possibleCombos);
            this.flowLayoutPanel1.Controls.Add(this.randomInfo);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(456, 307);
            this.flowLayoutPanel1.TabIndex = 32;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelTotalFPS
            // 
            this.panelTotalFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTotalFPS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTotalFPS.Controls.Add(this.lblFPS);
            this.panelTotalFPS.Controls.Add(this.lblMap);
            this.panelTotalFPS.Location = new System.Drawing.Point(3, 0);
            this.panelTotalFPS.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelTotalFPS.Name = "panelTotalFPS";
            this.panelTotalFPS.Size = new System.Drawing.Size(450, 20);
            this.panelTotalFPS.TabIndex = 1;
            // 
            // lblSpeedLocal
            // 
            this.lblSpeedLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedLocal.Location = new System.Drawing.Point(3, 100);
            this.lblSpeedLocal.Name = "lblSpeedLocal";
            this.lblSpeedLocal.Size = new System.Drawing.Size(350, 13);
            this.lblSpeedLocal.TabIndex = 35;
            this.lblSpeedLocal.Text = "SpeedLocal:";
            // 
            // lblAdditiveLocalSpeed
            // 
            this.lblAdditiveLocalSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditiveLocalSpeed.Location = new System.Drawing.Point(3, 113);
            this.lblAdditiveLocalSpeed.Name = "lblAdditiveLocalSpeed";
            this.lblAdditiveLocalSpeed.Size = new System.Drawing.Size(350, 13);
            this.lblAdditiveLocalSpeed.TabIndex = 36;
            this.lblAdditiveLocalSpeed.Text = "AdditiveLocalSpeed:";
            // 
            // lblAirNoDeceleration
            // 
            this.lblAirNoDeceleration.Location = new System.Drawing.Point(3, 126);
            this.lblAirNoDeceleration.Name = "lblAirNoDeceleration";
            this.lblAirNoDeceleration.Size = new System.Drawing.Size(400, 13);
            this.lblAirNoDeceleration.TabIndex = 38;
            this.lblAirNoDeceleration.Text = "AirNoDeceleration:";
            // 
            // lblSpeedFactor
            // 
            this.lblSpeedFactor.Location = new System.Drawing.Point(3, 139);
            this.lblSpeedFactor.Name = "lblSpeedFactor";
            this.lblSpeedFactor.Size = new System.Drawing.Size(400, 13);
            this.lblSpeedFactor.TabIndex = 37;
            this.lblSpeedFactor.Text = "SpeedFactor:";
            // 
            // panelHPEN
            // 
            this.panelHPEN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelHPEN.Controls.Add(this.lblHP);
            this.panelHPEN.Controls.Add(this.lblEN);
            this.panelHPEN.Location = new System.Drawing.Point(3, 152);
            this.panelHPEN.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelHPEN.Name = "panelHPEN";
            this.panelHPEN.Size = new System.Drawing.Size(320, 20);
            this.panelHPEN.TabIndex = 27;
            // 
            // panelOreKeys
            // 
            this.panelOreKeys.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOreKeys.Controls.Add(this.lblOre);
            this.panelOreKeys.Controls.Add(this.lblKeys);
            this.panelOreKeys.Location = new System.Drawing.Point(3, 172);
            this.panelOreKeys.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelOreKeys.Name = "panelOreKeys";
            this.panelOreKeys.Size = new System.Drawing.Size(320, 20);
            this.panelOreKeys.TabIndex = 28;
            // 
            // flowStateList
            // 
            this.flowStateList.AutoSize = true;
            this.flowStateList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowStateList.Location = new System.Drawing.Point(3, 235);
            this.flowStateList.MaximumSize = new System.Drawing.Size(450, 0);
            this.flowStateList.MinimumSize = new System.Drawing.Size(450, 0);
            this.flowStateList.Name = "flowStateList";
            this.flowStateList.Size = new System.Drawing.Size(450, 0);
            this.flowStateList.TabIndex = 39;
            // 
            // flowInputIcons
            // 
            this.flowInputIcons.AutoSize = true;
            this.flowInputIcons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowInputIcons.Location = new System.Drawing.Point(3, 241);
            this.flowInputIcons.Name = "flowInputIcons";
            this.flowInputIcons.Size = new System.Drawing.Size(0, 0);
            this.flowInputIcons.TabIndex = 41;
            this.flowInputIcons.WrapContents = false;
            // 
            // lblInputInts
            // 
            this.lblInputInts.Location = new System.Drawing.Point(3, 264);
            this.lblInputInts.MinimumSize = new System.Drawing.Size(50, 0);
            this.lblInputInts.Name = "lblInputInts";
            this.lblInputInts.Size = new System.Drawing.Size(150, 13);
            this.lblInputInts.TabIndex = 40;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 317);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(459, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // managerStatus
            // 
            this.managerStatus.Name = "managerStatus";
            this.managerStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // randomInfo
            // 
            this.randomInfo.AutoSize = true;
            this.randomInfo.Location = new System.Drawing.Point(3, 294);
            this.randomInfo.Name = "randomInfo";
            this.randomInfo.Size = new System.Drawing.Size(0, 13);
            this.randomInfo.TabIndex = 42;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(459, 339);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblNote);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::OriWotW.Properties.Resources.icon;
            this.KeyPreview = true;
            this.Name = "Manager";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Manager";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Manager_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelTotalFPS.ResumeLayout(false);
            this.panelHPEN.ResumeLayout(false);
            this.panelOreKeys.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblKeys;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblOre;
        private System.Windows.Forms.Label lblEN;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblScene;
        private System.Windows.Forms.Label lblSaved;
        private System.Windows.Forms.Label lblFPS;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.ToolTip tooltips;
        private System.Windows.Forms.Label inputsDown;
        private System.Windows.Forms.Label possibleCombos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelTotalFPS;
        private System.Windows.Forms.Panel panelHPEN;
        private System.Windows.Forms.Panel panelOreKeys;
        private System.Windows.Forms.Label lblSpeedLocal;
        private System.Windows.Forms.Label lblAdditiveLocalSpeed;
        private System.Windows.Forms.Label lblSpeedFactor;
        private System.Windows.Forms.Label lblAirNoDeceleration;
        private System.Windows.Forms.FlowLayoutPanel flowStateList;
        public System.Windows.Forms.Label lblInputInts;
        private System.Windows.Forms.FlowLayoutPanel flowInputIcons;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel managerStatus;
        public Label randomInfo;
    }
}