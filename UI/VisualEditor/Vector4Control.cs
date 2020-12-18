using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriWotW.UI.VisualEditor {
    public partial class Vector4Control : UserControl {
        private TColor vector = new TColor(0, 0, 0, 0);
        public Vector4Control() {
            InitializeComponent();
        }

        private void value_ValueChanged(object sender, EventArgs e) {
            NumericUpDown numeric = sender as NumericUpDown;

            switch (numeric.Name) {
                case "valueX": this.vector.r = (float)numeric.Value; break;
                case "valueY": this.vector.g = (float)numeric.Value; break;
                case "valueZ": this.vector.b = (float)numeric.Value; break;
                case "valueA": this.vector.a = (float)numeric.Value; break;
            }
        }

        public TColor GetValue() {
            return this.vector;
        }

        public void SetValue(TColor value) {
            this.vector = value;
            valueX.Value = (decimal)vector.r;
            valueY.Value = (decimal)vector.g;
            valueZ.Value = (decimal)vector.b;
            valueA.Value = (decimal)vector.a;
        }
    }
}
