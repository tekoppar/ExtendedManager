using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace OriWotW.UI {
    public partial class PlaybackInputDesigner {
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
            this.keyListContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelStartFrame = new System.Windows.Forms.Label();
            this.startFrame = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelLength = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelWaitAfter = new System.Windows.Forms.Label();
            this.waitAfter = new System.Windows.Forms.TextBox();
            this.removeInput = new System.Windows.Forms.Button();
            this.inputSelector1 = new OriWotW.UI.InputDropdown();
            this.keyListContainer.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyListContainer
            // 
            this.keyListContainer.AutoSize = true;
            this.keyListContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.keyListContainer.Controls.Add(this.inputSelector1);
            this.keyListContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.keyListContainer.Location = new System.Drawing.Point(3, 3);
            this.keyListContainer.Name = "keyListContainer";
            this.keyListContainer.Size = new System.Drawing.Size(121, 21);
            this.keyListContainer.TabIndex = 2;
            this.keyListContainer.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.keyListContainer);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel2.Controls.Add(this.removeInput);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(619, 36);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.labelStartFrame);
            this.flowLayoutPanel1.Controls.Add(this.startFrame);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(130, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(133, 26);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // labelStartFrame
            // 
            this.labelStartFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartFrame.Location = new System.Drawing.Point(3, 6);
            this.labelStartFrame.Name = "labelStartFrame";
            this.labelStartFrame.Size = new System.Drawing.Size(71, 13);
            this.labelStartFrame.TabIndex = 0;
            this.labelStartFrame.Text = "Start Frame:";
            // 
            // startFrame
            // 
            this.startFrame.Location = new System.Drawing.Point(80, 3);
            this.startFrame.Name = "startFrame";
            this.startFrame.Size = new System.Drawing.Size(50, 20);
            this.startFrame.TabIndex = 1;
            this.startFrame.Enter += new System.EventHandler(this._Enter);
            this.startFrame.Leave += new System.EventHandler(this._Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.labelLength);
            this.flowLayoutPanel3.Controls.Add(this.length);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(269, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(111, 26);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // labelLength
            // 
            this.labelLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLength.Location = new System.Drawing.Point(3, 6);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(49, 13);
            this.labelLength.TabIndex = 0;
            this.labelLength.Text = "Length:";
            // 
            // length
            // 
            this.length.Location = new System.Drawing.Point(58, 3);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(50, 20);
            this.length.TabIndex = 1;
            this.length.Enter += new System.EventHandler(this._Enter);
            this.length.Leave += new System.EventHandler(this._Leave);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.labelWaitAfter);
            this.flowLayoutPanel4.Controls.Add(this.waitAfter);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(386, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(122, 26);
            this.flowLayoutPanel4.TabIndex = 5;
            // 
            // labelWaitAfter
            // 
            this.labelWaitAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWaitAfter.Location = new System.Drawing.Point(3, 6);
            this.labelWaitAfter.Name = "labelWaitAfter";
            this.labelWaitAfter.Size = new System.Drawing.Size(60, 13);
            this.labelWaitAfter.TabIndex = 0;
            this.labelWaitAfter.Text = "Wait After:";
            // 
            // waitAfter
            // 
            this.waitAfter.Location = new System.Drawing.Point(69, 3);
            this.waitAfter.Name = "waitAfter";
            this.waitAfter.Size = new System.Drawing.Size(50, 20);
            this.waitAfter.TabIndex = 1;
            this.waitAfter.Enter += new System.EventHandler(this._Enter);
            this.waitAfter.Leave += new System.EventHandler(this._Leave);
            // 
            // removeInput
            // 
            this.removeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeInput.AutoSize = true;
            this.removeInput.Location = new System.Drawing.Point(514, 4);
            this.removeInput.Name = "removeInput";
            this.removeInput.Size = new System.Drawing.Size(98, 23);
            this.removeInput.TabIndex = 4;
            this.removeInput.Text = "Remove Input";
            this.removeInput.UseVisualStyleBackColor = true;
            this.removeInput.Click += new System.EventHandler(this.removeInput_Click);
            // 
            // inputSelector1
            // 
            this.inputSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSelector1.AutoSize = true;
            this.inputSelector1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputSelector1.Location = new System.Drawing.Point(0, 0);
            this.inputSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.inputSelector1.Name = "inputSelector1";
            this.inputSelector1.Size = new System.Drawing.Size(121, 21);
            this.inputSelector1.TabIndex = 0;
            this.inputSelector1.Enter += new System.EventHandler(this._Enter);
            this.inputSelector1.Leave += new System.EventHandler(this._Leave);
            // 
            // PlaybackInputDesigner
            // 
            this.AccessibleName = "Input Designer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "PlaybackInputDesigner";
            this.Size = new System.Drawing.Size(625, 42);
            this.keyListContainer.ResumeLayout(false);
            this.keyListContainer.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputDropdown inputSelector1;
        private System.Windows.Forms.FlowLayoutPanel keyListContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelStartFrame;
        private System.Windows.Forms.TextBox startFrame;
        private Button removeInput;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label labelLength;
        private TextBox length;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label labelWaitAfter;
        private TextBox waitAfter;
    }
}
