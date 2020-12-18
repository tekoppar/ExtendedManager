namespace OriWotW.UI {
    partial class BackupsaveUI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupsaveUI));
            this.butRefresh = new System.Windows.Forms.Button();
            this.backupsavesList = new System.Windows.Forms.FlowLayoutPanel();
            this.butCreateBackupsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butRefresh
            // 
            this.butRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefresh.Location = new System.Drawing.Point(503, 373);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(87, 24);
            this.butRefresh.TabIndex = 1;
            this.butRefresh.Text = "Refresh Saves";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // backupsavesList
            // 
            this.backupsavesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backupsavesList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backupsavesList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.backupsavesList.Location = new System.Drawing.Point(12, 12);
            this.backupsavesList.Name = "backupsavesList";
            this.backupsavesList.Size = new System.Drawing.Size(576, 356);
            this.backupsavesList.TabIndex = 2;
            this.backupsavesList.WrapContents = false;
            // 
            // butCreateBackupsave
            // 
            this.butCreateBackupsave.Location = new System.Drawing.Point(361, 373);
            this.butCreateBackupsave.Name = "butCreateBackupsave";
            this.butCreateBackupsave.Size = new System.Drawing.Size(136, 23);
            this.butCreateBackupsave.TabIndex = 3;
            this.butCreateBackupsave.Text = "Create New Backupsave";
            this.butCreateBackupsave.UseVisualStyleBackColor = true;
            this.butCreateBackupsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // BackupsaveUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(602, 409);
            this.Controls.Add(this.butCreateBackupsave);
            this.Controls.Add(this.backupsavesList);
            this.Controls.Add(this.butRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupsaveUI";
            this.Text = "BackupsaveUI";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.FlowLayoutPanel backupsavesList;
        private System.Windows.Forms.Button butCreateBackupsave;
    }
}