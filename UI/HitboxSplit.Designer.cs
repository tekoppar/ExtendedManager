namespace OriWotW.UI {
    partial class HitboxSplit {
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
            Manager.InjectCommunication.AddCall("CALL23");
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitboxSplit));
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.startXlbl = new System.Windows.Forms.Label();
            this.startX = new System.Windows.Forms.NumericUpDown();
            this.startYlbl = new System.Windows.Forms.Label();
            this.startY = new System.Windows.Forms.NumericUpDown();
            this.setStart = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scaleX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleY = new System.Windows.Forms.NumericUpDown();
            this.hitboxSplitCopy = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startY)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.AutoSize = true;
            this.flowLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel8.Controls.Add(this.label4);
            this.flowLayoutPanel8.Controls.Add(this.startXlbl);
            this.flowLayoutPanel8.Controls.Add(this.startX);
            this.flowLayoutPanel8.Controls.Add(this.startYlbl);
            this.flowLayoutPanel8.Controls.Add(this.startY);
            this.flowLayoutPanel8.Controls.Add(this.setStart);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(472, 29);
            this.flowLayoutPanel8.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Position";
            // 
            // startXlbl
            // 
            this.startXlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXlbl.AutoSize = true;
            this.startXlbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startXlbl.Location = new System.Drawing.Point(69, 8);
            this.startXlbl.Name = "startXlbl";
            this.startXlbl.Size = new System.Drawing.Size(17, 13);
            this.startXlbl.TabIndex = 3;
            this.startXlbl.Text = "X:";
            // 
            // startX
            // 
            this.startX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startX.DecimalPlaces = 5;
            this.startX.Location = new System.Drawing.Point(92, 4);
            this.startX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.startX.Name = "startX";
            this.startX.Size = new System.Drawing.Size(120, 20);
            this.startX.TabIndex = 4;
            this.startX.ValueChanged += new System.EventHandler(this.start_ValueChanged);
            this.startX.Enter += new System.EventHandler(this.input_Enter);
            this.startX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // startYlbl
            // 
            this.startYlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYlbl.AutoSize = true;
            this.startYlbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startYlbl.Location = new System.Drawing.Point(218, 8);
            this.startYlbl.Name = "startYlbl";
            this.startYlbl.Size = new System.Drawing.Size(17, 13);
            this.startYlbl.TabIndex = 5;
            this.startYlbl.Text = "Y:";
            // 
            // startY
            // 
            this.startY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startY.DecimalPlaces = 5;
            this.startY.Location = new System.Drawing.Point(241, 4);
            this.startY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.startY.Name = "startY";
            this.startY.Size = new System.Drawing.Size(120, 20);
            this.startY.TabIndex = 6;
            this.startY.ValueChanged += new System.EventHandler(this.start_ValueChanged);
            this.startY.Enter += new System.EventHandler(this.input_Enter);
            this.startY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // setStart
            // 
            this.setStart.Location = new System.Drawing.Point(367, 3);
            this.setStart.Name = "setStart";
            this.setStart.Size = new System.Drawing.Size(102, 23);
            this.setStart.TabIndex = 2;
            this.setStart.Text = "Set Position";
            this.setStart.UseVisualStyleBackColor = true;
            this.setStart.Click += new System.EventHandler(this.setStart_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.scaleX);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.scaleY);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(364, 26);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Size";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(69, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X:";
            // 
            // scaleX
            // 
            this.scaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleX.DecimalPlaces = 5;
            this.scaleX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.scaleX.Location = new System.Drawing.Point(92, 3);
            this.scaleX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.scaleX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(120, 20);
            this.scaleX.TabIndex = 4;
            this.scaleX.ValueChanged += new System.EventHandler(this.scale_ValueChanged);
            this.scaleX.Enter += new System.EventHandler(this.input_Enter);
            this.scaleX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(218, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y:";
            // 
            // scaleY
            // 
            this.scaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleY.DecimalPlaces = 5;
            this.scaleY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.scaleY.Location = new System.Drawing.Point(241, 3);
            this.scaleY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.scaleY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(120, 20);
            this.scaleY.TabIndex = 6;
            this.scaleY.ValueChanged += new System.EventHandler(this.scale_ValueChanged);
            this.scaleY.Enter += new System.EventHandler(this.input_Enter);
            this.scaleY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // hitboxSplitCopy
            // 
            this.hitboxSplitCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hitboxSplitCopy.Location = new System.Drawing.Point(12, 90);
            this.hitboxSplitCopy.Name = "hitboxSplitCopy";
            this.hitboxSplitCopy.ReadOnly = true;
            this.hitboxSplitCopy.Size = new System.Drawing.Size(467, 20);
            this.hitboxSplitCopy.TabIndex = 10;
            this.hitboxSplitCopy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.hitboxSplitCopy.Enter += new System.EventHandler(this.input_Enter);
            this.hitboxSplitCopy.Leave += new System.EventHandler(this.input_Leave);
            // 
            // HitboxSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(488, 115);
            this.Controls.Add(this.hitboxSplitCopy);
            this.Controls.Add(this.flowLayoutPanel8);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HitboxSplit";
            this.Text = "HitboxSplit";
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startY)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label startXlbl;
        private System.Windows.Forms.NumericUpDown startX;
        private System.Windows.Forms.Label startYlbl;
        private System.Windows.Forms.NumericUpDown startY;
        private System.Windows.Forms.Button setStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown scaleX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown scaleY;
        private System.Windows.Forms.TextBox hitboxSplitCopy;
    }
}