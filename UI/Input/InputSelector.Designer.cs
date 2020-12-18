namespace OriWotW.UI {
    public partial class InputSelector {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.inputList = new System.Windows.Forms.ComboBox();
            this.addInput = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputList
            // 
            this.inputList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inputList.AutoCompleteCustomSource.AddRange(new string[] {
            "Launch",
            "Spirit Edge",
            "Spirit Arc",
            "Spike",
            "Spirit Smash",
            "Spirit Star",
            "Light Burst",
            "Regenerate",
            "Flap",
            "Blaze",
            "Flash",
            "Sentry",
            "Movement Left",
            "Movement Right",
            "Movement Down",
            "Movement Up",
            "Save Copy",
            "Save Delete",
            "Interact",
            "Jump",
            "Ability 1",
            "Ability 2",
            "Ability 3",
            "Glide",
            "Grab",
            "Dash",
            "Burrow",
            "Bash",
            "Grapple",
            "Dialogue Advance",
            "Dialogue Option 1",
            "Dialogue Option 2",
            "Dialogue Option 3",
            "Dialogue Exit",
            "Open Maps Shards Inventory",
            "Open Inventory",
            "Open World Map",
            "Open Area Map",
            "Open Shards Screen",
            "Open Weapon Wheel",
            "Open Pause Screen",
            "Open Live Sign In",
            "Map Zoom In",
            "Map Zoom Out",
            "Menu Select",
            "Menu Back",
            "Menu Close",
            "Menu Down",
            "Menu Up",
            "Menu Left",
            "Menu Right",
            "Menu Page Left",
            "Menu Page Right",
            "Leaderboard Cycle Filter",
            "Map Filter",
            "Map Details",
            "Map Focus Ori",
            "Map Focus Objective"});
            this.inputList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.inputList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.inputList.FormattingEnabled = true;
            this.inputList.Location = new System.Drawing.Point(0, 1);
            this.inputList.Margin = new System.Windows.Forms.Padding(0);
            this.inputList.Name = "inputList";
            this.inputList.Size = new System.Drawing.Size(121, 21);
            this.inputList.TabIndex = 0;
            // 
            // addInput
            // 
            this.addInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addInput.AutoSize = true;
            this.addInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addInput.Location = new System.Drawing.Point(121, 0);
            this.addInput.Margin = new System.Windows.Forms.Padding(0);
            this.addInput.Name = "addInput";
            this.addInput.Size = new System.Drawing.Size(63, 23);
            this.addInput.TabIndex = 1;
            this.addInput.Text = "Add Input";
            this.addInput.UseVisualStyleBackColor = true;
            this.addInput.Click += new System.EventHandler(this.addInput_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.inputList);
            this.flowLayoutPanel1.Controls.Add(this.addInput);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(184, 23);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // InputSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InputSelector";
            this.Size = new System.Drawing.Size(184, 23);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox inputList;
        public System.Windows.Forms.Button addInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
