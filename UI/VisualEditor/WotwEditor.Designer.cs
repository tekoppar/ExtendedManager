using OriWotW.UI.VisualEditor;
namespace OriWotW.UI {
    partial class WotwEditor {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.matSortingOrder = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.moonZOffset = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.matRenderQueue = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.layerMaskValue = new System.Windows.Forms.NumericUpDown();
            this.rotation = new OriWotW.UI.VisualEditor.Vector4Control();
            this.scale = new OriWotW.UI.VisualEditor.Vector4Control();
            this.localPosition = new OriWotW.UI.VisualEditor.Vector4Control();
            this.position = new OriWotW.UI.VisualEditor.Vector4Control();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matSortingOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonZOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matRenderQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position Local:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(38, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Position:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(41, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Scale:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(31, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 40);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rotation:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Material Sorting Order:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.matSortingOrder);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.moonZOffset);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.matRenderQueue);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.layerMaskValue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 196);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(536, 60);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // matSortingOrder
            // 
            this.matSortingOrder.Location = new System.Drawing.Point(128, 3);
            this.matSortingOrder.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.matSortingOrder.Minimum = new decimal(new int[] {
            30000,
            0,
            0,
            -2147483648});
            this.matSortingOrder.Name = "matSortingOrder";
            this.matSortingOrder.Size = new System.Drawing.Size(120, 20);
            this.matSortingOrder.TabIndex = 10;
            this.matSortingOrder.Enter += new System.EventHandler(this.input_Enter);
            this.matSortingOrder.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(254, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Renderer Moon Z -Offset:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moonZOffset
            // 
            this.moonZOffset.DecimalPlaces = 5;
            this.moonZOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moonZOffset.Location = new System.Drawing.Point(396, 3);
            this.moonZOffset.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.moonZOffset.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.moonZOffset.Name = "moonZOffset";
            this.moonZOffset.Size = new System.Drawing.Size(120, 20);
            this.moonZOffset.TabIndex = 12;
            this.moonZOffset.Enter += new System.EventHandler(this.input_Enter);
            this.moonZOffset.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(3, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Material Render Queue:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // matRenderQueue
            // 
            this.matRenderQueue.Location = new System.Drawing.Point(138, 29);
            this.matRenderQueue.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.matRenderQueue.Minimum = new decimal(new int[] {
            30000,
            0,
            0,
            -2147483648});
            this.matRenderQueue.Name = "matRenderQueue";
            this.matRenderQueue.Size = new System.Drawing.Size(120, 20);
            this.matRenderQueue.TabIndex = 14;
            this.matRenderQueue.Enter += new System.EventHandler(this.input_Enter);
            this.matRenderQueue.Leave += new System.EventHandler(this.input_Leave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(603, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "Apply Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(264, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rendering Layer Mask:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layerMaskValue
            // 
            this.layerMaskValue.Location = new System.Drawing.Point(399, 29);
            this.layerMaskValue.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.layerMaskValue.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.layerMaskValue.Name = "layerMaskValue";
            this.layerMaskValue.Size = new System.Drawing.Size(120, 20);
            this.layerMaskValue.TabIndex = 16;
            this.layerMaskValue.Enter += new System.EventHandler(this.input_Enter);
            this.layerMaskValue.Leave += new System.EventHandler(this.input_Leave);
            // 
            // rotation
            // 
            this.rotation.AutoSize = true;
            this.rotation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rotation.BackColor = System.Drawing.Color.Transparent;
            this.rotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotation.Location = new System.Drawing.Point(91, 150);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(610, 40);
            this.rotation.TabIndex = 7;
            this.rotation.Enter += new System.EventHandler(this.input_Enter);
            this.rotation.Leave += new System.EventHandler(this.input_Leave);
            // 
            // scale
            // 
            this.scale.AutoSize = true;
            this.scale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scale.BackColor = System.Drawing.Color.Transparent;
            this.scale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scale.Location = new System.Drawing.Point(91, 104);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(610, 40);
            this.scale.TabIndex = 5;
            this.scale.Enter += new System.EventHandler(this.input_Enter);
            this.scale.Leave += new System.EventHandler(this.input_Leave);
            // 
            // localPosition
            // 
            this.localPosition.AutoSize = true;
            this.localPosition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.localPosition.BackColor = System.Drawing.Color.Transparent;
            this.localPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localPosition.Location = new System.Drawing.Point(91, 58);
            this.localPosition.Name = "localPosition";
            this.localPosition.Size = new System.Drawing.Size(610, 40);
            this.localPosition.TabIndex = 1;
            this.localPosition.Enter += new System.EventHandler(this.input_Enter);
            this.localPosition.Leave += new System.EventHandler(this.input_Leave);
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.position.BackColor = System.Drawing.Color.Transparent;
            this.position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.position.Location = new System.Drawing.Point(91, 12);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(610, 40);
            this.position.TabIndex = 0;
            this.position.Enter += new System.EventHandler(this.input_Enter);
            this.position.Leave += new System.EventHandler(this.input_Leave);
            // 
            // WotwEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(712, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localPosition);
            this.Controls.Add(this.position);
            this.Name = "WotwEditor";
            this.Text = "WotwEditor";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matSortingOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonZOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matRenderQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layerMaskValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Vector4Control position;
        public Vector4Control localPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public Vector4Control scale;
        private System.Windows.Forms.Label label4;
        public Vector4Control rotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.NumericUpDown matSortingOrder;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown moonZOffset;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown matRenderQueue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.NumericUpDown layerMaskValue;
    }
}