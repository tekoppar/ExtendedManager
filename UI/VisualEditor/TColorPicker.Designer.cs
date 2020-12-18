
namespace OriWotW.UI {
    partial class TColorPicker {
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.colorPicker = new System.Windows.Forms.PictureBox();
            this.lblColorValues = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.colorPicker);
            this.flowLayoutPanel1.Controls.Add(this.lblColorValues);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 70);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // colorPicker
            // 
            this.colorPicker.BackgroundImage = global::OriWotW.Properties.Resources.colorpickerbackground;
            this.colorPicker.Location = new System.Drawing.Point(3, 3);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(64, 64);
            this.colorPicker.TabIndex = 2;
            this.colorPicker.TabStop = false;
            this.toolTip1.SetToolTip(this.colorPicker, "Left click to copy color, right click to paste color. Double click to open color " +
        "picker.");
            this.colorPicker.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            this.colorPicker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // lblColorValues
            // 
            this.lblColorValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorValues.BackColor = System.Drawing.Color.Transparent;
            this.lblColorValues.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblColorValues.Location = new System.Drawing.Point(73, 28);
            this.lblColorValues.Name = "lblColorValues";
            this.lblColorValues.Size = new System.Drawing.Size(102, 13);
            this.lblColorValues.TabIndex = 1;
            this.lblColorValues.Text = "255, 255, 255, 255";
            this.toolTip1.SetToolTip(this.lblColorValues, "Displays the color values from red, green, blue and opacity.");
            // 
            // TColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Name = "TColorPicker";
            this.Size = new System.Drawing.Size(178, 70);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblColorValues;
        private System.Windows.Forms.PictureBox colorPicker;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
