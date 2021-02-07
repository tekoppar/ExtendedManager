
namespace OriWotW.UI.Editor {
    partial class SceneCreator {
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSceneName = new System.Windows.Forms.Label();
            this.tbxSceneName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblScenePosition = new System.Windows.Forms.Label();
            this.ScenePosition = new Tem.TemUI.Vector3Control();
            this.lblSceneSize = new System.Windows.Forms.Label();
            this.SceneSize = new Tem.TemUI.Vector2Control();
            this.SceneLoadingRect = new Tem.TemUI.Vector4Control();
            this.lblLoadingRect = new System.Windows.Forms.Label();
            this.btnCreateScene = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(623, 122);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.lblSceneName);
            this.flowLayoutPanel2.Controls.Add(this.tbxSceneName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(524, 26);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lblSceneName
            // 
            this.lblSceneName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSceneName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSceneName.Location = new System.Drawing.Point(6, 5);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(101, 16);
            this.lblSceneName.TabIndex = 0;
            this.lblSceneName.Text = "Scene Name:";
            // 
            // tbxSceneName
            // 
            this.tbxSceneName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSceneName.Location = new System.Drawing.Point(110, 3);
            this.tbxSceneName.Margin = new System.Windows.Forms.Padding(0);
            this.tbxSceneName.Name = "tbxSceneName";
            this.tbxSceneName.Size = new System.Drawing.Size(411, 20);
            this.tbxSceneName.TabIndex = 1;
            this.tbxSceneName.Enter += new System.EventHandler(this.input_Enter);
            this.tbxSceneName.Leave += new System.EventHandler(this.input_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.lblScenePosition);
            this.flowLayoutPanel3.Controls.Add(this.ScenePosition);
            this.flowLayoutPanel3.Controls.Add(this.lblSceneSize);
            this.flowLayoutPanel3.Controls.Add(this.SceneSize);
            this.flowLayoutPanel3.Controls.Add(this.lblLoadingRect);
            this.flowLayoutPanel3.Controls.Add(this.SceneLoadingRect);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(617, 84);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // lblScenePosition
            // 
            this.lblScenePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScenePosition.Location = new System.Drawing.Point(3, 9);
            this.lblScenePosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblScenePosition.MinimumSize = new System.Drawing.Size(125, 14);
            this.lblScenePosition.Name = "lblScenePosition";
            this.lblScenePosition.Size = new System.Drawing.Size(125, 14);
            this.lblScenePosition.TabIndex = 1;
            this.lblScenePosition.Text = "Scene Position:";
            // 
            // ScenePosition
            // 
            this.ScenePosition.AutoSize = true;
            this.ScenePosition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ScenePosition.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.SetFlowBreak(this.ScenePosition, true);
            this.ScenePosition.Location = new System.Drawing.Point(128, 3);
            this.ScenePosition.Margin = new System.Windows.Forms.Padding(0);
            this.ScenePosition.Name = "ScenePosition";
            this.ScenePosition.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ScenePosition.Size = new System.Drawing.Size(363, 26);
            this.ScenePosition.TabIndex = 0;
            this.ScenePosition.Enter += new System.EventHandler(this.input_Enter);
            this.ScenePosition.Leave += new System.EventHandler(this.input_Leave);
            // 
            // lblSceneSize
            // 
            this.lblSceneSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSceneSize.Location = new System.Drawing.Point(3, 35);
            this.lblSceneSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSceneSize.Name = "lblSceneSize";
            this.lblSceneSize.Size = new System.Drawing.Size(125, 14);
            this.lblSceneSize.TabIndex = 2;
            this.lblSceneSize.Text = "Scene Size:";
            // 
            // SceneSize
            // 
            this.SceneSize.AutoSize = true;
            this.SceneSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SceneSize.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.SetFlowBreak(this.SceneSize, true);
            this.SceneSize.Location = new System.Drawing.Point(128, 29);
            this.SceneSize.Margin = new System.Windows.Forms.Padding(0);
            this.SceneSize.Name = "SceneSize";
            this.SceneSize.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.SceneSize.Size = new System.Drawing.Size(240, 26);
            this.SceneSize.TabIndex = 3;
            this.SceneSize.Enter += new System.EventHandler(this.input_Enter);
            this.SceneSize.Leave += new System.EventHandler(this.input_Leave);
            // 
            // SceneLoadingRect
            // 
            this.SceneLoadingRect.AutoSize = true;
            this.SceneLoadingRect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SceneLoadingRect.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.SetFlowBreak(this.SceneLoadingRect, true);
            this.SceneLoadingRect.Location = new System.Drawing.Point(128, 55);
            this.SceneLoadingRect.Margin = new System.Windows.Forms.Padding(0);
            this.SceneLoadingRect.Name = "SceneLoadingRect";
            this.SceneLoadingRect.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.SceneLoadingRect.Size = new System.Drawing.Size(486, 26);
            this.SceneLoadingRect.TabIndex = 5;
            this.SceneLoadingRect.Enter += new System.EventHandler(this.input_Enter);
            this.SceneLoadingRect.Leave += new System.EventHandler(this.input_Leave);
            // 
            // lblLoadingRect
            // 
            this.lblLoadingRect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoadingRect.Location = new System.Drawing.Point(3, 61);
            this.lblLoadingRect.Margin = new System.Windows.Forms.Padding(0);
            this.lblLoadingRect.Name = "lblLoadingRect";
            this.lblLoadingRect.Size = new System.Drawing.Size(125, 14);
            this.lblLoadingRect.TabIndex = 6;
            this.lblLoadingRect.Text = "Loading Rect:";
            // 
            // btnCreateScene
            // 
            this.btnCreateScene.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreateScene.Location = new System.Drawing.Point(3, 3);
            this.btnCreateScene.Name = "btnCreateScene";
            this.btnCreateScene.Size = new System.Drawing.Size(90, 23);
            this.btnCreateScene.TabIndex = 1;
            this.btnCreateScene.Text = "Create Scene";
            this.btnCreateScene.UseVisualStyleBackColor = true;
            this.btnCreateScene.Click += new System.EventHandler(this.btnCreateScene_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(99, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.btnCreateScene);
            this.flowLayoutPanel4.Controls.Add(this.btnCancel);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(445, 140);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(192, 29);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // SceneCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(649, 181);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimumSize = new System.Drawing.Size(665, 0);
            this.Name = "SceneCreator";
            this.Text = "SceneCreator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.TextBox tbxSceneName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Tem.TemUI.Vector3Control ScenePosition;
        private System.Windows.Forms.Label lblScenePosition;
        private System.Windows.Forms.Label lblSceneSize;
        private Tem.TemUI.Vector2Control SceneSize;
        private System.Windows.Forms.Label lblLoadingRect;
        private Tem.TemUI.Vector4Control SceneLoadingRect;
        private System.Windows.Forms.Button btnCreateScene;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    }
}