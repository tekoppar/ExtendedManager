
namespace OriWotW.UI {
    partial class ColorWheel {
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
            this.colorGradient = new System.Windows.Forms.PictureBox();
            this.colorRainbow = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblR = new System.Windows.Forms.Label();
            this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.lblG = new System.Windows.Forms.Label();
            this.numericUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.lblB = new System.Windows.Forms.Label();
            this.numericUpDownBlue = new System.Windows.Forms.NumericUpDown();
            this.btnRainbowPicker = new System.Windows.Forms.Button();
            this.rainbowPanel = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorBoxPanel = new System.Windows.Forms.Panel();
            this.colorPickerLocation = new System.Windows.Forms.PictureBox();
            this.SliderAlphaValue = new System.Windows.Forms.TrackBar();
            this.chosenColor = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colorGradient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorRainbow)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).BeginInit();
            this.rainbowPanel.SuspendLayout();
            this.colorBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderAlphaValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenColor)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorGradient
            // 
            this.colorGradient.BackgroundImage = global::OriWotW.Properties.Resources.colorpickerbackground;
            this.colorGradient.Location = new System.Drawing.Point(6, 6);
            this.colorGradient.Name = "colorGradient";
            this.colorGradient.Size = new System.Drawing.Size(256, 256);
            this.colorGradient.TabIndex = 6;
            this.colorGradient.TabStop = false;
            this.colorGradient.Click += new System.EventHandler(this.colorGradient_Click);
            this.colorGradient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorBoxPanel_MouseDown);
            this.colorGradient.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorBoxPanel_MouseMove);
            this.colorGradient.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorBoxPanel_MouseUp);
            // 
            // colorRainbow
            // 
            this.colorRainbow.Location = new System.Drawing.Point(0, 0);
            this.colorRainbow.Name = "colorRainbow";
            this.colorRainbow.Size = new System.Drawing.Size(40, 360);
            this.colorRainbow.TabIndex = 4;
            this.colorRainbow.TabStop = false;
            this.colorRainbow.Click += new System.EventHandler(this.colorRainbow_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.lblR);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownRed);
            this.flowLayoutPanel1.Controls.Add(this.lblG);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownGreen);
            this.flowLayoutPanel1.Controls.Add(this.lblB);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownBlue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 276);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lblR
            // 
            this.lblR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblR.Location = new System.Drawing.Point(3, 9);
            this.lblR.Margin = new System.Windows.Forms.Padding(0);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(20, 13);
            this.lblR.TabIndex = 0;
            this.lblR.Text = "R:";
            // 
            // numericUpDownRed
            // 
            this.numericUpDownRed.Location = new System.Drawing.Point(26, 6);
            this.numericUpDownRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRed.Name = "numericUpDownRed";
            this.numericUpDownRed.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownRed.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numericUpDownRed, "Red color value, 0-255.");
            // 
            // lblG
            // 
            this.lblG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblG.Location = new System.Drawing.Point(89, 9);
            this.lblG.Margin = new System.Windows.Forms.Padding(0);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(20, 13);
            this.lblG.TabIndex = 2;
            this.lblG.Text = "G:";
            // 
            // numericUpDownGreen
            // 
            this.numericUpDownGreen.Location = new System.Drawing.Point(112, 6);
            this.numericUpDownGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGreen.Name = "numericUpDownGreen";
            this.numericUpDownGreen.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownGreen.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownGreen, "Green color value, 0-255.");
            // 
            // lblB
            // 
            this.lblB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(175, 9);
            this.lblB.Margin = new System.Windows.Forms.Padding(0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(17, 13);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "B:";
            // 
            // numericUpDownBlue
            // 
            this.numericUpDownBlue.Location = new System.Drawing.Point(195, 6);
            this.numericUpDownBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlue.Name = "numericUpDownBlue";
            this.numericUpDownBlue.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownBlue.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericUpDownBlue, "Blue color value, 0-255.");
            // 
            // btnRainbowPicker
            // 
            this.btnRainbowPicker.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRainbowPicker.Location = new System.Drawing.Point(0, 0);
            this.btnRainbowPicker.Margin = new System.Windows.Forms.Padding(0);
            this.btnRainbowPicker.Name = "btnRainbowPicker";
            this.btnRainbowPicker.Size = new System.Drawing.Size(40, 10);
            this.btnRainbowPicker.TabIndex = 3;
            this.btnRainbowPicker.UseVisualStyleBackColor = true;
            this.btnRainbowPicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRainbowPicker_MouseDown);
            this.btnRainbowPicker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRainbowPicker_MouseMove);
            this.btnRainbowPicker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRainbowPicker_MouseUp);
            // 
            // rainbowPanel
            // 
            this.rainbowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rainbowPanel.Controls.Add(this.btnRainbowPicker);
            this.rainbowPanel.Controls.Add(this.colorRainbow);
            this.rainbowPanel.Location = new System.Drawing.Point(289, 5);
            this.rainbowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rainbowPanel.Name = "rainbowPanel";
            this.rainbowPanel.Size = new System.Drawing.Size(40, 360);
            this.rainbowPanel.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 403);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.toolTip1.SetToolTip(this.btnOK, "Picks the active color.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(248, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Aborts picking the color.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // colorBoxPanel
            // 
            this.colorBoxPanel.AutoSize = true;
            this.colorBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorBoxPanel.Controls.Add(this.colorPickerLocation);
            this.colorBoxPanel.Controls.Add(this.colorGradient);
            this.colorBoxPanel.Location = new System.Drawing.Point(5, 5);
            this.colorBoxPanel.Name = "colorBoxPanel";
            this.colorBoxPanel.Padding = new System.Windows.Forms.Padding(3, 3, 16, 16);
            this.colorBoxPanel.Size = new System.Drawing.Size(281, 281);
            this.colorBoxPanel.TabIndex = 9;
            // 
            // colorPickerLocation
            // 
            this.colorPickerLocation.BackColor = System.Drawing.Color.Transparent;
            this.colorPickerLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorPickerLocation.InitialImage = null;
            this.colorPickerLocation.Location = new System.Drawing.Point(0, 0);
            this.colorPickerLocation.Margin = new System.Windows.Forms.Padding(0);
            this.colorPickerLocation.Name = "colorPickerLocation";
            this.colorPickerLocation.Size = new System.Drawing.Size(16, 16);
            this.colorPickerLocation.TabIndex = 10;
            this.colorPickerLocation.TabStop = false;
            this.colorPickerLocation.Visible = false;
            // 
            // SliderAlphaValue
            // 
            this.SliderAlphaValue.LargeChange = 1;
            this.SliderAlphaValue.Location = new System.Drawing.Point(8, 27);
            this.SliderAlphaValue.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.SliderAlphaValue.Maximum = 255;
            this.SliderAlphaValue.Name = "SliderAlphaValue";
            this.SliderAlphaValue.Size = new System.Drawing.Size(270, 45);
            this.SliderAlphaValue.TabIndex = 11;
            this.SliderAlphaValue.TabStop = false;
            this.SliderAlphaValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.SliderAlphaValue, "Sets the opacity of the color.");
            this.SliderAlphaValue.Value = 128;
            this.SliderAlphaValue.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.SliderAlphaValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SliderAlphaValue_MouseUp);
            // 
            // chosenColor
            // 
            this.chosenColor.BackgroundImage = global::OriWotW.Properties.Resources.colorpickerbackground;
            this.chosenColor.Location = new System.Drawing.Point(5, 371);
            this.chosenColor.Name = "chosenColor";
            this.chosenColor.Size = new System.Drawing.Size(64, 64);
            this.chosenColor.TabIndex = 12;
            this.chosenColor.TabStop = false;
            this.toolTip1.SetToolTip(this.chosenColor, "Preview of the chosen color.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "0";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.SliderAlphaValue);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 312);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(284, 78);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 15);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "255";
            // 
            // ColorWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(335, 438);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chosenColor);
            this.Controls.Add(this.colorBoxPanel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rainbowPanel);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ColorWheel";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Color Picker";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorWheel_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.colorGradient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorRainbow)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).EndInit();
            this.rainbowPanel.ResumeLayout(false);
            this.colorBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorPickerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderAlphaValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chosenColor)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox colorGradient;
        private System.Windows.Forms.PictureBox colorRainbow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.NumericUpDown numericUpDownRed;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.NumericUpDown numericUpDownGreen;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.NumericUpDown numericUpDownBlue;
        private System.Windows.Forms.Button btnRainbowPicker;
        private System.Windows.Forms.Panel rainbowPanel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel colorBoxPanel;
        private System.Windows.Forms.PictureBox colorPickerLocation;
        private System.Windows.Forms.TrackBar SliderAlphaValue;
        private System.Windows.Forms.PictureBox chosenColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
