namespace OriWotW.UI {
    partial class InputEditor {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addInput = new System.Windows.Forms.Button();
            this.confirmChanges = new System.Windows.Forms.Button();
            this.cancelChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 5);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addInput
            // 
            this.addInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addInput.Location = new System.Drawing.Point(12, 41);
            this.addInput.Name = "addInput";
            this.addInput.Size = new System.Drawing.Size(97, 23);
            this.addInput.TabIndex = 0;
            this.addInput.Text = "Add Input Row";
            this.addInput.UseVisualStyleBackColor = true;
            this.addInput.Click += new System.EventHandler(this.addInput_Click);
            // 
            // confirmChanges
            // 
            this.confirmChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmChanges.Location = new System.Drawing.Point(416, 41);
            this.confirmChanges.Name = "confirmChanges";
            this.confirmChanges.Size = new System.Drawing.Size(75, 23);
            this.confirmChanges.TabIndex = 1;
            this.confirmChanges.Text = "Save";
            this.confirmChanges.UseVisualStyleBackColor = true;
            this.confirmChanges.Click += new System.EventHandler(this.confirmChanges_Click);
            // 
            // cancelChanges
            // 
            this.cancelChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelChanges.Location = new System.Drawing.Point(497, 41);
            this.cancelChanges.Name = "cancelChanges";
            this.cancelChanges.Size = new System.Drawing.Size(75, 23);
            this.cancelChanges.TabIndex = 2;
            this.cancelChanges.Text = "Cancel";
            this.cancelChanges.UseVisualStyleBackColor = true;
            this.cancelChanges.Click += new System.EventHandler(this.cancelChanges_Click);
            // 
            // InputEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 76);
            this.Controls.Add(this.addInput);
            this.Controls.Add(this.confirmChanges);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelChanges);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.Name = "InputEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addInput;
        private System.Windows.Forms.Button confirmChanges;
        private System.Windows.Forms.Button cancelChanges;
    }
}
