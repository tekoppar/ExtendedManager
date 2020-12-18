using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Timers;
using OriWotW.Properties;

namespace OriWotW.UI {
    partial class RaceEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private object ClickedControl = null;
        private DateTime MouseDownTime;
        private bool IsDragging = false;
        private int OldDragValue = -1;

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

        private void OnMouseDown(object sender, MouseEventArgs e) {
            MouseDownTime = DateTime.Now;
            ClickedControl = sender;
            //DoDragDrop((Button)sender, DragDropEffects.All);
        }

        private void OnMouseMove(object sender, MouseEventArgs e) {
            if (MouseDownTime.Millisecond > 0 && IsDragging == false && ClickedControl != null) {
                TimeSpan time = DateTime.Now - MouseDownTime;
                if (time.TotalMilliseconds > 100 && time.TotalMilliseconds < 50000) {
                        DoDragDrop((Button)sender, DragDropEffects.All);
                    if (ClickedControl != null) {
                        IsDragging = true;
                    }
                }
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            ClickedControl = null;
            IsDragging = false;
            MouseDownTime = DateTime.MinValue;
        }

        private void OnDragOver(object sender, DragEventArgs e) {
            Button button = e.Data.GetData(typeof(Button)) as Button;
            PictureBox control = sender as PictureBox;

            if (control.Name.StartsWith("BoundAbility") && button.Name.StartsWith("abilityIcon")) {
                e.Effect = DragDropEffects.All;
            } else if (control.Name.StartsWith("EquippedShard") && button.Name.StartsWith("Shard")) {
                e.Effect = DragDropEffects.All;
            }
        }

        private void OnDragDrop(object sender, DragEventArgs e) {
            ClickedControl = null;
            IsDragging = false;
            MouseDownTime = DateTime.MinValue;

            Button button = e.Data.GetData(typeof(Button)) as Button;
            PictureBox control = sender as PictureBox;

            if (control.Name.StartsWith("BoundAbility") && button.Name.StartsWith("abilityIcon")) {
                Object obj = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                control.BackgroundImage = (Image)obj;
                control.Tag = button.Name;

                int index = AbilityTypeStringIndex[button.Name.Replace("abilityIcon", "").Replace("_off", "")];
                if (button.Name.EndsWith("_off") == true) {
                    Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                    button.BackgroundImage = (Image)img;
                    button.Name = button.Name.Replace("_off", "");
                    AllowedAbilities[index.ToString()] = OldDragValue == 1 ? true : false;
                    this.RaceSettings.SetAbilitiesStates(AllowedAbilities);
                } else {
                    Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                    button.BackgroundImage = (Image)img;
                    button.Name += "_off";
                    AllowedAbilities[index.ToString()] = OldDragValue == 1 ? true : false;
                    this.RaceSettings.SetAbilitiesStates(AllowedAbilities);
                }
            } else if (control.Name.StartsWith("EquippedShard") && button.Name.StartsWith("Shard")) {
                Object obj = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                control.BackgroundImage = (Image)obj;
                control.Tag = button.Name;

                int index = ShardTypeIndexString[button.Name.Replace("_off", "")];

                if (button.Name.EndsWith("_off") == true) {
                    Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                    Bitmap newImage = ResizeImage((Image)img, 54, 54);
                    button.Image = newImage;
                    //button.BackgroundImage = (Image)img;
                    button.Name = button.Name.Replace("_off", "");
                    this.RaceSettings.ShardsInInventory[index].Active = OldDragValue == 1 ? true : false;
                } else {
                    Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                    Bitmap newImage = ResizeImage((Image)img, 54, 54);
                    button.Image = newImage;
                    //button.BackgroundImage = (Image)img;
                    button.Name += "_off";
                    this.RaceSettings.ShardsInInventory[index].Active = OldDragValue == 1 ? true : false;
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.positionX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.positionY = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sizeX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeY = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkpointList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.createCheckpoint = new System.Windows.Forms.Button();
            this.removeCheckpoint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.raceName = new System.Windows.Forms.TextBox();
            this.newRace = new System.Windows.Forms.Button();
            this.saveRace = new System.Windows.Forms.Button();
            this.loadRace = new System.Windows.Forms.Button();
            this.setStart = new System.Windows.Forms.Button();
            this.setFinish = new System.Windows.Forms.Button();
            this.seinFaceDirection = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.startXlbl = new System.Windows.Forms.Label();
            this.startX = new System.Windows.Forms.NumericUpDown();
            this.startYlbl = new System.Windows.Forms.Label();
            this.startY = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.startZ = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.finishX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.finishY = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.finishZ = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.startRace = new System.Windows.Forms.Button();
            this.butSaveUber = new System.Windows.Forms.Button();
            this.butLoadUber = new System.Windows.Forms.Button();
            this.abiltiesSpellsList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
            this.butSaveAs = new System.Windows.Forms.Button();
            this.butLoadNRun = new System.Windows.Forms.Button();
            this.shardList = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel26 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
            this.BoundAbility1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel27 = new System.Windows.Forms.FlowLayoutPanel();
            this.BoundAbility2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel28 = new System.Windows.Forms.FlowLayoutPanel();
            this.BoundAbility3 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel34 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard3 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel35 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard4 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel36 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard5 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard6 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel29 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard7 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel30 = new System.Windows.Forms.FlowLayoutPanel();
            this.EquippedShard8 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butRaceFileFixer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeY)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startZ)).BeginInit();
            this.flowLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishZ)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel14.SuspendLayout();
            this.flowLayoutPanel17.SuspendLayout();
            this.flowLayoutPanel15.SuspendLayout();
            this.flowLayoutPanel26.SuspendLayout();
            this.flowLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility1)).BeginInit();
            this.flowLayoutPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility2)).BeginInit();
            this.flowLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility3)).BeginInit();
            this.flowLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard1)).BeginInit();
            this.flowLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard2)).BeginInit();
            this.flowLayoutPanel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard3)).BeginInit();
            this.flowLayoutPanel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard4)).BeginInit();
            this.flowLayoutPanel36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard5)).BeginInit();
            this.flowLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard6)).BeginInit();
            this.flowLayoutPanel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard7)).BeginInit();
            this.flowLayoutPanel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard8)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(373, 71);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.positionX);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.positionY);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(364, 26);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Position";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // positionX
            // 
            this.positionX.DecimalPlaces = 5;
            this.positionX.Location = new System.Drawing.Point(92, 3);
            this.positionX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.positionX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.positionX.Name = "positionX";
            this.positionX.Size = new System.Drawing.Size(120, 20);
            this.positionX.TabIndex = 1;
            this.positionX.ValueChanged += new System.EventHandler(this.position_ValueChanged);
            this.positionX.Enter += new System.EventHandler(this.input_Enter);
            this.positionX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // positionY
            // 
            this.positionY.DecimalPlaces = 5;
            this.positionY.Location = new System.Drawing.Point(241, 3);
            this.positionY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.positionY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.positionY.Name = "positionY";
            this.positionY.Size = new System.Drawing.Size(120, 20);
            this.positionY.TabIndex = 3;
            this.positionY.ValueChanged += new System.EventHandler(this.position_ValueChanged);
            this.positionY.Enter += new System.EventHandler(this.input_Enter);
            this.positionY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.sizeX);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.sizeY);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 35);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(364, 26);
            this.flowLayoutPanel3.TabIndex = 1;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "X:";
            // 
            // sizeX
            // 
            this.sizeX.DecimalPlaces = 5;
            this.sizeX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.sizeX.Location = new System.Drawing.Point(92, 3);
            this.sizeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sizeX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.sizeX.Name = "sizeX";
            this.sizeX.Size = new System.Drawing.Size(120, 20);
            this.sizeX.TabIndex = 1;
            this.sizeX.ValueChanged += new System.EventHandler(this.position_ValueChanged);
            this.sizeX.Enter += new System.EventHandler(this.input_Enter);
            this.sizeX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Y:";
            // 
            // sizeY
            // 
            this.sizeY.DecimalPlaces = 5;
            this.sizeY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.sizeY.Location = new System.Drawing.Point(241, 3);
            this.sizeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sizeY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.sizeY.Name = "sizeY";
            this.sizeY.Size = new System.Drawing.Size(120, 20);
            this.sizeY.TabIndex = 3;
            this.sizeY.ValueChanged += new System.EventHandler(this.position_ValueChanged);
            this.sizeY.Enter += new System.EventHandler(this.input_Enter);
            this.sizeY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // checkpointList
            // 
            this.checkpointList.AllowColumnReorder = true;
            this.checkpointList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.checkpointList.HideSelection = false;
            this.checkpointList.Location = new System.Drawing.Point(3, 115);
            this.checkpointList.Name = "checkpointList";
            this.checkpointList.Size = new System.Drawing.Size(568, 378);
            this.checkpointList.TabIndex = 2;
            this.checkpointList.UseCompatibleStateImageBehavior = false;
            this.checkpointList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.checkpointList_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Checkpoint Index";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Position X";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position Y";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size X";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Size Y";
            this.columnHeader5.Width = 90;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel7);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel4.Controls.Add(this.checkpointList);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(12, 203);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(579, 503);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel7.Controls.Add(this.createCheckpoint);
            this.flowLayoutPanel7.Controls.Add(this.removeCheckpoint);
            this.flowLayoutPanel7.Controls.Add(this.button1);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(395, 29);
            this.flowLayoutPanel7.TabIndex = 6;
            this.flowLayoutPanel7.WrapContents = false;
            // 
            // createCheckpoint
            // 
            this.createCheckpoint.Location = new System.Drawing.Point(3, 3);
            this.createCheckpoint.Name = "createCheckpoint";
            this.createCheckpoint.Size = new System.Drawing.Size(117, 23);
            this.createCheckpoint.TabIndex = 4;
            this.createCheckpoint.Text = "Create Checkpoint";
            this.createCheckpoint.UseVisualStyleBackColor = true;
            this.createCheckpoint.Click += new System.EventHandler(this.createCheckpoint_Click);
            // 
            // removeCheckpoint
            // 
            this.removeCheckpoint.Location = new System.Drawing.Point(126, 3);
            this.removeCheckpoint.Name = "removeCheckpoint";
            this.removeCheckpoint.Size = new System.Drawing.Size(115, 23);
            this.removeCheckpoint.TabIndex = 5;
            this.removeCheckpoint.Text = "Remove Checkpoint";
            this.removeCheckpoint.UseVisualStyleBackColor = true;
            this.removeCheckpoint.Click += new System.EventHandler(this.removeCheckpoint_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Toggle Checkpoint Debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.label7);
            this.flowLayoutPanel5.Controls.Add(this.raceName);
            this.flowLayoutPanel5.Controls.Add(this.newRace);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(341, 29);
            this.flowLayoutPanel5.TabIndex = 4;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Race Name:";
            // 
            // raceName
            // 
            this.raceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.raceName.Location = new System.Drawing.Point(76, 4);
            this.raceName.Name = "raceName";
            this.raceName.Size = new System.Drawing.Size(181, 20);
            this.raceName.TabIndex = 1;
            this.raceName.TextChanged += new System.EventHandler(this.raceName_TextChanged);
            this.raceName.Enter += new System.EventHandler(this.input_Enter);
            this.raceName.Leave += new System.EventHandler(this.input_Leave);
            // 
            // newRace
            // 
            this.newRace.Location = new System.Drawing.Point(263, 3);
            this.newRace.Name = "newRace";
            this.newRace.Size = new System.Drawing.Size(75, 23);
            this.newRace.TabIndex = 7;
            this.newRace.Text = "New Race";
            this.newRace.UseVisualStyleBackColor = true;
            this.newRace.Click += new System.EventHandler(this.newRace_Click);
            // 
            // saveRace
            // 
            this.saveRace.Location = new System.Drawing.Point(3, 3);
            this.saveRace.Name = "saveRace";
            this.saveRace.Size = new System.Drawing.Size(75, 23);
            this.saveRace.TabIndex = 5;
            this.saveRace.Text = "Save Race";
            this.saveRace.UseVisualStyleBackColor = true;
            this.saveRace.Click += new System.EventHandler(this.saveRace_Click);
            // 
            // loadRace
            // 
            this.loadRace.Location = new System.Drawing.Point(165, 3);
            this.loadRace.Name = "loadRace";
            this.loadRace.Size = new System.Drawing.Size(75, 23);
            this.loadRace.TabIndex = 6;
            this.loadRace.Text = "Load Race";
            this.loadRace.UseVisualStyleBackColor = true;
            this.loadRace.Click += new System.EventHandler(this.loadRace_Click);
            // 
            // setStart
            // 
            this.setStart.Location = new System.Drawing.Point(450, 3);
            this.setStart.Name = "setStart";
            this.setStart.Size = new System.Drawing.Size(102, 23);
            this.setStart.TabIndex = 2;
            this.setStart.Text = "Set Start Position";
            this.setStart.UseVisualStyleBackColor = true;
            this.setStart.Click += new System.EventHandler(this.setStart_Click);
            // 
            // setFinish
            // 
            this.setFinish.Location = new System.Drawing.Point(450, 3);
            this.setFinish.Name = "setFinish";
            this.setFinish.Size = new System.Drawing.Size(110, 23);
            this.setFinish.TabIndex = 3;
            this.setFinish.Text = "Set Finish Position";
            this.setFinish.UseVisualStyleBackColor = true;
            this.setFinish.Click += new System.EventHandler(this.setFinish_Click);
            // 
            // seinFaceDirection
            // 
            this.seinFaceDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.seinFaceDirection.AutoSize = true;
            this.seinFaceDirection.Location = new System.Drawing.Point(296, 6);
            this.seinFaceDirection.Name = "seinFaceDirection";
            this.seinFaceDirection.Size = new System.Drawing.Size(109, 17);
            this.seinFaceDirection.TabIndex = 7;
            this.seinFaceDirection.Text = "Face Left At Start";
            this.seinFaceDirection.UseVisualStyleBackColor = true;
            this.seinFaceDirection.CheckedChanged += new System.EventHandler(this.seinFaceDirection_CheckedChanged);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.AutoSize = true;
            this.flowLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel8.Controls.Add(this.startXlbl);
            this.flowLayoutPanel8.Controls.Add(this.startX);
            this.flowLayoutPanel8.Controls.Add(this.startYlbl);
            this.flowLayoutPanel8.Controls.Add(this.startY);
            this.flowLayoutPanel8.Controls.Add(this.label9);
            this.flowLayoutPanel8.Controls.Add(this.startZ);
            this.flowLayoutPanel8.Controls.Add(this.setStart);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(8, 113);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(555, 29);
            this.flowLayoutPanel8.TabIndex = 7;
            // 
            // startXlbl
            // 
            this.startXlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startXlbl.AutoSize = true;
            this.startXlbl.Location = new System.Drawing.Point(3, 8);
            this.startXlbl.Name = "startXlbl";
            this.startXlbl.Size = new System.Drawing.Size(17, 13);
            this.startXlbl.TabIndex = 3;
            this.startXlbl.Text = "X:";
            // 
            // startX
            // 
            this.startX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startX.DecimalPlaces = 5;
            this.startX.Location = new System.Drawing.Point(26, 4);
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
            this.startX.Enter += new System.EventHandler(this.input_Enter);
            this.startX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // startYlbl
            // 
            this.startYlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startYlbl.AutoSize = true;
            this.startYlbl.Location = new System.Drawing.Point(152, 8);
            this.startYlbl.Name = "startYlbl";
            this.startYlbl.Size = new System.Drawing.Size(17, 13);
            this.startYlbl.TabIndex = 5;
            this.startYlbl.Text = "Y:";
            // 
            // startY
            // 
            this.startY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startY.DecimalPlaces = 5;
            this.startY.Location = new System.Drawing.Point(175, 4);
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
            this.startY.Enter += new System.EventHandler(this.input_Enter);
            this.startY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Z:";
            // 
            // startZ
            // 
            this.startZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.startZ.DecimalPlaces = 5;
            this.startZ.Location = new System.Drawing.Point(324, 4);
            this.startZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.startZ.Name = "startZ";
            this.startZ.Size = new System.Drawing.Size(120, 20);
            this.startZ.TabIndex = 8;
            this.startZ.Enter += new System.EventHandler(this.input_Enter);
            this.startZ.Leave += new System.EventHandler(this.input_Leave);
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.AutoSize = true;
            this.flowLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel9.Controls.Add(this.label8);
            this.flowLayoutPanel9.Controls.Add(this.finishX);
            this.flowLayoutPanel9.Controls.Add(this.label10);
            this.flowLayoutPanel9.Controls.Add(this.finishY);
            this.flowLayoutPanel9.Controls.Add(this.label11);
            this.flowLayoutPanel9.Controls.Add(this.finishZ);
            this.flowLayoutPanel9.Controls.Add(this.setFinish);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(8, 148);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(563, 29);
            this.flowLayoutPanel9.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "X:";
            // 
            // finishX
            // 
            this.finishX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.finishX.DecimalPlaces = 5;
            this.finishX.Location = new System.Drawing.Point(26, 4);
            this.finishX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.finishX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.finishX.Name = "finishX";
            this.finishX.Size = new System.Drawing.Size(120, 20);
            this.finishX.TabIndex = 4;
            this.finishX.Enter += new System.EventHandler(this.input_Enter);
            this.finishX.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Y:";
            // 
            // finishY
            // 
            this.finishY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.finishY.DecimalPlaces = 5;
            this.finishY.Location = new System.Drawing.Point(175, 4);
            this.finishY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.finishY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.finishY.Name = "finishY";
            this.finishY.Size = new System.Drawing.Size(120, 20);
            this.finishY.TabIndex = 6;
            this.finishY.Enter += new System.EventHandler(this.input_Enter);
            this.finishY.Leave += new System.EventHandler(this.input_Leave);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Z:";
            // 
            // finishZ
            // 
            this.finishZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.finishZ.DecimalPlaces = 5;
            this.finishZ.Location = new System.Drawing.Point(324, 4);
            this.finishZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.finishZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.finishZ.Name = "finishZ";
            this.finishZ.Size = new System.Drawing.Size(120, 20);
            this.finishZ.TabIndex = 8;
            this.finishZ.Enter += new System.EventHandler(this.input_Enter);
            this.finishZ.Leave += new System.EventHandler(this.input_Leave);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel6.Controls.Add(this.startRace);
            this.flowLayoutPanel6.Controls.Add(this.butSaveUber);
            this.flowLayoutPanel6.Controls.Add(this.butLoadUber);
            this.flowLayoutPanel6.Controls.Add(this.seinFaceDirection);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(8, 78);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(408, 29);
            this.flowLayoutPanel6.TabIndex = 10;
            // 
            // startRace
            // 
            this.startRace.Location = new System.Drawing.Point(3, 3);
            this.startRace.Name = "startRace";
            this.startRace.Size = new System.Drawing.Size(75, 23);
            this.startRace.TabIndex = 0;
            this.startRace.Text = "Start Race";
            this.startRace.UseVisualStyleBackColor = true;
            this.startRace.Click += new System.EventHandler(this.startRace_Click);
            // 
            // butSaveUber
            // 
            this.butSaveUber.Location = new System.Drawing.Point(84, 3);
            this.butSaveUber.Name = "butSaveUber";
            this.butSaveUber.Size = new System.Drawing.Size(97, 23);
            this.butSaveUber.TabIndex = 8;
            this.butSaveUber.Text = "Save Uberstates";
            this.butSaveUber.UseVisualStyleBackColor = true;
            this.butSaveUber.Click += new System.EventHandler(this.butSaveUber_Click);
            // 
            // butLoadUber
            // 
            this.butLoadUber.Location = new System.Drawing.Point(187, 3);
            this.butLoadUber.Name = "butLoadUber";
            this.butLoadUber.Size = new System.Drawing.Size(103, 23);
            this.butLoadUber.TabIndex = 9;
            this.butLoadUber.Text = "Load Uberstates";
            this.butLoadUber.UseVisualStyleBackColor = true;
            this.butLoadUber.Click += new System.EventHandler(this.butLoadUber_Click);
            // 
            // abiltiesSpellsList
            // 
            this.abiltiesSpellsList.AutoSize = true;
            this.abiltiesSpellsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abiltiesSpellsList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.abiltiesSpellsList.Location = new System.Drawing.Point(6, 150);
            this.abiltiesSpellsList.MaximumSize = new System.Drawing.Size(1200, 0);
            this.abiltiesSpellsList.MinimumSize = new System.Drawing.Size(100, 100);
            this.abiltiesSpellsList.Name = "abiltiesSpellsList";
            this.abiltiesSpellsList.Size = new System.Drawing.Size(100, 100);
            this.abiltiesSpellsList.TabIndex = 11;
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.AutoSize = true;
            this.flowLayoutPanel14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel14.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel14.Controls.Add(this.flowLayoutPanel17);
            this.flowLayoutPanel14.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel14.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel14.Controls.Add(this.flowLayoutPanel9);
            this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel14.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel14.Size = new System.Drawing.Size(579, 185);
            this.flowLayoutPanel14.TabIndex = 13;
            // 
            // flowLayoutPanel17
            // 
            this.flowLayoutPanel17.AutoSize = true;
            this.flowLayoutPanel17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel17.Controls.Add(this.saveRace);
            this.flowLayoutPanel17.Controls.Add(this.butSaveAs);
            this.flowLayoutPanel17.Controls.Add(this.loadRace);
            this.flowLayoutPanel17.Controls.Add(this.butLoadNRun);
            this.flowLayoutPanel17.Controls.Add(this.butRaceFileFixer);
            this.flowLayoutPanel17.Location = new System.Drawing.Point(8, 43);
            this.flowLayoutPanel17.Name = "flowLayoutPanel17";
            this.flowLayoutPanel17.Size = new System.Drawing.Size(447, 29);
            this.flowLayoutPanel17.TabIndex = 11;
            // 
            // butSaveAs
            // 
            this.butSaveAs.Location = new System.Drawing.Point(84, 3);
            this.butSaveAs.Name = "butSaveAs";
            this.butSaveAs.Size = new System.Drawing.Size(75, 23);
            this.butSaveAs.TabIndex = 8;
            this.butSaveAs.Text = "Save As";
            this.butSaveAs.UseVisualStyleBackColor = true;
            this.butSaveAs.Visible = false;
            this.butSaveAs.Click += new System.EventHandler(this.butSaveAs_Click);
            // 
            // butLoadNRun
            // 
            this.butLoadNRun.Location = new System.Drawing.Point(246, 3);
            this.butLoadNRun.Name = "butLoadNRun";
            this.butLoadNRun.Size = new System.Drawing.Size(92, 23);
            this.butLoadNRun.TabIndex = 9;
            this.butLoadNRun.Text = "Load && Run";
            this.butLoadNRun.UseVisualStyleBackColor = true;
            this.butLoadNRun.Click += new System.EventHandler(this.butLoadNRun_Click);
            // 
            // shardList
            // 
            this.shardList.AutoSize = true;
            this.shardList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.shardList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.shardList.Location = new System.Drawing.Point(6, 352);
            this.shardList.MaximumSize = new System.Drawing.Size(1200, 0);
            this.shardList.MinimumSize = new System.Drawing.Size(100, 100);
            this.shardList.Name = "shardList";
            this.shardList.Size = new System.Drawing.Size(100, 100);
            this.shardList.TabIndex = 14;
            // 
            // flowLayoutPanel15
            // 
            this.flowLayoutPanel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel15.AutoScroll = true;
            this.flowLayoutPanel15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel15.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel15.Controls.Add(this.flowLayoutPanel26);
            this.flowLayoutPanel15.Controls.Add(this.abiltiesSpellsList);
            this.flowLayoutPanel15.Controls.Add(this.flowLayoutPanel11);
            this.flowLayoutPanel15.Controls.Add(this.shardList);
            this.flowLayoutPanel15.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel15.Location = new System.Drawing.Point(618, 12);
            this.flowLayoutPanel15.MinimumSize = new System.Drawing.Size(150, 0);
            this.flowLayoutPanel15.Name = "flowLayoutPanel15";
            this.flowLayoutPanel15.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel15.Size = new System.Drawing.Size(837, 694);
            this.flowLayoutPanel15.TabIndex = 15;
            this.flowLayoutPanel15.WrapContents = false;
            // 
            // flowLayoutPanel26
            // 
            this.flowLayoutPanel26.AutoSize = true;
            this.flowLayoutPanel26.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel26.Controls.Add(this.flowLayoutPanel16);
            this.flowLayoutPanel26.Controls.Add(this.flowLayoutPanel27);
            this.flowLayoutPanel26.Controls.Add(this.flowLayoutPanel28);
            this.flowLayoutPanel26.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel26.Name = "flowLayoutPanel26";
            this.flowLayoutPanel26.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel26.Size = new System.Drawing.Size(394, 138);
            this.flowLayoutPanel26.TabIndex = 21;
            // 
            // flowLayoutPanel16
            // 
            this.flowLayoutPanel16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel16.BackgroundImage = global::OriWotW.Properties.Resources.uiLoremmasterSelectionCircle;
            this.flowLayoutPanel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel16.Controls.Add(this.BoundAbility1);
            this.flowLayoutPanel16.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel16.MinimumSize = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel16.Name = "flowLayoutPanel16";
            this.flowLayoutPanel16.Size = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel16.TabIndex = 20;
            this.flowLayoutPanel16.WrapContents = false;
            // 
            // BoundAbility1
            // 
            this.BoundAbility1.BackColor = System.Drawing.Color.Transparent;
            this.BoundAbility1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BoundAbility1.Location = new System.Drawing.Point(24, 24);
            this.BoundAbility1.Margin = new System.Windows.Forms.Padding(24);
            this.BoundAbility1.MaximumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility1.MinimumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility1.Name = "BoundAbility1";
            this.BoundAbility1.Size = new System.Drawing.Size(80, 80);
            this.BoundAbility1.TabIndex = 0;
            this.BoundAbility1.TabStop = false;
            this.BoundAbility1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.BoundAbility1.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.BoundAbility1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel27
            // 
            this.flowLayoutPanel27.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel27.BackgroundImage = global::OriWotW.Properties.Resources.uiLoremmasterSelectionCircle;
            this.flowLayoutPanel27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel27.Controls.Add(this.BoundAbility2);
            this.flowLayoutPanel27.Location = new System.Drawing.Point(133, 5);
            this.flowLayoutPanel27.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel27.MinimumSize = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel27.Name = "flowLayoutPanel27";
            this.flowLayoutPanel27.Size = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel27.TabIndex = 21;
            this.flowLayoutPanel27.WrapContents = false;
            // 
            // BoundAbility2
            // 
            this.BoundAbility2.BackColor = System.Drawing.Color.Transparent;
            this.BoundAbility2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BoundAbility2.Location = new System.Drawing.Point(24, 24);
            this.BoundAbility2.Margin = new System.Windows.Forms.Padding(24);
            this.BoundAbility2.MaximumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility2.MinimumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility2.Name = "BoundAbility2";
            this.BoundAbility2.Size = new System.Drawing.Size(80, 80);
            this.BoundAbility2.TabIndex = 0;
            this.BoundAbility2.TabStop = false;
            this.BoundAbility2.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.BoundAbility2.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.BoundAbility2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel28
            // 
            this.flowLayoutPanel28.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel28.BackgroundImage = global::OriWotW.Properties.Resources.uiLoremmasterSelectionCircle;
            this.flowLayoutPanel28.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel28.Controls.Add(this.BoundAbility3);
            this.flowLayoutPanel28.Location = new System.Drawing.Point(261, 5);
            this.flowLayoutPanel28.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel28.MinimumSize = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel28.Name = "flowLayoutPanel28";
            this.flowLayoutPanel28.Size = new System.Drawing.Size(128, 128);
            this.flowLayoutPanel28.TabIndex = 22;
            this.flowLayoutPanel28.WrapContents = false;
            // 
            // BoundAbility3
            // 
            this.BoundAbility3.BackColor = System.Drawing.Color.Transparent;
            this.BoundAbility3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BoundAbility3.Location = new System.Drawing.Point(24, 24);
            this.BoundAbility3.Margin = new System.Windows.Forms.Padding(24);
            this.BoundAbility3.MaximumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility3.MinimumSize = new System.Drawing.Size(80, 80);
            this.BoundAbility3.Name = "BoundAbility3";
            this.BoundAbility3.Size = new System.Drawing.Size(80, 80);
            this.BoundAbility3.TabIndex = 0;
            this.BoundAbility3.TabStop = false;
            this.BoundAbility3.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.BoundAbility3.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.BoundAbility3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.AutoSize = true;
            this.flowLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel10);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel12);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel34);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel35);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel36);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel13);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel29);
            this.flowLayoutPanel11.Controls.Add(this.flowLayoutPanel30);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(6, 256);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel11.Size = new System.Drawing.Size(650, 90);
            this.flowLayoutPanel11.TabIndex = 23;
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel10.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel10.Controls.Add(this.EquippedShard1);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel10.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel10.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel10.TabIndex = 22;
            this.flowLayoutPanel10.WrapContents = false;
            // 
            // EquippedShard1
            // 
            this.EquippedShard1.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard1.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard1.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard1.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard1.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard1.Name = "EquippedShard1";
            this.EquippedShard1.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard1.TabIndex = 0;
            this.EquippedShard1.TabStop = false;
            this.EquippedShard1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard1.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel12.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel12.Controls.Add(this.EquippedShard2);
            this.flowLayoutPanel12.Location = new System.Drawing.Point(85, 5);
            this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel12.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel12.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel12.TabIndex = 23;
            this.flowLayoutPanel12.WrapContents = false;
            // 
            // EquippedShard2
            // 
            this.EquippedShard2.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard2.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard2.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard2.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard2.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard2.Name = "EquippedShard2";
            this.EquippedShard2.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard2.TabIndex = 0;
            this.EquippedShard2.TabStop = false;
            this.EquippedShard2.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard2.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel34
            // 
            this.flowLayoutPanel34.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel34.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel34.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel34.Controls.Add(this.EquippedShard3);
            this.flowLayoutPanel34.Location = new System.Drawing.Point(165, 5);
            this.flowLayoutPanel34.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel34.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel34.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel34.Name = "flowLayoutPanel34";
            this.flowLayoutPanel34.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel34.TabIndex = 30;
            this.flowLayoutPanel34.WrapContents = false;
            // 
            // EquippedShard3
            // 
            this.EquippedShard3.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard3.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard3.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard3.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard3.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard3.Name = "EquippedShard3";
            this.EquippedShard3.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard3.TabIndex = 0;
            this.EquippedShard3.TabStop = false;
            this.EquippedShard3.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard3.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel35
            // 
            this.flowLayoutPanel35.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel35.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel35.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel35.Controls.Add(this.EquippedShard4);
            this.flowLayoutPanel35.Location = new System.Drawing.Point(245, 5);
            this.flowLayoutPanel35.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel35.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel35.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel35.Name = "flowLayoutPanel35";
            this.flowLayoutPanel35.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel35.TabIndex = 31;
            this.flowLayoutPanel35.WrapContents = false;
            // 
            // EquippedShard4
            // 
            this.EquippedShard4.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard4.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard4.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard4.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard4.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard4.Name = "EquippedShard4";
            this.EquippedShard4.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard4.TabIndex = 0;
            this.EquippedShard4.TabStop = false;
            this.EquippedShard4.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard4.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel36
            // 
            this.flowLayoutPanel36.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel36.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel36.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel36.Controls.Add(this.EquippedShard5);
            this.flowLayoutPanel36.Location = new System.Drawing.Point(325, 5);
            this.flowLayoutPanel36.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel36.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel36.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel36.Name = "flowLayoutPanel36";
            this.flowLayoutPanel36.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel36.TabIndex = 32;
            this.flowLayoutPanel36.WrapContents = false;
            // 
            // EquippedShard5
            // 
            this.EquippedShard5.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard5.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard5.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard5.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard5.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard5.Name = "EquippedShard5";
            this.EquippedShard5.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard5.TabIndex = 0;
            this.EquippedShard5.TabStop = false;
            this.EquippedShard5.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard5.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel13.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel13.Controls.Add(this.EquippedShard6);
            this.flowLayoutPanel13.Location = new System.Drawing.Point(405, 5);
            this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel13.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel13.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel13.TabIndex = 33;
            this.flowLayoutPanel13.WrapContents = false;
            // 
            // EquippedShard6
            // 
            this.EquippedShard6.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard6.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard6.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard6.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard6.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard6.Name = "EquippedShard6";
            this.EquippedShard6.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard6.TabIndex = 0;
            this.EquippedShard6.TabStop = false;
            this.EquippedShard6.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard6.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel29
            // 
            this.flowLayoutPanel29.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel29.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel29.Controls.Add(this.EquippedShard7);
            this.flowLayoutPanel29.Location = new System.Drawing.Point(485, 5);
            this.flowLayoutPanel29.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel29.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel29.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel29.Name = "flowLayoutPanel29";
            this.flowLayoutPanel29.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel29.TabIndex = 34;
            this.flowLayoutPanel29.WrapContents = false;
            // 
            // EquippedShard7
            // 
            this.EquippedShard7.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard7.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard7.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard7.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard7.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard7.Name = "EquippedShard7";
            this.EquippedShard7.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard7.TabIndex = 0;
            this.EquippedShard7.TabStop = false;
            this.EquippedShard7.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard7.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // flowLayoutPanel30
            // 
            this.flowLayoutPanel30.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel30.BackgroundImage = global::OriWotW.Properties.Resources.ringDroplet;
            this.flowLayoutPanel30.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel30.Controls.Add(this.EquippedShard8);
            this.flowLayoutPanel30.Location = new System.Drawing.Point(565, 5);
            this.flowLayoutPanel30.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel30.MaximumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel30.MinimumSize = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel30.Name = "flowLayoutPanel30";
            this.flowLayoutPanel30.Size = new System.Drawing.Size(80, 80);
            this.flowLayoutPanel30.TabIndex = 35;
            this.flowLayoutPanel30.WrapContents = false;
            // 
            // EquippedShard8
            // 
            this.EquippedShard8.BackColor = System.Drawing.Color.Transparent;
            this.EquippedShard8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EquippedShard8.Location = new System.Drawing.Point(0, 0);
            this.EquippedShard8.Margin = new System.Windows.Forms.Padding(0);
            this.EquippedShard8.MaximumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard8.MinimumSize = new System.Drawing.Size(80, 80);
            this.EquippedShard8.Name = "EquippedShard8";
            this.EquippedShard8.Size = new System.Drawing.Size(80, 80);
            this.EquippedShard8.TabIndex = 0;
            this.EquippedShard8.TabStop = false;
            this.EquippedShard8.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.EquippedShard8.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.EquippedShard8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dragButtonState_MouseClick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // butRaceFileFixer
            // 
            this.butRaceFileFixer.Location = new System.Drawing.Point(344, 3);
            this.butRaceFileFixer.Name = "butRaceFileFixer";
            this.butRaceFileFixer.Size = new System.Drawing.Size(100, 23);
            this.butRaceFileFixer.TabIndex = 10;
            this.butRaceFileFixer.Text = "Race File Fixer";
            this.butRaceFileFixer.UseVisualStyleBackColor = true;
            this.butRaceFileFixer.Click += new System.EventHandler(this.butRaceFileFixer_Click);
            // 
            // RaceEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 718);
            this.Controls.Add(this.flowLayoutPanel15);
            this.Controls.Add(this.flowLayoutPanel14);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Name = "RaceEditor";
            this.Text = "RaceEditor";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeY)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startZ)).EndInit();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishZ)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel14.ResumeLayout(false);
            this.flowLayoutPanel14.PerformLayout();
            this.flowLayoutPanel17.ResumeLayout(false);
            this.flowLayoutPanel15.ResumeLayout(false);
            this.flowLayoutPanel15.PerformLayout();
            this.flowLayoutPanel26.ResumeLayout(false);
            this.flowLayoutPanel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility1)).EndInit();
            this.flowLayoutPanel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility2)).EndInit();
            this.flowLayoutPanel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BoundAbility3)).EndInit();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard1)).EndInit();
            this.flowLayoutPanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard2)).EndInit();
            this.flowLayoutPanel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard3)).EndInit();
            this.flowLayoutPanel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard4)).EndInit();
            this.flowLayoutPanel36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard5)).EndInit();
            this.flowLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard6)).EndInit();
            this.flowLayoutPanel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard7)).EndInit();
            this.flowLayoutPanel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EquippedShard8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown positionX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown positionY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sizeX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown sizeY;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView checkpointList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox raceName;
        private System.Windows.Forms.Button setStart;
        private System.Windows.Forms.Button setFinish;
        private System.Windows.Forms.Button createCheckpoint;
        private System.Windows.Forms.Button saveRace;
        private System.Windows.Forms.Button loadRace;
        private System.Windows.Forms.Button newRace;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Button removeCheckpoint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label startXlbl;
        private System.Windows.Forms.NumericUpDown startX;
        private System.Windows.Forms.Label startYlbl;
        private System.Windows.Forms.NumericUpDown startY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown startZ;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown finishX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown finishY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown finishZ;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button startRace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel abiltiesSpellsList;
        private System.Windows.Forms.CheckBox seinFaceDirection;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private System.Windows.Forms.FlowLayoutPanel shardList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel15;
        private System.Windows.Forms.ToolTip toolTip1;
        private FlowLayoutPanel flowLayoutPanel16;
        private PictureBox BoundAbility1;
        private FlowLayoutPanel flowLayoutPanel26;
        private FlowLayoutPanel flowLayoutPanel27;
        private PictureBox BoundAbility2;
        private FlowLayoutPanel flowLayoutPanel28;
        private PictureBox BoundAbility3;
        private FlowLayoutPanel flowLayoutPanel11;
        private FlowLayoutPanel flowLayoutPanel10;
        private PictureBox EquippedShard1;
        private FlowLayoutPanel flowLayoutPanel12;
        private PictureBox EquippedShard2;
        private FlowLayoutPanel flowLayoutPanel34;
        private PictureBox EquippedShard3;
        private FlowLayoutPanel flowLayoutPanel35;
        private PictureBox EquippedShard4;
        private FlowLayoutPanel flowLayoutPanel36;
        private PictureBox EquippedShard5;
        private FlowLayoutPanel flowLayoutPanel13;
        private PictureBox EquippedShard6;
        private FlowLayoutPanel flowLayoutPanel29;
        private PictureBox EquippedShard7;
        private FlowLayoutPanel flowLayoutPanel30;
        private PictureBox EquippedShard8;
        private Button butSaveUber;
        private Button butLoadUber;
        private FlowLayoutPanel flowLayoutPanel17;
        private Button butSaveAs;
        private Button butLoadNRun;
        private Button butRaceFileFixer;
    }
}