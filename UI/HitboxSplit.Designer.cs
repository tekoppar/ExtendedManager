using Communication.Inject;

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
            InjectCommunication._Instance.AddCall("CALL23");
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitboxSplit));
            this.setStart = new System.Windows.Forms.Button();
            this.hitboxSplitCopy = new System.Windows.Forms.TextBox();
            this.hitboxSplitValues = new Tem.TemUI.Vector4Control();
            this.SuspendLayout();
            // 
            // setStart
            // 
            this.setStart.Location = new System.Drawing.Point(503, 7);
            this.setStart.Name = "setStart";
            this.setStart.Size = new System.Drawing.Size(102, 23);
            this.setStart.TabIndex = 2;
            this.setStart.Text = "Set Position";
            this.setStart.UseVisualStyleBackColor = true;
            this.setStart.Click += new System.EventHandler(this.setStart_Click);
            // 
            // hitboxSplitCopy
            // 
            this.hitboxSplitCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hitboxSplitCopy.Location = new System.Drawing.Point(12, 43);
            this.hitboxSplitCopy.Name = "hitboxSplitCopy";
            this.hitboxSplitCopy.ReadOnly = true;
            this.hitboxSplitCopy.Size = new System.Drawing.Size(594, 20);
            this.hitboxSplitCopy.TabIndex = 10;
            this.hitboxSplitCopy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.hitboxSplitCopy.Enter += new System.EventHandler(this.input_Enter);
            this.hitboxSplitCopy.Leave += new System.EventHandler(this.input_Leave);
            // 
            // hitboxSplitValues
            // 
            this.hitboxSplitValues.AutoSize = true;
            this.hitboxSplitValues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hitboxSplitValues.BackColor = System.Drawing.Color.Transparent;
            this.hitboxSplitValues.Location = new System.Drawing.Point(12, 9);
            this.hitboxSplitValues.Margin = new System.Windows.Forms.Padding(0);
            this.hitboxSplitValues.Name = "hitboxSplitValues";
            this.hitboxSplitValues.Size = new System.Drawing.Size(486, 20);
            this.hitboxSplitValues.TabIndex = 11;
            this.hitboxSplitValues.OnValueChangedNoArgs += new System.EventHandler(this.hitboxSplitValues_OnValueChangedNoArgs);
            this.hitboxSplitValues.Enter += new System.EventHandler(this.input_Enter);
            this.hitboxSplitValues.Leave += new System.EventHandler(this.input_Leave);
            // 
            // HitboxSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(618, 70);
            this.Controls.Add(this.hitboxSplitValues);
            this.Controls.Add(this.hitboxSplitCopy);
            this.Controls.Add(this.setStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HitboxSplit";
            this.Text = "HitboxSplit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button setStart;
        private System.Windows.Forms.TextBox hitboxSplitCopy;
        private Tem.TemUI.Vector4Control hitboxSplitValues;
    }
}