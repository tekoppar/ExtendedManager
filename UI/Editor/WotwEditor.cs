using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using OriWotW.UI;
using OriWotW.UI.Editor;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Timers;
using Tem.TemUI;
using Tem.TemClass;
using Tem.Utility;

namespace OriWotW.UI {
    public partial class WotwEditor : Form {
        private Manager Manager;
        private SceneHierarchy MSceneHierarchy;
        private TreeNode SelectedTreeNodeGameObject;
        private SceneHierarchy SelectedSceneHierarchyGameObject;
        private TreeNode SelectedTreeNodeComponent;
        private SceneHierarchy SelectedSceneHierarchyComponent;
        private bool UserChanged = true;
        private bool UserExpanded = true;
        static public bool BlockValueChanges = false;
        private System.Timers.Timer ValueChangedTimer = new System.Timers.Timer(50);
        public WotwEditor(Manager manager) {
            InitializeComponent();
            this.Manager = manager;
            this.Manager.InjectCommunication.AddCall("CALL34");
            this.Manager.InjectCommunication.AddCall("CALL36");
            ValueChangedTimer.Elapsed += OnTimedEvent;
            ValueChangedTimer.AutoReset = false;
        }

        private void input_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void input_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        public void SetSelectedGameObject(string name) {
            lblSelectedObject.Text = name;
           
            if (name != "None")
                this.Manager.InjectCommunication.AddCall("CALL34");
        }

        private void MoveGameObjectInHierarchy(string currentHierarchy, string newHierarcy) {
            this.Manager.InjectCommunication.AddCall("CALL39PAR" + currentHierarchy + "|" + newHierarcy);

            var path1 = TE.StringToIntVector(currentHierarchy, ",");
            var path2 = TE.StringToIntVector(newHierarcy, ",");
            SceneHierarchy sceneHierarchyCurrent = MSceneHierarchy.GetHierarchyByIndexPath(path1, MSceneHierarchy);
            SceneHierarchy sceneHierarchyNew = MSceneHierarchy.GetHierarchyByIndexPath(path2, MSceneHierarchy);
            SceneHierarchy oldParent = sceneHierarchyCurrent.Object.ParentObject;
            oldParent.SceneChildren.Remove(sceneHierarchyCurrent.Object.HierarchyIndex.ToString());

            sceneHierarchyCurrent.Object.HierarchyIndex = sceneHierarchyNew.SceneChildren.Count;
            sceneHierarchyCurrent.Object.SceneIndexHierarchy = new List<int>(sceneHierarchyNew.Object.SceneIndexHierarchy);
            sceneHierarchyCurrent.Object.SceneIndexHierarchy.Add(sceneHierarchyNew.SceneChildren.Count);
            sceneHierarchyCurrent.Object.ParentObject = sceneHierarchyNew;
            sceneHierarchyNew.SceneChildren.Add(sceneHierarchyCurrent.Object.HierarchyIndex.ToString(), sceneHierarchyCurrent);
            SceneHierarchy.UpdateHierarchyIndex(ref sceneHierarchyNew);
            SceneHierarchy.UpdateHierarchyIndex(ref oldParent);
        }

        public void SetSceneHierarchy(string json) {
            sceneHierarchyTree.SuspendLayout();

            var options = new JsonSerializerOptions {
                MaxDepth = 256
            };
            MSceneHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(json, options);
            SceneHierarchy.SetParent(ref MSceneHierarchy);
            sceneHierarchyTree.Nodes.Add(MSceneHierarchy.Object.Name, MSceneHierarchy.Object.Name);
            TreeNode treeNode = sceneHierarchyTree.Nodes[0];
            treeNode.Tag = "MasterGameObject";
            MSceneHierarchy.Object.TreeNode = treeNode;

            List<string> keyList = new List<string>(MSceneHierarchy.SceneChildren.Keys);
            for (int i = 0; i < keyList.Count(); i++) {
                SceneHierarchy sceneHierarchy = MSceneHierarchy.SceneChildren[keyList[i]];
                sceneHierarchy.Object.ParentObject = MSceneHierarchy;
                string treeKey = sceneHierarchy.Object.Name + sceneHierarchy.Object.HierarchyIndex.ToString();
                treeNode.Nodes.Add(treeKey, sceneHierarchy.Object.Name);
                treeNode.Nodes[treeKey].Tag = sceneHierarchy.Object;
                sceneHierarchy.Object.TreeNode = treeNode.Nodes[treeKey];
                BuildSceneHierarchy(treeNode.Nodes[treeKey], sceneHierarchy);
            }
            sceneHierarchyTree.ResumeLayout();
        }

        private void BuildSceneHierarchy(TreeNode treeNode, SceneHierarchy sceneHierarchy) {
            if (treeNode.Nodes.ContainsKey("ClassName: " + sceneHierarchy.Object.ClassName) == false)
                treeNode.Nodes.Add("ClassName: " + sceneHierarchy.Object.ClassName, "ClassName: " + sceneHierarchy.Object.ClassName);

            if (sceneHierarchy.Object.SceneComponents.Count > 0) {
                if (treeNode.Nodes.ContainsKey("Components") == false) {
                    treeNode.Nodes.Add("Components", "Components");
                    treeNode.Nodes[1].Tag = "NodeComponents";
                }
                foreach (var component in sceneHierarchy.Object.SceneComponents) {
                    if (treeNode.Nodes[1].Nodes.ContainsKey(component.ClassName) == true) {
                        int index = treeNode.Nodes[1].Nodes.IndexOfKey(component.ClassName);

                        if (treeNode.Nodes[1].Nodes[index].Text != component.ClassName)
                            treeNode.Nodes[1].Nodes[index].Text = component.ClassName;
                    } else {
                        treeNode.Nodes[1].Nodes.Add(component.ClassName, component.ClassName);
                        treeNode.Nodes[1].Nodes[treeNode.Nodes[1].Nodes.Count - 1].Tag = "Component";
                    }
                }
            }

            if (sceneHierarchy.SceneChildren.Count > 0) {
                if (treeNode.Nodes.ContainsKey("Children") == false) {
                    treeNode.Nodes.Add("Children", "Children");
                    treeNode.Nodes[2].Tag = "NodeChildren";
                }

                List<string> keyList = new List<string>(sceneHierarchy.SceneChildren.Keys);
                for (int i = 0; i < keyList.Count(); i++) {
                    SceneHierarchy child = sceneHierarchy.SceneChildren[keyList[i]];
                    string treeKey = child.Object.Name + child.Object.HierarchyIndex.ToString();

                    if (treeNode.Nodes[2].Nodes.ContainsKey(treeKey)) {
                        treeNode.Nodes[2].Nodes[treeKey].Tag = sceneHierarchy.SceneChildren[keyList[i]].Object;
                        sceneHierarchy.SceneChildren[keyList[i]].Object.TreeNode = treeNode.Nodes[2].Nodes[treeKey];
                        BuildSceneHierarchy(treeNode.Nodes[2].Nodes[treeKey], child);
                    } else {
                        treeNode.Nodes[2].Nodes.Add(treeKey, child.Object.Name);
                        treeNode.Nodes[2].Nodes[treeKey].Tag = sceneHierarchy.SceneChildren[keyList[i]].Object;
                        sceneHierarchy.SceneChildren[keyList[i]].Object.TreeNode = treeNode.Nodes[2].Nodes[treeKey];
                        BuildSceneHierarchy(treeNode.Nodes[2].Nodes[treeKey], child);
                    }
                }
            }
        }

        private void sceneHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e) {
            if (sceneHierarchyTree.SelectedNode != null && sceneHierarchyTree.SelectedNode.Tag != null) {
                if (sceneHierarchyTree.SelectedNode.Tag.GetType().Name == "SceneObject") {
                    SceneObject temp = sceneHierarchyTree.SelectedNode.Tag as SceneObject;

                    if (temp.SceneIndexHierarchy.Count == 0) {
                        SceneHierarchy parentHierarchy = temp.ParentObject;
                        SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                    }

                    this.Manager.InjectCommunication.AddCall("CALL37PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
                    this.Manager.InjectCommunication.AddCall("CALL42PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
                    SelectedTreeNodeGameObject = e.Node;
                    SelectedSceneHierarchyGameObject = MSceneHierarchy.GetHierarchyByIndexPath(temp.SceneIndexHierarchy, MSceneHierarchy);
                } else if (sceneHierarchyTree.SelectedNode.Tag.ToString() == "Component") {
                    SelectedTreeNodeComponent = e.Node;
                    SceneObject temp = SelectedTreeNodeComponent.Parent.Parent.Tag as SceneObject;

                    if (temp.SceneIndexHierarchy.Count == 0) {
                        SceneHierarchy parentHierarchy = temp.ParentObject;
                        SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                    }

                    SelectedSceneHierarchyComponent = MSceneHierarchy.GetHierarchyByIndexPath(temp.SceneIndexHierarchy, MSceneHierarchy);

                    foreach (var component in SelectedSceneHierarchyComponent.Object.SceneComponents) {
                        if (component.ClassName == SelectedTreeNodeComponent.Text)
                            ShowFieldsPropertie(component);
                    }
                }
            }
        }

        private TreeNode? HierarchyIndexToTreeNode(ref List<string> path, ref TreeNode node) {
            if (path.Count == 0 || path[0] == node.Text)
                return node;

            for (int i = 0; i < node.Nodes.Count; i++) {
                TreeNode child = node.Nodes[i];

                if (child.Text == path[0]) {
                    List<string> newPath = new List<string>(path);
                    newPath.RemoveAt(0);
                    return HierarchyIndexToTreeNode(ref newPath, ref child);
                }
            }

            return null;
        }

        public void AddStringToSceneHierarchy(string content) {
            sceneHierarchyTree.SuspendLayout();
            List<string> contentT = content.Split('|').ToList();
            List<int> pathInt = TE.StringToIntVector(contentT[0], ",");

            if (pathInt.Count == 1 && pathInt[0] == 999) {
                SceneHierarchy newHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(contentT[1], new JsonSerializerOptions { MaxDepth = 256 });

                if (newHierarchy != null) {
                    foreach (var child in newHierarchy.SceneChildren) {
                        if (MSceneHierarchy.SceneChildren.ContainsKey(child.Key) == false) {
                            child.Value.Object.ParentObject = MSceneHierarchy;
                            string treeKey = child.Value.Object.Name + child.Value.Object.HierarchyIndex.ToString();
                            MSceneHierarchy.Object.TreeNode.Nodes.Add(treeKey, child.Value.Object.Name);
                            MSceneHierarchy.Object.TreeNode.Nodes[treeKey].Tag = child.Value.Object;
                            child.Value.Object.TreeNode = MSceneHierarchy.Object.TreeNode.Nodes[treeKey];
                            MSceneHierarchy.SceneChildren.Add(child.Key, child.Value);
                            BuildSceneHierarchy(MSceneHierarchy.Object.TreeNode.Nodes[treeKey], child.Value);
                        }
                    }
                    sceneHierarchyTree.ResumeLayout();
                }
            } else {
                SceneHierarchy oldScene = MSceneHierarchy.GetHierarchyByIndexPath(pathInt, MSceneHierarchy);
                SceneHierarchy newHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(contentT[1], new JsonSerializerOptions { MaxDepth = 256 });

                if (oldScene != null && newHierarchy != null && oldScene.Object.ParentObject != null) {
                    oldScene.SceneChildren.Clear();

                    if (oldScene.Object.TreeNode.Nodes.Count > 2)
                        oldScene.Object.TreeNode.Nodes[2].Nodes.Clear();

                    newHierarchy.Object.ParentObject = oldScene.Object.ParentObject;
                    oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()] = newHierarchy;
                    oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()].Object.TreeNode = oldScene.Object.TreeNode;
                    oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()].Object.TreeNode.Tag = oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()].Object;
                    SceneHierarchy.SetParent(ref newHierarchy);
                    BuildSceneHierarchy(oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()].Object.TreeNode, oldScene.Object.ParentObject.SceneChildren[oldScene.Object.HierarchyIndex.ToString()]);
                    sceneHierarchyTree.ResumeLayout();
                }
            }
        }

        private void cloneGameObject_Click(object sender, EventArgs e) {
            if (sceneHierarchyTree.SelectedNode != null && sceneHierarchyTree.SelectedNode.Tag != null && sceneHierarchyTree.SelectedNode.Tag.GetType().Name == "SceneObject") {
                SceneObject temp = sceneHierarchyTree.SelectedNode.Tag as SceneObject;

                if (temp.SceneIndexHierarchy.Count == 0) {
                    SceneHierarchy parentHierarchy = temp.ParentObject;
                    SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                }

                this.Manager.InjectCommunication.AddCall("CALL40PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
            }
        }

        private void sceneHierarchyTree_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            if (e.Node != null && e.Node.Tag != null && UserExpanded == true) {
                if (e.Node.Tag.GetType().Name == "SceneObject") {
                    SceneObject temp = e.Node.Tag as SceneObject;

                    if (temp.SceneIndexHierarchy.Count == 0) {
                        SceneHierarchy parentHierarchy = temp.ParentObject;
                        SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                    }

                    this.Manager.InjectCommunication.AddCall("CALL41PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
                } else if (e.Node.Text == "Scene Roots") {
                    this.Manager.InjectCommunication.AddCall("CALL41PAR999");
                } else {
                    switch (e.Node.Tag.ToString()) {

                        case "NodeComponents": {
                                if (e.Node.Parent != null && e.Node.Parent.Text != "Scene Roots") {
                                    SceneObject temp = e.Node.Parent.Tag as SceneObject;

                                    if (temp.SceneIndexHierarchy.Count == 0) {
                                        SceneHierarchy parentHierarchy = temp.ParentObject;
                                        SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                                    }

                                    this.Manager.InjectCommunication.AddCall("CALL42PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
                                    SelectedTreeNodeGameObject = e.Node.Parent;
                                    SelectedSceneHierarchyGameObject = MSceneHierarchy.GetHierarchyByIndexPath(temp.SceneIndexHierarchy, MSceneHierarchy);
                                }
                            }
                            break;
                    }
                }
            }
        }

        public void LoadFieldsProperties(string values) {
            if (values != "None") {
                values = values.Replace("\\", "\\\\");
                var options = new JsonSerializerOptions {
                    MaxDepth = 256
                };
                SceneHierarchy newHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(values, options);
                List<int> indexes = new List<int>(SelectedSceneHierarchyGameObject.Object.SceneIndexHierarchy);
                SceneObject Object = newHierarchy.Object;
                SceneHierarchy.SetObjectByNamePath(ref indexes, ref SelectedSceneHierarchyGameObject, ref Object);
                SceneHierarchy.SetParent(ref SelectedSceneHierarchyGameObject);
            }
        }

        public void LoadFieldsProperties(string values, List<int> hierarchyIndex) {
            if (values != "None") {
                values = values.Replace("\\", "\\\\");
                var options = new JsonSerializerOptions {
                    MaxDepth = 256
                };

                if (hierarchyIndex[0] == 999)
                    hierarchyIndex.RemoveAt(0);

                SceneHierarchy newHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(values, options);
                List<int> indexes = new List<int>(hierarchyIndex);
                SceneObject Object = newHierarchy.Object;
                List<int> tIndexes = new List<int>(hierarchyIndex);
                SceneHierarchy sceneHierarchy = MSceneHierarchy.GetHierarchyByIndexPath(tIndexes, MSceneHierarchy);
                SceneHierarchy.SetObjectByNamePath(ref indexes, ref sceneHierarchy, ref Object);
                SceneHierarchy.SetParent(ref sceneHierarchy);
                ShowFieldsProperties(newHierarchy.Object.Properties, newHierarchy.Object.Fields);
            }
        }

        private void ShowFieldsPropertie(Editor.Component component) {
            FieldsPropertiesTree.Nodes.Clear();

            FieldsPropertiesTree.Nodes.Add("Tree", "Tree");
            TreeNode tree = FieldsPropertiesTree.Nodes[0];
            FieldsPropertiesTree.Visible = true;
            selectedFieldProperty.Visible = true;
            selectedFieldProperty.Text = "Selected Field/Property: None";

            component.ObjectData.AddValueTreeNodes(ref tree);
            //ShowFieldsProperties(component.Properties, component.Fields);
        }

        private void ShowFieldsProperties(List<ClassProperty> properties, List<ClassField> fields) {
            FieldsPropertiesTree.Nodes.Clear();

            FieldsPropertiesTree.Nodes.Add("Tree", "Tree");
            TreeNode tree = FieldsPropertiesTree.Nodes[0];
            FieldsPropertiesTree.Visible = true;
            selectedFieldProperty.Visible = true;
            selectedFieldProperty.Text = "Selected Field/Property: None";
            foreach (var field in properties) {
                field.AddValueTreeNodes(ref tree);
            }
            foreach (var property in fields) {
                property.AddValueTreeNodes(ref tree);
            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e) {
            BlockValueChanges = false;
        }

        public string GetFieldPropertyTreePath(TreeNode node) {
            List<string> path = new List<string>();
            TreeNode active = node;

            while (active.Parent != null) {
                path.Add(active.Text);
                TreeNode temp = active.Parent;
                active = temp;
            }

            path.Reverse();
            return string.Join(".", path.ToArray());
        }

        public void Component_ValueChanged(object sender, EventArgs e) {
            if (UserChanged == false || BlockValueChanges == true)
                return;

            ValueChangedTimer.Enabled = true;
            BlockValueChanges = true;

            Control control = sender as Control;
            Type cType = control.Tag.GetType();
            string hierarchyIndex, componentName = "", fieldPropName, fieldPropPath, newValue;
            bool isField = true;
            VariableType type;

            if (cType.Name == "ClassField") {
                ClassField field = (ClassField)control.Tag;

                if (field.ParentObject == null)
                    return;

                type = field.Type;
                List<int> indexes = new List<int>();

                if (field.ParentObject.GetType().Name == "Component") {
                    Editor.Component comp = (Editor.Component)field.ParentObject;
                    SceneHierarchy.GetHierarchyIndexList(ref indexes, ref comp.ParentObject.ParentObject);
                    indexes.Reverse();
                    indexes.Add(comp.ParentObject.HierarchyIndex);
                    componentName = comp.ClassName;
                } else if (field.ParentObject.GetType().Name == "SceneObject") {
                    Editor.SceneObject scene = (Editor.SceneObject)field.ParentObject;
                    SceneHierarchy.GetHierarchyIndexList(ref indexes, ref scene.ParentObject);
                    indexes.Reverse();
                    indexes.Add(scene.HierarchyIndex);
                    componentName = scene.ClassName;
                }

                hierarchyIndex = TE.IntVectorToString(indexes, ",");
                fieldPropName = field.Name;
            } else {
                isField = false;
                ClassProperty property = (ClassProperty)control.Tag;

                if (property.ParentObject == null)
                    return;

                type = property.ReturnType;
                List<int> indexes = new List<int>();

                if (property.ParentObject.GetType().Name == "Component") {
                    Editor.Component comp = (Editor.Component)property.ParentObject;
                    SceneHierarchy.GetHierarchyIndexList(ref indexes, ref comp.ParentObject.ParentObject);
                    indexes.Reverse();
                    indexes.Add(comp.ParentObject.HierarchyIndex);
                    componentName = comp.ClassName;
                } else if (property.ParentObject.GetType().Name == "SceneObject") {
                    Editor.SceneObject scene = (Editor.SceneObject)property.ParentObject;
                    SceneHierarchy.GetHierarchyIndexList(ref indexes, ref scene.ParentObject);
                    indexes.Reverse();
                    indexes.Add(scene.HierarchyIndex);
                    componentName = scene.ClassName;
                }

                hierarchyIndex = TE.IntVectorToString(indexes, ",");
                fieldPropName = property.Name;
            }

            fieldPropPath = GetFieldPropertyTreePath(FieldsPropertiesTree.SelectedNode);

            switch (type) {
                default:
                case VariableType.String: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Short:
                case VariableType.Integer:
                case VariableType.Long:
                case VariableType.UShort:
                case VariableType.UInt:
                case VariableType.ULong: {
                        NumericUpDown temp = control as NumericUpDown;
                        newValue = temp.Value.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Value.ToString(CultureInfo.CreateSpecificCulture("en-US")) + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Char: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Pointer: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Vector: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Map: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Float: {
                        NumericUpDown temp = control as NumericUpDown;
                        newValue = temp.Value.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Value.ToString(CultureInfo.CreateSpecificCulture("en-US")) + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Bool: {
                        CheckBox temp = control as CheckBox;
                        newValue = temp.Checked.ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Checked.ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Vector4: {
                        Vector4Control temp = control as Vector4Control;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Color: {
                        Vector4Control temp = control as Vector4Control;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Vector3: {
                        Vector3Control temp = control as Vector3Control;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Rect: {
                        Vector4Control temp = control as Vector4Control;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Vector2: {
                        Vector2Control temp = control as Vector2Control;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Enum: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Bounds: {
                        BoundsControl temp = control as BoundsControl;
                        newValue = temp.GetValue().ToString();
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.GetValue().ToString() + "|" + isField.ToString());
                    }
                    break;
                case VariableType.Matrix4x4: {
                        TextBox temp = control as TextBox;
                        newValue = temp.Text;
                        this.Manager.InjectCommunication.AddCall("CALL43PAR" + hierarchyIndex + "|" + componentName + "|" + fieldPropPath + "|" + fieldPropName + "|" + temp.Text + "|" + isField.ToString());
                    }
                    break;
            }

            if (cType.Name == "ClassField") {
                ClassField field = (ClassField)control.Tag;
                field.FieldValue = newValue;
            } else {
                ClassProperty property = (ClassProperty)control.Tag;
                property.PropertyValue = newValue;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Manager.InjectCommunication.AddCall("CALL44");
        }

        private void btnLoadWorld_Click(object sender, EventArgs e) {
            this.Manager.InjectCommunication.AddCall("CALL45");
        }

        private void WotwEditor_Enter(object sender, EventArgs e) {
            this.Manager.rawInput.RemoveMessageFilter();
        }

        private void WotwEditor_Leave(object sender, EventArgs e) {
            this.Manager.rawInput.AddMessageFilter();
        }

        private void FieldsPropertiesTree_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode node = FieldsPropertiesTree.SelectedNode;
            UserChanged = false;

            if (node.Tag == null)
                return;

            Type cType = node.Tag.GetType();
            string value, name;
            object fieldProperty;
            VariableType type;

            if (cType.Name == "ClassField") {
                ClassField field = (ClassField)node.Tag;
                type = field.Type;
                value = field.FieldValue;
                name = field.Name;
                fieldProperty = field;
            } else if (cType.Name == "ClassProperty") {
                ClassProperty property = (ClassProperty)node.Tag;
                type = property.ReturnType;
                value = property.PropertyValue;
                name = property.Name;
                fieldProperty = property;
            } else
                return;

            fieldPropFloatValue.Visible = false;
            fieldPropIntValue.Visible = false;
            fieldPropStringValue.Visible = false;
            fieldPropVector2Value.Visible = false;
            fieldPropVector3Value.Visible = false;
            fieldPropVector4Value.Visible = false;
            fieldPropBooleanValue.Visible = false;
            fieldPropBoundsValue.Visible = false;

            switch (type) {
                default:
                case VariableType.String:
                case VariableType.Char:
                case VariableType.Pointer:
                case VariableType.Vector:
                case VariableType.Map:
                case VariableType.Matrix4x4:
                case VariableType.Enum:
                    fieldPropStringValue.Text = value;
                    fieldPropStringValue.Visible = true;
                    fieldPropStringValue.Tag = fieldProperty;
                    break;

                case VariableType.Float:
                    float tempFloat = float.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    if (tempFloat > (float)decimal.MinValue && tempFloat < (float)decimal.MaxValue)
                        fieldPropFloatValue.Value = (decimal)tempFloat;
                    else
                        fieldPropFloatValue.Value = -1;
                    fieldPropFloatValue.Visible = true;
                    fieldPropFloatValue.Tag = fieldProperty;
                    break;

                case VariableType.Bool:
                    fieldPropBooleanValue.Text = name;
                    fieldPropBooleanValue.Checked = value == "0" ? false : true;
                    fieldPropBooleanValue.Visible = true;
                    fieldPropBooleanValue.Tag = fieldProperty;
                    break;

                case VariableType.Integer:
                    fieldPropIntValue.Value = (decimal)int.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;
                case VariableType.Short:
                    fieldPropIntValue.Value = (decimal)int.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;
                case VariableType.Long:
                    fieldPropIntValue.Value = (decimal)Int64.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;
                case VariableType.UShort:
                    fieldPropIntValue.Value = (decimal)uint.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;
                case VariableType.UInt:
                    fieldPropIntValue.Value = (decimal)uint.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;
                case VariableType.ULong:
                    fieldPropIntValue.Value = (decimal)UInt64.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));
                    fieldPropIntValue.Visible = true;
                    fieldPropIntValue.Tag = fieldProperty;
                    break;

                case VariableType.Vector2:
                    fieldPropVector2Value.SetValue(new Vector2(value));
                    fieldPropVector2Value.Visible = true;
                    fieldPropVector2Value.Tag = fieldProperty;
                    break;

                case VariableType.Vector3:
                    fieldPropVector3Value.SetValue(new Vector3(value));
                    fieldPropVector3Value.Visible = true;
                    fieldPropVector3Value.Tag = fieldProperty;
                    break;

                case VariableType.Color:
                case VariableType.Vector4:
                case VariableType.Rect:
                    fieldPropVector4Value.SetValue(new TColor(value));
                    fieldPropVector4Value.Visible = true;
                    fieldPropVector4Value.Tag = fieldProperty;
                    break;

                case VariableType.Bounds:
                    string[] values = value.Split(';');
                    fieldPropBoundsValue.SetValue(new Vector3(values[0]), new Vector3(values[1]));
                    fieldPropBoundsValue.Visible = true;
                    fieldPropBoundsValue.Tag = fieldProperty;
                    break;

            }

            UserChanged = true;
        }

        private void treeView_DragOver(object sender, DragEventArgs e) {
            sceneHierarchyTree.Scroll();
        }

        private void sceneHierarchyTree_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (e.Node != null && e.Node.Tag != null && e.Node.Tag.GetType().Name == "SceneObject") {
                SceneObject temp = e.Node.Tag as SceneObject;

                if (temp.SceneIndexHierarchy.Count == 0) {
                    SceneHierarchy parentHierarchy = temp.ParentObject;
                    SceneHierarchy.UpdateHierarchyIndex(ref parentHierarchy);
                }
                this.Manager.InjectCommunication.AddCall("CALL47PAR" + TE.IntVectorToString(temp.SceneIndexHierarchy, ","));
            }
        }

        private void btnNewScene_Click(object sender, EventArgs e) {
            SceneCreator sceneCreator = new SceneCreator(this.Manager);

            if (sceneCreator.ShowDialog() == DialogResult.OK)
                this.Manager.InjectCommunication.AddCall("CALL8PAR" + sceneCreator.ReturnName + "|" + sceneCreator.ReturnPosition.ToString() + "|" + sceneCreator.ReturnSize.ToString() + "|" + sceneCreator.ReturnLoadingRect.ToString());
        }
    }

    public static class NativeMethods {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        public static void Scroll(this Control control) {
            var pt = control.PointToClient(Cursor.Position);

            if ((pt.Y + 20) > control.Height) {
                // scroll down
                SendMessage(control.Handle, 277, (IntPtr)1, (IntPtr)0);
            } else if (pt.Y < 20) {
                // scroll up
                SendMessage(control.Handle, 277, (IntPtr)0, (IntPtr)0);
            }
        }
    }
}
