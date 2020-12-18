namespace OriWotW.UI {
    partial class UberInput {
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUberGroup = new System.Windows.Forms.Label();
            this.uberGroupId = new System.Windows.Forms.ComboBox();
            this.labelUberId = new System.Windows.Forms.Label();
            this.uberId = new System.Windows.Forms.ComboBox();
            this.uberIdValueContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uberIdValueBool = new System.Windows.Forms.CheckBox();
            this.uberIdValueInt = new System.Windows.Forms.NumericUpDown();
            this.uberIdValueFloat = new System.Windows.Forms.NumericUpDown();
            this.uberIdValueByte = new System.Windows.Forms.NumericUpDown();
            this.remove = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.uberIdValueContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueByte)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.labelUberGroup);
            this.flowLayoutPanel1.Controls.Add(this.uberGroupId);
            this.flowLayoutPanel1.Controls.Add(this.labelUberId);
            this.flowLayoutPanel1.Controls.Add(this.uberId);
            this.flowLayoutPanel1.Controls.Add(this.uberIdValueContainer);
            this.flowLayoutPanel1.Controls.Add(this.remove);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1104, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // labelUberGroup
            // 
            this.labelUberGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUberGroup.AutoSize = true;
            this.labelUberGroup.Location = new System.Drawing.Point(3, 0);
            this.labelUberGroup.Name = "labelUberGroup";
            this.labelUberGroup.Size = new System.Drawing.Size(62, 32);
            this.labelUberGroup.TabIndex = 1;
            this.labelUberGroup.Text = "Uber Group";
            this.labelUberGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uberGroupId
            // 
            this.uberGroupId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberGroupId.AutoCompleteCustomSource.AddRange(new string[] {
            "animalCutsceneGroupDescriptor",
            "kwoloksGroupDescriptor",
            "_riverlandsGroup",
            "kwolokGroupDescriptor",
            "lagoonStateGroup",
            "playerUberStateGroupDescriptor",
            "lumaPoolsStateGroup",
            "testUberStateGroup",
            "desertAGroup",
            "statsUberStateGroup",
            "inkwaterMarshStateGroup",
            "windtornRuinsGroup",
            "howlsDenGroup",
            "leaderboardsUberStateGroup",
            "bashIntroductionA__clone1Group",
            "questUberStateGroup",
            "willowsEndGroup",
            "mouldwoodDepthsGroup",
            "eventsUberStateGroup",
            "windsweptWastesGroupDescriptor",
            "uiGroup",
            "minesUberStateGroup",
            "swampStateGroup",
            "pickupsGroup",
            "howlsOriginGroup",
            "convertedSetupsGymGroup",
            "winterForestGroupDescriptor",
            "baursReachGroup",
            "weepingRidgeElevatorFightGroup",
            "achievementsGroup",
            "gameStateGroup",
            "corruptedPeakGroup",
            "waterMillStateGroupDescriptor",
            "spiderBatTestGroup",
            "hubUberStateGroup",
            "wellspringGladesGroup",
            "raceGroup",
            "kwoloksCavernThroneRoomGroup",
            "npcsStateGroup",
            "wellspringGroupDescriptor",
            "prologueGroup",
            "_petrifiedForestGroup",
            "shrineGroup",
            "spiderGroupDescriptor",
            "testUberStateGroupDescriptor",
            "pickupOnSpawnGroup",
            "twillenShopDontWorry",
            "opherShopDontWorry",
            "treesDontWorry"});
            this.uberGroupId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uberGroupId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.uberGroupId.FormattingEnabled = true;
            this.uberGroupId.Location = new System.Drawing.Point(71, 5);
            this.uberGroupId.Name = "uberGroupId";
            this.uberGroupId.Size = new System.Drawing.Size(200, 21);
            this.uberGroupId.TabIndex = 0;
            this.uberGroupId.SelectedIndexChanged += new System.EventHandler(this.uberGroupId_SelectedIndexChanged);
            // 
            // labelUberId
            // 
            this.labelUberId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUberId.AutoSize = true;
            this.labelUberId.Location = new System.Drawing.Point(277, 0);
            this.labelUberId.Name = "labelUberId";
            this.labelUberId.Size = new System.Drawing.Size(44, 32);
            this.labelUberId.TabIndex = 2;
            this.labelUberId.Text = "Uber ID";
            this.labelUberId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uberId
            // 
            this.uberId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uberId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.uberId.FormattingEnabled = true;
            this.uberId.Location = new System.Drawing.Point(327, 5);
            this.uberId.Name = "uberId";
            this.uberId.Size = new System.Drawing.Size(256, 21);
            this.uberId.TabIndex = 3;
            this.uberId.SelectedIndexChanged += new System.EventHandler(this.uberId_SelectedIndexChanged);
            // 
            // uberIdValueContainer
            // 
            this.uberIdValueContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberIdValueContainer.AutoSize = true;
            this.uberIdValueContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uberIdValueContainer.Controls.Add(this.uberIdValueBool);
            this.uberIdValueContainer.Controls.Add(this.uberIdValueInt);
            this.uberIdValueContainer.Controls.Add(this.uberIdValueFloat);
            this.uberIdValueContainer.Controls.Add(this.uberIdValueByte);
            this.uberIdValueContainer.Location = new System.Drawing.Point(589, 3);
            this.uberIdValueContainer.MinimumSize = new System.Drawing.Size(0, 25);
            this.uberIdValueContainer.Name = "uberIdValueContainer";
            this.uberIdValueContainer.Size = new System.Drawing.Size(431, 26);
            this.uberIdValueContainer.TabIndex = 1;
            // 
            // uberIdValueBool
            // 
            this.uberIdValueBool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberIdValueBool.AutoSize = true;
            this.uberIdValueBool.Location = new System.Drawing.Point(3, 4);
            this.uberIdValueBool.Name = "uberIdValueBool";
            this.uberIdValueBool.Size = new System.Drawing.Size(47, 17);
            this.uberIdValueBool.TabIndex = 0;
            this.uberIdValueBool.Text = "Bool";
            this.uberIdValueBool.UseVisualStyleBackColor = true;
            this.uberIdValueBool.Visible = false;
            // 
            // uberIdValueInt
            // 
            this.uberIdValueInt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberIdValueInt.Location = new System.Drawing.Point(56, 3);
            this.uberIdValueInt.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.uberIdValueInt.Name = "uberIdValueInt";
            this.uberIdValueInt.Size = new System.Drawing.Size(120, 20);
            this.uberIdValueInt.TabIndex = 1;
            this.uberIdValueInt.Visible = false;
            // 
            // uberIdValueFloat
            // 
            this.uberIdValueFloat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberIdValueFloat.DecimalPlaces = 6;
            this.uberIdValueFloat.Location = new System.Drawing.Point(182, 3);
            this.uberIdValueFloat.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.uberIdValueFloat.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.uberIdValueFloat.Name = "uberIdValueFloat";
            this.uberIdValueFloat.Size = new System.Drawing.Size(120, 20);
            this.uberIdValueFloat.TabIndex = 4;
            this.uberIdValueFloat.Visible = false;
            // 
            // uberIdValueByte
            // 
            this.uberIdValueByte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uberIdValueByte.Location = new System.Drawing.Point(308, 3);
            this.uberIdValueByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.uberIdValueByte.Name = "uberIdValueByte";
            this.uberIdValueByte.Size = new System.Drawing.Size(120, 20);
            this.uberIdValueByte.TabIndex = 5;
            this.uberIdValueByte.Visible = false;
            // 
            // remove
            // 
            this.remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.remove.Location = new System.Drawing.Point(1026, 3);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 25);
            this.remove.TabIndex = 4;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // UberInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UberInput";
            this.Size = new System.Drawing.Size(852, 38);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.uberIdValueContainer.ResumeLayout(false);
            this.uberIdValueContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uberIdValueByte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelUberGroup;
        public System.Windows.Forms.ComboBox uberGroupId;
        private System.Windows.Forms.Label labelUberId;
        public System.Windows.Forms.ComboBox uberId;
        private System.Windows.Forms.FlowLayoutPanel uberIdValueContainer;
        public System.Windows.Forms.CheckBox uberIdValueBool;
        public System.Windows.Forms.NumericUpDown uberIdValueInt;
        public System.Windows.Forms.NumericUpDown uberIdValueFloat;
        public System.Windows.Forms.NumericUpDown uberIdValueByte;
        private System.Windows.Forms.Button remove;
    }
}
