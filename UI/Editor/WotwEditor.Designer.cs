using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using OriWotW;
using OriWotW.UI.Editor;
using Tem.TemUI;
using Tem.Utility;

namespace OriWotW.UI {
    partial class WotwEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private object ClickedControl = null;
        private DateTime MouseDownTime;
        private bool IsDragging = false;
        private string DraggingTreeNodeHierarchy = "";

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            Manager._Instance.rawInput.AddMessageFilter();
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            ClickedControl = null;
            IsDragging = false;
            MouseDownTime = DateTime.MinValue;
        }

        private string GetTreeNodeHierarchy(TreeNode node) {
            TreeNode parent = node;
            List<int> hierarchy = new List<int>();
            string stringHierarchy = "";

            while (parent != null) {
                if (parent.Tag != null && parent.Tag.GetType().Name == "SceneObject" && parent.Index.ToString() != "") {
                    hierarchy.Add(parent.Index);
                }
                parent = parent.Parent;
            }
            hierarchy.Reverse();
            
            for (int i = 0; i < hierarchy.Count; i++) {
                int index = hierarchy[i];
                if (i == hierarchy.Count - 1)
                    stringHierarchy += index.ToString();
                else
                    stringHierarchy += index.ToString() + ",";
            }

            return stringHierarchy;
        }

        private void OnMouseMove(object sender, MouseEventArgs e) {
            if (MouseDownTime.Millisecond > 0 && IsDragging == false && ClickedControl != null) {
                TimeSpan time = DateTime.Now - MouseDownTime;
                if (time.TotalMilliseconds > 100 && time.TotalMilliseconds < 50000) {
                    DoDragDrop((TreeNode)sender, DragDropEffects.All);
                    if (ClickedControl != null) {
                        IsDragging = true;
                    }
                }
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e) {
            TreeNode targetNode = e.Item as TreeNode;
            if (targetNode.Tag != null && targetNode.Tag.GetType().Name == "SceneObject") {
                DraggingTreeNodeHierarchy = GetTreeNodeHierarchy(targetNode);
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e) {
            Point targetPoint = sceneHierarchyTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = sceneHierarchyTree.GetNodeAt(targetPoint);
            if (targetNode != null) { 
                if (targetNode.Tag != null && targetNode.Tag.GetType().Name == "SceneObject")
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e) {
            Point targetPoint = sceneHierarchyTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = sceneHierarchyTree.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TreeNode Parent = targetNode;

            while (Parent != null) {
                if (Parent != draggedNode)
                    Parent = Parent.Parent;
                else
                    return;
            }

            string newHierarchy = GetTreeNodeHierarchy(targetNode);

            if (targetNode.Tag == null || targetNode.Tag.GetType().Name != "SceneObject")
                return;

            if (!draggedNode.Equals(targetNode) && targetNode != null) {
                draggedNode.Remove();

                if (targetNode.Nodes.ContainsKey("Children") == false) {
                    targetNode.Nodes.Add("Children", "Children");
                    targetNode.Nodes[2].Tag = "NodeChildren";
                }

                targetNode.Nodes[2].Nodes.Add(draggedNode);
                UserExpanded = false;
                targetNode.Expand();
                UserExpanded = true;
                SceneObject movingScene = draggedNode.Tag as SceneObject;

                if (movingScene.SceneIndexHierarchy.Count == 0) {
                    SceneHierarchy parentHierarchy = movingScene.ParentObject;
                    SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                }

                SceneObject movingTo = targetNode.Tag as SceneObject;

                if (movingTo.SceneIndexHierarchy.Count == 0) {
                    SceneHierarchy parentHierarchy = movingTo.ParentObject;
                    SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                }

                MoveGameObjectInHierarchy(TE.IntVectorToString(movingScene.SceneIndexHierarchy, ","), TE.IntVectorToString(movingTo.SceneIndexHierarchy, ","));
                DraggingTreeNodeHierarchy = "";
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.sceneHierarchyTree = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSelectedObject = new System.Windows.Forms.Label();
            this.cloneGameObject = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLoadWorld = new System.Windows.Forms.Button();
            this.FieldsPropertiesTree = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.fieldPropVector4Value = new Tem.TemUI.Vector4Control();
            this.fieldPropVector3Value = new Tem.TemUI.Vector3Control();
            this.fieldPropVector2Value = new Tem.TemUI.Vector2Control();
            this.fieldPropStringValue = new System.Windows.Forms.TextBox();
            this.fieldPropFloatValue = new System.Windows.Forms.NumericUpDown();
            this.fieldPropIntValue = new System.Windows.Forms.NumericUpDown();
            this.fieldPropBooleanValue = new System.Windows.Forms.CheckBox();
            this.fieldPropBoundsValue = new Tem.TemUI.BoundsControl();
            this.selectedFieldProperty = new System.Windows.Forms.Label();
            this.btnNewScene = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPropFloatValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPropIntValue)).BeginInit();
            this.SuspendLayout();
            // 
            // sceneHierarchyTree
            // 
            this.sceneHierarchyTree.AllowDrop = true;
            this.sceneHierarchyTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sceneHierarchyTree.HideSelection = false;
            this.sceneHierarchyTree.HotTracking = true;
            this.sceneHierarchyTree.Location = new System.Drawing.Point(12, 30);
            this.sceneHierarchyTree.Name = "sceneHierarchyTree";
            this.sceneHierarchyTree.Size = new System.Drawing.Size(609, 776);
            this.sceneHierarchyTree.TabIndex = 12;
            this.sceneHierarchyTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.sceneHierarchyTree_BeforeExpand);
            this.sceneHierarchyTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.sceneHierarchyTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.sceneHierarchyTree_BeforeSelect);
            this.sceneHierarchyTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.sceneHierarchyTree_AfterSelect);
            this.sceneHierarchyTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.sceneHierarchyTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.sceneHierarchyTree.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_DragOver);
            this.sceneHierarchyTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.sceneHierarchyTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "Selected Object:";
            // 
            // lblSelectedObject
            // 
            this.lblSelectedObject.AutoSize = true;
            this.lblSelectedObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedObject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSelectedObject.Location = new System.Drawing.Point(138, 9);
            this.lblSelectedObject.Name = "lblSelectedObject";
            this.lblSelectedObject.Size = new System.Drawing.Size(0, 18);
            this.lblSelectedObject.TabIndex = 14;
            // 
            // cloneGameObject
            // 
            this.cloneGameObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cloneGameObject.Location = new System.Drawing.Point(11, 812);
            this.cloneGameObject.Name = "cloneGameObject";
            this.cloneGameObject.Size = new System.Drawing.Size(109, 25);
            this.cloneGameObject.TabIndex = 15;
            this.cloneGameObject.Text = "Clone Game Object";
            this.cloneGameObject.UseVisualStyleBackColor = true;
            this.cloneGameObject.Click += new System.EventHandler(this.cloneGameObject_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1093, 814);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Save World";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLoadWorld
            // 
            this.btnLoadWorld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadWorld.Location = new System.Drawing.Point(1005, 814);
            this.btnLoadWorld.Name = "btnLoadWorld";
            this.btnLoadWorld.Size = new System.Drawing.Size(82, 23);
            this.btnLoadWorld.TabIndex = 18;
            this.btnLoadWorld.Text = "Load World";
            this.btnLoadWorld.UseVisualStyleBackColor = true;
            this.btnLoadWorld.Click += new System.EventHandler(this.btnLoadWorld_Click);
            // 
            // FieldsPropertiesTree
            // 
            this.FieldsPropertiesTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldsPropertiesTree.HideSelection = false;
            this.FieldsPropertiesTree.HotTracking = true;
            this.FieldsPropertiesTree.Location = new System.Drawing.Point(627, 89);
            this.FieldsPropertiesTree.MaximumSize = new System.Drawing.Size(800, 1200);
            this.FieldsPropertiesTree.Name = "FieldsPropertiesTree";
            this.FieldsPropertiesTree.Size = new System.Drawing.Size(546, 719);
            this.FieldsPropertiesTree.TabIndex = 19;
            this.FieldsPropertiesTree.Visible = false;
            this.FieldsPropertiesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FieldsPropertiesTree_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.fieldPropVector4Value);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropVector3Value);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropVector2Value);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropStringValue);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropFloatValue);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropIntValue);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropBooleanValue);
            this.flowLayoutPanel1.Controls.Add(this.fieldPropBoundsValue);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(627, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(548, 48);
            this.flowLayoutPanel1.TabIndex = 20;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // fieldPropVector4Value
            // 
            this.fieldPropVector4Value.AutoSize = true;
            this.fieldPropVector4Value.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fieldPropVector4Value.BackColor = System.Drawing.Color.Transparent;
            this.fieldPropVector4Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldPropVector4Value.Location = new System.Drawing.Point(0, 0);
            this.fieldPropVector4Value.Margin = new System.Windows.Forms.Padding(0);
            this.fieldPropVector4Value.MinimumSize = new System.Drawing.Size(2, 14);
            this.fieldPropVector4Value.Name = "fieldPropVector4Value";
            this.fieldPropVector4Value.Size = new System.Drawing.Size(488, 22);
            this.fieldPropVector4Value.TabIndex = 0;
            this.fieldPropVector4Value.Visible = false;
            this.fieldPropVector4Value.OnValueChangedNoArgs += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropVector4Value.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropVector4Value.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropVector3Value
            // 
            this.fieldPropVector3Value.AutoSize = true;
            this.fieldPropVector3Value.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fieldPropVector3Value.BackColor = System.Drawing.Color.Transparent;
            this.fieldPropVector3Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldPropVector3Value.Location = new System.Drawing.Point(0, 22);
            this.fieldPropVector3Value.Margin = new System.Windows.Forms.Padding(0);
            this.fieldPropVector3Value.MinimumSize = new System.Drawing.Size(2, 14);
            this.fieldPropVector3Value.Name = "fieldPropVector3Value";
            this.fieldPropVector3Value.Size = new System.Drawing.Size(365, 22);
            this.fieldPropVector3Value.TabIndex = 1;
            this.fieldPropVector3Value.Visible = false;
            this.fieldPropVector3Value.OnValueChangedNoArgs += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropVector3Value.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropVector3Value.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropVector2Value
            // 
            this.fieldPropVector2Value.AutoSize = true;
            this.fieldPropVector2Value.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fieldPropVector2Value.BackColor = System.Drawing.Color.Transparent;
            this.fieldPropVector2Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldPropVector2Value.Location = new System.Drawing.Point(0, 44);
            this.fieldPropVector2Value.Margin = new System.Windows.Forms.Padding(0);
            this.fieldPropVector2Value.MinimumSize = new System.Drawing.Size(2, 14);
            this.fieldPropVector2Value.Name = "fieldPropVector2Value";
            this.fieldPropVector2Value.Size = new System.Drawing.Size(242, 22);
            this.fieldPropVector2Value.TabIndex = 6;
            this.fieldPropVector2Value.Visible = false;
            this.fieldPropVector2Value.OnValueChangedNoArgs += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropVector2Value.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropVector2Value.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropStringValue
            // 
            this.fieldPropStringValue.Location = new System.Drawing.Point(3, 69);
            this.fieldPropStringValue.Name = "fieldPropStringValue";
            this.fieldPropStringValue.Size = new System.Drawing.Size(493, 20);
            this.fieldPropStringValue.TabIndex = 2;
            this.fieldPropStringValue.Visible = false;
            this.fieldPropStringValue.TextChanged += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropStringValue.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropStringValue.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropFloatValue
            // 
            this.fieldPropFloatValue.DecimalPlaces = 5;
            this.fieldPropFloatValue.Location = new System.Drawing.Point(3, 95);
            this.fieldPropFloatValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.fieldPropFloatValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.fieldPropFloatValue.Name = "fieldPropFloatValue";
            this.fieldPropFloatValue.Size = new System.Drawing.Size(120, 20);
            this.fieldPropFloatValue.TabIndex = 3;
            this.fieldPropFloatValue.Visible = false;
            this.fieldPropFloatValue.ValueChanged += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropFloatValue.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropFloatValue.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropIntValue
            // 
            this.fieldPropIntValue.Location = new System.Drawing.Point(3, 121);
            this.fieldPropIntValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.fieldPropIntValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.fieldPropIntValue.Name = "fieldPropIntValue";
            this.fieldPropIntValue.Size = new System.Drawing.Size(120, 20);
            this.fieldPropIntValue.TabIndex = 4;
            this.fieldPropIntValue.Visible = false;
            this.fieldPropIntValue.ValueChanged += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropIntValue.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropIntValue.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropBooleanValue
            // 
            this.fieldPropBooleanValue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fieldPropBooleanValue.Location = new System.Drawing.Point(3, 147);
            this.fieldPropBooleanValue.Name = "fieldPropBooleanValue";
            this.fieldPropBooleanValue.Size = new System.Drawing.Size(493, 24);
            this.fieldPropBooleanValue.TabIndex = 5;
            this.fieldPropBooleanValue.Text = "checkBox1";
            this.fieldPropBooleanValue.UseVisualStyleBackColor = true;
            this.fieldPropBooleanValue.Visible = false;
            this.fieldPropBooleanValue.CheckedChanged += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropBooleanValue.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropBooleanValue.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // fieldPropBoundsValue
            // 
            this.fieldPropBoundsValue.AutoSize = true;
            this.fieldPropBoundsValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fieldPropBoundsValue.BackColor = System.Drawing.Color.Transparent;
            this.fieldPropBoundsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldPropBoundsValue.Location = new System.Drawing.Point(0, 174);
            this.fieldPropBoundsValue.Margin = new System.Windows.Forms.Padding(0);
            this.fieldPropBoundsValue.MinimumSize = new System.Drawing.Size(2, 14);
            this.fieldPropBoundsValue.Name = "fieldPropBoundsValue";
            this.fieldPropBoundsValue.Size = new System.Drawing.Size(416, 42);
            this.fieldPropBoundsValue.TabIndex = 7;
            this.fieldPropBoundsValue.Visible = false;
            this.fieldPropBoundsValue.OnValueChangedNoArgs += new System.EventHandler(this.Component_ValueChanged);
            this.fieldPropBoundsValue.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.fieldPropBoundsValue.Leave += new System.EventHandler(this.WotwEditor_Leave);
            // 
            // selectedFieldProperty
            // 
            this.selectedFieldProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedFieldProperty.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.selectedFieldProperty.Location = new System.Drawing.Point(627, 9);
            this.selectedFieldProperty.Name = "selectedFieldProperty";
            this.selectedFieldProperty.Size = new System.Drawing.Size(536, 23);
            this.selectedFieldProperty.TabIndex = 21;
            this.selectedFieldProperty.Text = "label1";
            this.selectedFieldProperty.Visible = false;
            // 
            // btnNewScene
            // 
            this.btnNewScene.Location = new System.Drawing.Point(126, 814);
            this.btnNewScene.Name = "btnNewScene";
            this.btnNewScene.Size = new System.Drawing.Size(75, 23);
            this.btnNewScene.TabIndex = 22;
            this.btnNewScene.Text = "New Scene";
            this.btnNewScene.UseVisualStyleBackColor = true;
            this.btnNewScene.Click += new System.EventHandler(this.btnNewScene_Click);
            // 
            // WotwEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1180, 845);
            this.Controls.Add(this.btnNewScene);
            this.Controls.Add(this.selectedFieldProperty);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.FieldsPropertiesTree);
            this.Controls.Add(this.btnLoadWorld);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cloneGameObject);
            this.Controls.Add(this.lblSelectedObject);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sceneHierarchyTree);
            this.Name = "WotwEditor";
            this.Text = "WotwEditor";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.WotwEditor_Enter);
            this.Deactivate += new System.EventHandler(this.WotwEditor_Leave);
            this.Enter += new System.EventHandler(this.WotwEditor_Enter);
            this.Leave += new System.EventHandler(this.WotwEditor_Leave);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPropFloatValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPropIntValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView sceneHierarchyTree;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSelectedObject;
        private Button cloneGameObject;
        private Button button3;
        private Button btnLoadWorld;
        private TreeView FieldsPropertiesTree;
        private FlowLayoutPanel flowLayoutPanel1;
        private Vector4Control fieldPropVector4Value;
        private Vector3Control fieldPropVector3Value;
        private TextBox fieldPropStringValue;
        private NumericUpDown fieldPropFloatValue;
        private NumericUpDown fieldPropIntValue;
        private CheckBox fieldPropBooleanValue;
        private Label selectedFieldProperty;
        private Vector2Control fieldPropVector2Value;
        private BoundsControl fieldPropBoundsValue;
        private Button btnNewScene;
    }
}