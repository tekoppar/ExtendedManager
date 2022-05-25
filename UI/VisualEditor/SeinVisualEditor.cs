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
using Communication.Inject;
using Tem.TemClass;
using Tem.TemUI;
using Tem.Utility;

namespace OriWotW.UI {
    public partial class SeinVisualEditor : Form {
        private SeinVisualSettings VisualSettings;
        private SeinVisualSetting SeinVisualSettings;
        private VisualEditorSettings VisualEditorSettings;
        private bool IsSettingsLoaded = false;
        private ColorWheel ColorWheel = new ColorWheel();
        private Dictionary<string, int> ExistingVisualSettings = new Dictionary<string, int>();
        private Dictionary<string, FlowLayoutPanel> PickerLayouts = new Dictionary<string, FlowLayoutPanel>();

        public SeinVisualEditor(bool LoadSettings = true) {
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

                    if (panel.Name.Contains("ColorPickers"))
                        PickerLayouts.Add(panel.Name.Replace("ColorPickers", ""), panel);

                    foreach (Control control1 in control.Controls)
                        allControls.Add(control1);
                } else
                    foreach (Control control1 in control.Controls)
                        allControls.Add(control1);
            }

            this.LoadVisualSettings(LoadSettings);
        }

        public void LoadVisualSettings(bool LoadSettings = true) {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\VisualEditorSettings.settings") == true) {
                string jsonString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\VisualEditorSettings.settings");
                VisualEditorSettings = JsonSerializer.Deserialize<VisualEditorSettings>(jsonString);
            }
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings") == true) {
                if (IsSettingsLoaded == false && (LoadSettings == true || VisualEditorSettings.AutoApplyOnStartup == true)) {
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
                        loadVisualSettingsToolStripMenuItem.DropDownItems.Add(item);
                        ExistingVisualSettings.Add(item.Name, ExistingVisualSettings.Count());
                    }

                    LoadColorPickers();
                    this.ApplyVisualSettings();
                    if (VisualEditorSettings.AutoApplyOnStartup == true) {
                        this.SaveVisualSettings();
                        InjectCommunication._Instance.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
                    }
                    IsSettingsLoaded = true;
                }
            } else {
                LoadColorPickers();

                this.ApplyVisualSettings();
            }
        }

        private void ResetSettingsDropdownList() {
            ExistingVisualSettings.Clear();
            this.loadVisualSettingsToolStripMenuItem.DropDownItems.Clear();
            foreach (SeinVisualSetting setting in this.VisualSettings.VisualSettings) {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = setting.SettingName;
                item.Text = setting.SettingName;
                item.Click += Item_Click;
                loadVisualSettingsToolStripMenuItem.DropDownItems.Add(item);
                ExistingVisualSettings.Add(item.Name, ExistingVisualSettings.Count());
            }
        }

        private void ApplyVisualSettings() {
            if (this.SeinVisualSettings != null) {
                ApplyTexture("textureImage");
                ApplyTexture("oriHatTexture");

                this.chkbHideGlow.Checked = this.SeinVisualSettings.OriVisualSettings.HideGlow;
                this.chkAutoApply.Checked = this.VisualEditorSettings.AutoApplyOnStartup;
                this.tbxSettingName.Text = this.SeinVisualSettings.SettingName;
            }
        }

        private void ApplyTexture(string controlName) {
            switch (controlName) {
                case "textureImage":
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
                    break;

                case "oriHatTexture":
                    if (Path.IsPathRooted(this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath) == true && File.Exists(this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath) == true) {
                        this.oriHatTexture.Image = Image.FromFile(this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath);
                        this.oriHatTexture.SizeMode = PictureBoxSizeMode.StretchImage;
                    } else {
                        if (Path.IsPathRooted(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath) == true && File.Exists(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath) == true) {
                            this.oriHatTexture.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath);
                            this.oriHatTexture.SizeMode = PictureBoxSizeMode.StretchImage;
                        } else {
                            this.oriHatTexture.Image = null;
                        }
                    }
                    break;
        }
    }

        private void ResetVisualSettings() {
            this.textureImage.Image = null;
            this.chkbHideGlow.Checked = this.SeinVisualSettings.OriVisualSettings.HideGlow;
            this.chkAutoApply.Checked = this.VisualEditorSettings.AutoApplyOnStartup;
            this.oriHatTexture.Image = null;

            this.ApplyVisualSettings();
        }

        private void Item_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SeinVisualSetting setting = this.VisualSettings.GetSettingByName(item.Name);

            if (setting != null) {
                ResetSettings(SeinVisualSettings, setting);
                ApplyVisualSettings();
            }
        }

        private void ResetSettings(SeinVisualSetting oldSetting, SeinVisualSetting newSetting) {
            var valuesOld = TE.GetPropertyObjectsByType(oldSetting, "SeinVisualSettings", typeof(TColorPicker));

            this.SeinVisualSettings = newSetting;
            var valuesNew = TE.GetPropertyObjectsByType(SeinVisualSettings, "SeinVisualSettings", typeof(TColorPicker));

            this.VisualSettings.ActiveVisualSetting = newSetting;

            this.SuspendLayout();
            foreach (var picker in PickerLayouts) { picker.Value.SuspendLayout(); }
            foreach (var key in valuesOld.Keys) {
                var property = valuesOld[key];
                var propertyNew = valuesNew[key];

                TColorPicker picker = (TColorPicker)property;
                TColorPicker pickerNew = (TColorPicker)propertyNew;
                pickerNew.SetInitialized();
                FlowLayoutPanel layout = picker.Parent as FlowLayoutPanel;
                int index = layout.Controls.IndexOf(picker);
                layout.SuspendLayout();
                pickerNew.SetColor(pickerNew.Color.Value);
                layout.Controls.Remove(picker);
                pickerNew.PickerSize = new Point(32, 32);
                pickerNew.Size = new Size(146, 38);
                layout.Controls.Add(pickerNew);
                layout.Controls.SetChildIndex(pickerNew, index);
                layout.ResumeLayout();
            }
            foreach (var picker in PickerLayouts) { picker.Value.ResumeLayout(); }
            this.ResumeLayout();

            if (VisualEditorSettings.AutoApplyOnStartup == true)
                InjectCommunication._Instance.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
        }

        private void SaveVisualSettings() {
            this.VisualSettings.SaveActiveSetting();
            this.ResetSettingsDropdownList();
            string jsonString = JsonSerializer.Serialize(this.VisualSettings);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings", jsonString);
            jsonString = JsonSerializer.Serialize(this.VisualEditorSettings);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\VisualEditorSettings.settings", jsonString);
        }

        private void btnTextureLoader_Click(object sender, EventArgs e) {
            Button clickedButton = sender as Button;
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

                    if (TE.IsPathRelative(filePath, AppDomain.CurrentDomain.BaseDirectory)) {
                        filePath = TE.GetRelativePath(filePath, AppDomain.CurrentDomain.BaseDirectory);
                    }

                    switch (clickedButton.Name) {
                        case "btnTextureLoader":
                            this.SeinVisualSettings.OriVisualSettings.TexturePath = filePath;
                            this.textureImage.Image = Image.FromFile(this.SeinVisualSettings.OriVisualSettings.TexturePath);
                            this.textureImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;

                        case "btnOriHatTextureLoader":
                            this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath = filePath;
                            this.oriHatTexture.Image = Image.FromFile(this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath);
                            this.oriHatTexture.SizeMode = PictureBoxSizeMode.StretchImage;
                            break;
                    }
                    this.SaveVisualSettings();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.SaveVisualSettings();
            InjectCommunication._Instance.AddCall("CALL32PAR" + AppDomain.CurrentDomain.BaseDirectory + "\\visuals.settings");
        }

        private void chkbHideGlow_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.SeinVisualSettings.OriVisualSettings.HideGlow = checkBox.Checked;
        }

        private void chkAutoApply_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.VisualEditorSettings.AutoApplyOnStartup = checkBox.Checked;
        }

        private void btnSaveSetting_Click(object sender, EventArgs e) {
            string name = tbxSettingName.Text;

            if (name == "")
                name = "Visual Setting " + VisualSettings.VisualSettings.Count.ToString();

            if (ExistingVisualSettings.ContainsKey(name) == false || name == SeinVisualSettings.SettingName) {
                string oldName = SeinVisualSettings.SettingName;
                SeinVisualSettings.SettingName = name;

                if (ExistingVisualSettings.ContainsKey(oldName) == false) {
                    VisualSettings.VisualSettings.Add(SeinVisualSettings);
                    ExistingVisualSettings.Add(name, ExistingVisualSettings.Count());
                } else {
                    ExistingVisualSettings.Remove(oldName);
                    ExistingVisualSettings.Add(name, ExistingVisualSettings.Count());
                    VisualSettings.SetSettingsName(oldName, name);
                }
                SaveVisualSettings();
            } else {
                MessageBox.Show("A visual setting already exists with that name", "Error", MessageBoxButtons.OK);
            }
        }

        private void input_Enter(object sender, EventArgs e) {
            Manager._Instance.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            Manager._Instance.rawInput.AddMessageFilter();
        }

        private void resetActiveSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.NukeVisualSettings();
            this.ResetVisualSettings();
        }

        private void NukeVisualSettings() {
            ResetSettings(this.SeinVisualSettings, new SeinVisualSetting());
        }
        private void chkEnableTrailMesh_CheckedChanged(object sender, EventArgs e) {
            CheckBox checkBox = sender as CheckBox;
            this.SeinVisualSettings.TorchVisualSettings.TorchTrailMeshEnable = checkBox.Checked;
        }

        private void removeActiveSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            if (VisualSettings.VisualSettings.Count > 0) {
                var results = MessageBox.Show("Do you really want to delete the current active setting " + SeinVisualSettings.SettingName + "?", "Remove Settings", MessageBoxButtons.YesNo);
                if (results == DialogResult.Yes) {
                    int index = 0;
                    for (int i = 0; i < this.VisualSettings.VisualSettings.Count(); i++) {
                        if (this.VisualSettings.VisualSettings[i].SettingName == this.SeinVisualSettings.SettingName)
                            index = i;
                    }
                    this.VisualSettings.VisualSettings.RemoveAt(index);
                    ResetSettings(this.SeinVisualSettings, new SeinVisualSetting());
                    this.ResetVisualSettings();
                    this.ResetSettingsDropdownList();
                }
            } else
                MessageBox.Show("No more settings found", "Error", MessageBoxButtons.OK);
        }

        private void LoadColorPickers() {
            var value = TE.GetPropertyObjectsByType(SeinVisualSettings, "SeinVisualSettings", typeof(TColorPicker));
            foreach (var property in value) {
                string fieldName = property.Key.Name;
                TColorPicker picker = (TColorPicker)property.Value;
                picker.SetColor(picker.Color.Value, true);
                picker.PickerSize = new Point(32, 32);
                picker.Size = new Size(146, 38);
                picker.Name = fieldName;
                Label label = new Label();
                label.Text = fieldName + ":";
                label.Size = new Size(131, 38);
                label.TextAlign = ContentAlignment.MiddleRight;

                if (PickerLayouts.ContainsKey(property.Key.Parent) == true) {
                    PickerLayouts[property.Key.Parent].Controls.Add(label);
                    PickerLayouts[property.Key.Parent].Controls.Add(picker);
                }
            }
        }

        private void defaultGameSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            InjectCommunication._Instance.AddCall("CALL35");
        }

        private void newSettingToolStripMenuItem_Click(object sender, EventArgs e) {
            var results = MessageBox.Show("Would you like to save the changes made to " + SeinVisualSettings.SettingName + " before creating a new one?", "Save", MessageBoxButtons.YesNo);

            if (results == DialogResult.Yes)
                SaveVisualSettings();

            ResetSettings(this.SeinVisualSettings, new SeinVisualSetting());
            ApplyVisualSettings();
        }

        private void btnRemoveOriHatTexture_Click(object sender, EventArgs e) {
            Button clickedButton = sender as Button;

            switch (clickedButton.Name) {
                case "btnRemoveOriHatTexture": this.oriHatTexture.Image = null; this.SeinVisualSettings.OriVisualSettings.HatVisualSettings.TexturePath = "NONE"; break;
            }
        }
    }

    public class ArrowVisualSettings {
        public TColorPicker ArrowEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowEffectEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowSpear { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowSpearEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TipImpact { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TipImpactEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TipParticle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TipParticleEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowTrail { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowTrailEmissive { get; set; } = TColorPicker.ColorPicker();

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
            this.ArrowTrail = setting.ArrowTrail;
            this.ArrowTrailEmissive = setting.ArrowTrailEmissive;
        }
    }
    public class ArrowHitVisualSettings {
        public TColorPicker DistortionNew { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FxBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BloodSplat { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticlesFallBig { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker GlowUnmask { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BlowingUpForceField { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare20b { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare9 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialIrisImpact { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker StarSpike2 { get; set; } = TColorPicker.ColorPicker();

        public ArrowHitVisualSettings() { }

        public ArrowHitVisualSettings(ArrowHitVisualSettings setting) {
            this.DistortionNew = setting.DistortionNew;
            this.FxBox = setting.FxBox;
            this.BloodSplat = setting.BloodSplat;
            this.DebrisParticles = setting.DebrisParticles;
            this.DebrisParticlesFallBig = setting.DebrisParticlesFallBig;
            this.GlowUnmask = setting.GlowUnmask;
            this.VignetteMaskC = setting.VignetteMaskC;
            this.BlowingUpForceField = setting.BlowingUpForceField;
            this.LensFlare20b = setting.LensFlare20b;
            this.LensFlare9 = setting.LensFlare9;
            this.RadialBurned = setting.RadialBurned;
            this.RadialBurned2 = setting.RadialBurned2;
            this.RadialIrisImpact = setting.RadialIrisImpact;
            this.StarSpike2 = setting.StarSpike2;
        }
    }
    public class BowVisualSettings {
        public TColorPicker BowShaft { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BowShaftEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BowString { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BowStringEmissive { get; set; } = TColorPicker.ColorPicker();
        public ArrowVisualSettings ArrowVisualSettings { get; set; } = new ArrowVisualSettings();
        public ArrowHitVisualSettings ArrowHitVisualSettings { get; set; } = new ArrowHitVisualSettings();

        public BowVisualSettings() { }

        public BowVisualSettings(BowVisualSettings setting) {
            this.BowShaft = setting.BowShaft;
            this.BowShaftEmissive = setting.BowShaftEmissive;
            this.BowString = setting.BowString;
            this.BowStringEmissive = setting.BowStringEmissive;
            this.ArrowVisualSettings = new ArrowVisualSettings(setting.ArrowVisualSettings);
            this.ArrowHitVisualSettings = new ArrowHitVisualSettings(setting.ArrowHitVisualSettings);
        }
    }

    public class GlideVisualSettings {
        public TColorPicker Feather { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FeatherEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Featherflap { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FeatherflapEmissive { get; set; } = TColorPicker.ColorPicker();

        public GlideVisualSettings() { }

        public GlideVisualSettings(GlideVisualSettings setting) {
            this.Feather = setting.Feather;
            this.FeatherEmissive = setting.FeatherEmissive;
            this.Featherflap = setting.Featherflap;
            this.FeatherflapEmissive = setting.FeatherflapEmissive;
        }
    }

    public class TorchHit {
        public TColorPicker FsBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FlameFireC { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FlameGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FireEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FireEffect2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpriteSnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker GlowUnmask { get; set; } = TColorPicker.ColorPicker();

        public TorchHit() { }

        public TorchHit(TorchHit setting) {
            this.FsBox = setting.FsBox;
            this.FlameFireC = setting.FlameFireC;
            this.FlameGlow = setting.FlameGlow;
            this.FireEffect = setting.FireEffect;
            this.FireEffect2 = setting.FireEffect2;
            this.RadialBurned = setting.RadialBurned;
            this.RadialBurned2 = setting.RadialBurned2;
            this.SpriteSnowPattern = setting.SpriteSnowPattern;
            this.Glow = setting.Glow;
            this.GlowUnmask = setting.GlowUnmask;
        }

    }
    public class TorchBreak {
        public TColorPicker AcidParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker CharacterGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Smoke { get; set; } = TColorPicker.ColorPicker();

        public TorchBreak() { }

        public TorchBreak(TorchBreak setting) {
            this.AcidParticles = setting.AcidParticles;
            this.CharacterGlow = setting.CharacterGlow;
            this.Smoke = setting.Smoke;
        }
    }
    public class TorchAttack {
        public TColorPicker FireSprite { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TrailZigZag { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker Torch { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TorchFloatingSpark { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TorchRunning { get; set; } = TColorPicker.ColorPicker();
        public bool TorchTrailMeshEnable { get; set; } = false;
        public TColorPicker TorchTrailMesh { get; set; } = TColorPicker.ColorPicker();
        public TorchAttack TorchAirAttacks1 { get; set; } = new TorchAttack();
        public TorchAttack TorchAirAttacks2 { get; set; } = new TorchAttack();
        public TorchAttack TorchAirAttacks3 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks1 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks2 { get; set; } = new TorchAttack();
        public TorchAttack TorchGroundAttacks3 { get; set; } = new TorchAttack();
        public TorchBreak TorchBreak { get; set; } = new TorchBreak();
        public TorchHit TorchHit { get; set; } = new TorchHit();
        public TorchHit TorchHitSmall { get; set; } = new TorchHit();
        public TColorPicker TorchLightEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TorchSpark { get; set; } = TColorPicker.ColorPicker();

        public TorchVisualSetting() { }

        public TorchVisualSetting(TorchVisualSetting settings) {
            this.HideGlow = settings.HideGlow;
            this.TorchAirAttacks1 = new TorchAttack(settings.TorchAirAttacks1);
            this.TorchAirAttacks2 = new TorchAttack(settings.TorchAirAttacks2);
            this.TorchAirAttacks3 = new TorchAttack(settings.TorchAirAttacks3); ;
            this.TorchBreak = new TorchBreak(settings.TorchBreak);
            this.Torch = settings.Torch;
            this.TorchFloatingSpark = settings.TorchFloatingSpark;
            this.TorchGroundAttacks1 = new TorchAttack(settings.TorchGroundAttacks1);
            this.TorchGroundAttacks2 = new TorchAttack(settings.TorchGroundAttacks2);
            this.TorchGroundAttacks3 = new TorchAttack(settings.TorchGroundAttacks3);
            this.TorchHit = new TorchHit(settings.TorchHit);
            this.TorchHitSmall = new TorchHit(settings.TorchHitSmall);
            this.TorchLightEffect = settings.TorchLightEffect;
            this.TorchRunning = settings.TorchRunning;
            this.TorchSpark = settings.TorchSpark;
            this.TorchTrailMesh = settings.TorchTrailMesh;
            this.TorchTrailMeshEnable = settings.TorchTrailMeshEnable;
        }
    }
    public class GrenadeEffect {
        public TColorPicker FireEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Flame1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Flame2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Flame3 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Smoke { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern3 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FireSprite { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LightCircle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker MainTrail { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ProtectiveLight { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker TrailZigZag { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker Burst { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Distortion { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BurstPreGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowDistortion { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowSingleParticle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowSmoke { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArrowVignette { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker OriSparkle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker OuterGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ParticleDropGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ParticleImpactGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SingleSnowParticle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SharedCircleGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Sprite { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Trail { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker ForceField { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Distortion { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LightCircle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LightGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker StarSpike { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FX { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FireEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Smoke { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpriteSheetFire { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialCrack { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialIrisImpact { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker VignetteMask1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMask2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ArcaneOrb { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ChargingJump { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker EnergySplash { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker Sparkle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker OuterGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Sprite1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Sprite2 { get; set; } = TColorPicker.ColorPicker();

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
        public TColorPicker FireSprite3Flip { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();

        public HammerStompPreparation() { }

        public HammerStompPreparation(HammerStompPreparation setting) {
            this.FireSprite3Flip = setting.FireSprite3Flip;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class HammerHit {
        public TColorPicker DistortionNew { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FxBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles3 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticlesFallBig { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker GlowUnmask { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker KuroNestEggCrackD { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare20b { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare3 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare9 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensRadialSpike { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialIrisImpact { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialLightRays { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialMaskB { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpikeHitLarge1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpikeHitLarge2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ParticleShape { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker StarSpike2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();

        public HammerHit() { }

        public HammerHit(HammerHit setting) {
            this.DistortionNew = setting.DistortionNew;
            this.FxBox = setting.FxBox;
            this.Glow = setting.Glow;
            this.DebrisParticles = setting.DebrisParticles;
            this.DebrisParticles1 = setting.DebrisParticles1;
            this.DebrisParticles2 = setting.DebrisParticles2;
            this.DebrisParticles3 = setting.DebrisParticles3;
            this.DebrisParticlesFallBig = setting.DebrisParticlesFallBig;
            this.GlowUnmask = setting.GlowUnmask;
            this.KuroNestEggCrackD = setting.KuroNestEggCrackD;
            this.LensFlare20b = setting.LensFlare20b;
            this.LensFlare3 = setting.LensFlare3;
            this.LensFlare9 = setting.LensFlare9;
            this.LensRadialSpike = setting.LensRadialSpike;
            this.RadialBurned2 = setting.RadialBurned2;
            this.RadialIrisImpact = setting.RadialIrisImpact;
            this.RadialLightRays = setting.RadialLightRays;
            this.RadialMaskB = setting.RadialMaskB;
            this.SpikeHitLarge1 = setting.SpikeHitLarge1;
            this.SpikeHitLarge2 = setting.SpikeHitLarge2;
            this.ParticleShape = setting.ParticleShape;
            this.StarSpike2 = setting.StarSpike2;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class HammerBlock {
        public TColorPicker AcidParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker CharacterGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Circle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LavaFountainA { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = TColorPicker.ColorPicker();

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
    public class HammerShockwave {
        public TColorPicker BulletGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FxBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker AtlantisRockFarBackgroundAg { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialMaskB { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SharedSmokeA { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Sparks { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SplashEdge2localOrient { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpritesheetSpikes { get; set; } = TColorPicker.ColorPicker();

        public HammerShockwave() { }

        public HammerShockwave(HammerShockwave setting) {
            this.BulletGlow = setting.BulletGlow;
            this.FxBox = setting.FxBox;
            this.AtlantisRockFarBackgroundAg = setting.AtlantisRockFarBackgroundAg;
            this.RadialMaskB = setting.RadialMaskB;
            this.SharedSmokeA = setting.SharedSmokeA;
            this.Sparks = setting.Sparks;
            this.SplashEdge2localOrient = setting.SplashEdge2localOrient;
            this.SpritesheetSpikes = setting.SpritesheetSpikes;
        }
    }
    public class HammerStomp {
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker GiftLeafTransformationLightRing { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow1 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Smoke { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = TColorPicker.ColorPicker();

        public HammerStomp() { }

        public HammerStomp(HammerStomp setting) {
            this.Glow = setting.Glow;
            this.GiftLeafTransformationLightRing = setting.GiftLeafTransformationLightRing;
            this.Glow1 = setting.Glow1;
            this.Smoke = setting.Smoke;
            this.SingleSnowParticleA = setting.SingleSnowParticleA;
            this.DebrisParticles = setting.DebrisParticles;
        }
    }
    public class HammerAttack {
        public TColorPicker FireSprite { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LinearGradientMask { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker EnergyEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SpriteSnowPettern2 { get; set; } = TColorPicker.ColorPicker();

        public HammerAttack() { }

        public HammerAttack(HammerAttack setting) {
            this.FireSprite = setting.FireSprite;
            this.LinearGradientMask = setting.LinearGradientMask;
            this.VignetteMaskC = setting.VignetteMaskC;
            this.SpriteSnowPettern2 = setting.SpriteSnowPettern2;
            this.EnergyEffect = setting.EnergyEffect;
        }
    }
    public class HammerVisualSettings {
        public TColorPicker Hammer { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker HammerEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker HammerHitEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker HammerHitEffectEmissive { get; set; } = TColorPicker.ColorPicker();
        public HammerAttack HammerAttackAir1 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAir2 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAir3 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackAirUpSwipe { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGround1 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGround2 { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGroundDown { get; set; } = new HammerAttack();
        public HammerAttack HammerAttackGroundUpSwipe { get; set; } = new HammerAttack();
        public HammerStomp HammerAttackStomp { get; set; } = new HammerStomp();
        public HammerShockwave HammerShockwave { get; set; } = new HammerShockwave();
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
            this.HammerShockwave = new HammerShockwave(setting.HammerShockwave);
            this.HammerBlock = new HammerBlock(setting.HammerBlock);
            this.HammerHit = new HammerHit(setting.HammerHit);
            this.HammerStompPreparation = new HammerStompPreparation(setting.HammerStompPreparation);
        }
    }
    public class SwordAttackAirPoke {
        public TColorPicker BlowingSand { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();

        public SwordAttackAirPoke() { }

        public SwordAttackAirPoke(SwordAttackAirPoke setting) {
            this.BlowingSand = setting.BlowingSand;
            this.Glow = setting.Glow;
        }
    }
    public class SwordAttack {
        public TColorPicker EnergyEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FireSprite { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();

        public SwordAttack() { }

        public SwordAttack(SwordAttack setting) {
            this.EnergyEffect = setting.EnergyEffect;
            this.SnowPattern = setting.SnowPattern;
            this.FireSprite = setting.FireSprite;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class SwordAttackC {
        public TColorPicker BlowingSand { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();

        public SwordAttackC() { }

        public SwordAttackC(SwordAttackC setting) {
            this.BlowingSand = setting.BlowingSand;
            this.SnowPattern = setting.SnowPattern;
            this.SnowPattern2 = setting.SnowPattern2;
            this.VignetteMaskC = setting.VignetteMaskC;
        }
    }
    public class SwordBlock {
        public TColorPicker AcidParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker CharacterGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Distortion { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Circle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FxBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker CircleGlowC { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker NoiseCaustic { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LavaFountainA { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SnowPattern2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker StarSpike { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Glow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SingleSnowParticleA { get; set; } = TColorPicker.ColorPicker();


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
        public TColorPicker BurningCoreParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker BurnMarks { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ImpactSparklesA { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker Distortion { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker ImpactCenter { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SmokeParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SparkStartParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();


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
        public TColorPicker DistortionNew { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker FxBox { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DropGlowB { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticles { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker DebrisParticlesFallBig { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker GlowUnmask { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker VignetteMaskC { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensCrossStart { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare20b { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensFlare9 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LensRadialSpike { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LightCircleShape { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker LightGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialBurned2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialLightRays { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker RadialMaskB { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SparksLong { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SplashEdge { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SplashEdge2 { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker StarSpike2 { get; set; } = TColorPicker.ColorPicker();


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
        public TColorPicker Sword { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SwordEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SwordHitEffect { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SwordHitEffectEmissive { get; set; } = TColorPicker.ColorPicker();
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
        public TColorPicker SeinBody { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SeinBodyEmissive { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SeinParticle { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SeinRadialLight { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SeinTrail { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker SeinTrailMesh { get; set; } = TColorPicker.ColorPicker();

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
    public class HatVisualSettings {
        public TColorPicker Hat { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker HatEmissive { get; set; } = TColorPicker.ColorPicker();
        public string TexturePath { get; set; } = "NONE";

        public HatVisualSettings() {}

        public HatVisualSettings(HatVisualSettings setting) {
            this.TexturePath = setting.TexturePath;
            this.Hat = setting.Hat;
            this.HatEmissive = setting.HatEmissive;
        }
    }
    public class OriVisualSettings {
        public HatVisualSettings HatVisualSettings { get; set; } = new HatVisualSettings();
        public TColorPicker Ori { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker OriGlow { get; set; } = TColorPicker.ColorPicker();
        public TColorPicker OriTrail { get; set; } = TColorPicker.ColorPicker();
        public bool HideGlow { get; set; } = false;
        public string TexturePath { get; set; } = "NONE";

        public OriVisualSettings() { }

        public OriVisualSettings(OriVisualSettings setting) {
            this.Ori = setting.Ori;
            this.OriGlow = setting.OriGlow;
            this.OriTrail = setting.OriTrail;
            this.HideGlow = setting.HideGlow;
            this.TexturePath = setting.TexturePath;
            this.HatVisualSettings = new HatVisualSettings(setting.HatVisualSettings);
        }
    }
    public class SeinVisualSetting {
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
        public void SetSettingsName(string oldName, string newName) {
            foreach (SeinVisualSetting setting in this.VisualSettings) {
                if (oldName == setting.SettingName) {
                    setting.SettingName = newName;
                }
            }
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

    public class VisualEditorSettings {
        public bool AutoApplyOnStartup { get; set; } = false;
    }
}
