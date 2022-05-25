using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Timers;
using System.Drawing.Drawing2D;
using OriWotW.RaceStuff;
using OriWotW.Properties;
using Tem.TemClass;
using Communication.Inject;

namespace OriWotW.UI {

    public enum AbilityType {
        None = 255,
        Bash = 0,
        ChargeFlame = 2,
        WallJump = 3,
        Stomp = 4,
        DoubleJump = 5,
        ChargeJump = 8,
        Magnet = 10,
        UltraMagnet = 11,
        Climb = 12,
        Glide = 14,
        SpiritFlame = 15,
        RapidFlame = 17,
        SplitFlameUpgrade = 18,
        SoulEfficiency = 22,
        WaterBreath = 23,
        ChargeFlameBlast = 27,
        ChargeFlameBurn = 28,
        DoubleJumpUpgrade = 29,
        BashBuff = 30,
        UltraDefense = 31,
        HealthEfficiency = 32,
        Sense = 33,
        UltraStomp = 34,
        SparkFlame = 36,
        QuickFlame = 37,
        MapMarkers = 38,
        EnergyEfficiency = 39,
        HealthMarkers = 40,
        EnergyMarkers = 41,
        AbilityMarkers = 42,
        Rekindle = 43,
        Regroup = 44,
        ChargeFlameEfficiency = 45,
        UltraSoulFlame = 46,
        SoulFlameEfficiency = 47,
        CinderFlame = 48,
        UltraSplitFlame = 49,
        Dash = 50,
        Grenade = 51,
        GrenadeUpgrade = 52,
        ChargeDash = 53,
        AirDash = 54,
        GrenadeEfficiency = 55,
        Bounce = 56,
        SpiritLeash = 57,
        SpiritSlash = 58,
        HeavySpiritSlash = 59,
        FireburstSpell = 60,
        FirewhirlSpell = 61,
        GlowSpell = 62,
        LockOnSpell = 63,
        TimeWarpSpell = 64,
        ShieldSpell = 65,
        EnergyWallSpell = 66,
        InvisibilitySpell = 67,
        TrapSpell = 68,
        WarpSpell = 69,
        LightSpell = 70,
        MindControlSpell = 71,
        MirageSpell = 72,
        StickyMineSpell = 73,
        SpiritSpearSpell = 74,
        LightSpearSpell = 75,
        LifeAbsorbSpell = 76,
        MeditateSpell = 77,
        ChargeShotSpell = 78,
        SpiritShardsSpell = 79,
        SpiritSentrySpell = 80,
        PowerslideSpell = 81,
        CounterstrikeSpell = 82,
        EarthShatterSpell = 83,
        JumpShotSpell = 84,
        RoundupLeashSpell = 85,
        BurrowSpell = 86,
        PowerOfFriendshipSpell = 87,
        LightningSpell = 88,
        SpiritFlareSpell = 89,
        EntanglingRootsSpell = 90,
        MarkOfTheWildsSpell = 91,
        HomingMissileSpell = 92,
        SpiritCrescentSpell = 93,
        MineSpell = 94,
        Pinned = 95,
        Leached = 96,
        Bow = 97,
        Hammer = 98,
        Torch = 99,
        Sword = 100,
        Digging = 101,
        DashNew = 102,
        Launch = 103,
        WaterDash = 104,
        TeleportSpell = 105,
        ChakramSpell = 106,
        Drill = 107,
        GoldenSein = 108,
        BowCharge = 109,
        Swordstaff = 110,
        Chainsword = 111,
        SpiritMagnet = 112,
        SwordCharge = 113,
        HammerCharge = 114,
        Blaze = 115,
        TurretSpell = 116,
        Regenerate = 117,
        FeatherFlap = 118,
        WeaponCharge = 119,
        DamageUpgradeA = 120,
        DamageUpgradeB = 121
    };

    public enum ShardType {
        None = 0,
        GlassCannon = 1,
        TripleJump = 2,
        AntiAir = 3,
        Focus = 4,
        Swap = 5,
        CrescentShot_Deprecated = 6,
        Pierce = 7,
        SpiritMagnet = 8,
        Splinter = 9,
        Blaze_Deprecated = 10,
        Frost_Deprecated = 11,
        LifeLeech_Deprecated = 12,
        Reckless = 13,
        Frenzy = 14,
        Explosive_Deprecated = 15,
        Ricochet = 16,
        Climb_Deprecated = 17,
        Barrier = 18,
        SpiritLightLuck = 19,
        Compass_Deprecated = 20,
        Waterbreathing_Deprecated = 21,
        Vitality = 22,
        VitalityLuck = 23,
        SpiritWellShield_Deprecated = 24,
        EnergyLuck = 25,
        Energy = 26,
        BloodPact = 27,
        LastResort = 28,
        HarvestOfLight_Deprecated = 29,
        Sense = 30,
        UnderwaterEfficiency_Deprecated = 31,
        UltraBash = 32,
        UltraLeash = 33,
        Recycler = 34,
        Counterstrike = 35,
        HollowEnergy = 36,
        Supressor = 37,
        Aggressor = 38,
        Glue = 39,
        CombatLuck = 40,
        SpiritPower = 41,
        Overcharge_Deprecated = 42,
        Untouchable = 43,
        MirrorStrike = 44,
        Stinger = 45,
        Fracture = 46,
        ChainLightning = 47
    };

    public partial class RaceEditor : Form {
        public RaceSettings RaceSettings { get; set; }
        public Manager Manager { get; set; }
        private bool UserChangedValue = false;
        private int SelectedCheckpointIndex = -1;
        public Dictionary<string, bool> AllowedAbilities = new Dictionary<string, bool>();
        static public Dictionary<string, int> AbilityTypeStringIndex = new Dictionary<string, int>() {
            ["None"] = 255,
            ["Bash"] = 0,
            ["ChargeFlame"] = 2,
            ["WallJump"] = 3,
            ["Stomp"] = 4,
            ["DoubleJump"] = 5,
            ["ChargeJump"] = 8,
            ["Magnet"] = 10,
            ["UltraMagnet"] = 11,
            ["Climb"] = 12,
            ["Glide"] = 14,
            ["SpiritFlame"] = 15,
            ["RapidFlame"] = 17,
            ["SplitFlameUpgrade"] = 18,
            ["SoulEfficiency"] = 22,
            ["WaterBreath"] = 23,
            ["ChargeFlameBlast"] = 27,
            ["ChargeFlameBurn"] = 28,
            ["DoubleJumpUpgrade"] = 29,
            ["BashBuff"] = 30,
            ["UltraDefense"] = 31,
            ["HealthEfficiency"] = 32,
            ["Sense"] = 33,
            ["UltraStomp"] = 34,
            ["SparkFlame"] = 36,
            ["QuickFlame"] = 37,
            ["MapMarkers"] = 38,
            ["EnergyEfficiency"] = 39,
            ["HealthMarkers"] = 40,
            ["EnergyMarkers"] = 41,
            ["AbilityMarkers"] = 42,
            ["Rekindle"] = 43,
            ["Regroup"] = 44,
            ["ChargeFlameEfficiency"] = 45,
            ["UltraSoulFlame"] = 46,
            ["SoulFlameEfficiency"] = 47,
            ["CinderFlame"] = 48,
            ["UltraSplitFlame"] = 49,
            ["Dash"] = 50,
            ["Grenade"] = 51,
            ["GrenadeUpgrade"] = 52,
            ["ChargeDash"] = 53,
            ["AirDash"] = 54,
            ["GrenadeEfficiency"] = 55,
            ["Bounce"] = 56,
            ["SpiritLeash"] = 57,
            ["SpiritSlash"] = 58,
            ["HeavySpiritSlash"] = 59,
            ["FireburstSpell"] = 60,
            ["FirewhirlSpell"] = 61,
            ["GlowSpell"] = 62,
            ["LockOnSpell"] = 63,
            ["TimeWarpSpell"] = 64,
            ["ShieldSpell"] = 65,
            ["EnergyWallSpell"] = 66,
            ["InvisibilitySpell"] = 67,
            ["TrapSpell"] = 68,
            ["WarpSpell"] = 69,
            ["LightSpell"] = 70,
            ["MindControlSpell"] = 71,
            ["MirageSpell"] = 72,
            ["StickyMineSpell"] = 73,
            ["SpiritSpearSpell"] = 74,
            ["LightSpearSpell"] = 75,
            ["LifeAbsorbSpell"] = 76,
            ["MeditateSpell"] = 77,
            ["ChargeShotSpell"] = 78,
            ["SpiritShardsSpell"] = 79,
            ["SpiritSentrySpell"] = 80,
            ["PowerslideSpell"] = 81,
            ["CounterstrikeSpell"] = 82,
            ["EarthShatterSpell"] = 83,
            ["JumpShotSpell"] = 84,
            ["RoundupLeashSpell"] = 85,
            ["BurrowSpell"] = 86,
            ["PowerOfFriendshipSpell"] = 87,
            ["LightningSpell"] = 88,
            ["SpiritFlareSpell"] = 89,
            ["EntanglingRootsSpell"] = 90,
            ["MarkOfTheWildsSpell"] = 91,
            ["HomingMissileSpell"] = 92,
            ["SpiritCrescentSpell"] = 93,
            ["MineSpell"] = 94,
            ["Pinned"] = 95,
            ["Leached"] = 96,
            ["Bow"] = 97,
            ["Hammer"] = 98,
            ["Torch"] = 99,
            ["Sword"] = 100,
            ["Digging"] = 101,
            ["DashNew"] = 102,
            ["Launch"] = 103,
            ["WaterDash"] = 104,
            ["TeleportSpell"] = 105,
            ["ChakramSpell"] = 106,
            ["Drill"] = 107,
            ["GoldenSein"] = 108,
            ["BowCharge"] = 109,
            ["Swordstaff"] = 110,
            ["Chainsword"] = 111,
            ["SpiritMagnet"] = 112,
            ["SwordCharge"] = 113,
            ["HammerCharge"] = 114,
            ["Blaze"] = 115,
            ["TurretSpell"] = 116,
            ["Regenerate"] = 117,
            ["FeatherFlap"] = 118,
            ["WeaponCharge"] = 119,
            ["DamageUpgradeA"] = 120,
            ["DamageUpgradeB"] = 121,
            ["BlazeUpgrade"] = 256,
            ["ChakramUpgrade"] = 257,
            ["Shockwave"] = 258,
            ["SpiritSentryUpgrade"] = 259,
            ["SpiritSpearUpgrade"] = 260,
        };
        static public Dictionary<int, int> ShardMaxLevel = new Dictionary<int, int>() {
            //None = 0,
            [1] = 0,
            [2] = 0,
            [3] = 0,
            [4] = 0,
            [5] = 0,
            //CrescentShot_Deprecated = 6,
            //Pierce = 7,
            [8] = 1,
            [9] = 2,
            //Blaze_Deprecated = 10,
            //Frost_Deprecated = 11,
            //LifeLeech_Deprecated = 12,
            [13] = 2,
            [14] = 0,
            //Explosive_Deprecated = 15,
            //Ricochet = 16,
            //Climb_Deprecated = 17,
            [18] = 3,
            [19] = 2,
            //Compass_Deprecated = 20,
            //Waterbreathing_Deprecated = 21,
            [22] = 2,
            [23] = 0,
            //SpiritWellShield_Deprecated = 24,
            [25] = 0,
            [26] = 2,
            [27] = 0,
            [28] = 0,
            //HarvestOfLight_Deprecated = 29,
            [30] = 0,
            //UnderwaterEfficiency_Deprecated = 31,
            [32] = 1,
            [33] = 2,
            [34] = 0,
            [35] = 1,
            [36] = 1,
            [37] = 0,
            [38] = 0,
            [39] = 0,
            [40] = 1,
            [41] = 1,
            //Overcharge_Deprecated = 42,
            [43] = 2,
            [44] = 0,
            //Stinger = 45,
            [46] = 0,
            [47] = 0
        };
        public Dictionary<int, int> AbilityTypeIndexString = new Dictionary<int, int>();
        public Dictionary<string, int> ShardTypeIndexString = new Dictionary<string, int>();
        static public List<string> AbilitiesBound = new List<string>() { "None", "Spirit Edge", "Spirit Arc", "Spike", "Spirit Smash", "Spirit Star", "Light Burst", "Regenerate", "Flap", "Blaze", "Flash", "Sentry", "Launch" };
        public int SeinFacesDirection = 0;

        public RaceEditor(Manager manager) {
            Manager = manager;
            Application.EnableVisualStyles();
            InitializeComponent();

            this.BoundAbility1.AllowDrop = true;
            this.BoundAbility2.AllowDrop = true;
            this.BoundAbility3.AllowDrop = true;

            this.EquippedShard1.AllowDrop = true;
            this.EquippedShard2.AllowDrop = true;
            this.EquippedShard3.AllowDrop = true;
            this.EquippedShard4.AllowDrop = true;
            this.EquippedShard5.AllowDrop = true;
            this.EquippedShard6.AllowDrop = true;
            this.EquippedShard7.AllowDrop = true;
            this.EquippedShard8.AllowDrop = true;

            this.checkpointList.View = System.Windows.Forms.View.Details;
            this.checkpointList.FullRowSelect = true;
            this.RaceSettings = new RaceSettings();

            foreach (var ability in AbilityTypeStringIndex) {
                Button button = new Button();
                Object img = Resources.ResourceManager.GetObject("abilityIcon" + ability.Key + "_off");
                if (img != null) {
                    button.BackgroundImage = (Image)img;
                    button.BackgroundImageLayout = ImageLayout.Zoom;
                    button.Height = button.Width = 64;
                    button.ForeColor = button.BackColor = SystemColors.ActiveCaptionText;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Name = "abilityIcon" + ability.Key + "_off";
                    button.MouseDown += buttonState_Click;
                    button.MouseUp += OnMouseUp;
                    button.MouseMove += OnMouseMove;
                    this.toolTip1.SetToolTip(button, ability.Key);
                    AbilityTypeIndexString[ability.Value] = abiltiesSpellsList.Controls.Count;
                    abiltiesSpellsList.Controls.Add(button);
                }

                /*CheckBox checkBox = new CheckBox();
                checkBox.Name = ability.Key;
                checkBox.Text = ability.Key;
                checkBox.CheckedChanged += checkbox_Changed;
                checkBox.Enter += input_Enter;
                checkBox.Leave += input_Leave;*/
                //abiltiesSpellsList.Controls.Add(checkBox);
            }

            var values = Enum.GetValues(typeof(ShardType));
            foreach (var shardType in values) {
                int shardIndex = (int)(ShardType)shardType;
                Button button = new Button();
                Object img = Resources.ResourceManager.GetObject("Shard" + shardType.ToString() + "_off");
                if (img != null) {
                    Bitmap newImage = ResizeImage((Image)img, 54, 54);
                    button.Image = newImage;
                    button.Height = button.Width = 64;
                    button.BackgroundImageLayout = ImageLayout.Zoom;
                    button.ForeColor = button.BackColor = SystemColors.ActiveCaptionText;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Name = "Shard" + shardType.ToString() + "_off";
                    button.MouseDown += buttonShardState_Click;
                    button.MouseUp += OnMouseUp;
                    button.MouseMove += OnMouseMove;
                    this.toolTip1.SetToolTip(button, shardType.ToString() + " - " + shardIndex.ToString());

                    if (ShardMaxLevel.ContainsKey(shardIndex) == true) {
                        int maxLevel = ShardMaxLevel[shardIndex];
                        Object imgt;
                        OriWotW.RaceStuff.Shard newShard = new OriWotW.RaceStuff.Shard();
                        newShard.Active = false;
                        newShard.Level = 0;
                        newShard.ShardType = (int)(ShardType)shardType;
                        switch (maxLevel) {
                            case 0:
                                imgt = Resources.ResourceManager.GetObject("shardFrame1Level0");
                                button.BackgroundImage = (Image)imgt;
                                newShard.MaxLevel = 0;
                                break;
                            case 1:
                                imgt = Resources.ResourceManager.GetObject("shardFrame2Level0");
                                button.BackgroundImage = (Image)imgt;
                                newShard.MaxLevel = 1;
                                break;
                            case 2:
                                imgt = Resources.ResourceManager.GetObject("shardFrame3Level0");
                                button.BackgroundImage = (Image)imgt;
                                newShard.MaxLevel = 2;
                                break;
                            case 3:
                                imgt = Resources.ResourceManager.GetObject("shardFrame4Level0");
                                button.BackgroundImage = (Image)imgt;
                                newShard.MaxLevel = 3;
                                break;
                            case 4:
                                imgt = Resources.ResourceManager.GetObject("shardFrame5Level0");
                                button.BackgroundImage = (Image)imgt;
                                newShard.MaxLevel = 4;
                                break;
                        }
                        this.RaceSettings.ShardsInInventory[shardIndex] = newShard;
                    }
                    ShardTypeIndexString["Shard" + shardType.ToString()] = shardIndex;
                    shardList.Controls.Add(button);
                }

                /*CheckBox checkBox = new CheckBox();
                int shardIndex = (int)(ShardType)shardType;
                checkBox.Name = shardIndex.ToString();
                checkBox.Text = shardType.ToString();
                checkBox.CheckedChanged += checkboxShards_Changed;
                checkBox.Enter += input_Enter;
                checkBox.Leave += input_Leave;

                shardList.Controls.Add(checkBox);*/
            }
        }

        public Bitmap ResizeImage(Image img, int width, int height) {
            Bitmap newImage = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(newImage)) {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(img, new Rectangle(0, 0, width, height));
            }
            return newImage;
        }

        private void InsertCheckpoints() {
            for (int i = 0; i < RaceSettings.RaceCheckpoints.Count(); i++) {
                var checkpoint = RaceSettings.RaceCheckpoints[i];

                ListViewItem item1 = new ListViewItem(i.ToString(), 0);
                item1.SubItems.Add(checkpoint.x.ToString("F4", CultureInfo.CreateSpecificCulture("en-US")));
                item1.SubItems.Add(checkpoint.y.ToString("F4", CultureInfo.CreateSpecificCulture("en-US")));
                item1.SubItems.Add(checkpoint.w.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")));
                item1.SubItems.Add(checkpoint.h.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")));

                this.checkpointList.Items.Add(item1);
            }
        }

        private void InsertCheckpoint(Vector3 checkpoint) {
            ListViewItem item1 = new ListViewItem(this.checkpointList.Items.Count.ToString(), 0);
            item1.SubItems.Add(checkpoint.X.ToString());
            item1.SubItems.Add(checkpoint.Y.ToString());
            item1.SubItems.Add(3.0.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")));
            item1.SubItems.Add(15.0.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")));

            this.checkpointList.Items.Add(item1);
            this.RaceSettings.AddCheckpoint(checkpoint);
        }

        private void setStart_Click(object sender, EventArgs e) {
            RaceSettings.SetStart(Manager.Memory.Position());
            SetStartPosition();
        }

        private void SetStartPosition() {
            startX.Value = (decimal)RaceSettings.GetStart().X;
            startY.Value = (decimal)RaceSettings.GetStart().Y;
            startZ.Value = (decimal)RaceSettings.GetStart().Z;
            InjectCommunication._Instance.AddCall("CALL21");
        }

        private void setFinish_Click(object sender, EventArgs e) {
            RaceSettings.SetFinish(Manager.Memory.Position());
            SetFinishPosition();
        }

        private void SetFinishPosition() {
            finishX.Value = (decimal)RaceSettings.GetFinish().X;
            finishY.Value = (decimal)RaceSettings.GetFinish().Y;
            finishZ.Value = (decimal)RaceSettings.GetFinish().Z;
        }

        private void createCheckpoint_Click(object sender, EventArgs e) {
            RaceSettings.AddCheckpoint(Manager.Memory.Position());
            Vector3 pos = Manager.Memory.Position();
            InjectCommunication._Instance.AddCall("CALL13PAR" + pos.ToString());
            InsertCheckpoint(pos);
        }

        private void saveRace_Click(object sender, EventArgs e) {
            RaceSettings.SetAbilitiesStates(AllowedAbilities);
            this.RaceSettings.Ability1Bound = this.BoundAbility1.Tag == null ? "None" : this.BoundAbility1.Tag.ToString().Replace("abilityIcon", "").Replace("_off", "");// Ability1List.SelectedItem.ToString();
            this.RaceSettings.Ability2Bound = this.BoundAbility2.Tag == null ? "None" : this.BoundAbility2.Tag.ToString().Replace("abilityIcon", "").Replace("_off", ""); //Ability2List.SelectedItem.ToString();
            this.RaceSettings.Ability3Bound = this.BoundAbility3.Tag == null ? "None" : this.BoundAbility3.Tag.ToString().Replace("abilityIcon", "").Replace("_off", ""); //Ability3List.SelectedItem.ToString();

            this.RaceSettings.ShardsEquipped.Shard1 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard1.Tag == null ? "None" : this.EquippedShard1.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard2 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard2.Tag == null ? "None" : this.EquippedShard2.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard3 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard3.Tag == null ? "None" : this.EquippedShard3.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard4 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard4.Tag == null ? "None" : this.EquippedShard4.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard5 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard5.Tag == null ? "None" : this.EquippedShard5.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard6 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard6.Tag == null ? "None" : this.EquippedShard6.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard7 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard7.Tag == null ? "None" : this.EquippedShard7.Tag.ToString().Replace("Shard", "").Replace("_off", ""));
            this.RaceSettings.ShardsEquipped.Shard8 = (int)Enum.Parse(typeof(ShardType), this.EquippedShard8.Tag == null ? "None" : this.EquippedShard8.Tag.ToString().Replace("Shard", "").Replace("_off", ""));

            RaceSettings.SaveRace(RaceSettings);
        }

        private void loadRace_Click(object sender, EventArgs e) {
            CleanRaceEditor();
            LoadRace(true);
        }

        public void LoadRace(bool isEditor = false) {
            RaceSettings = RaceSettings.LoadRace();
            InsertCheckpoints();
            SetStartPosition();
            SetFinishPosition();
            SetRaceName();
            AllowedAbilities = RaceSettings.GetAbilitiesStates();
            UpdateAbilitiesStates();
            UpdateShardStates();
            this.seinFaceDirection.Checked = this.RaceSettings.GetFacesDirection() == 0 ? true : false;

            Object img = Resources.ResourceManager.GetObject("abilityIcon" + this.RaceSettings.Ability1Bound);
            if (img != null) {
                BoundAbility1.BackgroundImage = (Image)img;
                BoundAbility1.Tag = "abilityIcon" + this.RaceSettings.Ability1Bound;
            }

            img = Resources.ResourceManager.GetObject("abilityIcon" + this.RaceSettings.Ability2Bound);
            if (img != null) {
                BoundAbility2.BackgroundImage = (Image)img;
                BoundAbility2.Tag = "abilityIcon" + this.RaceSettings.Ability2Bound;
            }

            img = Resources.ResourceManager.GetObject("abilityIcon" + this.RaceSettings.Ability3Bound);
            if (img != null) {
                BoundAbility3.BackgroundImage = (Image)img;
                BoundAbility3.Tag = "abilityIcon" + this.RaceSettings.Ability3Bound;
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard1).ToString());
            if (img != null) {
                EquippedShard1.BackgroundImage = (Image)img;
                EquippedShard1.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard1).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard2).ToString());
            if (img != null) {
                EquippedShard2.BackgroundImage = (Image)img;
                EquippedShard2.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard2).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard3).ToString());
            if (img != null) {
                EquippedShard3.BackgroundImage = (Image)img;
                EquippedShard3.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard3).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard4).ToString());
            if (img != null) {
                EquippedShard4.BackgroundImage = (Image)img;
                EquippedShard4.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard4).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard5).ToString());
            if (img != null) {
                EquippedShard5.BackgroundImage = (Image)img;
                EquippedShard5.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard5).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard6).ToString());
            if (img != null) {
                EquippedShard6.BackgroundImage = (Image)img;
                EquippedShard6.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard6).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard7).ToString());
            if (img != null) {
                EquippedShard7.BackgroundImage = (Image)img;
                EquippedShard7.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard7).ToString();
            }

            img = Resources.ResourceManager.GetObject("Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard8).ToString());
            if (img != null) {
                EquippedShard8.BackgroundImage = (Image)img;
                EquippedShard8.Tag = "Shard" + ((ShardType)this.RaceSettings.ShardsEquipped.Shard8).ToString();
            }

            string racePath = AppDomain.CurrentDomain.BaseDirectory + "\\RaceSettings\\" + RaceSettings.GetRaceName() + "\\";
            if (Directory.Exists(racePath) == false)
                Directory.CreateDirectory(racePath);

            RaceSettings.SetRacePath(racePath);

            if (File.Exists(racePath + RaceSettings.GetRaceName() + ".race"))
                InjectCommunication._Instance.AddCall("CALL16PAR" + racePath + RaceSettings.GetRaceName() + ".race" + "|" + (!isEditor).ToString());
        }

        private void UpdateAbilitiesStates() {
            int index = 0;

            if (abiltiesSpellsList.Controls.Count > 0) {
                foreach (var state in AllowedAbilities) {
                    int key = int.Parse(state.Key);
                    if (AbilityTypeIndexString.ContainsKey(key)) {
                        Button button = abiltiesSpellsList.Controls[AbilityTypeIndexString[key]] as Button;

                        if (state.Value == true) {
                            Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                            button.BackgroundImage = (Image)img;
                            button.Name = button.Name.Replace("_off", "");
                        } else {
                            Object img = Resources.ResourceManager.GetObject(button.Name);
                            button.BackgroundImage = (Image)img;
                        }
                    }
                    index++;
                }
            }
        }

        private void UpdateShardStates() {
            int index = 0;

            if (shardList.Controls.Count > 0) {
                var values = Enum.GetValues(typeof(ShardType));

                foreach (var shard in values) {
                    int shardIndex = (int)(ShardType)shard;

                    if (ShardTypeIndexString.ContainsKey("Shard" + shard.ToString())) {
                        int raceSettingsShardsIndex = ShardTypeIndexString["Shard" + shard.ToString()];
                        //bool state = this.RaceSettings.ShardsInInventory[raceSettingsShardsIndex];

                        if (shardList.Controls.Count > index && shardList.Controls[index] != null) {
                            Button button = shardList.Controls[index] as Button;
                            SetShardGraphic(button, 0);

                            /*if (state == true) {
                                Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                                button.BackgroundImage = (Image)img;
                                button.Name = button.Name.Replace("_off", "");
                            } else {
                                Object img = Resources.ResourceManager.GetObject(button.Name);
                                button.BackgroundImage = (Image)img;
                            }*/
                        }
                        index++;
                    }
                }
            }
        }

        private void newRace_Click(object sender, EventArgs e) {
            string newRaceName = raceName.Text;
            CleanRaceEditor();
            if (newRaceName != "") {
                RaceSettings = new RaceSettings();
                RaceSettings.SetRaceName(newRaceName);
                string racePath = AppDomain.CurrentDomain.BaseDirectory + "\\RaceSettings\\" + RaceSettings.GetRaceName() + "\\";
                if (Directory.Exists(racePath) == false)
                    Directory.CreateDirectory(racePath);

                RaceSettings.SetRacePath(racePath);
                SetRaceName();
            }
        }

        private void removeCheckpoint_Click(object sender, EventArgs e) {
            RaceSettings.RemoveCheckpoint(SelectedCheckpointIndex);
            InjectCommunication._Instance.AddCall("CALL15PAR" + SelectedCheckpointIndex.ToString());
            checkpointList.Items.Remove(checkpointList.Items[SelectedCheckpointIndex]);
        }

        private void checkpointList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            SelectedCheckpointIndex = this.checkpointList.FocusedItem.Index;
            Checkpoint checkpoint = RaceSettings.GetCheckpoint(SelectedCheckpointIndex);
            this.positionX.Value = (decimal)checkpoint.x;
            this.positionY.Value = (decimal)checkpoint.y;
            this.sizeX.Value = (decimal)checkpoint.w;
            this.sizeY.Value = (decimal)checkpoint.h;
        }

        private void raceName_TextChanged(object sender, EventArgs e) {
            RaceSettings.SetRaceName(raceName.Text);
        }

        private void SetRaceName() {
            raceName.Text = RaceSettings.GetRaceName();
        }

        private void input_Enter(object sender, EventArgs e) {
            UserChangedValue = true;
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            UserChangedValue = false;
            this.Manager.rawInput.AddMessageFilter();
        }

        private void position_ValueChanged(object sender, EventArgs e) {
            if (UserChangedValue == true) {
                InjectCommunication._Instance.AddCall("CALL18PAR" + positionX.Value.ToString("F4", CultureInfo.CreateSpecificCulture("en-US")) + ";" + positionY.Value.ToString("F4", CultureInfo.CreateSpecificCulture("en-US")) +
                    "|" + sizeX.Value.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")) + ";" + sizeY.Value.ToString("F3", CultureInfo.CreateSpecificCulture("en-US")) + ";0|" + SelectedCheckpointIndex);
                this.checkpointList.FocusedItem.SubItems[1].Text = positionX.Value.ToString("F4", CultureInfo.CreateSpecificCulture("en-US"));
                this.checkpointList.FocusedItem.SubItems[2].Text = positionY.Value.ToString("F4", CultureInfo.CreateSpecificCulture("en-US"));
                this.checkpointList.FocusedItem.SubItems[3].Text = sizeX.Value.ToString("F3", CultureInfo.CreateSpecificCulture("en-US"));
                this.checkpointList.FocusedItem.SubItems[4].Text = sizeY.Value.ToString("F3", CultureInfo.CreateSpecificCulture("en-US"));
                Vector3 position = new Vector3();
                position.X = (float)positionX.Value;
                position.Y = (float)positionY.Value;
                position.Z = 0.0f;
                Vector3 scale = new Vector3();
                scale.X = (float)sizeY.Value;
                scale.Y = (float)sizeX.Value;
                scale.Z = 0.0f;
                RaceSettings.SetCheckpointPosition(position, scale, SelectedCheckpointIndex);
            }
        }

        private void CleanRaceEditor() {
            this.checkpointList.Items.Clear();
            this.raceName.Text = "";
            this.startX.Value = 0;
            this.startY.Value = 0;
            this.startZ.Value = 0;
            this.finishX.Value = 0;
            this.finishY.Value = 0;
            this.finishZ.Value = 0;
            this.positionX.Value = 0;
            this.positionY.Value = 0;
            this.sizeX.Value = 0;
            this.sizeY.Value = 0;

            foreach (var control in abiltiesSpellsList.Controls) {
                Button button = control as Button;
                button.Name = button.Name.Replace("_off", "");
                Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                button.BackgroundImage = (Image)img;
                button.Name += "_off";
            }

            foreach (var control in abiltiesSpellsList.Controls) {
                Button button = control as Button;
                button.Name = button.Name.Replace("_off", "");
                Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                button.BackgroundImage = (Image)img;
                button.Name += "_off";
            }

            BoundAbility3.BackgroundImage = BoundAbility2.BackgroundImage = BoundAbility1.BackgroundImage = null;
            EquippedShard8.BackgroundImage = EquippedShard7.BackgroundImage = EquippedShard6.BackgroundImage = EquippedShard5.BackgroundImage = EquippedShard4.BackgroundImage = EquippedShard3.BackgroundImage = EquippedShard2.BackgroundImage = EquippedShard1.BackgroundImage = null;
        }

        private void startRace_Click(object sender, EventArgs e) {
            StartRace(true);
        }

        public void StartRace(bool isEditor = false) {
            RaceSettings.SaveRace(this.RaceSettings);
            if (File.Exists(RaceSettings.GetRacePath() + RaceSettings.GetRaceName() + ".race") == false)
                LoadRace(isEditor);

            if (File.Exists(RaceSettings.GetRacePath() + RaceSettings.GetRaceName() + ".race"))
                InjectCommunication._Instance.AddCall("CALL14PAR" + RaceSettings.GetRacePath() + RaceSettings.GetRaceName() + ".race");
        }

        public void LoadAndRun(bool isEditor = false) {
            CleanRaceEditor();
            LoadRace(isEditor);

            InjectCommunication._Instance.AddCall("CALL14PAR" + RaceSettings.GetRacePath() + RaceSettings.GetRaceName() + ".race");
        }

        private void button1_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL20");
        }

        private void seinFaceDirection_CheckedChanged(object sender, EventArgs e) {
            this.RaceSettings.SetFacesDirection(this.seinFaceDirection.Checked == true ? 0 : 1);
        }

        private void buttonState_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            int index = AbilityTypeStringIndex[button.Name.Replace("abilityIcon", "").Replace("_off", "")];

            if (button.Name.EndsWith("_off") == true) {
                Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                button.BackgroundImage = (Image)img;
                button.Name = button.Name.Replace("_off", "");
                AllowedAbilities[index.ToString()] = true;
                this.RaceSettings.SetAbilitiesStates(AllowedAbilities);
                this.OldDragValue = 0;
            } else {
                Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                button.BackgroundImage = (Image)img;
                button.Name += "_off";
                AllowedAbilities[index.ToString()] = false;
                this.RaceSettings.SetAbilitiesStates(AllowedAbilities);
                this.OldDragValue = 1;
            }

            OnMouseDown(sender, (MouseEventArgs)e);
        }

        private void SetShardGraphic(Button button, int amount) {
            int index = ShardTypeIndexString[button.Name.Replace("_off", "")];

            if (ShardMaxLevel.ContainsKey(index) == true && this.RaceSettings.ShardsInInventory.ContainsKey(index) == true) {
                int maxLevel = ShardMaxLevel[index];
                int currentLevel = this.RaceSettings.ShardsInInventory[index].Level;
                currentLevel += amount;
                Object imgt;
                switch (maxLevel) {
                    case 0:
                        if (currentLevel > 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = currentLevel;
                            this.RaceSettings.ShardsInInventory[index].Level = Math.Min(this.RaceSettings.ShardsInInventory[index].Level, this.RaceSettings.ShardsInInventory[index].MaxLevel + 1);
                            imgt = Resources.ResourceManager.GetObject("shardFrame1Level");// + this.RaceSettings.ShardsInInventory[index].Level.ToString());
                        } else if (currentLevel == 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = 0;
                            imgt = Resources.ResourceManager.GetObject("shardFrame1Level0");
                        } else {
                            imgt = Resources.ResourceManager.GetObject("shardFrame1Level0");
                        }
                        button.BackgroundImage = (Image)imgt;
                        break;
                    case 1:
                        if (currentLevel > 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = currentLevel;
                            this.RaceSettings.ShardsInInventory[index].Level = Math.Min(this.RaceSettings.ShardsInInventory[index].Level, this.RaceSettings.ShardsInInventory[index].MaxLevel + 1);
                            imgt = Resources.ResourceManager.GetObject("shardFrame2Level" + this.RaceSettings.ShardsInInventory[index].Level.ToString());
                        } else if (currentLevel == 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = 0;
                            imgt = Resources.ResourceManager.GetObject("shardFrame2Level0");
                        } else {
                            imgt = Resources.ResourceManager.GetObject("shardFrame2Level0");
                        }
                        button.BackgroundImage = (Image)imgt;
                        break;
                    case 2:
                        if (currentLevel > 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = currentLevel;
                            this.RaceSettings.ShardsInInventory[index].Level = Math.Min(this.RaceSettings.ShardsInInventory[index].Level, this.RaceSettings.ShardsInInventory[index].MaxLevel + 1);
                            imgt = Resources.ResourceManager.GetObject("shardFrame3Level" + this.RaceSettings.ShardsInInventory[index].Level.ToString());
                        } else if (currentLevel == 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = 0;
                            imgt = Resources.ResourceManager.GetObject("shardFrame3Level0");
                        } else {
                            imgt = Resources.ResourceManager.GetObject("shardFrame3Level0");
                        }
                        button.BackgroundImage = (Image)imgt;
                        break;
                    case 3:
                        if (currentLevel > 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = currentLevel;
                            this.RaceSettings.ShardsInInventory[index].Level = Math.Min(this.RaceSettings.ShardsInInventory[index].Level, this.RaceSettings.ShardsInInventory[index].MaxLevel + 1);
                            imgt = Resources.ResourceManager.GetObject("shardFrame4Level" + this.RaceSettings.ShardsInInventory[index].Level.ToString());
                        } else if (currentLevel == 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = 0;
                            imgt = Resources.ResourceManager.GetObject("shardFrame4Level0");
                        } else {
                            imgt = Resources.ResourceManager.GetObject("shardFrame4Level0");
                        }
                        button.BackgroundImage = (Image)imgt;
                        break;
                    case 4:
                        if (currentLevel > 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = currentLevel;
                            this.RaceSettings.ShardsInInventory[index].Level = Math.Min(this.RaceSettings.ShardsInInventory[index].Level, this.RaceSettings.ShardsInInventory[index].MaxLevel + 1);
                            imgt = Resources.ResourceManager.GetObject("shardFrame5Level" + this.RaceSettings.ShardsInInventory[index].Level.ToString());
                        } else if (currentLevel == 0) {
                            this.RaceSettings.ShardsInInventory[index].Level = 0;
                            imgt = Resources.ResourceManager.GetObject("shardFrame5Level0");
                        } else {
                            imgt = Resources.ResourceManager.GetObject("shardFrame5Level0");
                        }
                        button.BackgroundImage = (Image)imgt;
                        break;
                }

                if (this.RaceSettings.ShardsInInventory[index].Level > 0) {
                    Object img = Resources.ResourceManager.GetObject(button.Name.Replace("_off", ""));
                    if (img != null) {
                        Bitmap newImage = ResizeImage((Image)img, 54, 54);
                        button.Image = newImage;
                    }
                    //button.BackgroundImage = (Image)img;
                    button.Name = button.Name.Replace("_off", "");
                    this.RaceSettings.ShardsInInventory[index].Active = true;
                    this.OldDragValue = 0;
                } else {
                    Object img = Resources.ResourceManager.GetObject(button.Name + "_off");
                    if (img != null) {
                        Bitmap newImage = ResizeImage((Image)img, 54, 54);
                        button.Image = newImage;
                    }
                    //button.BackgroundImage = (Image)img;
                    button.Name += "_off";
                    this.RaceSettings.ShardsInInventory[index].Active = false;
                    this.OldDragValue = 1;
                }
            }
        }

        private void buttonShardState_Click(object sender, EventArgs e) {
            MouseEventArgs ee = e as MouseEventArgs;
            if (ee.Button == MouseButtons.Left) {
                SetShardGraphic((Button)sender, 1);
            } else if (ee.Button == MouseButtons.Right) {
                SetShardGraphic((Button)sender, -1);
            }
            OnMouseDown(sender, (MouseEventArgs)e);
        }

        private void dragButtonState_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pictureBox = sender as PictureBox;

            if (e.Button == MouseButtons.Right) {
                if (pictureBox.Tag != null) {
                    pictureBox.BackgroundImage = null;
                    pictureBox.Tag = "None";
                }
            }
        }

        private void butSaveUber_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL26");
        }

        private void butLoadUber_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL27");
        }

        private void butSaveAs_Click(object sender, EventArgs e) {
            /*DialogResult result = this.folderBrowserDialog1.ShowDialog();

             if (result == DialogResult.OK || result == DialogResult.Yes) {
                 this.RaceSettings.SetRacePath(this.folderBrowserDialog1.SelectedPath);
             }*/
        }

        private void butLoadNRun_Click(object sender, EventArgs e) {
            LoadAndRun(true);
        }

        private void butRaceFileFixer_Click(object sender, EventArgs e) {
            RaceFixer raceFixer = new RaceFixer();
            raceFixer.Show();
        }
    }
}
