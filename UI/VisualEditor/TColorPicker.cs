using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OriWotW.UI {
    [JsonConverter(typeof(SystemTextJsonSamples.JsonConverterTColorPicker))]
    public partial class TColorPicker : UserControl {
        [Description("Displays the color values as text next to the color picker"), Category("Appearance")]
        public bool ShowColorValues {
            get {
                return this.ShowColorValue;
            }
            set {
                this.ShowColorValue = value;
                this.lblColorValues.Visible = this.ShowColorValue;
                this.lblColorValues.Text = this.Color.Value.R.ToString() + ", " + this.Color.Value.G.ToString() + ", " + this.Color.Value.B.ToString() + ", " + this.Color.Value.A.ToString();
            }
        }
        [Description("Sets the dimensions of the color picker"), Category("Appearance")]
        public Point PickerSize {
            get {
                return this.ColorPickerSize;
            }
            set {
                this.ColorPickerSize = value;
                this.colorPicker.Width = this.ColorPickerSize.X;
                this.colorPicker.Height = this.ColorPickerSize.Y;
            }
        }

        public event EventHandler<PickedColorEventArgs> OnPickedColor;
        protected virtual void PickedColor(PickedColorEventArgs e) {
            EventHandler<PickedColorEventArgs> handler = OnPickedColor;
            if (handler != null) {
                handler(this, e);
            }
        }

        static private ColorWheel ColorWheel;
        static private Color? CopyColor = null;
        public Color? Color { get; set; } = System.Drawing.Color.FromArgb(255, 255, 255, 255);
        private int Alpha = 255;
        private bool ShowColorValue { get; set; } = true;
        private Point ColorPickerSize { get; set; } = new Point(64, 64);
        public TColorPicker() {
            InitializeComponent();

            if (this.ShowColorValue == true) {
                this.lblColorValues.Visible = true;
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e) {
            if (this.Color.HasValue == true)
                TColorPicker.ColorWheel = new ColorWheel(this.Color.Value);
            else
                TColorPicker.ColorWheel = new ColorWheel();

            if (TColorPicker.ColorWheel.ShowDialog() == DialogResult.OK) {
                this.Color = TColorPicker.ColorWheel.ReturnColor;
                this.Alpha = this.Color.Value.A;
                this.colorPicker.Image = this.DrawPreviewColorImage(this.Color.Value, this.Alpha);
                this.lblColorValues.Text = this.Color.Value.R.ToString() + ", " + this.Color.Value.G.ToString() + ", " + this.Color.Value.B.ToString() + ", " + this.Color.Value.A.ToString();

                PickedColorEventArgs args = new PickedColorEventArgs();
                args.Color = this.Color.Value;
                PickedColor(args);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                TColorPicker.CopyColor = this.Color;
            } else if (e.Button == MouseButtons.Right) {
                this.Color = TColorPicker.CopyColor;
                this.Alpha = this.Color.Value.A;
                this.colorPicker.Image = this.DrawPreviewColorImage(this.Color.Value, this.Alpha);
                this.lblColorValues.Text = this.Color.Value.R.ToString() + ", " + this.Color.Value.G.ToString() + ", " + this.Color.Value.B.ToString() + ", " + this.Color.Value.A.ToString();
                PickedColorEventArgs args = new PickedColorEventArgs();
                args.Color = this.Color.Value;
                PickedColor(args);
            }
        }

        private Image DrawPreviewColorImage(Color color, int alpha) {
            var finalImage = new Bitmap(64, 64, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(finalImage);
            Pen opaquePen = new Pen(System.Drawing.Color.FromArgb(alpha, color.R, color.G, color.B), 64);
            Rectangle rect = new Rectangle(0, 0, 64, 64);
            g.DrawRectangle(opaquePen, rect);
            return finalImage;
        }

        public void SetColor(Color color) {
            this.Color = color;
            this.Alpha = this.Color.Value.A;
            this.colorPicker.Image = this.DrawPreviewColorImage(color, color.A);
            this.lblColorValues.Text = this.Color.Value.R.ToString() + ", " + this.Color.Value.G.ToString() + ", " + this.Color.Value.B.ToString() + ", " + this.Color.Value.A.ToString();
            /*PickedColorEventArgs args = new PickedColorEventArgs();
            args.Color = this.Color.Value;
            PickedColor(args);*/
        }
    }

    public class PickedColorEventArgs : EventArgs {
        public Color Color { get; set; }
    }
}

namespace SystemTextJsonSamples {
    internal sealed class JsonConverterTColorPicker : JsonConverter<OriWotW.UI.TColorPicker> {
        public override OriWotW.UI.TColorPicker Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            OriWotW.UI.TColorPicker colorPicker = new OriWotW.UI.TColorPicker();
            string colorValues;
            using (var jsonDoc = JsonDocument.ParseValue(ref reader)) {
                colorValues = jsonDoc.RootElement.GetRawText();
            }
            int startOfR = colorValues.IndexOf("r\":");
            int endOfR = colorValues.IndexOf(",", startOfR);
            int startOfG = colorValues.IndexOf("g\":");
            int endOfG = colorValues.IndexOf(",", startOfG);
            int startOfB = colorValues.IndexOf("b\":");
            int endOfB = colorValues.IndexOf(",", startOfB);
            int startOfA = colorValues.IndexOf("a\":");
            int endOfA = colorValues.IndexOf("}", startOfA);
            OriWotW.TColor color = new OriWotW.TColor(float.Parse(colorValues.Substring(startOfR + 3, endOfR - (startOfR + 3)), CultureInfo.InvariantCulture.NumberFormat), float.Parse(colorValues.Substring(startOfG + 3, endOfG - (startOfG + 3)), CultureInfo.InvariantCulture.NumberFormat), float.Parse(colorValues.Substring(startOfB + 3, endOfB - (startOfB + 3)), CultureInfo.InvariantCulture.NumberFormat), float.Parse(colorValues.Substring(startOfA + 3, endOfA - (startOfA + 3)), CultureInfo.InvariantCulture.NumberFormat));
            colorPicker.SetColor(color.ToColor());
            return colorPicker;
        }

        public override void Write(Utf8JsonWriter writer, OriWotW.UI.TColorPicker value, JsonSerializerOptions options) {
            OriWotW.TColor color = new OriWotW.TColor(value.Color.HasValue == true ? value.Color.Value : Color.FromArgb(255, 255, 255, 255));
            //writer.WriteStringValue(color.ToJsonString());
            using (JsonDocument document = JsonDocument.Parse(color.ToJsonString())) {
                document.RootElement.WriteTo(writer);
            }
        }
    }
}
