namespace OriWotW.UI {
    partial class UberstateEditor {
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
            this.uberStateList = new System.Windows.Forms.FlowLayoutPanel();
            this.newUberEditor = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.storeUberstates = new System.Windows.Forms.Button();
            this.compareUberstates = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uberStateList
            // 
            this.uberStateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uberStateList.AutoSize = true;
            this.uberStateList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uberStateList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uberStateList.Location = new System.Drawing.Point(12, 12);
            this.uberStateList.MaximumSize = new System.Drawing.Size(0, 700);
            this.uberStateList.MinimumSize = new System.Drawing.Size(720, 70);
            this.uberStateList.Name = "uberStateList";
            this.uberStateList.Size = new System.Drawing.Size(720, 70);
            this.uberStateList.TabIndex = 0;
            this.uberStateList.WrapContents = false;
            // 
            // newUberEditor
            // 
            this.newUberEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newUberEditor.Location = new System.Drawing.Point(12, 97);
            this.newUberEditor.Name = "newUberEditor";
            this.newUberEditor.Size = new System.Drawing.Size(91, 23);
            this.newUberEditor.TabIndex = 0;
            this.newUberEditor.Text = "Add Uberstate";
            this.newUberEditor.UseVisualStyleBackColor = true;
            this.newUberEditor.Click += new System.EventHandler(this.newUberEditor_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(3, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Location = new System.Drawing.Point(84, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.save);
            this.flowLayoutPanel2.Controls.Add(this.cancel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(563, 91);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(162, 29);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // storeUberstates
            // 
            this.storeUberstates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.storeUberstates.Location = new System.Drawing.Point(110, 96);
            this.storeUberstates.Name = "storeUberstates";
            this.storeUberstates.Size = new System.Drawing.Size(102, 23);
            this.storeUberstates.TabIndex = 4;
            this.storeUberstates.Text = "Store Uberstates";
            this.storeUberstates.UseVisualStyleBackColor = true;
            this.storeUberstates.Click += new System.EventHandler(this.storeUberstates_Click);
            // 
            // compareUberstates
            // 
            this.compareUberstates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.compareUberstates.Location = new System.Drawing.Point(218, 97);
            this.compareUberstates.Name = "compareUberstates";
            this.compareUberstates.Size = new System.Drawing.Size(115, 23);
            this.compareUberstates.TabIndex = 5;
            this.compareUberstates.Text = "Compare Uberstates";
            this.compareUberstates.UseVisualStyleBackColor = true;
            this.compareUberstates.Click += new System.EventHandler(this.compareUberstates_Click);
            // 
            // UberstateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(737, 132);
            this.Controls.Add(this.compareUberstates);
            this.Controls.Add(this.storeUberstates);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.newUberEditor);
            this.Controls.Add(this.uberStateList);
            this.Name = "UberstateEditor";
            this.Text = "UberstateEditor";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uberStateList;
        private System.Windows.Forms.Button newUberEditor;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button storeUberstates;
        private System.Windows.Forms.Button compareUberstates;
    }
}