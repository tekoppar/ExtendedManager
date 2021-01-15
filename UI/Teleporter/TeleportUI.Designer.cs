namespace OriWotW.UI.Teleporter {
    partial class TeleportUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeleportUI));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelX = new System.Windows.Forms.Label();
            this.positionX = new System.Windows.Forms.NumericUpDown();
            this.labelY = new System.Windows.Forms.Label();
            this.positionY = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.teleport = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.previousTeleports = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.teleportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.labelX);
            this.flowLayoutPanel1.Controls.Add(this.positionX);
            this.flowLayoutPanel1.Controls.Add(this.labelY);
            this.flowLayoutPanel1.Controls.Add(this.positionY);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 34);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(257, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // labelX
            // 
            this.labelX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelX.Location = new System.Drawing.Point(8, 5);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(22, 26);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "X:";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // positionX
            // 
            this.positionX.DecimalPlaces = 4;
            this.positionX.Location = new System.Drawing.Point(36, 8);
            this.positionX.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.positionX.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.positionX.Name = "positionX";
            this.positionX.Size = new System.Drawing.Size(90, 20);
            this.positionX.TabIndex = 2;
            this.positionX.Enter += new System.EventHandler(this.positionX_Enter);
            this.positionX.Leave += new System.EventHandler(this.positionX_Leave);
            // 
            // labelY
            // 
            this.labelY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelY.Location = new System.Drawing.Point(132, 5);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(21, 26);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y:";
            this.labelY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // positionY
            // 
            this.positionY.DecimalPlaces = 4;
            this.positionY.Location = new System.Drawing.Point(159, 8);
            this.positionY.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.positionY.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.positionY.Name = "positionY";
            this.positionY.Size = new System.Drawing.Size(90, 20);
            this.positionY.TabIndex = 3;
            this.positionY.Enter += new System.EventHandler(this.positionX_Enter);
            this.positionY.Leave += new System.EventHandler(this.positionX_Leave);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(319, 1);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // teleport
            // 
            this.teleport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.teleport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.teleport.Location = new System.Drawing.Point(271, 41);
            this.teleport.Name = "teleport";
            this.teleport.Size = new System.Drawing.Size(75, 23);
            this.teleport.TabIndex = 0;
            this.teleport.Text = "Teleport";
            this.teleport.UseVisualStyleBackColor = true;
            this.teleport.Click += new System.EventHandler(this.teleport_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(352, 41);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // previousTeleports
            // 
            this.previousTeleports.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.previousTeleports.Location = new System.Drawing.Point(12, 74);
            this.previousTeleports.Name = "previousTeleports";
            this.previousTeleports.Size = new System.Drawing.Size(856, 322);
            this.previousTeleports.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teleportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(878, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // teleportsToolStripMenuItem
            // 
            this.teleportsToolStripMenuItem.Name = "teleportsToolStripMenuItem";
            this.teleportsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.teleportsToolStripMenuItem.Text = "Teleports";
            // 
            // TeleportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(878, 408);
            this.Controls.Add(this.previousTeleports);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.teleport);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeleportUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Teleport UI";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown positionX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.NumericUpDown positionY;
        private System.Windows.Forms.Button teleport;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.FlowLayoutPanel previousTeleports;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teleportsToolStripMenuItem;
    }
}