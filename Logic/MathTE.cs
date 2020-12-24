using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.IO;

public static class MathTE {
    static public bool IsEqualTo(this double a, double b, double margin) {
        return Math.Abs(a - b) < margin;
    }

    static public float Map(float input, float inputMin, float inputMax, float min, float max) {
        return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
    }
    static public float MapClamp(float input, float inputMin, float inputMax, float min, float max) {
        if (min > max)
            return Math.Max(Math.Min(min + (input - inputMin) * (max - min) / (inputMax - inputMin), min), max);
        else
            return Math.Min(Math.Max(min + (input - inputMin) * (max - min) / (inputMax - inputMin), min), max);
    }
}

public static class TE {
    public static bool IsDisposingNow = false;

    private static Dictionary<string, int> ParentIndexes = new Dictionary<string, int>();
    public struct ObjectValue {
        public string Name { get; set; }
        public string Parent { get; set; }

        public ObjectValue(string name, string parent) {
            this.Name = name;
            this.Parent = parent;
        }
    };
    public static Dictionary<ObjectValue, object> GetPropertyObjectsByType(object src, string objectName, Type type) {
        Dictionary<ObjectValue, object> objects = new Dictionary<ObjectValue, object>();
        FieldInfo[] fields = src.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields) {
            string fieldName = field.Name.Replace("<", "").Replace(">k__BackingField", "").Replace("Color", "");
            var value = TE.GetPropertyValue(src, fieldName);
            if (value != null) {
                if (value.GetType() == type) {
                    ObjectValue value1 = new ObjectValue();
                    value1.Name = fieldName;
                    value1.Parent = objectName;
                    objects.Add(value1, value);
                } else {
                    if (value is IList && value.GetType().IsGenericType) {
                        foreach (var iProp in (IList)value) {
                            Dictionary<ObjectValue, object> foundObjects = GetPropertyObjectsByType(iProp, fieldName, type);
                            if (foundObjects.Count > 0) {
                                foreach (var fObject in foundObjects) {
                                    if (ParentIndexes.ContainsKey(fObject.Key.Parent + '.' + fObject.Key.Name) == true) {
                                        ParentIndexes[fObject.Key.Parent + '.' + fObject.Key.Name] = ParentIndexes[fObject.Key.Parent + '.' + fObject.Key.Name] + 1;

                                        int count = ParentIndexes[fObject.Key.Parent + '.' + fObject.Key.Name];
                                        objects.Add(new ObjectValue(fObject.Key.Name, fObject.Key.Parent + count.ToString()), fObject.Value);
                                    } else {
                                        ParentIndexes[fObject.Key.Parent + '.' + fObject.Key.Name] = 1;
                                        objects.Add(new ObjectValue(fObject.Key.Name, fObject.Key.Parent + ParentIndexes[fObject.Key.Parent + '.' + fObject.Key.Name].ToString()), fObject.Value);
                                    }
                                }
                            }
                        }
                    } else {
                        Dictionary<ObjectValue, object> foundObjects = GetPropertyObjectsByType(value, fieldName, type);
                        if (foundObjects.Count > 0) {
                            foreach (var fObject in foundObjects) {
                                objects.Add(new ObjectValue(fObject.Key.Name, fObject.Key.Parent), fObject.Value);
                            }
                        }
                    }
                }
            }
        }
        return objects;
    }
    public static object GetPropertyValue(object src, string propName) {
        if (src == null) throw new ArgumentException("Value cannot be null.", "src");
        if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

        var properties = src.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in properties) {
            if (prop.Name == propName) {
                var propFound = src.GetType().GetProperty(propName);
                return propFound != null ? propFound.GetValue(src, null) : null;
            }
        }

        foreach (var prop in properties) {
            if (prop.PropertyType.IsClass == true && prop.CanWrite == true) {
                object oProp = prop.GetValue(src, null);
                if (oProp != null) {
                    if (oProp is IList && oProp.GetType().IsGenericType) {
                        foreach (var iProp in (IList)oProp) {
                            if (iProp != null) {
                                object rProp = GetPropertyValue(iProp, propName);
                                if (rProp != null)
                                    return rProp;
                            }
                        }
                    } else {
                        object rProp = GetPropertyValue(oProp, propName);
                        if (rProp != null)
                            return rProp;
                    }
                }
            }
        }

        return null;
    }

    public static bool IsPathRelative(string a, string relative) {
        string rootFolder = "";
        if (Path.IsPathRooted(relative))
            rootFolder = Path.GetPathRoot(relative);

        return rootFolder != "" && a.Contains(rootFolder);
    }

    public static string GetRelativePath(string a, string relative) {
        string rootFolder = "";
        if (Path.IsPathRooted(relative))
            rootFolder = Path.GetPathRoot(relative);

        if (rootFolder != "") {
            rootFolder = a.Replace(relative, "");
        }
        return rootFolder;
    }

    public static string Reverse(string s) {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

public static class ColorTE {

    static float getBrightness(Color c) { return (c.R * 0.299f + c.G * 0.587f + c.B * 0.114f) / 256f; }

    public struct HSV {
        public float h;
        public float s;
        public float b;

        public HSV(Color color) {
            this.h = color.GetHue();
            this.s = color.GetSaturation();
            this.b = getBrightness(color);
        }
    }

    public static HSV ColorToHSV(Color color) {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));
        HSV hsv = new HSV();
        hsv.h = color.GetHue();
        hsv.s = (float)((max == 0) ? 0 : 1d - (1d * min / max));
        hsv.b = (float)(max / 255d);

        return hsv;
    }

    public static Color ColorFromHSV(HSV hsv) {
        int hi = Convert.ToInt32(Math.Floor(hsv.h / 60)) % 6;
        double f = hsv.h / 60 - Math.Floor(hsv.h / 60);

        hsv.b = hsv.b * 255;
        int v = Convert.ToInt32(hsv.b);
        int p = Convert.ToInt32(hsv.b * (1 - hsv.s));
        int q = Convert.ToInt32(hsv.b * (1 - f * hsv.s));
        int t = Convert.ToInt32(hsv.b * (1 - (1 - f) * hsv.s));

        if (hi == 0)
            return Color.FromArgb(255, v, t, p);
        else if (hi == 1)
            return Color.FromArgb(255, q, v, p);
        else if (hi == 2)
            return Color.FromArgb(255, p, v, t);
        else if (hi == 3)
            return Color.FromArgb(255, p, q, v);
        else if (hi == 4)
            return Color.FromArgb(255, t, p, v);
        else
            return Color.FromArgb(255, v, p, q);
    }

    public static Color ColorFromHSV(double hue, double saturation, double value) {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);

        value = value * 255;
        int v = Convert.ToInt32(value);
        int p = Convert.ToInt32(value * (1 - saturation));
        int q = Convert.ToInt32(value * (1 - f * saturation));
        int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        if (hi == 0)
            return Color.FromArgb(255, v, t, p);
        else if (hi == 1)
            return Color.FromArgb(255, q, v, p);
        else if (hi == 2)
            return Color.FromArgb(255, p, v, t);
        else if (hi == 3)
            return Color.FromArgb(255, p, q, v);
        else if (hi == 4)
            return Color.FromArgb(255, t, p, v);
        else
            return Color.FromArgb(255, v, p, q);
    }
}

public static class ColorTT {
    public struct RGB {
        private byte _r;
        private byte _g;
        private byte _b;

        public RGB(byte r, byte g, byte b) {
            this._r = r;
            this._g = g;
            this._b = b;
        }

        public byte R {
            get { return this._r; }
            set { this._r = value; }
        }

        public byte G {
            get { return this._g; }
            set { this._g = value; }
        }

        public byte B {
            get { return this._b; }
            set { this._b = value; }
        }

        public bool Equals(RGB rgb) {
            return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
        }
    }

    public struct HSL {
        private int _h;
        private float _s;
        private float _l;

        public HSL(int h, float s, float l) {
            this._h = h;
            this._s = s;
            this._l = l;
        }

        public int H {
            get { return this._h; }
            set { this._h = value; }
        }

        public float S {
            get { return this._s; }
            set { this._s = value; }
        }

        public float L {
            get { return this._l; }
            set { this._l = value; }
        }

        public bool Equals(HSL hsl) {
            return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
        }
    }

    public static RGB HSLToRGB(HSL hsl) {
        byte r = 0;
        byte g = 0;
        byte b = 0;

        if (hsl.S == 0) {
            r = g = b = (byte)(hsl.L * 255);
        } else {
            float v1, v2;
            float hue = (float)hsl.H / 360;

            v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
            v1 = 2 * hsl.L - v2;

            r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
            g = (byte)(255 * HueToRGB(v1, v2, hue));
            b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
        }

        return new RGB(r, g, b);
    }

    private static float HueToRGB(float v1, float v2, float vH) {
        if (vH < 0)
            vH += 1;

        if (vH > 1)
            vH -= 1;

        if ((6 * vH) < 1)
            return (v1 + (v2 - v1) * 6 * vH);

        if ((2 * vH) < 1)
            return v2;

        if ((3 * vH) < 2)
            return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

        return v1;
    }
}