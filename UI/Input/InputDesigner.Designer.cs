using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace OriWotW.UI {
    public partial class InputDesigner {
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
            this.keyList = new System.Windows.Forms.FlowLayoutPanel();
            this.keyListContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTiming = new System.Windows.Forms.Label();
            this.timings = new System.Windows.Forms.TextBox();
            this.removeInput = new System.Windows.Forms.Button();
            this.inputSelector1 = new OriWotW.UI.InputSelector();
            this.keyListContainer.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyList
            // 
            this.keyList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyList.AutoSize = true;
            this.keyList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.keyList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.keyList.Location = new System.Drawing.Point(3, 3);
            this.keyList.MinimumSize = new System.Drawing.Size(200, 25);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(200, 25);
            this.keyList.TabIndex = 1;
            // 
            // keyListContainer
            // 
            this.keyListContainer.AutoSize = true;
            this.keyListContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.keyListContainer.Controls.Add(this.keyList);
            this.keyListContainer.Controls.Add(this.inputSelector1);
            this.keyListContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.keyListContainer.Location = new System.Drawing.Point(3, 3);
            this.keyListContainer.Name = "keyListContainer";
            this.keyListContainer.Size = new System.Drawing.Size(206, 54);
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
            this.flowLayoutPanel2.Controls.Add(this.removeInput);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(539, 64);
            this.flowLayoutPanel2.TabIndex = 3;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.labelTiming);
            this.flowLayoutPanel1.Controls.Add(this.timings);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(215, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(213, 39);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // labelTiming
            // 
            this.labelTiming.AutoSize = true;
            this.labelTiming.Location = new System.Drawing.Point(3, 0);
            this.labelTiming.Name = "labelTiming";
            this.labelTiming.Size = new System.Drawing.Size(43, 13);
            this.labelTiming.TabIndex = 0;
            this.labelTiming.Text = "Timings";
            // 
            // timings
            // 
            this.timings.Location = new System.Drawing.Point(3, 16);
            this.timings.Name = "timings";
            this.timings.Size = new System.Drawing.Size(210, 20);
            this.timings.TabIndex = 1;
            // 
            // removeInput
            // 
            this.removeInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeInput.AutoSize = true;
            this.removeInput.Location = new System.Drawing.Point(434, 3);
            this.removeInput.Name = "removeInput";
            this.removeInput.Size = new System.Drawing.Size(98, 23);
            this.removeInput.TabIndex = 4;
            this.removeInput.Text = "Remove Input";
            this.removeInput.UseVisualStyleBackColor = true;
            this.removeInput.Click += new System.EventHandler(this.removeInput_Click);
            // 
            // inputSelector1
            // 
            this.inputSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSelector1.AutoSize = true;
            this.inputSelector1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputSelector1.Location = new System.Drawing.Point(0, 31);
            this.inputSelector1.Margin = new System.Windows.Forms.Padding(0);
            this.inputSelector1.Name = "inputSelector1";
            this.inputSelector1.Size = new System.Drawing.Size(206, 23);
            this.inputSelector1.TabIndex = 0;
            // 
            // InputDesigner
            // 
            this.AccessibleName = "Input Designer";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "InputDesigner";
            this.Size = new System.Drawing.Size(545, 70);
            this.keyListContainer.ResumeLayout(false);
            this.keyListContainer.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputSelector inputSelector1;
        private System.Windows.Forms.FlowLayoutPanel keyList;
        private System.Windows.Forms.FlowLayoutPanel keyListContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelTiming;
        private System.Windows.Forms.TextBox timings;
        private Button removeInput;
    }
}
