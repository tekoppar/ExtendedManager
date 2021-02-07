using System;
using System.Collections.Generic;
using System.Linq;
#nullable enable
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using OriWotW.UI;
using Tem.TemClass;
using Tem.TemUI;

namespace OriWotW.UI.Editor {
    public enum VariableType {
        Null = -1,
        String = 0,
        Integer = 1,
        Char = 2,
        Pointer = 3,
        Vector = 4,
        Map = 5,
        Float = 6,
        Bool = 7,
        Rect = 8,
        Quaternion = 9,
        Vector3 = 10,
        Vector4 = 11,
        Color = 12,
        Vector2 = 13,
        Enum = 14,
        Bounds = 15,
        Long = 16,
        Short = 17,
        UShort = 18,
        UInt = 19,
        ULong = 20,
        Matrix4x4 = 21
    };
    public class ClassProperty {
        [NonSerialized] public bool IsSceneOrComponent = false;
        [NonSerialized] public object? ParentObject = null;
        public string Name { get; set; } = "";
        public VariableType ReturnType { get; set; } = VariableType.Null;
        public string PropertyValue { get; set; } = "";
        public void AddPropertyControls(ref Control control, EventHandler eventHandler, EventHandler onEnter, EventHandler onLeave) {
            Control newControl = Component.AddValueControls(ref control, ref eventHandler, ref onEnter, ref onLeave, this.Name, this.PropertyValue, false, this.ReturnType);
            newControl.Tag = this;
        }
        public void AddValueTreeNodes(ref TreeNode node) {
            TreeNode newNode = node.Nodes.Add(this.Name);
            newNode.Tag = this;
        }
    };
    public class ClassField {
        [NonSerialized] public bool IsSceneOrComponent = false;
        [NonSerialized] public object? ParentObject = null;
        [NonSerialized] public ClassField? ParentField = null;
        public string Name { get; set; } = "";
        public int TypeDefIndex { get; set; } = -1;
        public VariableType Type { get; set; } = VariableType.Null;
        public string FieldValue { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string Namespace { get; set; } = "";
        public string ClassName { get; set; } = "";
        public void AddFieldControls(ref Control control, EventHandler eventHandler, EventHandler onEnter, EventHandler onLeave) {
            Control newControl = Component.AddValueControls(ref control, ref eventHandler, ref onEnter, ref onLeave, this.Name, this.FieldValue, true, this.Type);
            newControl.Tag = this;
        }

        public string GetFieldHierarchy() {
            List<string> fieldHierarchy = new List<string>();
            if (this.ParentField != null) {
                fieldHierarchy.Add(this.Name);

                ClassField? field = this.ParentField;
                while (field != null) {
                    fieldHierarchy.Add(field.Name);
                    field = field.ParentField;
                }
            }
            fieldHierarchy.Reverse();
            return string.Join(".", fieldHierarchy.ToArray());
        }
        public void AddValueTreeNodes(ref TreeNode node) {
            TreeNode newNode = node.Nodes.Add(Name);
            newNode.Tag = this;
        }
    };

    public class ObjectData {
        public bool HasChanged { get; set; } = false;
        public string Namespace { get; set; } = "";
        public string Name { get; set; } = "";
        public List<ClassField> Fields { get; set; } = new List<ClassField>();
        public List<ClassProperty> Properties { get; set; } = new List<ClassProperty>();
        public List<ObjectData> NestedObjects { get; set; } = new List<ObjectData>();

        public void AddValueTreeNodes(ref TreeNode node) {
            TreeNode newNode = node.Nodes.Add(Name);
            newNode.Tag = this;

            for (int i = 0; i < Fields.Count; i++) {
                Fields[i].AddValueTreeNodes(ref newNode);
            }
            for (int i = 0; i < Properties.Count; i++) {
                Properties[i].AddValueTreeNodes(ref newNode);
            }
            for (int i = 0; i < NestedObjects.Count; i++) {
                NestedObjects[i].AddValueTreeNodes(ref newNode);
            }
        }

        public static void SetParent(ref ObjectData data, ref Component component) {
            int index = 0;
            foreach (var child2 in data.Fields) {
                child2.ParentObject = component;
                index++;
            }
            index = 0;
            foreach (var child2 in data.Properties) {
                child2.ParentObject = component;
                index++;
            }

            for (int i = 0; i < data.NestedObjects.Count; i++) {
                ObjectData temp = data.NestedObjects[i];
                SetParent(ref temp, ref component);
            }
        }
}
    public class Component {
        [NonSerialized] public SceneObject? ParentObject = null;
        public string ClassName { get; set; } = "";
        public ObjectData ObjectData { get; set; } = new ObjectData();

        public static Control AddValueControls(ref Control control, ref EventHandler eventHandler, ref EventHandler onEnter, ref EventHandler onLeave, string name, string value, bool isField, VariableType type) {
            Control newControl;
            switch (type) {
                default:
                case VariableType.String: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Integer: {
                        NumericUpDown temp = new NumericUpDown();
                        temp.Maximum = decimal.MaxValue;
                        temp.Minimum = decimal.MinValue;
                        temp.DecimalPlaces = 0;
                        temp.ReadOnly = false;
                        temp.Value = (decimal)int.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                        temp.ValueChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Char: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Pointer: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Vector: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Map: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Float: {
                        NumericUpDown temp = new NumericUpDown();
                        temp.Maximum = decimal.MaxValue;
                        temp.Minimum = decimal.MinValue;
                        temp.DecimalPlaces = 5;
                        temp.ReadOnly = false;
                        float tempFloat = float.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                        if (tempFloat > (float)decimal.MinValue && tempFloat < (float)decimal.MaxValue)
                            temp.Value = (decimal)tempFloat;
                        else
                            temp.Value = -1;

                        temp.ValueChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Bool: {
                        CheckBox temp = new CheckBox();
                        temp.Checked = value == "0" ? false : true;
                        temp.CheckedChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Vector4: {
                        Vector4Control temp = new Vector4Control();
                        temp.SetValue(new TColor(value));
                        temp.OnValueChangedNoArgs += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Vector3: {
                        Vector3Control temp = new Vector3Control();
                        temp.SetValue(new Vector3(value));
                        temp.OnValueChangedNoArgs += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Rect: {
                        Vector4Control temp = new Vector4Control();
                        temp.SetValue(new TColor(value));
                        temp.OnValueChangedNoArgs += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Vector2: {
                        Vector2Control temp = new Vector2Control();
                        temp.SetValue(new Vector2(value));
                        temp.OnValueChangedNoArgs += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Enum: {
                        TextBox temp = new TextBox();
                        temp.Text = value.Trim();
                        temp.ReadOnly = false;
                        temp.TextChanged += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
                case VariableType.Bounds: {
                        BoundsControl temp = new BoundsControl();
                        string[] values = value.Split(';');
                        temp.SetValue(new Vector3(values[0]), new Vector3(values[1]));
                        temp.OnValueChangedNoArgs += eventHandler;
                        newControl = (Control)temp;
                    }
                    break;
            }

            Label label = new Label();
            label.Text = name;
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.BottomLeft;
            label.Size = new Size(300, 23);
            newControl.Name = name;
            newControl.Enter += onEnter;
            newControl.Leave += onLeave;
            control.Controls.Add(label);
            control.Controls.Add(newControl);
            return newControl;
        }
    };
    public class SceneObject {
        [NonSerialized] public SceneHierarchy? ParentObject = null;
        [NonSerialized] public TreeNode? TreeNode = null;
        public bool IsCustomObject { get; set; } = false;
        public bool HasChanged { get; set; } = false;
        public string Name { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string ClassName { get; set; } = "";
        public List<Component> SceneComponents { get; set; } = new List<Component>();
        public int HierarchyIndex { get; set; } = -1;
        public List<int> SceneIndexHierarchy { get; set; } = new List<int>();
        public List<string> ClonedSceneNameHierarchy { get; set; } = new List<string>();
        public List<ClassField> Fields { get; set; } = new List<ClassField>();
        public List<ClassProperty> Properties { get; set; } = new List<ClassProperty>();
    };
    public class SceneHierarchy {
        public SceneObject Object { get; set; } = new SceneObject();
        public Dictionary<string, SceneHierarchy> SceneChildren { get; set; } = new Dictionary<string, SceneHierarchy>();

        /*ADD STATIC METHOD SO THAT WE CAN ADD THE FIRST CALLER  TO THE INDEXES LIST*/
        public static void GetHierarchyIndexList(ref List<int> indexes, ref SceneHierarchy hierarchy) {
            if (hierarchy.Object.HierarchyIndex != 999)
                indexes.Add(hierarchy.Object.HierarchyIndex);

            if (hierarchy.Object.ParentObject != null)
                GetHierarchyIndexList(ref indexes, ref hierarchy.Object.ParentObject);
        }
        public static SceneHierarchy TraverseHierarchyString(List<string> path, SceneHierarchy hierarchy) {
            if (path.Count == 0)
                return hierarchy;

            foreach (var child in hierarchy.SceneChildren) {
                if (path[0] == child.Value.Object.Name) {
                    List<string> newPathT = new List<string>(path);
                    newPathT.RemoveAt(0);
                    return TraverseHierarchyString(newPathT, child.Value);
                }
            }

            foreach (var component in hierarchy.Object.SceneComponents) {
                if (path[0] == component.ClassName) {
                    List<string> newPathT = new List<string>(path);
                    newPathT.RemoveAt(0);
                    return hierarchy;
                }
            }

            return new SceneHierarchy();
        }

        public static void SetParent(ref SceneHierarchy hierarchy) {
            foreach (var child2 in hierarchy.Object.Properties) {
                child2.ParentObject = hierarchy.Object;
            }

            for (int i = 0; i < hierarchy.Object.SceneComponents.Count; i++) {
                Component component = hierarchy.Object.SceneComponents[i];
                component.ParentObject = hierarchy.Object;
                ObjectData temp = component.ObjectData;
                ObjectData.SetParent(ref temp, ref component);
            }

            foreach (var child in hierarchy.SceneChildren) {
                child.Value.Object.ParentObject = hierarchy;

                if (child.Value.SceneChildren.Count > 0) {
                    SceneHierarchy temp = child.Value;
                    SetParent(ref temp);
                }
            }
        }

        public int ContainsChild(int index) {
                if (this.SceneChildren.ContainsKey(index.ToString()) == true)
                    return index;
                else
                return -1;
        }

        public static bool ContainsChild(List<int> indexes, SceneHierarchy hierarchy, string parentName) {
            SceneHierarchy temp = hierarchy;

            while (indexes.Count > 0 && temp.SceneChildren.ContainsKey(indexes[0].ToString()) == true) {
                SceneHierarchy temp2 = temp.SceneChildren[indexes[0].ToString()];
                indexes.RemoveAt(0);
                temp = temp2;
            }

            return temp.Object.Name == parentName;
        }

        public static void GetHierarchyIndexPath(ref List<int> indexes, ref SceneHierarchy hierarchy) {
            if (hierarchy.Object.HierarchyIndex != 999)
                indexes.Add(hierarchy.Object.HierarchyIndex);

            if (hierarchy.Object.ParentObject != null)
                GetHierarchyIndexPath(ref indexes, ref hierarchy.Object.ParentObject);
        }

        public static void UpdateHierarchyIndex(ref SceneHierarchy hierarchy) {
            SceneHierarchy ptrHierarchy = hierarchy;
            while (ptrHierarchy.Object.ParentObject != null && ptrHierarchy.Object.SceneIndexHierarchy.Count == 0) {
                ptrHierarchy = ptrHierarchy.Object.ParentObject;
            }

            List<string> keyList = new List<string>(ptrHierarchy.SceneChildren.Keys);
            for (int i = 0; i < ptrHierarchy.SceneChildren.Count; i++) {
                SceneHierarchy temp = ptrHierarchy.SceneChildren[keyList[i]];
                temp.Object.SceneIndexHierarchy = new List<int>(ptrHierarchy.Object.SceneIndexHierarchy);
                temp.Object.SceneIndexHierarchy.Add(temp.Object.HierarchyIndex);
                temp.Object.HierarchyIndex = temp.Object.HierarchyIndex;
                temp.Object.ParentObject = ptrHierarchy;

                UpdateHierarchyIndexP(ref temp);
            }
        }
        private static void UpdateHierarchyIndexP(ref SceneHierarchy hierarchy) {
            List<string> keyList = new List<string>(hierarchy.SceneChildren.Keys);
            for (int i = 0; i < hierarchy.SceneChildren.Count; i++) {
                SceneHierarchy temp = hierarchy.SceneChildren[keyList[i]];
                temp.Object.SceneIndexHierarchy = new List<int>(hierarchy.Object.SceneIndexHierarchy);
                temp.Object.SceneIndexHierarchy.Add(temp.Object.HierarchyIndex);
                temp.Object.HierarchyIndex = temp.Object.HierarchyIndex;
                temp.Object.ParentObject = hierarchy;

                UpdateHierarchyIndexP(ref temp);
            }
        }

        public static void SetObjectByNamePath(ref List<int> indexes, ref SceneHierarchy hierarchy, ref SceneObject Object) {
            if (indexes.Count > 0 && hierarchy.SceneChildren.ContainsKey(indexes[0].ToString()) == true) {
                SceneHierarchy temp = hierarchy.SceneChildren[indexes[0].ToString()];
                indexes.RemoveAt(0);
                SetObjectByNamePath(ref indexes, ref temp, ref Object);
            } else {
                Object.ParentObject = hierarchy.Object.ParentObject;
                Object.TreeNode = hierarchy.Object.TreeNode;
                hierarchy.Object = Object;

                if (hierarchy.Object.TreeNode != null)
                    hierarchy.Object.TreeNode.Tag = hierarchy.Object;
            }
        }

        public SceneHierarchy GetHierarchyByIndexPath(List<int> path, SceneHierarchy hierarchy) {
            if (path.Count == 0)
                return hierarchy;

            if (path[0] == 999) {
                List<int> newPathT = new List<int>(path);
                newPathT.RemoveAt(0);
                return GetHierarchyByIndexPath(newPathT, hierarchy);
            }

            foreach (var child in hierarchy.SceneChildren) {
                if (path[0] == child.Value.Object.HierarchyIndex) {
                    List<int> newPathT = new List<int>(path);
                    newPathT.RemoveAt(0);
                    return GetHierarchyByIndexPath(newPathT, child.Value);
                }
            }
            return new SceneHierarchy();
        }

        public int GetHighestIndex() {
            return this.SceneChildren.Count + 1;
        }

        public List<string> GetTreeNodeFromHierarchy() {
            List<string> treePath = new List<string>();
            SceneHierarchy hierarchy = this;
            while (hierarchy.Object.ParentObject != null) {
                treePath.Add(hierarchy.Object.Name);
                hierarchy = hierarchy.Object.ParentObject;
            }

            return treePath;
        }
    }
}
