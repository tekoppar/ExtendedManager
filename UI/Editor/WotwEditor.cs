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
using OriWotW.UI.VisualEditor;
using OriWotW.UI.Editor;

namespace OriWotW.UI {
    public partial class WotwEditor : Form {
        private Manager Manager;
        public WotwEditor(Manager manager) {
            InitializeComponent();
            this.Manager = manager;
            this.Manager.InjectCommunication.AddCall("CALL34");
            this.Manager.InjectCommunication.AddCall("CALL36");
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Manager.InjectCommunication.AddCall("CALL33PAR" + this.position.GetValue().ToString() + "|" + this.localPosition.GetValue().ToString() + "|" + this.scale.GetValue().ToString() + "|" + this.rotation.GetValue().ToString() + "|" + this.matSortingOrder.Value.ToString() + "|" + this.moonZOffset.Value.ToString() + "|" + this.matRenderQueue.Value.ToString() + "|" + this.layerMaskValue.Value.ToString());
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
        }

        public void SetSceneHierarchy(string json) {
            SceneHierarchy sceneHierarchy = new SceneHierarchy();
            sceneHierarchy = JsonSerializer.Deserialize<SceneHierarchy>(json);
            sceneHierarchyTree.Nodes.Add("Scene Hierarchy");
            sceneHierarchyTree.Nodes[0].Nodes.Add(sceneHierarchy.Object.Name);
            TreeNode treeNode = sceneHierarchyTree.Nodes[0].Nodes[0];
            treeNode.Tag = "MasterGameObject";
            BuildSceneHierarchy(ref treeNode, sceneHierarchy);
            /*sceneHierarchyTree.Nodes.Add(sceneHierarchy.Object.Name);
            sceneHierarchyTree.Nodes[0].Nodes.Add("ClassName: " + sceneHierarchy.Object.ClassName);
            sceneHierarchyTree.Nodes[0].Nodes.Add("Components");
            sceneHierarchyTree.Nodes[0].Nodes.Add("Children");

            foreach (string component in sceneHierarchy.Object.SceneComponents) {
                sceneHierarchyTree.Nodes[0].Nodes[1].Nodes.Add(component);
            }

            for (int i = 0; i < sceneHierarchy.SceneChildren.Count; i++) {
                SceneHierarchy sceneChild = sceneHierarchy.SceneChildren[i];
                sceneHierarchyTree.Nodes[0].Nodes[2].Nodes.Add("Name: " + sceneChild.Object.Name);
                sceneHierarchyTree.Nodes[0].Nodes[2].Nodes[i].Nodes.Add("ClassName: " + sceneChild.Object.ClassName);
                sceneHierarchyTree.Nodes[0].Nodes[2].Nodes[i].Nodes.Add("ParentName: " + sceneChild.Object.ParentName);
                sceneHierarchyTree.Nodes[0].Nodes[2].Nodes[i].Nodes.Add("Components");

                foreach (string sceneChildComponent in sceneChild.Object.SceneComponents) {
                    sceneHierarchyTree.Nodes[0].Nodes[2].Nodes[i].Nodes[2].Nodes.Add(sceneChildComponent);
                }
            }*/
        }

        private void BuildSceneHierarchy(ref TreeNode treeNode, SceneHierarchy sceneHierarchy) {
            treeNode.Nodes.Add("ClassName: " + sceneHierarchy.Object.ClassName);
            treeNode.Nodes.Add("Components");
            treeNode.Nodes.Add("Children");

            foreach (string component in sceneHierarchy.Object.SceneComponents) {
                treeNode.Nodes[1].Nodes.Add(component);
            }

            for (int i = 0; i < sceneHierarchy.SceneChildren.Count; i++) {
                SceneHierarchy sceneChild = sceneHierarchy.SceneChildren[i];
                treeNode.Nodes[2].Nodes.Add(sceneChild.Object.Name);
                TreeNode treeChildNode = treeNode.Nodes[2].Nodes[i];
                treeChildNode.Tag = "GameObject";
                BuildSceneHierarchy(ref treeChildNode, sceneChild);
            }
        }

        private void sceneHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e) {
            if (sceneHierarchyTree.SelectedNode != null && sceneHierarchyTree.SelectedNode.Parent != null)
                this.Manager.InjectCommunication.AddCall("CALL37PAR" + sceneHierarchyTree.SelectedNode.Parent.Parent.Text + "|" + sceneHierarchyTree.SelectedNode.Text);
        }
    }
}
