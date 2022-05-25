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
    public partial class InputDropdown : UserControl {
        public List<string> InputNames = new List<string>() {
            "LMOUSE",
            "RMOUSE",
            "SPACEBAR",
            "LSHIFT",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"
        };
        public FlowLayoutPanel KeyInputsPanel;

        public InputDropdown() {
            InitializeComponent();
            this.GenerateInputList();
        }

        public void GenerateInputList() {
            foreach (string name in this.InputNames) {
                this.inputList.Items.Add(name);
            }
        }

        public void SetInput(string key) {
            int index = this.inputList.FindString(key);

            if (index != -1)
                this.inputList.SelectedItem = this.inputList.Items[index];
        }

        public string GetInput() {
            return this.inputList.Items[this.inputList.SelectedIndex].ToString();
        }
    }
}
