
using System.Windows.Forms;
namespace OriWotW.UI {
    partial class SeinVisualEditor {
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

        void Form_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            }
            // Prompt user to save his data

            if (e.CloseReason == CloseReason.WindowsShutDown)
                e.Cancel = false;
            // Autosave and clear up ressources
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.textureImage = new System.Windows.Forms.PictureBox();
            this.btnTextureLoader = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkbHideGlow = new System.Windows.Forms.CheckBox();
            this.chkAutoApply = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.visualSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadVisualSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultGameSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeActiveSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetActiveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxSettingName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.OriVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label25 = new System.Windows.Forms.Label();
            this.GoldenSeinVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.oriHatTexture = new System.Windows.Forms.PictureBox();
            this.btnOriHatTextureLoader = new System.Windows.Forms.Button();
            this.btnRemoveOriHatTexture = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.HatVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkEnableTrailMesh = new System.Windows.Forms.CheckBox();
            this.TorchVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.TorchBreakColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.TorchHitColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.TorchHitSmallColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.TorchGroundAttacks1ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.TorchGroundAttacks2ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.TorchGroundAttacks3ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.TorchAirAttacks1ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.TorchAirAttacks2ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.TorchAirAttacks3ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.GlideVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel44 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.BowVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.ArrowVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.ArrowHitVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel84 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.SwordVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label27 = new System.Windows.Forms.Label();
            this.SwordAttackAirPokeColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.SwordAttackDownAirColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label29 = new System.Windows.Forms.Label();
            this.SwordAttackGroundAColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label30 = new System.Windows.Forms.Label();
            this.SwordAttackGroundBColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label31 = new System.Windows.Forms.Label();
            this.SwordAttackGroundCColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label32 = new System.Windows.Forms.Label();
            this.SwordAttackUpColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label35 = new System.Windows.Forms.Label();
            this.SwordBlockColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label33 = new System.Windows.Forms.Label();
            this.SwordDamageBlueColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label34 = new System.Windows.Forms.Label();
            this.SwordHitColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.GrenadeColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.GrenadeFracturedColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.GrenadeExplosionColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.ChargedColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.GrenadeExplosionChargedColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.GrenadeExplosionFracturedColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.GrenadeAimingColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.GrenadeChargingColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.HammerVisualSettingsColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label36 = new System.Windows.Forms.Label();
            this.HammerAttackAir1ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.HammerAttackAir2ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.HammerAttackAir3ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label40 = new System.Windows.Forms.Label();
            this.HammerAttackAirUpSwipeColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label41 = new System.Windows.Forms.Label();
            this.HammerAttackGround1ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label42 = new System.Windows.Forms.Label();
            this.HammerAttackGround2ColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label43 = new System.Windows.Forms.Label();
            this.HammerAttackGroundDownColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label44 = new System.Windows.Forms.Label();
            this.HammerAttackGroundUpSwipeColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label45 = new System.Windows.Forms.Label();
            this.HammerAttackStompColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label49 = new System.Windows.Forms.Label();
            this.HammerShockwaveColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label46 = new System.Windows.Forms.Label();
            this.HammerBlockColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label47 = new System.Windows.Forms.Label();
            this.HammerHitColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.label48 = new System.Windows.Forms.Label();
            this.HammerStompPreparationColorPickers = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textureImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oriHatTexture)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.flowLayoutPanel44.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.flowLayoutPanel84.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textureImage
            // 
            this.textureImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textureImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureImage.Location = new System.Drawing.Point(6, 19);
            this.textureImage.Name = "textureImage";
            this.textureImage.Size = new System.Drawing.Size(512, 512);
            this.textureImage.TabIndex = 0;
            this.textureImage.TabStop = false;
            // 
            // btnTextureLoader
            // 
            this.btnTextureLoader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTextureLoader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTextureLoader.Location = new System.Drawing.Point(6, 537);
            this.btnTextureLoader.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.btnTextureLoader.Name = "btnTextureLoader";
            this.btnTextureLoader.Size = new System.Drawing.Size(97, 23);
            this.btnTextureLoader.TabIndex = 4;
            this.btnTextureLoader.Text = "Load Texture";
            this.btnTextureLoader.UseVisualStyleBackColor = true;
            this.btnTextureLoader.Click += new System.EventHandler(this.btnTextureLoader_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(290, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Apply Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkbHideGlow
            // 
            this.chkbHideGlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbHideGlow.AutoSize = true;
            this.chkbHideGlow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkbHideGlow.Location = new System.Drawing.Point(6, 591);
            this.chkbHideGlow.Name = "chkbHideGlow";
            this.chkbHideGlow.Size = new System.Drawing.Size(512, 17);
            this.chkbHideGlow.TabIndex = 7;
            this.chkbHideGlow.Text = "Hide Glow";
            this.chkbHideGlow.UseVisualStyleBackColor = true;
            this.chkbHideGlow.CheckedChanged += new System.EventHandler(this.chkbHideGlow_CheckedChanged);
            // 
            // chkAutoApply
            // 
            this.chkAutoApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoApply.AutoSize = true;
            this.chkAutoApply.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAutoApply.Location = new System.Drawing.Point(22, 793);
            this.chkAutoApply.Name = "chkAutoApply";
            this.chkAutoApply.Size = new System.Drawing.Size(165, 17);
            this.chkAutoApply.TabIndex = 8;
            this.chkAutoApply.Text = "Auto apply settings on startup";
            this.chkAutoApply.UseVisualStyleBackColor = true;
            this.chkAutoApply.CheckedChanged += new System.EventHandler(this.chkAutoApply_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualSettingsToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // visualSettingsToolStripMenuItem
            // 
            this.visualSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSettingToolStripMenuItem,
            this.loadVisualSettingsToolStripMenuItem});
            this.visualSettingsToolStripMenuItem.Name = "visualSettingsToolStripMenuItem";
            this.visualSettingsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.visualSettingsToolStripMenuItem.Text = "File";
            // 
            // newSettingToolStripMenuItem
            // 
            this.newSettingToolStripMenuItem.Name = "newSettingToolStripMenuItem";
            this.newSettingToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.newSettingToolStripMenuItem.Text = "New Setting";
            this.newSettingToolStripMenuItem.Click += new System.EventHandler(this.newSettingToolStripMenuItem_Click);
            // 
            // loadVisualSettingsToolStripMenuItem
            // 
            this.loadVisualSettingsToolStripMenuItem.Name = "loadVisualSettingsToolStripMenuItem";
            this.loadVisualSettingsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.loadVisualSettingsToolStripMenuItem.Text = "Load Visual Settings";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultGameSettingsToolStripMenuItem,
            this.removeActiveSettingToolStripMenuItem,
            this.resetActiveSettingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // defaultGameSettingsToolStripMenuItem
            // 
            this.defaultGameSettingsToolStripMenuItem.Name = "defaultGameSettingsToolStripMenuItem";
            this.defaultGameSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.defaultGameSettingsToolStripMenuItem.Text = "Default Game Settings";
            this.defaultGameSettingsToolStripMenuItem.ToolTipText = "Sets the visual settings to the default game ones, does not change the values in " +
    "the editor.";
            this.defaultGameSettingsToolStripMenuItem.Click += new System.EventHandler(this.defaultGameSettingsToolStripMenuItem_Click);
            // 
            // removeActiveSettingToolStripMenuItem
            // 
            this.removeActiveSettingToolStripMenuItem.Name = "removeActiveSettingToolStripMenuItem";
            this.removeActiveSettingToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeActiveSettingToolStripMenuItem.Text = "Remove Active Setting";
            this.removeActiveSettingToolStripMenuItem.ToolTipText = "Remoes the current active setting.";
            this.removeActiveSettingToolStripMenuItem.Click += new System.EventHandler(this.removeActiveSettingToolStripMenuItem_Click);
            // 
            // resetActiveSettingsToolStripMenuItem
            // 
            this.resetActiveSettingsToolStripMenuItem.Name = "resetActiveSettingsToolStripMenuItem";
            this.resetActiveSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.resetActiveSettingsToolStripMenuItem.Text = "Reset Active Settings";
            this.resetActiveSettingsToolStripMenuItem.ToolTipText = "Resets the current active settings to default values.";
            this.resetActiveSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetActiveSettingsToolStripMenuItem_Click);
            // 
            // tbxSettingName
            // 
            this.tbxSettingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSettingName.Location = new System.Drawing.Point(92, 7);
            this.tbxSettingName.Name = "tbxSettingName";
            this.tbxSettingName.Size = new System.Drawing.Size(192, 20);
            this.tbxSettingName.TabIndex = 10;
            this.tbxSettingName.Enter += new System.EventHandler(this.input_Enter);
            this.tbxSettingName.Leave += new System.EventHandler(this.input_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.tbxSettingName);
            this.flowLayoutPanel3.Controls.Add(this.button1);
            this.flowLayoutPanel3.Controls.Add(this.btnSaveSetting);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(194, 785);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(481, 35);
            this.flowLayoutPanel3.TabIndex = 11;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Setting Name";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSetting.Location = new System.Drawing.Point(393, 6);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(82, 23);
            this.btnSaveSetting.TabIndex = 12;
            this.btnSaveSetting.Text = "Save Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 741);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.flowLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 715);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ori & Sein";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.Controls.Add(this.label26);
            this.flowLayoutPanel4.Controls.Add(this.textureImage);
            this.flowLayoutPanel4.Controls.Add(this.btnTextureLoader);
            this.flowLayoutPanel4.Controls.Add(this.label24);
            this.flowLayoutPanel4.Controls.Add(this.chkbHideGlow);
            this.flowLayoutPanel4.Controls.Add(this.OriVisualSettingsColorPickers);
            this.flowLayoutPanel4.Controls.Add(this.label25);
            this.flowLayoutPanel4.Controls.Add(this.GoldenSeinVisualSettingsColorPickers);
            this.flowLayoutPanel4.Controls.Add(this.oriHatTexture);
            this.flowLayoutPanel4.Controls.Add(this.btnOriHatTextureLoader);
            this.flowLayoutPanel4.Controls.Add(this.btnRemoveOriHatTexture);
            this.flowLayoutPanel4.Controls.Add(this.label50);
            this.flowLayoutPanel4.Controls.Add(this.HatVisualSettingsColorPickers);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(643, 703);
            this.flowLayoutPanel4.TabIndex = 0;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "Ori Texture";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 575);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Ori";
            // 
            // OriVisualSettingsColorPickers
            // 
            this.OriVisualSettingsColorPickers.AutoSize = true;
            this.OriVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriVisualSettingsColorPickers.Location = new System.Drawing.Point(6, 614);
            this.OriVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.OriVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.OriVisualSettingsColorPickers.Name = "OriVisualSettingsColorPickers";
            this.OriVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.OriVisualSettingsColorPickers.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 679);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "Golden Sein";
            // 
            // GoldenSeinVisualSettingsColorPickers
            // 
            this.GoldenSeinVisualSettingsColorPickers.AutoSize = true;
            this.GoldenSeinVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GoldenSeinVisualSettingsColorPickers.Location = new System.Drawing.Point(6, 695);
            this.GoldenSeinVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GoldenSeinVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GoldenSeinVisualSettingsColorPickers.Name = "GoldenSeinVisualSettingsColorPickers";
            this.GoldenSeinVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GoldenSeinVisualSettingsColorPickers.TabIndex = 0;
            // 
            // oriHatTexture
            // 
            this.oriHatTexture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.oriHatTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oriHatTexture.Location = new System.Drawing.Point(6, 763);
            this.oriHatTexture.Name = "oriHatTexture";
            this.oriHatTexture.Size = new System.Drawing.Size(256, 256);
            this.oriHatTexture.TabIndex = 33;
            this.oriHatTexture.TabStop = false;
            // 
            // btnOriHatTextureLoader
            // 
            this.btnOriHatTextureLoader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnOriHatTextureLoader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOriHatTextureLoader.Location = new System.Drawing.Point(6, 1025);
            this.btnOriHatTextureLoader.Name = "btnOriHatTextureLoader";
            this.btnOriHatTextureLoader.Size = new System.Drawing.Size(97, 23);
            this.btnOriHatTextureLoader.TabIndex = 34;
            this.btnOriHatTextureLoader.Text = "Load Texture";
            this.btnOriHatTextureLoader.UseVisualStyleBackColor = true;
            this.btnOriHatTextureLoader.Click += new System.EventHandler(this.btnTextureLoader_Click);
            // 
            // btnRemoveOriHatTexture
            // 
            this.btnRemoveOriHatTexture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveOriHatTexture.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveOriHatTexture.Location = new System.Drawing.Point(6, 1054);
            this.btnRemoveOriHatTexture.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.btnRemoveOriHatTexture.Name = "btnRemoveOriHatTexture";
            this.btnRemoveOriHatTexture.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveOriHatTexture.TabIndex = 35;
            this.btnRemoveOriHatTexture.Text = "Remove Texture";
            this.btnRemoveOriHatTexture.UseVisualStyleBackColor = true;
            this.btnRemoveOriHatTexture.Click += new System.EventHandler(this.btnRemoveOriHatTexture_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 1092);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 13);
            this.label50.TabIndex = 32;
            this.label50.Text = "Hat Visuals";
            // 
            // HatVisualSettingsColorPickers
            // 
            this.HatVisualSettingsColorPickers.AutoSize = true;
            this.HatVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HatVisualSettingsColorPickers.Location = new System.Drawing.Point(6, 1108);
            this.HatVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HatVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HatVisualSettingsColorPickers.Name = "HatVisualSettingsColorPickers";
            this.HatVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HatVisualSettingsColorPickers.TabIndex = 31;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.flowLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 715);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Torch";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel5.AutoScroll = true;
            this.flowLayoutPanel5.Controls.Add(this.label23);
            this.flowLayoutPanel5.Controls.Add(this.checkBox1);
            this.flowLayoutPanel5.Controls.Add(this.chkEnableTrailMesh);
            this.flowLayoutPanel5.Controls.Add(this.TorchVisualSettingsColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label16);
            this.flowLayoutPanel5.Controls.Add(this.TorchBreakColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label14);
            this.flowLayoutPanel5.Controls.Add(this.TorchHitColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label15);
            this.flowLayoutPanel5.Controls.Add(this.TorchHitSmallColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label17);
            this.flowLayoutPanel5.Controls.Add(this.TorchGroundAttacks1ColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label18);
            this.flowLayoutPanel5.Controls.Add(this.TorchGroundAttacks2ColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label19);
            this.flowLayoutPanel5.Controls.Add(this.TorchGroundAttacks3ColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label20);
            this.flowLayoutPanel5.Controls.Add(this.TorchAirAttacks1ColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label21);
            this.flowLayoutPanel5.Controls.Add(this.TorchAirAttacks2ColorPickers);
            this.flowLayoutPanel5.Controls.Add(this.label22);
            this.flowLayoutPanel5.Controls.Add(this.TorchAirAttacks3ColorPickers);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(643, 706);
            this.flowLayoutPanel5.TabIndex = 0;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Torch";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Hide Glow";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkEnableTrailMesh
            // 
            this.chkEnableTrailMesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnableTrailMesh.AutoSize = true;
            this.chkEnableTrailMesh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkEnableTrailMesh.Location = new System.Drawing.Point(6, 42);
            this.chkEnableTrailMesh.Name = "chkEnableTrailMesh";
            this.chkEnableTrailMesh.Size = new System.Drawing.Size(116, 17);
            this.chkEnableTrailMesh.TabIndex = 7;
            this.chkEnableTrailMesh.Text = "Enable Trail Mesh";
            this.chkEnableTrailMesh.UseVisualStyleBackColor = true;
            this.chkEnableTrailMesh.CheckedChanged += new System.EventHandler(this.chkEnableTrailMesh_CheckedChanged);
            // 
            // TorchVisualSettingsColorPickers
            // 
            this.TorchVisualSettingsColorPickers.AutoSize = true;
            this.TorchVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchVisualSettingsColorPickers.Location = new System.Drawing.Point(6, 65);
            this.TorchVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchVisualSettingsColorPickers.Name = "TorchVisualSettingsColorPickers";
            this.TorchVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchVisualSettingsColorPickers.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Torch Break";
            // 
            // TorchBreakColorPickers
            // 
            this.TorchBreakColorPickers.AutoSize = true;
            this.TorchBreakColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchBreakColorPickers.Location = new System.Drawing.Point(6, 146);
            this.TorchBreakColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchBreakColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchBreakColorPickers.Name = "TorchBreakColorPickers";
            this.TorchBreakColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchBreakColorPickers.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 211);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Torch Hit";
            // 
            // TorchHitColorPickers
            // 
            this.TorchHitColorPickers.AutoSize = true;
            this.TorchHitColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchHitColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchHitColorPickers.Location = new System.Drawing.Point(6, 227);
            this.TorchHitColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchHitColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchHitColorPickers.Name = "TorchHitColorPickers";
            this.TorchHitColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchHitColorPickers.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Torch Hit Small";
            // 
            // TorchHitSmallColorPickers
            // 
            this.TorchHitSmallColorPickers.AutoSize = true;
            this.TorchHitSmallColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchHitSmallColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchHitSmallColorPickers.Location = new System.Drawing.Point(6, 308);
            this.TorchHitSmallColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchHitSmallColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchHitSmallColorPickers.Name = "TorchHitSmallColorPickers";
            this.TorchHitSmallColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchHitSmallColorPickers.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 373);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Torch Ground Attack 1";
            // 
            // TorchGroundAttacks1ColorPickers
            // 
            this.TorchGroundAttacks1ColorPickers.AutoSize = true;
            this.TorchGroundAttacks1ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchGroundAttacks1ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchGroundAttacks1ColorPickers.Location = new System.Drawing.Point(6, 389);
            this.TorchGroundAttacks1ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchGroundAttacks1ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks1ColorPickers.Name = "TorchGroundAttacks1ColorPickers";
            this.TorchGroundAttacks1ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks1ColorPickers.TabIndex = 15;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 454);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Torch Ground Attack 2";
            // 
            // TorchGroundAttacks2ColorPickers
            // 
            this.TorchGroundAttacks2ColorPickers.AutoSize = true;
            this.TorchGroundAttacks2ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchGroundAttacks2ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchGroundAttacks2ColorPickers.Location = new System.Drawing.Point(6, 470);
            this.TorchGroundAttacks2ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchGroundAttacks2ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks2ColorPickers.Name = "TorchGroundAttacks2ColorPickers";
            this.TorchGroundAttacks2ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks2ColorPickers.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 535);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "Torch Ground Attack 3";
            // 
            // TorchGroundAttacks3ColorPickers
            // 
            this.TorchGroundAttacks3ColorPickers.AutoSize = true;
            this.TorchGroundAttacks3ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchGroundAttacks3ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchGroundAttacks3ColorPickers.Location = new System.Drawing.Point(6, 551);
            this.TorchGroundAttacks3ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchGroundAttacks3ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks3ColorPickers.Name = "TorchGroundAttacks3ColorPickers";
            this.TorchGroundAttacks3ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchGroundAttacks3ColorPickers.TabIndex = 17;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 616);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Torch Air Attack 1";
            // 
            // TorchAirAttacks1ColorPickers
            // 
            this.TorchAirAttacks1ColorPickers.AutoSize = true;
            this.TorchAirAttacks1ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchAirAttacks1ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchAirAttacks1ColorPickers.Location = new System.Drawing.Point(6, 632);
            this.TorchAirAttacks1ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchAirAttacks1ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks1ColorPickers.Name = "TorchAirAttacks1ColorPickers";
            this.TorchAirAttacks1ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks1ColorPickers.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 697);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Torch Air Attack 2";
            // 
            // TorchAirAttacks2ColorPickers
            // 
            this.TorchAirAttacks2ColorPickers.AutoSize = true;
            this.TorchAirAttacks2ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchAirAttacks2ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchAirAttacks2ColorPickers.Location = new System.Drawing.Point(6, 713);
            this.TorchAirAttacks2ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchAirAttacks2ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks2ColorPickers.Name = "TorchAirAttacks2ColorPickers";
            this.TorchAirAttacks2ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks2ColorPickers.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 778);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "Torch Air Attack 3";
            // 
            // TorchAirAttacks3ColorPickers
            // 
            this.TorchAirAttacks3ColorPickers.AutoSize = true;
            this.TorchAirAttacks3ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TorchAirAttacks3ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TorchAirAttacks3ColorPickers.Location = new System.Drawing.Point(6, 794);
            this.TorchAirAttacks3ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.TorchAirAttacks3ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks3ColorPickers.Name = "TorchAirAttacks3ColorPickers";
            this.TorchAirAttacks3ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.TorchAirAttacks3ColorPickers.TabIndex = 17;
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.Black;
            this.tabPage11.Controls.Add(this.GlideVisualSettingsColorPickers);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(655, 715);
            this.tabPage11.TabIndex = 2;
            this.tabPage11.Text = "Glide & Feather";
            // 
            // GlideVisualSettingsColorPickers
            // 
            this.GlideVisualSettingsColorPickers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GlideVisualSettingsColorPickers.AutoScroll = true;
            this.GlideVisualSettingsColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GlideVisualSettingsColorPickers.Location = new System.Drawing.Point(6, 6);
            this.GlideVisualSettingsColorPickers.Name = "GlideVisualSettingsColorPickers";
            this.GlideVisualSettingsColorPickers.Size = new System.Drawing.Size(643, 703);
            this.GlideVisualSettingsColorPickers.TabIndex = 0;
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.Black;
            this.tabPage12.Controls.Add(this.flowLayoutPanel44);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(655, 715);
            this.tabPage12.TabIndex = 3;
            this.tabPage12.Text = "Bow";
            // 
            // flowLayoutPanel44
            // 
            this.flowLayoutPanel44.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel44.AutoScroll = true;
            this.flowLayoutPanel44.Controls.Add(this.label12);
            this.flowLayoutPanel44.Controls.Add(this.BowVisualSettingsColorPickers);
            this.flowLayoutPanel44.Controls.Add(this.label13);
            this.flowLayoutPanel44.Controls.Add(this.ArrowVisualSettingsColorPickers);
            this.flowLayoutPanel44.Controls.Add(this.label39);
            this.flowLayoutPanel44.Controls.Add(this.ArrowHitVisualSettingsColorPickers);
            this.flowLayoutPanel44.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel44.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel44.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel44.Name = "flowLayoutPanel44";
            this.flowLayoutPanel44.Size = new System.Drawing.Size(643, 703);
            this.flowLayoutPanel44.TabIndex = 0;
            this.flowLayoutPanel44.WrapContents = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Bow";
            // 
            // BowVisualSettingsColorPickers
            // 
            this.BowVisualSettingsColorPickers.AutoSize = true;
            this.BowVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BowVisualSettingsColorPickers.Location = new System.Drawing.Point(3, 16);
            this.BowVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.BowVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.BowVisualSettingsColorPickers.Name = "BowVisualSettingsColorPickers";
            this.BowVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.BowVisualSettingsColorPickers.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Arrow";
            // 
            // ArrowVisualSettingsColorPickers
            // 
            this.ArrowVisualSettingsColorPickers.AutoSize = true;
            this.ArrowVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrowVisualSettingsColorPickers.Location = new System.Drawing.Point(3, 97);
            this.ArrowVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.ArrowVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.ArrowVisualSettingsColorPickers.Name = "ArrowVisualSettingsColorPickers";
            this.ArrowVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.ArrowVisualSettingsColorPickers.TabIndex = 1;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 162);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(50, 13);
            this.label39.TabIndex = 24;
            this.label39.Text = "Arrow Hit";
            // 
            // ArrowHitVisualSettingsColorPickers
            // 
            this.ArrowHitVisualSettingsColorPickers.AutoSize = true;
            this.ArrowHitVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArrowHitVisualSettingsColorPickers.Location = new System.Drawing.Point(3, 178);
            this.ArrowHitVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.ArrowHitVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.ArrowHitVisualSettingsColorPickers.Name = "ArrowHitVisualSettingsColorPickers";
            this.ArrowHitVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.ArrowHitVisualSettingsColorPickers.TabIndex = 23;
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.Color.Black;
            this.tabPage13.Controls.Add(this.flowLayoutPanel84);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(655, 715);
            this.tabPage13.TabIndex = 4;
            this.tabPage13.Text = "Sword";
            // 
            // flowLayoutPanel84
            // 
            this.flowLayoutPanel84.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel84.AutoScroll = true;
            this.flowLayoutPanel84.Controls.Add(this.label10);
            this.flowLayoutPanel84.Controls.Add(this.SwordVisualSettingsColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label27);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackAirPokeColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label28);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackDownAirColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label29);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackGroundAColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label30);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackGroundBColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label31);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackGroundCColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label32);
            this.flowLayoutPanel84.Controls.Add(this.SwordAttackUpColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label35);
            this.flowLayoutPanel84.Controls.Add(this.SwordBlockColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label33);
            this.flowLayoutPanel84.Controls.Add(this.SwordDamageBlueColorPickers);
            this.flowLayoutPanel84.Controls.Add(this.label34);
            this.flowLayoutPanel84.Controls.Add(this.SwordHitColorPickers);
            this.flowLayoutPanel84.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel84.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel84.Name = "flowLayoutPanel84";
            this.flowLayoutPanel84.Size = new System.Drawing.Size(643, 703);
            this.flowLayoutPanel84.TabIndex = 0;
            this.flowLayoutPanel84.WrapContents = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Sword";
            // 
            // SwordVisualSettingsColorPickers
            // 
            this.SwordVisualSettingsColorPickers.AutoSize = true;
            this.SwordVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordVisualSettingsColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordVisualSettingsColorPickers.Location = new System.Drawing.Point(3, 16);
            this.SwordVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordVisualSettingsColorPickers.Name = "SwordVisualSettingsColorPickers";
            this.SwordVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordVisualSettingsColorPickers.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label27.Location = new System.Drawing.Point(3, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(81, 13);
            this.label27.TabIndex = 3;
            this.label27.Text = "Attack Air Poke";
            // 
            // SwordAttackAirPokeColorPickers
            // 
            this.SwordAttackAirPokeColorPickers.AutoSize = true;
            this.SwordAttackAirPokeColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackAirPokeColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackAirPokeColorPickers.Location = new System.Drawing.Point(3, 97);
            this.SwordAttackAirPokeColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackAirPokeColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackAirPokeColorPickers.Name = "SwordAttackAirPokeColorPickers";
            this.SwordAttackAirPokeColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackAirPokeColorPickers.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label28.Location = new System.Drawing.Point(3, 162);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 13);
            this.label28.TabIndex = 5;
            this.label28.Text = "Attack Down Air";
            // 
            // SwordAttackDownAirColorPickers
            // 
            this.SwordAttackDownAirColorPickers.AutoSize = true;
            this.SwordAttackDownAirColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackDownAirColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackDownAirColorPickers.Location = new System.Drawing.Point(3, 178);
            this.SwordAttackDownAirColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackDownAirColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackDownAirColorPickers.Name = "SwordAttackDownAirColorPickers";
            this.SwordAttackDownAirColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackDownAirColorPickers.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label29.Location = new System.Drawing.Point(3, 243);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(86, 13);
            this.label29.TabIndex = 7;
            this.label29.Text = "Attack Ground A";
            // 
            // SwordAttackGroundAColorPickers
            // 
            this.SwordAttackGroundAColorPickers.AutoSize = true;
            this.SwordAttackGroundAColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackGroundAColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackGroundAColorPickers.Location = new System.Drawing.Point(3, 259);
            this.SwordAttackGroundAColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackGroundAColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundAColorPickers.Name = "SwordAttackGroundAColorPickers";
            this.SwordAttackGroundAColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundAColorPickers.TabIndex = 6;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label30.Location = new System.Drawing.Point(3, 324);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(86, 13);
            this.label30.TabIndex = 9;
            this.label30.Text = "Attack Ground B";
            // 
            // SwordAttackGroundBColorPickers
            // 
            this.SwordAttackGroundBColorPickers.AutoSize = true;
            this.SwordAttackGroundBColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackGroundBColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackGroundBColorPickers.Location = new System.Drawing.Point(3, 340);
            this.SwordAttackGroundBColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackGroundBColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundBColorPickers.Name = "SwordAttackGroundBColorPickers";
            this.SwordAttackGroundBColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundBColorPickers.TabIndex = 8;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label31.Location = new System.Drawing.Point(3, 405);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(86, 13);
            this.label31.TabIndex = 11;
            this.label31.Text = "Attack Ground C";
            // 
            // SwordAttackGroundCColorPickers
            // 
            this.SwordAttackGroundCColorPickers.AutoSize = true;
            this.SwordAttackGroundCColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackGroundCColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackGroundCColorPickers.Location = new System.Drawing.Point(3, 421);
            this.SwordAttackGroundCColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackGroundCColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundCColorPickers.Name = "SwordAttackGroundCColorPickers";
            this.SwordAttackGroundCColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackGroundCColorPickers.TabIndex = 10;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label32.Location = new System.Drawing.Point(3, 486);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(55, 13);
            this.label32.TabIndex = 13;
            this.label32.Text = "Attack Up";
            // 
            // SwordAttackUpColorPickers
            // 
            this.SwordAttackUpColorPickers.AutoSize = true;
            this.SwordAttackUpColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordAttackUpColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordAttackUpColorPickers.Location = new System.Drawing.Point(3, 502);
            this.SwordAttackUpColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordAttackUpColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordAttackUpColorPickers.Name = "SwordAttackUpColorPickers";
            this.SwordAttackUpColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordAttackUpColorPickers.TabIndex = 12;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label35.Location = new System.Drawing.Point(3, 567);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 13);
            this.label35.TabIndex = 19;
            this.label35.Text = "Block Effect";
            // 
            // SwordBlockColorPickers
            // 
            this.SwordBlockColorPickers.AutoSize = true;
            this.SwordBlockColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordBlockColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordBlockColorPickers.Location = new System.Drawing.Point(3, 583);
            this.SwordBlockColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordBlockColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordBlockColorPickers.Name = "SwordBlockColorPickers";
            this.SwordBlockColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordBlockColorPickers.TabIndex = 18;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label33.Location = new System.Drawing.Point(3, 648);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(71, 13);
            this.label33.TabIndex = 15;
            this.label33.Text = "Damage Blue";
            // 
            // SwordDamageBlueColorPickers
            // 
            this.SwordDamageBlueColorPickers.AutoSize = true;
            this.SwordDamageBlueColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordDamageBlueColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordDamageBlueColorPickers.Location = new System.Drawing.Point(3, 664);
            this.SwordDamageBlueColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordDamageBlueColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordDamageBlueColorPickers.Name = "SwordDamageBlueColorPickers";
            this.SwordDamageBlueColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordDamageBlueColorPickers.TabIndex = 14;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label34.Location = new System.Drawing.Point(3, 729);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(51, 13);
            this.label34.TabIndex = 17;
            this.label34.Text = "Hit Effect";
            // 
            // SwordHitColorPickers
            // 
            this.SwordHitColorPickers.AutoSize = true;
            this.SwordHitColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwordHitColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SwordHitColorPickers.Location = new System.Drawing.Point(3, 745);
            this.SwordHitColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.SwordHitColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.SwordHitColorPickers.Name = "SwordHitColorPickers";
            this.SwordHitColorPickers.Size = new System.Drawing.Size(50, 50);
            this.SwordHitColorPickers.TabIndex = 16;
            // 
            // tabPage14
            // 
            this.tabPage14.AutoScroll = true;
            this.tabPage14.BackColor = System.Drawing.Color.Black;
            this.tabPage14.Controls.Add(this.flowLayoutPanel6);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(655, 715);
            this.tabPage14.TabIndex = 5;
            this.tabPage14.Text = "Grenade";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel6.AutoScroll = true;
            this.flowLayoutPanel6.Controls.Add(this.label8);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label6);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeFracturedColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label4);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeExplosionColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label9);
            this.flowLayoutPanel6.Controls.Add(this.ChargedColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label5);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeExplosionChargedColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label7);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeExplosionFracturedColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label3);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeAimingColorPickers);
            this.flowLayoutPanel6.Controls.Add(this.label2);
            this.flowLayoutPanel6.Controls.Add(this.GrenadeChargingColorPickers);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(646, 703);
            this.flowLayoutPanel6.TabIndex = 6;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Grenade";
            // 
            // GrenadeColorPickers
            // 
            this.GrenadeColorPickers.AutoSize = true;
            this.GrenadeColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeColorPickers.Location = new System.Drawing.Point(6, 19);
            this.GrenadeColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeColorPickers.Name = "GrenadeColorPickers";
            this.GrenadeColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeColorPickers.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Grenade Fractured";
            // 
            // GrenadeFracturedColorPickers
            // 
            this.GrenadeFracturedColorPickers.AutoSize = true;
            this.GrenadeFracturedColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeFracturedColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeFracturedColorPickers.Location = new System.Drawing.Point(6, 100);
            this.GrenadeFracturedColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeFracturedColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeFracturedColorPickers.Name = "GrenadeFracturedColorPickers";
            this.GrenadeFracturedColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeFracturedColorPickers.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Grenade Explosion";
            // 
            // GrenadeExplosionColorPickers
            // 
            this.GrenadeExplosionColorPickers.AutoSize = true;
            this.GrenadeExplosionColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeExplosionColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeExplosionColorPickers.Location = new System.Drawing.Point(6, 181);
            this.GrenadeExplosionColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeExplosionColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionColorPickers.Name = "GrenadeExplosionColorPickers";
            this.GrenadeExplosionColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionColorPickers.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(6, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Grenade Charged";
            // 
            // ChargedColorPickers
            // 
            this.ChargedColorPickers.AutoSize = true;
            this.ChargedColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChargedColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChargedColorPickers.Location = new System.Drawing.Point(6, 262);
            this.ChargedColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.ChargedColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.ChargedColorPickers.Name = "ChargedColorPickers";
            this.ChargedColorPickers.Size = new System.Drawing.Size(50, 50);
            this.ChargedColorPickers.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(6, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Grenade Charged Explosion";
            // 
            // GrenadeExplosionChargedColorPickers
            // 
            this.GrenadeExplosionChargedColorPickers.AutoSize = true;
            this.GrenadeExplosionChargedColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeExplosionChargedColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeExplosionChargedColorPickers.Location = new System.Drawing.Point(6, 343);
            this.GrenadeExplosionChargedColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeExplosionChargedColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionChargedColorPickers.Name = "GrenadeExplosionChargedColorPickers";
            this.GrenadeExplosionChargedColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionChargedColorPickers.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(6, 408);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Grenade Charged Fractured";
            // 
            // GrenadeExplosionFracturedColorPickers
            // 
            this.GrenadeExplosionFracturedColorPickers.AutoSize = true;
            this.GrenadeExplosionFracturedColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeExplosionFracturedColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeExplosionFracturedColorPickers.Location = new System.Drawing.Point(6, 424);
            this.GrenadeExplosionFracturedColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeExplosionFracturedColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionFracturedColorPickers.Name = "GrenadeExplosionFracturedColorPickers";
            this.GrenadeExplosionFracturedColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeExplosionFracturedColorPickers.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(6, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Aiming";
            // 
            // GrenadeAimingColorPickers
            // 
            this.GrenadeAimingColorPickers.AutoSize = true;
            this.GrenadeAimingColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeAimingColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeAimingColorPickers.Location = new System.Drawing.Point(6, 505);
            this.GrenadeAimingColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeAimingColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeAimingColorPickers.Name = "GrenadeAimingColorPickers";
            this.GrenadeAimingColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeAimingColorPickers.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 570);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Charging";
            // 
            // GrenadeChargingColorPickers
            // 
            this.GrenadeChargingColorPickers.AutoSize = true;
            this.GrenadeChargingColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GrenadeChargingColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrenadeChargingColorPickers.Location = new System.Drawing.Point(6, 586);
            this.GrenadeChargingColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.GrenadeChargingColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.GrenadeChargingColorPickers.Name = "GrenadeChargingColorPickers";
            this.GrenadeChargingColorPickers.Size = new System.Drawing.Size(50, 50);
            this.GrenadeChargingColorPickers.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Black;
            this.tabPage3.Controls.Add(this.flowLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(655, 715);
            this.tabPage3.TabIndex = 6;
            this.tabPage3.Text = "Hammer";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.HammerVisualSettingsColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label36);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackAir1ColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label37);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackAir2ColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label38);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackAir3ColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label40);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackAirUpSwipeColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label41);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackGround1ColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label42);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackGround2ColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label43);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackGroundDownColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label44);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackGroundUpSwipeColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label45);
            this.flowLayoutPanel1.Controls.Add(this.HammerAttackStompColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label49);
            this.flowLayoutPanel1.Controls.Add(this.HammerShockwaveColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label46);
            this.flowLayoutPanel1.Controls.Add(this.HammerBlockColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label47);
            this.flowLayoutPanel1.Controls.Add(this.HammerHitColorPickers);
            this.flowLayoutPanel1.Controls.Add(this.label48);
            this.flowLayoutPanel1.Controls.Add(this.HammerStompPreparationColorPickers);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(643, 703);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Hammer";
            // 
            // HammerVisualSettingsColorPickers
            // 
            this.HammerVisualSettingsColorPickers.AutoSize = true;
            this.HammerVisualSettingsColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerVisualSettingsColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerVisualSettingsColorPickers.Location = new System.Drawing.Point(3, 16);
            this.HammerVisualSettingsColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerVisualSettingsColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerVisualSettingsColorPickers.Name = "HammerVisualSettingsColorPickers";
            this.HammerVisualSettingsColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerVisualSettingsColorPickers.TabIndex = 3;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label36.Location = new System.Drawing.Point(3, 81);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(62, 13);
            this.label36.TabIndex = 6;
            this.label36.Text = "Attack Air 1";
            // 
            // HammerAttackAir1ColorPickers
            // 
            this.HammerAttackAir1ColorPickers.AutoSize = true;
            this.HammerAttackAir1ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackAir1ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackAir1ColorPickers.Location = new System.Drawing.Point(3, 97);
            this.HammerAttackAir1ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackAir1ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackAir1ColorPickers.Name = "HammerAttackAir1ColorPickers";
            this.HammerAttackAir1ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackAir1ColorPickers.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label37.Location = new System.Drawing.Point(3, 162);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(62, 13);
            this.label37.TabIndex = 8;
            this.label37.Text = "Attack Air 2";
            // 
            // HammerAttackAir2ColorPickers
            // 
            this.HammerAttackAir2ColorPickers.AutoSize = true;
            this.HammerAttackAir2ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackAir2ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackAir2ColorPickers.Location = new System.Drawing.Point(3, 178);
            this.HammerAttackAir2ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackAir2ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackAir2ColorPickers.Name = "HammerAttackAir2ColorPickers";
            this.HammerAttackAir2ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackAir2ColorPickers.TabIndex = 7;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label38.Location = new System.Drawing.Point(3, 243);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(62, 13);
            this.label38.TabIndex = 10;
            this.label38.Text = "Attack Air 3";
            // 
            // HammerAttackAir3ColorPickers
            // 
            this.HammerAttackAir3ColorPickers.AutoSize = true;
            this.HammerAttackAir3ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackAir3ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackAir3ColorPickers.Location = new System.Drawing.Point(3, 259);
            this.HammerAttackAir3ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackAir3ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackAir3ColorPickers.Name = "HammerAttackAir3ColorPickers";
            this.HammerAttackAir3ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackAir3ColorPickers.TabIndex = 9;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label40.Location = new System.Drawing.Point(3, 324);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(102, 13);
            this.label40.TabIndex = 14;
            this.label40.Text = "Attack Air Up Swipe";
            // 
            // HammerAttackAirUpSwipeColorPickers
            // 
            this.HammerAttackAirUpSwipeColorPickers.AutoSize = true;
            this.HammerAttackAirUpSwipeColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackAirUpSwipeColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackAirUpSwipeColorPickers.Location = new System.Drawing.Point(3, 340);
            this.HammerAttackAirUpSwipeColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackAirUpSwipeColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackAirUpSwipeColorPickers.Name = "HammerAttackAirUpSwipeColorPickers";
            this.HammerAttackAirUpSwipeColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackAirUpSwipeColorPickers.TabIndex = 13;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label41.Location = new System.Drawing.Point(3, 405);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(85, 13);
            this.label41.TabIndex = 16;
            this.label41.Text = "Attack Ground 1";
            // 
            // HammerAttackGround1ColorPickers
            // 
            this.HammerAttackGround1ColorPickers.AutoSize = true;
            this.HammerAttackGround1ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackGround1ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackGround1ColorPickers.Location = new System.Drawing.Point(3, 421);
            this.HammerAttackGround1ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackGround1ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackGround1ColorPickers.Name = "HammerAttackGround1ColorPickers";
            this.HammerAttackGround1ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackGround1ColorPickers.TabIndex = 15;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label42.Location = new System.Drawing.Point(3, 486);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(85, 13);
            this.label42.TabIndex = 18;
            this.label42.Text = "Attack Ground 2";
            // 
            // HammerAttackGround2ColorPickers
            // 
            this.HammerAttackGround2ColorPickers.AutoSize = true;
            this.HammerAttackGround2ColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackGround2ColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackGround2ColorPickers.Location = new System.Drawing.Point(3, 502);
            this.HammerAttackGround2ColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackGround2ColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackGround2ColorPickers.Name = "HammerAttackGround2ColorPickers";
            this.HammerAttackGround2ColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackGround2ColorPickers.TabIndex = 17;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label43.Location = new System.Drawing.Point(3, 567);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(107, 13);
            this.label43.TabIndex = 20;
            this.label43.Text = "Attack Ground Down";
            // 
            // HammerAttackGroundDownColorPickers
            // 
            this.HammerAttackGroundDownColorPickers.AutoSize = true;
            this.HammerAttackGroundDownColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackGroundDownColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackGroundDownColorPickers.Location = new System.Drawing.Point(3, 583);
            this.HammerAttackGroundDownColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackGroundDownColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackGroundDownColorPickers.Name = "HammerAttackGroundDownColorPickers";
            this.HammerAttackGroundDownColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackGroundDownColorPickers.TabIndex = 19;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label44.Location = new System.Drawing.Point(3, 648);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(125, 13);
            this.label44.TabIndex = 22;
            this.label44.Text = "Attack Ground Up Swipe";
            // 
            // HammerAttackGroundUpSwipeColorPickers
            // 
            this.HammerAttackGroundUpSwipeColorPickers.AutoSize = true;
            this.HammerAttackGroundUpSwipeColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackGroundUpSwipeColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackGroundUpSwipeColorPickers.Location = new System.Drawing.Point(3, 664);
            this.HammerAttackGroundUpSwipeColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackGroundUpSwipeColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackGroundUpSwipeColorPickers.Name = "HammerAttackGroundUpSwipeColorPickers";
            this.HammerAttackGroundUpSwipeColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackGroundUpSwipeColorPickers.TabIndex = 21;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label45.Location = new System.Drawing.Point(3, 729);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(71, 13);
            this.label45.TabIndex = 24;
            this.label45.Text = "Attack Stomp";
            // 
            // HammerAttackStompColorPickers
            // 
            this.HammerAttackStompColorPickers.AutoSize = true;
            this.HammerAttackStompColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerAttackStompColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerAttackStompColorPickers.Location = new System.Drawing.Point(3, 745);
            this.HammerAttackStompColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerAttackStompColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerAttackStompColorPickers.Name = "HammerAttackStompColorPickers";
            this.HammerAttackStompColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerAttackStompColorPickers.TabIndex = 23;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label49.Location = new System.Drawing.Point(3, 810);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(64, 13);
            this.label49.TabIndex = 32;
            this.label49.Text = "Shockwave";
            // 
            // HammerShockwaveColorPickers
            // 
            this.HammerShockwaveColorPickers.AutoSize = true;
            this.HammerShockwaveColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerShockwaveColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerShockwaveColorPickers.Location = new System.Drawing.Point(3, 826);
            this.HammerShockwaveColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerShockwaveColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerShockwaveColorPickers.Name = "HammerShockwaveColorPickers";
            this.HammerShockwaveColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerShockwaveColorPickers.TabIndex = 31;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label46.Location = new System.Drawing.Point(3, 891);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(34, 13);
            this.label46.TabIndex = 26;
            this.label46.Text = "Block";
            // 
            // HammerBlockColorPickers
            // 
            this.HammerBlockColorPickers.AutoSize = true;
            this.HammerBlockColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerBlockColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerBlockColorPickers.Location = new System.Drawing.Point(3, 907);
            this.HammerBlockColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerBlockColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerBlockColorPickers.Name = "HammerBlockColorPickers";
            this.HammerBlockColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerBlockColorPickers.TabIndex = 25;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label47.Location = new System.Drawing.Point(3, 972);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(20, 13);
            this.label47.TabIndex = 28;
            this.label47.Text = "Hit";
            // 
            // HammerHitColorPickers
            // 
            this.HammerHitColorPickers.AutoSize = true;
            this.HammerHitColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerHitColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerHitColorPickers.Location = new System.Drawing.Point(3, 988);
            this.HammerHitColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerHitColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerHitColorPickers.Name = "HammerHitColorPickers";
            this.HammerHitColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerHitColorPickers.TabIndex = 27;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label48.Location = new System.Drawing.Point(3, 1053);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(94, 13);
            this.label48.TabIndex = 30;
            this.label48.Text = "Stomp Preparation";
            // 
            // HammerStompPreparationColorPickers
            // 
            this.HammerStompPreparationColorPickers.AutoSize = true;
            this.HammerStompPreparationColorPickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HammerStompPreparationColorPickers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HammerStompPreparationColorPickers.Location = new System.Drawing.Point(3, 1069);
            this.HammerStompPreparationColorPickers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.HammerStompPreparationColorPickers.MinimumSize = new System.Drawing.Size(50, 50);
            this.HammerStompPreparationColorPickers.Name = "HammerStompPreparationColorPickers";
            this.HammerStompPreparationColorPickers.Size = new System.Drawing.Size(50, 50);
            this.HammerStompPreparationColorPickers.TabIndex = 29;
            // 
            // SeinVisualEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(687, 830);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.chkAutoApply);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SeinVisualEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SeinVisualEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.textureImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oriHatTexture)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.flowLayoutPanel44.ResumeLayout(false);
            this.flowLayoutPanel44.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.flowLayoutPanel84.ResumeLayout(false);
            this.flowLayoutPanel84.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox textureImage;
        private System.Windows.Forms.Button btnTextureLoader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkbHideGlow;
        private System.Windows.Forms.CheckBox chkAutoApply;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem visualSettingsToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxSettingName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox chkEnableTrailMesh;
        private System.Windows.Forms.FlowLayoutPanel TorchHitColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchHitSmallColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchGroundAttacks1ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchGroundAttacks2ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchGroundAttacks3ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchBreakColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchAirAttacks1ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchAirAttacks2ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchAirAttacks3ColorPickers;
        private System.Windows.Forms.FlowLayoutPanel TorchVisualSettingsColorPickers;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.FlowLayoutPanel GlideVisualSettingsColorPickers;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel44;
        private System.Windows.Forms.FlowLayoutPanel BowVisualSettingsColorPickers;
        private System.Windows.Forms.FlowLayoutPanel ArrowVisualSettingsColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GoldenSeinVisualSettingsColorPickers;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel84;
        private System.Windows.Forms.FlowLayoutPanel SwordVisualSettingsColorPickers;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.FlowLayoutPanel ChargedColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeAimingColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeChargingColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeExplosionColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeExplosionFracturedColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeFracturedColorPickers;
        private System.Windows.Forms.FlowLayoutPanel GrenadeExplosionChargedColorPickers;
        private System.Windows.Forms.FlowLayoutPanel OriVisualSettingsColorPickers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel HammerVisualSettingsColorPickers;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackAirPokeColorPickers;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackDownAirColorPickers;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackGroundAColorPickers;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackGroundBColorPickers;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackGroundCColorPickers;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.FlowLayoutPanel SwordAttackUpColorPickers;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.FlowLayoutPanel SwordBlockColorPickers;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.FlowLayoutPanel SwordDamageBlueColorPickers;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.FlowLayoutPanel SwordHitColorPickers;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackAir1ColorPickers;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackAir2ColorPickers;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackAir3ColorPickers;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackAirUpSwipeColorPickers;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackGround1ColorPickers;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackGround2ColorPickers;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackGroundDownColorPickers;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackGroundUpSwipeColorPickers;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.FlowLayoutPanel HammerAttackStompColorPickers;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.FlowLayoutPanel HammerBlockColorPickers;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.FlowLayoutPanel HammerHitColorPickers;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.FlowLayoutPanel HammerStompPreparationColorPickers;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.FlowLayoutPanel ArrowHitVisualSettingsColorPickers;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.FlowLayoutPanel HammerShockwaveColorPickers;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultGameSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeActiveSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetActiveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVisualSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSettingToolStripMenuItem;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.FlowLayoutPanel HatVisualSettingsColorPickers;
        private System.Windows.Forms.PictureBox oriHatTexture;
        private System.Windows.Forms.Button btnOriHatTextureLoader;
        private System.Windows.Forms.Button btnRemoveOriHatTexture;
    }
}