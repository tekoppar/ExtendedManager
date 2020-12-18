
namespace OriWotW.UI.Teleporter {
    partial class TeleportLocation {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblAreaName = new System.Windows.Forms.Label();
            this.lblSubArea = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.SaveTeleport = new System.Windows.Forms.Button();
            this.Teleport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAreaName.Location = new System.Drawing.Point(3, 8);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.lblAreaName.Size = new System.Drawing.Size(180, 13);
            this.lblAreaName.TabIndex = 0;
            this.lblAreaName.Text = "Inkwater Marsh";
            // 
            // lblSubArea
            // 
            this.lblSubArea.AutoSize = true;
            this.lblSubArea.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSubArea.Location = new System.Drawing.Point(189, 8);
            this.lblSubArea.Name = "lblSubArea";
            this.lblSubArea.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.lblSubArea.Size = new System.Drawing.Size(180, 13);
            this.lblSubArea.TabIndex = 1;
            this.lblSubArea.Text = "swampIntroTop";
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCoordinates.Location = new System.Drawing.Point(375, 8);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.lblCoordinates.Size = new System.Drawing.Size(169, 13);
            this.lblCoordinates.TabIndex = 2;
            this.lblCoordinates.Text = "X: 0.0, Y: 0.0";
            // 
            // SaveTeleport
            // 
            this.SaveTeleport.Location = new System.Drawing.Point(631, 3);
            this.SaveTeleport.Name = "SaveTeleport";
            this.SaveTeleport.Size = new System.Drawing.Size(87, 23);
            this.SaveTeleport.TabIndex = 3;
            this.SaveTeleport.Text = "Save Teleport";
            this.SaveTeleport.UseVisualStyleBackColor = true;
            this.SaveTeleport.Click += new System.EventHandler(this.SaveTeleport_Click);
            // 
            // Teleport
            // 
            this.Teleport.Location = new System.Drawing.Point(550, 3);
            this.Teleport.Name = "Teleport";
            this.Teleport.Size = new System.Drawing.Size(75, 23);
            this.Teleport.TabIndex = 4;
            this.Teleport.Text = "Teleport";
            this.Teleport.UseVisualStyleBackColor = true;
            this.Teleport.Click += new System.EventHandler(this.Teleport_Click);
            // 
            // TeleportLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Teleport);
            this.Controls.Add(this.SaveTeleport);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.lblSubArea);
            this.Controls.Add(this.lblAreaName);
            this.Name = "TeleportLocation";
            this.Size = new System.Drawing.Size(723, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAreaName;
        private System.Windows.Forms.Label lblSubArea;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Button SaveTeleport;
        private System.Windows.Forms.Button Teleport;
    }
}
