using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriWotW.UI {
    public partial class InputSelector : UserControl {
        public List<string> InputNames = new List<string>() { "Movement Left", "Movement Right", "Movement Down", "Movement Up", "SaveCopy", "SaveDelete", "Interact",
        "Jump", "Ability 1", "Ability 2", "Ability 3", "Glide", "Grab", "Dash", "Burrow", "Bash", "Grapple", "Dialogue Advance", "Dialogue Option 1", "Dialogue Option 2", "Dialogue Option 3", "Dialogue Exit",
        "Open Maps Shards Inventory", "Open Inventory", "Open World Map", "Open Area Map", "Open Shards Screen", "Open Weapon Wheel", "Open Pause Screen", "Open Live Sign In", "Map Zoom In", "Map Zoom Out",
        "Menu Select", "Menu Back", "Menu Close", "Menu Down", "Menu Up", "Menu Left", "Menu Right", "Menu Page Left", "Menu Page Right", "Leaderboard Cycle Filter", "Map Filter", "Map Details", "Map Focus Ori", "Map Focus Objective",
        "Launch", "Spirit Edge", "Spirit Arc", "Spike", "Spirit Smash", "Spirit Star", "Light Burst", "Regenerate", "Flap", "Blaze", "Flash", "Sentry"};
        public FlowLayoutPanel KeyInputsPanel;

        public InputSelector() {
            InitializeComponent();
            this.GenerateInputList();
        }

        public void GenerateInputList() {
            foreach (string name in this.InputNames) {
                this.inputList.Items.Add(name);
            }
        }

        private void addInput_Click(object sender, EventArgs e) {
            if (inputList.SelectedIndex != -1) {
                KeyInput keyInput = new KeyInput();
                keyInput.SetKey(inputList.SelectedItem.ToString());
                this.KeyInputsPanel.Controls.Add(keyInput);
            } else {
                MessageBox.Show("No input is selected, please select a input in the dropdown list next to the add input button.", "No input selected", MessageBoxButtons.OK);
            }
        }
    }
}
