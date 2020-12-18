using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Text.Json.Serialization.Converters;
using System.Reflection;

namespace OriWotW.UI {
    public partial class SeinVisualEditor : Form {
        private SeinVisualSettings VisualSettings = new SeinVisualSettings();
        private SeinVisualSetting SeinVisualSettings = new SeinVisualSetting();
        private Manager Manager;
        private ColorWheel ColorWheel = new ColorWheel();
        private Dictionary<string, int> ExistingVisualSettings = new Dictionary<string, int>();
        private Dictionary<string, FlowLayoutPanel> PickerLayouts = new Dictionary<string, FlowLayoutPanel>();

        public SeinVisualEditor(Manager manager) {
            Application.EnableVisualStyles();
            InitializeComponent();

            List<Control> allControls = new List<Control>();
            foreach (Control control in this.Controls) {
                allControls.Add(control);
            }
            while (allControls.Count > 0) {
                Control control = allControls[0];
                allControls.RemoveAt(0);
                if (control.GetType() == typeof(FlowLayoutPanel)) {
                    FlowLayoutPanel panel = control as FlowLayoutPanel;
                    PickerLayouts.Add(panel.Name.Replace("ColorPickers", ""), panel);

                    foreach (Control control1 in control.Controls)
                        allControls.Add(control1);
                } else
                    foreach (Control control1 in control.Controls)
                        allControls.Add(control1);
            }

            this.Manager = manager;
            this.LoadVisualSettings();
        }

        private void LoadVisualSettings() {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings") == true) {
                string jsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
                this.VisualSettings = JsonSerializer.Deserialize<SeinVisualSettings>(jsonString);
                this.SeinVisualSettings = this.VisualSettings.ActiveVisualSetting;

                if (this.SeinVisualSettings == null) {
                    this.SeinVisualSettings = new SeinVisualSetting();
                }

                foreach (SeinVisualSetting setting in this.VisualSettings.VisualSettings) {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = setting.SettingName;
                    item.Text = setting.SettingName;
                    item.Click += Item_Click;
                    visualSettingsToolStripMenuItem.DropDownItems.Add(item);
                    ExistingVisualSettings.Add(item.Name, ExistingVisualSettings.Count());
                }

                LoadColorPickers();
                this.ApplyVisualSettings();
                if (SeinVisualSettings.AutoApplyOnStartup == true)
                    this.Manager.InjectCommunication.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
            } else {
                LoadColorPickers();
                this.ApplyVisualSettings();
            }
        }

        private void ResetSettingsDropdownList() {
            ExistingVisualSettings.Clear();
            this.visualSettingsToolStripMenuItem.DropDownItems.Clear();
            foreach (SeinVisualSetting setting in this.VisualSettings.VisualSettings) {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = setting.SettingName;
                item.Text = setting.SettingName;
                item.Click += Item_Click;
                visualSettingsToolStripMenuItem.DropDownItems.Add(item);
                ExistingVisualSettings.Add(item.Name, ExistingVisualSettings.Count());
            }
        }

        private void ApplyVisualSettings() {
            if (this.SeinVisualSettings != null) {
                if (Path.IsPathRooted(this.SeinVisualSettings.OriVisualSettings.TexturePath) == true && File.Exists(this.SeinVisualSettings.OriVisualSettings.TexturePath) == true) {
                    this.textureImage.Image = Image.FromFile(this.SeinVisualSettings.OriVisualSettings.TexturePath);
                    this.textureImage.SizeMode = PictureBoxSizeMode.StretchImage;
                } else {
                    if (Path.IsPathRooted(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.TexturePath) == true && File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.TexturePath) == true) {
                        this.textureImage.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.TexturePath);
                        this.textureImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    } else {
                        this.textureImage.Image = null;
                    }
                }

                this.chkbHideGlow.Checked = this.SeinVisualSettings.OriVisualSettings.HideGlow;
                this.chkAutoApply.Checked = this.SeinVisualSettings.AutoApplyOnStartup;
                this.tbxSettingName.Text = this.SeinVisualSettings.SettingName;
            }
        }

        private void ResetVisualSettings() {
            this.textureImage.Image = null;
            this.chkbHideGlow.Checked = this.SeinVisualSettings.OriVisualSettings.HideGlow;
            this.chkAutoApply.Checked = this.SeinVisualSettings.AutoApplyOnStartup;

            this.ApplyVisualSettings();
        }

        private void Item_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SeinVisualSetting setting = this.VisualSettings.GetSettingByName(item.Name);

            if (setting != null) {
                this.SeinVisualSettings = setting;
                this.VisualSettings.ActiveVisualSetting = setting;
                this.SaveVisualSettings();
                if (SeinVisualSettings.AutoApplyOnStartup == true)
                    this.Manager.InjectCommunication.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
            }
        }

        private void SaveVisualSettings() {
            this.VisualSettings.SaveActiveSetting();
            this.ResetSettingsDropdownList();
            string jsonString = JsonSerializer.Serialize(this.VisualSettings);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings", jsonString);
        }

        private void btnTextureLoader_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "Texture file (*.dds)|*.dds|(*.png)|*.png|(*.jpeg)|*.jpeg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

FileErrorBrowseAgain:
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;

                    if (Path.HasExtension(filePath) == false)
                        goto FileErrorBrowseAgain;

                    if (Path.GetExtension(filePath) != ".dds" && Path.GetExtension(filePath) != ".png" && Path.GetExtension(filePath) != ".jpeg")
                        goto FileErrorBrowseAgain;

                    if (File.Exists(filePath) == false)
                        goto FileErrorBrowseAgain;

                    this.SeinVisualSettings.OriVisualSettings.TexturePath = filePath;
                    this.textureImage.Image = Image.FromFile(this.SeinVisualSettings.OriVisualSettings.TexturePath);
                    this.textureImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.SaveVisualSettings();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.SaveVisualSettings();
            this.Manager.InjectCommunication.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
        }

        private void chkbHideGlow_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.SeinVisualSettings.OriVisualSettings.HideGlow = checkBox.Checked;
        }

        private void chkAutoApply_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.SeinVisualSettings.AutoApplyOnStartup = checkBox.Checked;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e) {
            string name = this.tbxSettingName.Text;

            if (name == "")
                name = "Visual Setting " + this.VisualSettings.VisualSettings.Count.ToString();

            this.SeinVisualSettings.SettingName = name;

            if (this.ExistingVisualSettings.ContainsKey(this.SeinVisualSettings.SettingName) == false) {
                this.VisualSettings.VisualSettings.Add(this.SeinVisualSettings);
                this.ExistingVisualSettings.Add(name, this.ExistingVisualSettings.Count());
            }

            this.SaveVisualSettings();
        }

        private void input_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        private void resetActiveSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.NukeVisualSettings();
            this.ResetVisualSettings();
        }

        private void NukeVisualSettings() {
            this.SeinVisualSettings = new SeinVisualSetting();
        }
        private void chkEnableTrailMesh_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.SeinVisualSettings.TorchVisualSettings.TorchTrailMeshEnable = checkBox.Checked;
        }

        private void removeActiveSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            int index = 0;
            for (int i = 0; i < this.VisualSettings.VisualSettings.Count(); i++) {
                if (this.VisualSettings.VisualSettings[i].SettingName == this.SeinVisualSettings.SettingName)
                    index = i;
            }
            this.VisualSettings.VisualSettings.RemoveAt(index);
            this.VisualSettings.ActiveVisualSetting = new SeinVisualSetting();
            this.SeinVisualSettings = new SeinVisualSetting();
            this.NukeVisualSettings();
            this.ResetVisualSettings();
            this.ResetSettingsDropdownList();
        }

        private void LoadColorPickers() {
            var value = TE.GetPropertyObjectsByType(SeinVisualSettings, "SeinVisualSettings", typeof(TColorPicker));
            foreach (var property in value) {
                string fieldName = property.Key.Name;
                TColorPicker picker = (TColorPicker)property.Value;
                picker.PickerSize = new Point(32, 32);
                picker.Size = new Size(146, 38);
                picker.Name = fieldName;
                Label label = new Label();
                label.Text = fieldName + ":";
                label.Size = new Size(131, 38);
                label.TextAlign = ContentAlignment.MiddleRight;
                picker.SetColor(picker.Color.Value);

                if (PickerLayouts.ContainsKey(property.Key.Parent) == true) {
                    PickerLayouts[property.Key.Parent].Controls.Add(label);
                    PickerLayouts[property.Key.Parent].Controls.Add(picker);
                }
            }
        }
    }

    public class ArrowVisualSettings {
        public TColorPicker ArrowEffect { get; set; } = new TColorPicker();
        public TColorPicker ArrowEffectEmissive { get; set; } = new TColorPicker();
        public TColorPicker ArrowSpear { get; set; } = new TColorPicker();
        public TColorPicker ArrowSpearEmissive { get; set; } = new TColorPicker();
        public TColorPicker TipImpact { get; set; } = new TColorPicker();
        public TColorPicker TipImpactEmissive { get; set; } = new TColorPicker();
        public TColorPicker TipParticle { get; set; } = new TColorPicker();
        public TColorPicker TipParticleEmissive { get; set; } = new TColorPicker();

        public ArrowVisualSettings() { }

        public ArrowVisualSettings(ArrowVisualSettings setting) {
            this.ArrowEffect = setting.ArrowEffect;
            this.ArrowEffectEmissive = setting.ArrowEffectEmissive;
            this.ArrowSpear = setting.ArrowSpear;
            this.ArrowSpearEmissive = setting.ArrowSpearEmissive;
            this.TipImpact = setting.TipImpact;
            this.TipImpactEmissive = setting.TipImpactEmissive;
            this.TipParticle = setting.TipParticle;
            this.TipParticleEmissive = setting.TipParticleEmissive;
        }
    }

    public class BowVisualSettings {
        public TColorPicker BowShaft { get; set; } = new TColorPicker();
        public TColorPicker BowShaftEmissive { get; set; } = new TColorPicker();
        public TColorPicker BowString { get; set; } = new TColorPicker();
        public TColorPicker BowStringEmissive { get; set; } = new TColorPicker();
        public ArrowVisualSettings ArrowVisualSettings { get; set; } = new ArrowVisualSettings();

        public BowVisualSettings() { }

        public BowVisualSettings(BowVisualSettings setting) {
            this.BowShaft = setting.BowShaft;
            this.BowShaftEmissive = setting.BowShaftEmissive;
            this.BowString = setting.BowString;
            this.BowStringEmissive = setting.BowStringEmissive;
            this.ArrowVisualSettings = new ArrowVisualSettings(setting.ArrowVisualSettings);
        }
    }

    public class GlideVisualSettings {
        public TColorPicker Feather { get; set; } = new TColorPicker();
        public TColorPicker FeatherEmissive { get; set; } = new TColorPicker();
        public TColorPicker Featherflap { get; set; } = new TColorPicker();
        public TColorPicker FeatherflapEmissive { get; set; } = new TColorPicker();

        public GlideVisualSettings() { }

        public GlideVisualSettings(GlideVisualSettings setting) {
            this.Feather = setting.Feather;
            this.FeatherEmissive = setting.FeatherEmissive;
            this.Featherflap = setting.Featherflap;
            this.FeatherflapEmissive = setting.FeatherflapEmissive;
        }
    }

    public class TorchHit {
        public TColorPicker FsBox { get; set; } = new TColorPicker();
        public TColorPicker FlameFireC { get; set; } = new TColorPicker();
        public TColorPicker FlameGlow { get; set; } = new TColorPicker();
        public TColorPicker FireEffect { get; set; } = new TColorPicker();
        public TColorPicker FireEffect2 { get; set; } = new TColorPicker();
        public TColorPicker RadialBurned { get; set; } = new TColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = new TColorPicker();
        public TColorPicker SpriteSnowPattern { get; set; } = new TColorPicker();
        public TColorPicker Glow { get; set; } = new TColorPicker();
        public TColorPicker GlowUnmask { get; set; } = new TColorPicker();

        public override string ToString() {
            return FsBox.ToString() + "|" + FlameFireC.ToString() + "|" + FlameGlow.ToString() + "|" + FireEffect.ToString() + "|" + FireEffect2.ToString() + "|" + RadialBurned.ToString() + "|" + RadialBurned2.ToString() + "|" + SpriteSnowPattern.ToString() + "|" + Glow.ToString() + "|" + GlowUnmask.ToString();
        }
    }
    public class TorchBreak {
        public TColorPicker AcidParticles { get; set; } = new TColorPicker();
        public TColorPicker CharacterGlow { get; set; } = new TColorPicker();

        public override string ToString() {
            return AcidParticles.ToString() + "|" + AcidParticles.ToString();
        }
    }
    public class TorchAttack {
        public TColorPicker FireSprite { get; set; } = new TColorPicker();
        public TColorPicker TrailZigZag { get; set; } = new TColorPicker();

        public override string ToString() {
            return FireSprite.ToString() + "|" + TrailZigZag.ToString();
        }

        public TorchAttack() { }

        public TorchAttack(TorchAttack setting) {
            this.FireSprite = setting.FireSprite;
            this.TrailZigZag = setting.TrailZigZag;
        }
    }

    public class TorchVisualSetting {
        public bool HideGlow { get; set; } = false;
        public TColorPicker Torch { get; set; } = new TColorPicker();
        public TColorPicker TorchFloatingSpark { get; set; } = new TColorPicker();
        public TColorPicker TorchRunning { get; set; } = new TColorPicker();
        public bool TorchTrailMeshEnable { get; set; } = false;
        public TColorPicker TorchTrailMesh { get; set; } = new TColorPicker();
        public TorchAttack TorchAirAttacks1 { get; set; } = new TorchAttack();
        public TorchAttack TorchAirAttacks2 { get; set; } = new TorchAttack();
        public TorchAttack TorchAirAttacks3 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks1 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks2 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks3 { get; set; } = new TorchAttack();
        public TorchBreak TorchBreak { get; set; } = new TorchBreak();
        public TorchHit TorchHit { get; set; } = new TorchHit();
        public TorchHit TorchHitSmall { get; set; } = new TorchHit();
        public TColorPicker TorchLightEffect { get; set; } = new TColorPicker();
        public TColorPicker TorchSpark { get; set; } = new TColorPicker();

        public TorchVisualSetting() { }

        public TorchVisualSetting(TorchVisualSetting settings) {
            this.HideGlow = settings.HideGlow;
            this.TorchAirAttacks1 = new TorchAttack(settings.TorchAirAttacks1);
            this.TorchAirAttacks2 = new TorchAttack(settings.TorchAirAttacks2);
            this.TorchAirAttacks3 = new TorchAttack(settings.TorchAirAttacks3);

            TorchBreak torchBreak = new TorchBreak();
            torchBreak.AcidParticles = settings.TorchBreak.AcidParticles;
            torchBreak.CharacterGlow = settings.TorchBreak.CharacterGlow;
            this.TorchBreak = torchBreak;

            this.Torch = settings.Torch;
            this.TorchFloatingSpark = settings.TorchFloatingSpark;

            this.TorchGroundAttacks1 = new TorchAttack(settings.TorchGroundAttacks1);
            this.TorchGroundAttacks2 = new TorchAttack(settings.TorchGroundAttacks2);
            this.TorchGroundAttacks3 = new TorchAttack(settings.TorchGroundAttacks3);

            TorchHit torchHit = new TorchHit();
            torchHit.FireEffect = settings.TorchHit.FireEffect;
            torchHit.FireEffect2 = settings.TorchHit.FireEffect2;
            torchHit.FlameFireC = settings.TorchHit.FlameFireC;
            torchHit.FlameGlow = settings.TorchHit.FlameGlow;
            torchHit.FsBox = settings.TorchHit.FsBox;
            torchHit.Glow = settings.TorchHit.Glow;
            torchHit.GlowUnmask = settings.TorchHit.GlowUnmask;
            torchHit.RadialBurned = settings.TorchHit.RadialBurned;
            torchHit.RadialBurned2 = settings.TorchHit.RadialBurned2;
            torchHit.SpriteSnowPattern = settings.TorchHit.SpriteSnowPattern;
            this.TorchHit = torchHit;

            TorchHit torchHitSmall = new TorchHit();
            torchHitSmall.FireEffect = settings.TorchHitSmall.FireEffect;
            torchHitSmall.FireEffect2 = settings.TorchHitSmall.FireEffect2;
            torchHitSmall.FlameFireC = settings.TorchHitSmall.FlameFireC;
            torchHitSmall.FlameGlow = settings.TorchHitSmall.FlameGlow;
            torchHitSmall.FsBox = settings.TorchHitSmall.FsBox;
            torchHitSmall.Glow = settings.TorchHitSmall.Glow;
            torchHitSmall.GlowUnmask = settings.TorchHitSmall.GlowUnmask;
            torchHitSmall.RadialBurned = settings.TorchHitSmall.RadialBurned;
            torchHitSmall.RadialBurned2 = settings.TorchHitSmall.RadialBurned2;
            torchHitSmall.SpriteSnowPattern = settings.TorchHitSmall.SpriteSnowPattern;
            this.TorchHitSmall = torchHitSmall;

            this.TorchLightEffect = settings.TorchLightEffect;
            this.TorchRunning = settings.TorchRunning;
            this.TorchSpark = settings.TorchSpark;
            this.TorchTrailMesh = settings.TorchTrailMesh;
            this.TorchTrailMeshEnable = settings.TorchTrailMeshEnable;
        }
    }
    public class GrenadeEffect {
        public TColorPicker FireEffect { get; set; } = new TColorPicker();
        public TColorPicker Flame1 { get; set; } = new TColorPicker();
        public TColorPicker Flame2 { get; set; } = new TColorPicker();
        public TColorPicker Flame3 { get; set; } = new TColorPicker();
        public TColorPicker Smoke { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern1 { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern3 { get; set; } = new TColorPicker();
        public TColorPicker FireSprite { get; set; } = new TColorPicker();
        public TColorPicker LightCircle { get; set; } = new TColorPicker();
        public TColorPicker MainTrail { get; set; } = new TColorPicker();
        public TColorPicker ProtectiveLight { get; set; } = new TColorPicker();
        public TColorPicker TrailZigZag { get; set; } = new TColorPicker();

        public GrenadeEffect() { }

        public GrenadeEffect(GrenadeEffect setting) {
            this.FireEffect = setting.FireEffect;
            this.Flame1 = setting.Flame1;
            this.Flame2 = setting.Flame2;
            this.Flame3 = setting.Flame3;
            this.Smoke = setting.Smoke;
            this.SnowPattern1 = setting.SnowPattern1;
            this.SnowPattern2 = setting.SnowPattern2;
            this.SnowPattern3 = setting.SnowPattern3;
            this.FireSprite = setting.FireSprite;
            this.LightCircle = setting.LightCircle;
            this.MainTrail = setting.MainTrail;
            this.ProtectiveLight = setting.ProtectiveLight;
            this.TrailZigZag = setting.TrailZigZag;
        }
    }
    public class GrenadeExplosionFractured {
        public TColorPicker Burst { get; set; } = new TColorPicker();
        public TColorPicker Distortion { get; set; } = new TColorPicker();
        public TColorPicker BurstPreGlow { get; set; } = new TColorPicker();
        public TColorPicker ArrowDistortion { get; set; } = new TColorPicker();
        public TColorPicker ArrowGlow { get; set; } = new TColorPicker();
        public TColorPicker ArrowSingleParticle { get; set; } = new TColorPicker();
        public TColorPicker ArrowSmoke { get; set; } = new TColorPicker();
        public TColorPicker ArrowVignette { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();

        public GrenadeExplosionFractured() { }

        public GrenadeExplosionFractured(GrenadeExplosionFractured setting) {
            this.Burst = setting.Burst;
            this.Distortion = setting.Distortion;
            this.BurstPreGlow = setting.BurstPreGlow;
            this.ArrowDistortion = setting.ArrowDistortion;
            this.ArrowGlow = setting.ArrowGlow;
            this.ArrowSingleParticle = setting.ArrowSingleParticle;
            this.ArrowSmoke = setting.ArrowSmoke;
            this.ArrowVignette = setting.ArrowVignette;
            this.SnowPattern = setting.SnowPattern;
        }
    }
    public class GrenadeFractured {
        public TColorPicker OriSparkle { get; set; } = new TColorPicker();
        public TColorPicker OuterGlow { get; set; } = new TColorPicker();
        public TColorPicker ParticleDropGlow { get; set; } = new TColorPicker();
        public TColorPicker ParticleImpactGlow { get; set; } = new TColorPicker();
        public TColorPicker SingleSnowParticle { get; set; } = new TColorPicker();
        public TColorPicker SharedCircleGlow { get; set; } = new TColorPicker();
        public TColorPicker Sprite { get; set; } = new TColorPicker();
        public TColorPicker Trail { get; set; } = new TColorPicker();

        public GrenadeFractured() { }

        public GrenadeFractured(GrenadeFractured setting) {
            this.OriSparkle = setting.OriSparkle;
            this.OuterGlow = setting.OuterGlow;
            this.ParticleDropGlow = setting.ParticleDropGlow;
            this.ParticleImpactGlow = setting.ParticleImpactGlow;
            this.SingleSnowParticle = setting.SingleSnowParticle;
            this.SharedCircleGlow = setting.SharedCircleGlow;
            this.Sprite = setting.Sprite;
            this.Trail = setting.Trail;
        }
    }
    public class GrenadeExplosionEffect {
        public TColorPicker ForceField { get; set; } = new TColorPicker();
        public TColorPicker Distortion { get; set; } = new TColorPicker();
        public TColorPicker LightCircle { get; set; } = new TColorPicker();
        public TColorPicker LightGlow { get; set; } = new TColorPicker();
        public TColorPicker StarSpike { get; set; } = new TColorPicker();
        public TColorPicker FX { get; set; } = new TColorPicker();
        public TColorPicker FireEffect { get; set; } = new TColorPicker();
        public TColorPicker Smoke { get; set; } = new TColorPicker();
        public TColorPicker SpriteSheetFire { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();
        public TColorPicker RadialBurned { get; set; } = new TColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = new TColorPicker();
        public TColorPicker RadialCrack { get; set; } = new TColorPicker();
        public TColorPicker RadialIrisImpact { get; set; } = new TColorPicker();

        public GrenadeExplosionEffect() { }

        public GrenadeExplosionEffect(GrenadeExplosionEffect setting) {
            this.ForceField = setting.ForceField;
            this.Distortion = setting.Distortion;
            this.LightCircle = setting.LightCircle;
            this.LightGlow = setting.LightGlow;
            this.StarSpike = setting.StarSpike;
            this.FX = setting.FX;
            this.FireEffect = setting.FireEffect;
            this.Smoke = setting.Smoke;
            this.SpriteSheetFire = setting.SpriteSheetFire;
            this.SnowPattern = setting.SnowPattern;
            this.RadialBurned = setting.RadialBurned;
            this.RadialBurned2 = setting.RadialBurned2;
            this.RadialCrack = setting.RadialCrack;
            this.RadialIrisImpact = setting.RadialIrisImpact;
            this.ForceField = setting.ForceField;
            this.Distortion = setting.Distortion;
        }
    }
    public class GrenadeCharging {
        public TColorPicker VignetteMask1 { get; set; } = new TColorPicker();
        public TColorPicker VignetteMask2 { get; set; } = new TColorPicker();
        public TColorPicker ArcaneOrb { get; set; } = new TColorPicker();
        public TColorPicker ChargingJump { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();
        public TColorPicker EnergySplash { get; set; } = new TColorPicker();

        public GrenadeCharging() { }

        public GrenadeCharging(GrenadeCharging setting) {
            this.VignetteMask1 = setting.VignetteMask1;
            this.VignetteMask2 = setting.VignetteMask2;
            this.ArcaneOrb = setting.ArcaneOrb;
            this.ChargingJump = setting.ChargingJump;
            this.SnowPattern = setting.SnowPattern;
            this.EnergySplash = setting.EnergySplash;
        }
    }
    public class GrenadeAiming {
        public TColorPicker Sparkle { get; set; } = new TColorPicker();
        public TColorPicker OuterGlow { get; set; } = new TColorPicker();
        public TColorPicker Sprite1 { get; set; } = new TColorPicker();
        public TColorPicker Sprite2 { get; set; } = new TColorPicker();

        public GrenadeAiming() { }

        public GrenadeAiming(GrenadeAiming setting) {
            this.Sparkle = setting.Sparkle;
            this.OuterGlow = setting.OuterGlow;
            this.Sprite1 = setting.Sprite1;
            this.Sprite2 = setting.Sprite2;
        }
    }
    public class GrenadeVisualSettings {
        public GrenadeEffect Grenade { get; set; } = new GrenadeEffect();
        public GrenadeEffect Charged { get; set; } = new GrenadeEffect();
        public GrenadeAiming GrenadeAiming { get; set; } = new GrenadeAiming();
        public GrenadeCharging GrenadeCharging { get; set; } = new GrenadeCharging();
        public GrenadeExplosionEffect GrenadeExplosion { get; set; } = new GrenadeExplosionEffect();
        public GrenadeExplosionEffect GrenadeExplosionCharged { get; set; } = new GrenadeExplosionEffect();
        public GrenadeFractured GrenadeFractured { get; set; } = new GrenadeFractured();
        public GrenadeExplosionFractured GrenadeExplosionFractured { get; set; } = new GrenadeExplosionFractured();

        public GrenadeVisualSettings() { }

        public GrenadeVisualSettings(GrenadeVisualSettings setting) {
            this.Charged = new GrenadeEffect(setting.Charged);
            this.Grenade = new GrenadeEffect(setting.Grenade);
            this.GrenadeAiming = new GrenadeAiming(setting.GrenadeAiming);
            this.GrenadeCharging = new GrenadeCharging(setting.GrenadeCharging);
            this.GrenadeExplosion = new GrenadeExplosionEffect(setting.GrenadeExplosion);
            this.GrenadeExplosionCharged = new GrenadeExplosionEffect(setting.GrenadeExplosionCharged);
            this.GrenadeFractured = new GrenadeFractured(setting.GrenadeFractured);
            this.GrenadeExplosionFractured = new GrenadeExplosionFractured(setting.GrenadeExplosionFractured);
        }

    }
    public class HammerStompPreparation {
        public TColorPicker FireSprite3Flip { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();

        public HammerStompPreparation() { }

        public HammerStompPreparation(HammerStompPreparation setting) {
            this.FireSprite3Flip = setting.FireSprite3Flip;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class HammerHit {
        public TColorPicker DistortionNew { get; set; } = new TColorPicker();
        public TColorPicker FxBox { get; set; } = new TColorPicker();
        public TColorPicker Glow { get; set; } = new TColorPicker();

        public HammerHit() { }

        public HammerHit(HammerHit setting) {
            this.DistortionNew = setting.DistortionNew;
            this.FxBox = setting.FxBox;
            this.Glow = setting.Glow;
        }
    }
    public class HammerBlock {
        public TColorPicker AcidParticles { get; set; } = new TColorPicker();
        public TColorPicker Glow { get; set; } = new TColorPicker();
        public TColorPicker CharacterGlow { get; set; } = new TColorPicker();
        public TColorPicker Circle { get; set; } = new TColorPicker();
        public TColorPicker LavaFountainA { get; set; } = new TColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = new TColorPicker();

        public HammerBlock() { }

        public HammerBlock(HammerBlock setting) {
            this.AcidParticles = setting.AcidParticles;
            this.Glow = setting.Glow;
            this.CharacterGlow = setting.CharacterGlow;
            this.Circle = setting.Circle;
            this.LavaFountainA = setting.LavaFountainA;
            this.SingleSnowParticleA = setting.SingleSnowParticleA;
        }
    }
    public class HammerStomp {
        public TColorPicker Glow { get; set; } = new TColorPicker();
        public TColorPicker GiftLeafTransformationLightRing { get; set; } = new TColorPicker();
        public TColorPicker Glow1 { get; set; } = new TColorPicker();
        public TColorPicker Smoke { get; set; } = new TColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = new TColorPicker();

        public HammerStomp() { }

        public HammerStomp(HammerStomp setting) {
            this.Glow = setting.Glow;
            this.GiftLeafTransformationLightRing = setting.GiftLeafTransformationLightRing;
            this.Glow1 = setting.Glow1;
            this.Smoke = setting.Smoke;
            this.SingleSnowParticleA = setting.SingleSnowParticleA;
        }
    }
    public class HammerAttack {
        public TColorPicker FireSprite { get; set; } = new TColorPicker();
        public TColorPicker LinearGradientMask { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();
        public TColorPicker EnergyEffect { get; set; } = new TColorPicker();
        public TColorPicker SpriteSnowPettern2 { get; set; } = new TColorPicker();

        public HammerAttack() { }

        public HammerAttack(HammerAttack setting) {
            this.FireSprite = setting.FireSprite;
            this.LinearGradientMask = setting.LinearGradientMask;
            this.VignetteMaskC = setting.VignetteMaskC;
            this.SpriteSnowPettern2 = setting.SpriteSnowPettern2;
        }
    }
    public class HammerVisualSettings {
        public TColorPicker Hammer { get; set; } = new TColorPicker();
        public TColorPicker HammerEmissive { get; set; } = new TColorPicker();
        public TColorPicker HammerHitEffect { get; set; } = new TColorPicker();
        public TColorPicker HammerHitEffectEmissive { get; set; } = new TColorPicker();
        public HammerAttack HammerAttackAir1 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAir2 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAir3 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAirUpSwipe { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGround1 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGround2 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGroundDown { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGroundUpSwipe { get; set; } = new HammerAttack();
        public HammerStomp HammerAttackStomp { get; set; } = new HammerStomp();
        public HammerBlock HammerBlock { get; set; } = new HammerBlock();
        public HammerHit HammerHit { get; set; } = new HammerHit();
        public HammerStompPreparation HammerStompPreparation { get; set; } = new HammerStompPreparation();

        public HammerVisualSettings() { }

        public HammerVisualSettings(HammerVisualSettings setting) {
            this.Hammer = setting.Hammer;
            this.HammerEmissive = setting.HammerEmissive;
            this.HammerHitEffect = setting.HammerHitEffect;
            this.HammerHitEffectEmissive = setting.HammerHitEffectEmissive;
            this.HammerAttackAir1 = new HammerAttack(setting.HammerAttackAir1);
            this.HammerAttackAir2 = new HammerAttack(setting.HammerAttackAir2);
            this.HammerAttackAir3 = new HammerAttack(setting.HammerAttackAir3);
            this.HammerAttackAirUpSwipe = new HammerAttack(setting.HammerAttackAirUpSwipe);
            this.HammerAttackGround1 = new HammerAttack(setting.HammerAttackGround1);
            this.HammerAttackGround2 = new HammerAttack(setting.HammerAttackGround2);
            this.HammerAttackGroundDown = new HammerAttack(setting.HammerAttackGroundDown);
            this.HammerAttackGroundUpSwipe = new HammerAttack(setting.HammerAttackGroundUpSwipe);
            this.HammerAttackStomp = new HammerStomp(setting.HammerAttackStomp);
            this.HammerBlock = new HammerBlock(setting.HammerBlock);
            this.HammerHit = new HammerHit(setting.HammerHit);
            this.HammerStompPreparation = new HammerStompPreparation(setting.HammerStompPreparation);
        }
    }
    public class SwordAttackAirPoke {
        public TColorPicker BlowingSand { get; set; } = new TColorPicker();
        public TColorPicker Glow { get; set; } = new TColorPicker();

        public SwordAttackAirPoke() { }

        public SwordAttackAirPoke(SwordAttackAirPoke setting) {
            this.BlowingSand = setting.BlowingSand;
            this.Glow = setting.Glow;
        }
    }
    public class SwordAttack {
        public TColorPicker EnergyEffect { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();
        public TColorPicker FireSprite { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();

        public SwordAttack() { }

        public SwordAttack(SwordAttack setting) {
            this.EnergyEffect = setting.EnergyEffect;
            this.SnowPattern = setting.SnowPattern;
            this.FireSprite = setting.FireSprite;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class SwordAttackC {
        public TColorPicker BlowingSand { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();

        public SwordAttackC() { }

        public SwordAttackC(SwordAttackC setting) {
            this.BlowingSand = setting.BlowingSand;
            this.SnowPattern = setting.SnowPattern;
            this.SnowPattern2 = setting.SnowPattern2;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class SwordBlock {
        public TColorPicker AcidParticles { get; set; } = new TColorPicker();
        public TColorPicker CharacterGlow { get; set; } = new TColorPicker();
        public TColorPicker Distortion { get; set; } = new TColorPicker();
        public TColorPicker Circle { get; set; } = new TColorPicker();
        public TColorPicker FxBox { get; set; } = new TColorPicker();
        public TColorPicker CircleGlowC { get; set; } = new TColorPicker();
        public TColorPicker NoiseCaustic { get; set; } = new TColorPicker();
        public TColorPicker LavaFountainA { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern { get; set; } = new TColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = new TColorPicker();
        public TColorPicker StarSpike { get; set; } = new TColorPicker();
        public TColorPicker Glow { get; set; } = new TColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = new TColorPicker();

        public SwordBlock() { }

        public SwordBlock(SwordBlock setting) {
            this.AcidParticles = setting.AcidParticles;
            this.CharacterGlow = setting.CharacterGlow;
            this.Distortion = setting.Distortion;
            this.Circle = setting.Circle;
            this.FxBox = setting.FxBox;
            this.CircleGlowC = setting.CircleGlowC;
            this.NoiseCaustic = setting.NoiseCaustic;
            this.LavaFountainA = setting.LavaFountainA;
            this.SnowPattern = setting.SnowPattern;
            this.SnowPattern2 = setting.SnowPattern2;
            this.StarSpike = setting.StarSpike;
            this.Glow = setting.Glow;
            this.SingleSnowParticleA = setting.SingleSnowParticleA;
        }
    }
    public class SwordDamageBlue {
        public TColorPicker BurningCoreParticles { get; set; } = new TColorPicker();
        public TColorPicker BurnMarks { get; set; } = new TColorPicker();
        public TColorPicker ImpactSparklesA { get; set; } = new TColorPicker();
        public TColorPicker DebrisParticles { get; set; } = new TColorPicker();
        public TColorPicker Distortion { get; set; } = new TColorPicker();
        public TColorPicker ImpactCenter { get; set; } = new TColorPicker();
        public TColorPicker SmokeParticles { get; set; } = new TColorPicker();
        public TColorPicker SparkStartParticles { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();

        public SwordDamageBlue() { }

        public SwordDamageBlue(SwordDamageBlue setting) {
            this.BurningCoreParticles = setting.BurningCoreParticles;
            this.BurnMarks = setting.BurnMarks;
            this.ImpactSparklesA = setting.ImpactSparklesA;
            this.DebrisParticles = setting.DebrisParticles;
            this.Distortion = setting.Distortion;
            this.ImpactCenter = setting.ImpactCenter;
            this.SmokeParticles = setting.SmokeParticles;
            this.SparkStartParticles = setting.SparkStartParticles;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class SwordHit {
        public TColorPicker DistortionNew { get; set; } = new TColorPicker();
        public TColorPicker FxBox { get; set; } = new TColorPicker();
        public TColorPicker DropGlowB { get; set; } = new TColorPicker();
        public TColorPicker DebrisParticles { get; set; } = new TColorPicker();
        public TColorPicker DebrisParticlesFallBig { get; set; } = new TColorPicker();
        public TColorPicker GlowUnmask { get; set; } = new TColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = new TColorPicker();
        public TColorPicker LensCrossStart { get; set; } = new TColorPicker();
        public TColorPicker LensFlare20b { get; set; } = new TColorPicker();
        public TColorPicker LensFlare9 { get; set; } = new TColorPicker();
        public TColorPicker LensRadialSpike { get; set; } = new TColorPicker();
        public TColorPicker LightCircleShape { get; set; } = new TColorPicker();
        public TColorPicker LightGlow { get; set; } = new TColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = new TColorPicker();
        public TColorPicker RadialLightRays { get; set; } = new TColorPicker();
        public TColorPicker RadialMaskB { get; set; } = new TColorPicker();
        public TColorPicker SparksLong { get; set; } = new TColorPicker();
        public TColorPicker SplashEdge { get; set; } = new TColorPicker();
        public TColorPicker SplashEdge2 { get; set; } = new TColorPicker();
        public TColorPicker StarSpike2 { get; set; } = new TColorPicker();

        public SwordHit() { }

        public SwordHit(SwordHit setting) {
            this.DistortionNew = setting.DistortionNew;
            this.FxBox = setting.FxBox;
            this.DropGlowB = setting.DropGlowB;
            this.DebrisParticles = setting.DebrisParticles;
            this.DebrisParticlesFallBig = setting.DebrisParticlesFallBig;
            this.GlowUnmask = setting.GlowUnmask;
            this.VignetteMaskC = setting.VignetteMaskC;
            this.LensCrossStart = setting.LensCrossStart;
            this.LensFlare20b = setting.LensFlare20b;
            this.LensFlare9 = setting.LensFlare9;
            this.LensRadialSpike = setting.LensRadialSpike;
            this.LightCircleShape = setting.LightCircleShape;
            this.LightGlow = setting.LightGlow;
            this.RadialBurned2 = setting.RadialBurned2;
            this.RadialLightRays = setting.RadialLightRays;
            this.RadialMaskB = setting.RadialMaskB;
            this.SparksLong = setting.SparksLong;
            this.SplashEdge = setting.SplashEdge;
            this.SplashEdge2 = setting.SplashEdge2;
            this.StarSpike2 = setting.StarSpike2;
        }
    }
    public class SwordVisualSettings {
        public TColorPicker Sword { get; set; } = new TColorPicker();
        public TColorPicker SwordEmissive { get; set; } = new TColorPicker();
        public TColorPicker SwordHitEffect { get; set; } = new TColorPicker();
        public TColorPicker SwordHitEffectEmissive { get; set; } = new TColorPicker();
        public SwordAttackAirPoke SwordAttackAirPoke { get; set; } = new SwordAttackAirPoke();
        public SwordAttack SwordAttackDownAir { get; set; } = new SwordAttack();
        public SwordAttack SwordAttackGroundA { get; set; } = new SwordAttack();
        public SwordAttack SwordAttackGroundB { get; set; } = new SwordAttack();
        public SwordAttackC SwordAttackGroundC { get; set; } = new SwordAttackC();
        public SwordAttack SwordAttackUp { get; set; } = new SwordAttack();
        public SwordBlock SwordBlock { get; set; } = new SwordBlock();
        public SwordDamageBlue SwordDamageBlue { get; set; } = new SwordDamageBlue();
        public SwordHit SwordHit { get; set; } = new SwordHit();

        public SwordVisualSettings() { }

        public SwordVisualSettings(SwordVisualSettings setting) {
            this.Sword = setting.Sword;
            this.SwordEmissive = setting.SwordEmissive;
            this.SwordHitEffect = setting.SwordHitEffect;
            this.SwordHitEffectEmissive = setting.SwordHitEffectEmissive;
            this.SwordAttackAirPoke = new SwordAttackAirPoke(setting.SwordAttackAirPoke);
            this.SwordAttackDownAir = new SwordAttack(setting.SwordAttackDownAir);
            this.SwordAttackGroundA = new SwordAttack(setting.SwordAttackGroundA);
            this.SwordAttackGroundB = new SwordAttack(setting.SwordAttackGroundB);
            this.SwordAttackGroundC = new SwordAttackC(setting.SwordAttackGroundC);
            this.SwordAttackUp = new SwordAttack(setting.SwordAttackUp);
            this.SwordBlock = new SwordBlock(setting.SwordBlock);
            this.SwordDamageBlue = new SwordDamageBlue(setting.SwordDamageBlue);
            this.SwordHit = new SwordHit(setting.SwordHit);
        }
    }
    public class GoldenSeinVisualSettings {
        public TColorPicker SeinBody { get; set; } = new TColorPicker();
        public TColorPicker SeinBodyEmissive { get; set; } = new TColorPicker();
        public TColorPicker SeinParticle { get; set; } = new TColorPicker();
        public TColorPicker SeinRadialLight { get; set; } = new TColorPicker();
        public TColorPicker SeinTrail { get; set; } = new TColorPicker();
        public TColorPicker SeinTrailMesh { get; set; } = new TColorPicker();

        public GoldenSeinVisualSettings() { }

        public GoldenSeinVisualSettings(GoldenSeinVisualSettings setting) {
            this.SeinBody = setting.SeinBody;
            this.SeinBodyEmissive = setting.SeinBodyEmissive;
            this.SeinParticle = setting.SeinParticle;
            this.SeinRadialLight = setting.SeinRadialLight;
            this.SeinTrail = setting.SeinTrail;
            this.SeinTrailMesh = setting.SeinTrailMesh;
        }
    }
    public class OriVisualSettings {
        public TColorPicker Ori { get; set; } = new TColorPicker();
        public TColorPicker OriGlow { get; set; } = new TColorPicker();
        public TColorPicker OriTrail { get; set; } = new TColorPicker();
        public bool HideGlow { get; set; } = false;
        public string TexturePath { get; set; } = "NONE";

        public OriVisualSettings() { }

        public OriVisualSettings(OriVisualSettings setting) {
            this.Ori = setting.Ori;
            this.OriGlow = setting.OriGlow;
            this.OriTrail = setting.OriTrail;
            this.HideGlow = setting.HideGlow;
            this.TexturePath = setting.TexturePath;
        }
    }
    public class SeinVisualSetting {
        public bool AutoApplyOnStartup { get; set; } = false;
        public string SettingName { get; set; } = "";
        public OriVisualSettings OriVisualSettings { get; set; } = new OriVisualSettings();
        public TorchVisualSetting TorchVisualSettings { get; set; } = new TorchVisualSetting();
        public GlideVisualSettings GlideVisualSettings { get; set; } = new GlideVisualSettings();
        public BowVisualSettings BowVisualSettings { get; set; } = new BowVisualSettings();
        public GoldenSeinVisualSettings GoldenSeinVisualSettings { get; set; } = new GoldenSeinVisualSettings();
        public SwordVisualSettings SwordVisualSettings { get; set; } = new SwordVisualSettings();
        public HammerVisualSettings HammerVisualSettings { get; set; } = new HammerVisualSettings();
        public GrenadeVisualSettings GrenadeVisualSettings { get; set; } = new GrenadeVisualSettings();
    }

    public class SeinVisualSettings {
        public List<SeinVisualSetting> VisualSettings { get; set; } = new List<SeinVisualSetting>();
        public SeinVisualSetting ActiveVisualSetting { get; set; } = new SeinVisualSetting();
        public SeinVisualSetting GetSettingByName(string name) {
            foreach (SeinVisualSetting setting in this.VisualSettings) {
                if (name == setting.SettingName) {
                    SeinVisualSetting foundSetting = new SeinVisualSetting();
                    foundSetting.AutoApplyOnStartup = setting.AutoApplyOnStartup;
                    foundSetting.SettingName = setting.SettingName;
                    foundSetting.OriVisualSettings = new OriVisualSettings(setting.OriVisualSettings);
                    foundSetting.TorchVisualSettings = new TorchVisualSetting(setting.TorchVisualSettings);
                    foundSetting.GlideVisualSettings = new GlideVisualSettings(setting.GlideVisualSettings);
                    foundSetting.BowVisualSettings = new BowVisualSettings(setting.BowVisualSettings);
                    foundSetting.GoldenSeinVisualSettings = new GoldenSeinVisualSettings(setting.GoldenSeinVisualSettings);
                    foundSetting.SwordVisualSettings = new SwordVisualSettings(setting.SwordVisualSettings);
                    foundSetting.HammerVisualSettings = new HammerVisualSettings(setting.HammerVisualSettings);
                    foundSetting.GrenadeVisualSettings = new GrenadeVisualSettings(setting.GrenadeVisualSettings);
                    return foundSetting;
                }
            }

            return null;
        }
        public void SaveActiveSetting() {
            for (int i = 0; i < this.VisualSettings.Count(); i++) {
                SeinVisualSetting setting = this.VisualSettings[i];
                if (setting.SettingName == this.ActiveVisualSetting.SettingName) {
                    this.VisualSettings[i] = this.ActiveVisualSetting;
                }
            }
        }
    }
}
