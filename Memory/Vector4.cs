using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;
namespace OriWotW {
    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
    public struct Vector4 {
        [FieldOffset(0)]
        public float X;
        [FieldOffset(4)]
        public float Y;
        [FieldOffset(8)]
        public float W;
        [FieldOffset(12)]
        public float H;

        public Vector4(string cordinates) {
            string[] cords = cordinates.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            if (cords.Length == 4) {
                float temp = 0;
                float.TryParse(cords[0], out temp);
                this.X = temp;
                float.TryParse(cords[1], out temp);
                this.Y = temp;
                float.TryParse(cords[2], out temp);
                this.W = temp;
                float.TryParse(cords[3], out temp);
                this.H = temp;
            } else {
                this.X = 0;
                this.Y = 0;
                this.W = 0;
                this.H = 0;
            }
        }
        public Vector4(Vector2 pos, float w, float h, bool center) {
            if (center) {
                this.X = pos.X - (w / 2);
                this.Y = pos.Y + (h / 2);
            } else {
                this.X = pos.X;
                this.Y = pos.Y;
            }

            this.W = w;
            this.H = h;
        }
        public Vector4(Vector3 pos, float w, float h, bool center) {
            if (center) {
                this.X = pos.X - (w / 2);
                this.Y = pos.Y + (h / 2);
            } else {
                this.X = pos.X;
                this.Y = pos.Y;
            }

            this.W = w;
            this.H = h;
        }
        public Vector2 GetCenter() {
            return new Vector2() { X = X + (W / 2), Y = Y - (H / 2) };
        }
        public bool Intersects(Vector4 other) {
            return X + W >= other.X && other.X + other.W >= X && Y - H <= other.Y && other.Y - other.H <= Y;
        }
        public override string ToString() {
            return $"{X:0.00}, {Y:0.00}, {W:0.00}, {H:0.00}";
        }
    }

    public struct TColor {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }
        public TColor(float r, float g, float b, float a) {
            if (r <= 1.0f && g <= 1.0f && b <= 1.0f && a <= 1.0f) {
                this.r = r * 255.0f;
                this.g = g * 255.0f;
                this.b = b * 255.0f;
                this.a = a * 255.0f;
            } else {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }
        }
        public TColor(Color color) {
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
            this.a = color.A;
        }

        public TColor(string r, string g, string b, string a) {
            this.r = float.Parse(r, CultureInfo.CreateSpecificCulture("en-US"));
            this.g = float.Parse(g, CultureInfo.CreateSpecificCulture("en-US"));
            this.b = float.Parse(b, CultureInfo.CreateSpecificCulture("en-US"));
            this.a = float.Parse(a, CultureInfo.CreateSpecificCulture("en-US"));
        }
        public TColor(string value) {
            string[] values = value.Split(',');
            this.r = float.Parse(values[0], CultureInfo.CreateSpecificCulture("en-US"));
            this.g = float.Parse(values[1], CultureInfo.CreateSpecificCulture("en-US"));
            this.b = float.Parse(values[2], CultureInfo.CreateSpecificCulture("en-US"));

            if (values.Length >= 4)
                this.a = float.Parse(values[3], CultureInfo.CreateSpecificCulture("en-US"));
            else
                this.a = 1.0f;
        }
        public Color ToColor() {
            return Color.FromArgb((int)this.a, (int)this.r, (int)this.g, (int)this.b);
        }
        public string ToJsonString() {
            string json = "{\"r\":" + this.r.ToString() + ",\"g\":" + this.g.ToString() + ",\"b\":" + this.b.ToString() + ",\"a\":" + this.a.ToString() + "}";
            return json;
        }
        public override string ToString() {
            return this.r.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + this.g.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + this.b.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + this.a.ToString(CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}