
namespace OriWotW.UI.VisualEditor {
    partial class Vector4Control {
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
            this.label1 = new System.Windows.Forms.Label();
            this.valueX = new System.Windows.Forms.NumericUpDown();
            this.valueY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.valueZ = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.valueA = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueA)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // valueX
            // 
            this.valueX.DecimalPlaces = 5;
            this.valueX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.valueX.Location = new System.Drawing.Point(29, 6);
            this.valueX.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.valueX.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.valueX.Name = "valueX";
            this.valueX.Size = new System.Drawing.Size(120, 20);
            this.valueX.TabIndex = 1;
            this.valueX.ValueChanged += new System.EventHandler(this.value_ValueChanged);
            // 
            // valueY
            // 
            this.valueY.DecimalPlaces = 5;
            this.valueY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.valueY.Location = new System.Drawing.Point(178, 6);
            this.valueY.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.valueY.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.valueY.Name = "valueY";
            this.valueY.Size = new System.Drawing.Size(120, 20);
            this.valueY.TabIndex = 3;
            this.valueY.ValueChanged += new System.EventHandler(this.value_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(155, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // valueZ
            // 
            this.valueZ.DecimalPlaces = 5;
            this.valueZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.valueZ.Location = new System.Drawing.Point(327, 6);
            this.valueZ.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.valueZ.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.valueZ.Name = "valueZ";
            this.valueZ.Size = new System.Drawing.Size(120, 20);
            this.valueZ.TabIndex = 5;
            this.valueZ.ValueChanged += new System.EventHandler(this.value_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(304, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Z:";
            // 
            // valueA
            // 
            this.valueA.DecimalPlaces = 5;
            this.valueA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.valueA.Location = new System.Drawing.Point(476, 6);
            this.valueA.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.valueA.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.valueA.Name = "valueA";
            this.valueA.Size = new System.Drawing.Size(120, 20);
            this.valueA.TabIndex = 7;
            this.valueA.ValueChanged += new System.EventHandler(this.value_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(453, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "A:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.valueX);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.valueY);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.valueZ);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.valueA);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(602, 32);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // Vector4Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Vector4Control";
            this.Size = new System.Drawing.Size(608, 38);
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueA)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown valueX;
        private System.Windows.Forms.NumericUpDown valueY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown valueZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown valueA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
