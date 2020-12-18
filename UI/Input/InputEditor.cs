using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WMKeyToChar;

namespace OriWotW.UI {
    public partial class InputEditor : Form {
        private WOTWCombination WOTWCombination;
        private List<InputDesigner> InputDesigners = new List<InputDesigner>();

        public InputEditor(WOTWCombination WOTWCombination, List<Inputs> inputs) {
            InitializeComponent();
            this.AddContent(inputs);
            this.WOTWCombination = WOTWCombination;
        }
		
		public void AddContent(List<Inputs> inputs) {
            foreach (Inputs input in inputs) {
                InputDesigner inputDesigner = new InputDesigner();
                inputDesigner.SetParent(this);
                inputDesigner.FillKeys(input.Keys as List<string>);
                inputDesigner.SetTimings(input.Timing as List<int>);
                this.InputDesigners.Add(inputDesigner);

                this.tableLayoutPanel1.RowCount++;
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
                this.tableLayoutPanel1.Controls.Add(inputDesigner, 0, this.tableLayoutPanel1.RowCount - 1);
            }
        }

        public void RemoveInputDesigner(InputDesigner inputDesigner) {
            int index = this.InputDesigners.IndexOf(inputDesigner);

            if (index != -1) {
                this.InputDesigners.RemoveAt(index);
            }
        }

        private void addInput_Click(object sender, EventArgs e) {
            InputDesigner inputDesigner = new InputDesigner();
            inputDesigner.SetParent(this);
            this.InputDesigners.Add(inputDesigner);

            this.tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 1));
            this.tableLayoutPanel1.Controls.Add(inputDesigner, 0, this.tableLayoutPanel1.RowCount - 1);
        }

        private void confirmChanges_Click(object sender, EventArgs e) {
            List<List<string>> keys = new List<List<string>>();
            List<List<int>> timings = new List<List<int>>();

            foreach (InputDesigner inputDesigner in this.InputDesigners) {
                keys.Add(inputDesigner.GetKeys());
                timings.Add(inputDesigner.GetTimings());
            }

            this.WOTWCombination.UpdateInputs(keys, timings);
            this.Close();
        }

        private void cancelChanges_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
