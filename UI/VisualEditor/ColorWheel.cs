using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Imaging;

namespace OriWotW.UI {
    public partial class ColorWheel : Form {
        public Color ReturnColor { get; set; }

        private bool DraggingRainbowPicker = false;
        private bool DraggingColorBoxPicker = false;
        private int DraggingMouseOffset = 0;
        public System.Timers.Timer Timer = new System.Timers.Timer();
        public System.Timers.Timer ColorBoxTimer = new System.Timers.Timer();
        private ColorTE.HSV ActiveColor;
        private float AlphaValue = 1.0f;
        private Image ColorBox;
        private Point ColorpickerLocation = new Point(0,0);
        private bool TrackBarMouseClick = false;

        public ColorWheel(Color? color = null) {
            InitializeComponent();
            this.ActiveColor = ColorTE.ColorToHSV((color == null ? Color.White: color.Value));
            this.AlphaValue = color == null ? 1 : (float)color.Value.A / 255.0f;
            this.DrawColorRainbow();
            this.UpdateActiveColor();
            this.DrawColorBox();

            Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            Timer.AutoReset = false;
            Timer.Interval = 50;
            Timer.Enabled = false;

            ColorBoxTimer.Elapsed += new ElapsedEventHandler(OnTimedColorBoxEvent);
            ColorBoxTimer.AutoReset = false;
            ColorBoxTimer.Interval = 50;
            ColorBoxTimer.Enabled = false;
        }

        public void SetActiveColor(Color? color = null) {
            this.ActiveColor = ColorTE.ColorToHSV((color == null ? Color.White : color.Value));
            this.AlphaValue = (color == null ? 1.0f : (float)color.Value.A / 255.0f);
            this.UpdateActiveColor();
            this.DrawColorBox();
            this.DrawColorRainbow();
        }

        private void UpdateActiveColor() {
            Color color = ColorTE.ColorFromHSV(this.ActiveColor.h, this.ActiveColor.s, this.ActiveColor.b);
            if (this.InvokeRequired) {
                this.Invoke((Action)delegate () {
                    this.numericUpDownRed.Value = color.R;
                    this.numericUpDownGreen.Value = color.G;
                    this.numericUpDownBlue.Value = color.B;
                    this.SliderAlphaValue.Value = (int)(AlphaValue * 255);
                    this.chosenColor.Image = DrawPreviewColorImage(color, (int)(AlphaValue * 255.0f));
                    this.SetColorBoxLocation();
                    this.SetRainbowLocation();
                    this.SetAlphaLocation();
                });
            } else {
                this.numericUpDownRed.Value = color.R;
                this.numericUpDownGreen.Value = color.G;
                this.numericUpDownBlue.Value = color.B;
                this.SliderAlphaValue.Value = (int)(AlphaValue * 255);
                this.chosenColor.Image = DrawPreviewColorImage(color, (int)(AlphaValue * 255.0f));
                this.SetColorBoxLocation();
                this.SetRainbowLocation();
                this.SetAlphaLocation();
            }
        }

        private void DrawColorRainbow() {
            Bitmap hbitmap = new Bitmap(40, 360);
            ColorTE.HSV hsv;
            hsv.b = 1.0f;
            hsv.s = 1.0f;
            hsv.h = 0;
            for (int x = 0; x < 40; x++) {
                for (int i = 0; i < 360; i++) {
                    hbitmap.SetPixel(x, i, ColorTE.ColorFromHSV(hsv));
                    hsv.h = i;
                }
            }
            PixelFormat format = PixelFormat.Format32bppArgb;
            Image image = Image.FromHbitmap(hbitmap.GetHbitmap(), (IntPtr)format);
            this.colorRainbow.Image = image;
        }

        private Image DrawPreviewColorImage(Color color, int alpha) {
            var finalImage = new Bitmap(64, 64, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(finalImage);
            Pen opaquePen = new Pen(Color.FromArgb(alpha, color.R, color.G, color.B), 64);
            Rectangle rect = new Rectangle(0, 0, 64, 64);
            g.DrawRectangle(opaquePen, rect);
            return finalImage;
        }

        private void DrawColorBox() {
            ColorTE.HSV hsvColor = ActiveColor; 
            Color tempColor = Color.Red;
            float mVal = 255.0f;
            float divVal = 255.0f;
            var finalImage = new Bitmap(256, 256, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(finalImage);

            for (int x = 0; x < 256; x++) {
                for (int y = 0; y < 256; y++) {
                    float xV = (float)x / divVal;
                    float yV = ((mVal - (float)y) / divVal);
                    hsvColor.b = yV;
                    hsvColor.s = xV;
                    tempColor = ColorTE.ColorFromHSV(hsvColor);
                    int alpha = (int)(this.AlphaValue * 255.0f);
                    Pen opaquePen = new Pen(Color.FromArgb(alpha, tempColor.R, tempColor.G, tempColor.B), 1);
                    Rectangle rect = new Rectangle(x, y, 1, 1);
                    g.DrawRectangle(opaquePen, rect);
                }
            }
            this.ColorBox = finalImage;
            this.Invalidate();
        }

        private void btnRainbowPicker_MouseDown(object sender, MouseEventArgs e) {
            this.DraggingRainbowPicker = true;
            this.DraggingMouseOffset = e.Y;
        }

        private void btnRainbowPicker_MouseUp(object sender, MouseEventArgs e) {
            this.DraggingRainbowPicker = false;
        }

        private void btnRainbowPicker_MouseMove(object sender, MouseEventArgs e) {
            if (this.DraggingRainbowPicker == true) {
                Point mousePos = Cursor.Position;
                Point panelPosition = this.PointToScreen(this.rainbowPanel.Location);
                int y = Math.Max(0 + DraggingMouseOffset, Math.Min(mousePos.Y - panelPosition.Y, (this.rainbowPanel.Height - (10 - DraggingMouseOffset))));
                this.btnRainbowPicker.Location = new Point(0, y - DraggingMouseOffset);
                
                Timer.Interval = 50;
                Timer.Enabled = true;
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e) {
            ActiveColor.h = this.btnRainbowPicker.Location.Y;
            this.UpdateActiveColor();
            this.DrawColorBox();
            Timer.Enabled = false;
            this.TrackBarMouseClick = false;
        }

        private void UpdateHSVColor(int colorType, int colorValue) {
            Color color = ColorTE.ColorFromHSV(this.ActiveColor);
            switch (colorType) {
                case 0:
                    Color newColor = Color.FromArgb(color.A, colorValue, color.G, color.B);
                    this.ActiveColor = ColorTE.ColorToHSV(newColor);
                    break;
                case 1:
                    Color newColor1 = Color.FromArgb(color.A, color.R, colorValue, color.B);
                    this.ActiveColor = ColorTE.ColorToHSV(newColor1);
                    break;
                case 2:
                    Color newColor2 = Color.FromArgb(color.A, color.R, color.G, colorValue);
                    this.ActiveColor = ColorTE.ColorToHSV(newColor2);
                    break;
            }

            Timer.Interval = 50;
            Timer.Enabled = true;
        }

        private void UpdateHSVColorAlpha(float colorValue) {
            this.AlphaValue = colorValue;

            Timer.Interval = 50;
            Timer.Enabled = true;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e) {
            NumericUpDown x = sender as NumericUpDown;
            this.UpdateHSVColorAlpha((float)x.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) {
            NumericUpDown x = sender as NumericUpDown;
            this.UpdateHSVColor(2, (int)x.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
            NumericUpDown x = sender as NumericUpDown;
            this.UpdateHSVColor(1, (int)x.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            NumericUpDown x = sender as NumericUpDown;
            this.UpdateHSVColor(0, (int)x.Value);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            Color color = ColorTE.ColorFromHSV(this.ActiveColor);
            this.ReturnColor = Color.FromArgb((int)(this.AlphaValue * 255.0f), color.R, color.G, color.B);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void colorRainbow_Click(object sender, EventArgs e) {
            Point mousePos = Cursor.Position;
            Point panelPosition = this.PointToScreen(this.rainbowPanel.Location);
            int y = Math.Max(0, Math.Min(mousePos.Y - panelPosition.Y, this.rainbowPanel.Height - 10));
            this.btnRainbowPicker.Location = new Point(0, y);

            Timer.Interval = 50;
            Timer.Enabled = true;
        }

        private void colorGradient_Click(object sender, EventArgs e) {
            Point mousePos = Cursor.Position;
            Point panelPosition = this.PointToScreen(this.colorBoxPanel.Location);
            int y = Math.Max(0 + DraggingMouseOffset, Math.Min(mousePos.Y - panelPosition.Y, (this.colorBoxPanel.Height - (8 - DraggingMouseOffset))));
            int x = Math.Max(0 + DraggingMouseOffset, Math.Min(mousePos.X - panelPosition.X, (this.colorBoxPanel.Width - (8 - DraggingMouseOffset))));
            this.ColorpickerLocation = new Point(x, y - DraggingMouseOffset);

            ActiveColor.b = MathTE.MapClamp(Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.Y / 255.0f)), 0, 1, 1, 0);
            ActiveColor.s = Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.X / 255.0f));
            this.UpdateActiveColor();
            this.Invalidate();
        }

        private void colorBoxPanel_MouseUp(object sender, MouseEventArgs e) {
            this.DraggingColorBoxPicker = false;
        }

        private void colorBoxPanel_MouseMove(object sender, MouseEventArgs e) {
            if (this.DraggingColorBoxPicker == true) {
                Point mousePos = Cursor.Position;
                Point panelPosition = this.PointToScreen(this.colorBoxPanel.Location);
                int y = Math.Max(0 + DraggingMouseOffset, Math.Min(mousePos.Y - panelPosition.Y, (this.colorBoxPanel.Height - (8 - DraggingMouseOffset))));
                int x = Math.Max(0 + DraggingMouseOffset, Math.Min(mousePos.X - panelPosition.X, (this.colorBoxPanel.Width - (8 - DraggingMouseOffset))));
                this.ColorpickerLocation = new Point(x, y - DraggingMouseOffset);

                ActiveColor.b = MathTE.MapClamp(Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.Y / 255.0f)), 0, 1, 1, 0);
                ActiveColor.s = Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.X / 255.0f));
                this.UpdateActiveColor();
                this.Invalidate();
            }
        }

        private void SetColorBoxLocation() {
            float y = this.ActiveColor.b * 255.0f;
            y = MathTE.Map(y, 0, 256, 256, 0);
            float x = this.ActiveColor.s * 255.0f;
            this.ColorpickerLocation = new Point((int)x,(int)y);
        }

        private void SetRainbowLocation() {
            this.btnRainbowPicker.Location = new Point(0, (int)this.ActiveColor.h);
        }

        private void SetAlphaLocation() {
            this.SliderAlphaValue.Value = (int)(this.AlphaValue * 255);
        }

        private void colorBoxPanel_MouseDown(object sender, MouseEventArgs e) {
            this.DraggingColorBoxPicker = true;
        }

        private void colorBoxPanel_Click(object sender, EventArgs e) {

        }

        private void OnTimedColorBoxEvent(object source, ElapsedEventArgs e) {
            ActiveColor.b = MathTE.MapClamp(Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.Y / 255.0f)), 0, 1, 1, 0);
            ActiveColor.s = Math.Max(0.0f, Math.Min(1.0f, (float)this.ColorpickerLocation.X / 255.0f));
            this.UpdateActiveColor();
            ColorBoxTimer.Enabled = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            if (this.TrackBarMouseClick == false) {
                TrackBar x = sender as TrackBar;
                this.UpdateHSVColorAlpha((float)x.Value / 255);
            }
        }

        private void ColorWheel_Paint(object sender, PaintEventArgs e) {
            Point p = this.colorBoxPanel.Location;
            var finalImage = new Bitmap(this.ColorBox.Width, this.ColorBox.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(finalImage);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            //e.Graphics.DrawImage(OriWotW.Properties.Resources.colorpickerbackground, p.X, p.Y, 256, 256);
            g.DrawImage(OriWotW.Properties.Resources.colorpickerbackground, p.X, p.Y, 256, 256);
            g.DrawImage(this.ColorBox, p.X, p.Y, 256, 256);
            g.DrawImage(OriWotW.Properties.Resources.colorpicker, Math.Max(0, this.ColorpickerLocation.X - 16), Math.Max(0, this.ColorpickerLocation.Y - 16), 16, 16);
            this.colorGradient.BackgroundImage = finalImage;
            finalImage.Save(@"C:\moon\final.jpg", ImageFormat.Jpeg);
        }

        private void SliderAlphaValue_MouseUp(object sender, MouseEventArgs e) {
            this.TrackBarMouseClick = true;
            TrackBar bar = sender as TrackBar;
            bar.Value = Math.Min(255, Math.Max(0, e.X - 8));
            this.UpdateHSVColorAlpha((float)bar.Value / 255);
        }
    }
}