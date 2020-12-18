namespace OriWotW.UI {
    partial class ControllerUI {
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
            this.joypadA = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.joypadB = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.joypad = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.joypadA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joypadB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joypad)).BeginInit();
            this.SuspendLayout();
            // 
            // joypadA
            // 
            this.joypadA.BackColor = System.Drawing.Color.Transparent;
            this.joypadA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.joypadA.Image = global::OriWotW.Properties.Resources.JoypadA;
            this.joypadA.Location = new System.Drawing.Point(1325, 954);
            this.joypadA.Name = "joypadA";
            this.joypadA.Size = new System.Drawing.Size(190, 190);
            this.joypadA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.joypadA.TabIndex = 1;
            this.joypadA.TabStop = false;
            this.joypadA.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::OriWotW.Properties.Resources.JoypadX;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1221, 861);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 187);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::OriWotW.Properties.Resources.JoypadY;
            this.pictureBox2.Location = new System.Drawing.Point(1325, 745);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(218, 187);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // joypadB
            // 
            this.joypadB.BackColor = System.Drawing.Color.Transparent;
            this.joypadB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.joypadB.Image = global::OriWotW.Properties.Resources.JoypadB;
            this.joypadB.Location = new System.Drawing.Point(1436, 851);
            this.joypadB.Name = "joypadB";
            this.joypadB.Size = new System.Drawing.Size(218, 187);
            this.joypadB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.joypadB.TabIndex = 4;
            this.joypadB.TabStop = false;
            this.joypadB.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-15, -15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // joypad
            // 
            this.joypad.Image = global::OriWotW.Properties.Resources.controller;
            this.joypad.Location = new System.Drawing.Point(0, 0);
            this.joypad.Name = "joypad";
            this.joypad.Size = new System.Drawing.Size(2048, 2048);
            this.joypad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.joypad.TabIndex = 7;
            this.joypad.TabStop = false;
            this.joypad.Paint += new System.Windows.Forms.PaintEventHandler(this.joypad_Paint);
            // 
            // ControllerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.joypadB);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.joypadA);
            this.Controls.Add(this.joypad);
            this.Name = "ControllerUI";
            this.Size = new System.Drawing.Size(2048, 2048);
            ((System.ComponentModel.ISupportInitialize)(this.joypadA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joypadB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joypad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox joypadA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox joypadB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox joypad;
    }
}
