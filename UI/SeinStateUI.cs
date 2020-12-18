using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.Memory;

namespace OriWotW.UI {
    public class SeinStateUI {
        private FlowLayoutPanel FlowStateList;
        public Dictionary<string, FlowLayoutPanel> FlowLabels = new Dictionary<string, FlowLayoutPanel>();
        public Dictionary<string, Label> StateLabels = new Dictionary<string, Label>();
        public Dictionary<string, ToolStripMenuItem> MenuItems = new Dictionary<string, ToolStripMenuItem>();
        public Dictionary<string, string> StateNames = new Dictionary<string, string>();
        public ManagerSettings Settings;

        public SeinStateUI(FlowLayoutPanel stateList, List<Tuple<string, string>> flowLabels, Dictionary<string, Label> stateLabels, EventHandler eventHandler, ref ManagerSettings settings) {
            this.FlowStateList = stateList;
            this.GenerateFlowLabels(flowLabels, eventHandler);
            this.StateLabels = stateLabels;
            this.Settings = settings;
        }

        private void GenerateFlowLabels(List<Tuple<string, string>> flowLabels, EventHandler eventHandler) {
            foreach (Tuple<string, string> s in flowLabels) {
                FlowLayoutPanel container = new FlowLayoutPanel();
                Label label = new Label();
                Label labelState = new Label();

                label.Name = "lbl" + s.Item1;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                label.Text = s.Item2 + ":";
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                label.Size = new System.Drawing.Size(115, 16);
                label.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                labelState.Name = "lbl" + s.Item1 + "State";
                labelState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelState.Size = new System.Drawing.Size(100, 16);
                labelState.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                container.WrapContents = false;
                container.Name = "flow" + s.Item1;
                container.Size = new System.Drawing.Size(195, 16);
                container.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);

                container.Controls.Add(label);
                container.Controls.Add(labelState);
                this.FlowStateList.Controls.Add(container);
                this.FlowLabels.Add(s.Item1, container);
                this.StateNames.Add(s.Item1, s.Item2);

                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Name = "Visibility " + s.Item2;
                menuItem.Text = "Visibility " + s.Item2;
                menuItem.CheckOnClick = true;
                menuItem.Checked = true;
                menuItem.Click += eventHandler;

                this.MenuItems.Add(s.Item1, menuItem);
            }
        }

        public void SetVisibility(string label, bool vis) {
            if (this.FlowLabels.ContainsKey(label) == true) {
                this.FlowLabels[label].Visible = vis;
                this.MenuItems[label].Checked = vis;
                this.Settings.SetSetting("Visibility" + this.StateNames[label].Replace(" ", ""), vis);
            }
        }

        public List<ToolStripMenuItem> GetMenuItems() {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            foreach (var item in this.MenuItems) {
                items.Add(item.Value);
            }
            return items;
        }

        public void UpdateStates(SeinCharacter seinCharacter) {
            if (Convert.ToInt32(seinCharacter.Abilities.DoubleJumpWrapper.m_numberOfJumpsAvailable) == 1) {
                FlowLabels["Djump"].Controls["lblDjumpState"].Text = "Can Djump";
            } else if (Convert.ToInt32(seinCharacter.Abilities.DoubleJumpWrapper.m_numberOfJumpsAvailable) >= 2) {
                FlowLabels["Djump"].Controls["lblDjumpState"].Text = "Can Tjump";
            } else {
                FlowLabels["Djump"].Controls["lblDjumpState"].Text = "Can't Djump";
            }

            if (Convert.ToInt32(seinCharacter.Abilities.DashNewWrapper.m_allowDash) == 1) {
                FlowLabels["Dash"].Controls["lblDashState"].Text = "Can Dash";
            } else {
                FlowLabels["Dash"].Controls["lblDashState"].Text = "Can't Dash";
            }

            if (seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.m_climblableWallTimer > 0) {
                FlowLabels["Walljump"].Controls["lblWalljumpState"].Text = "Can Walljump";
            } else {
                FlowLabels["Walljump"].Controls["lblWalljumpState"].Text = "Can't Walljump";
            }

            if (Convert.ToInt32(seinCharacter.Abilities.WallSlideWrapper.CurrentState) == 1) {
                FlowLabels["IsOnWall"].Controls["lblIsOnWallState"].Text = "Wall Left";
            } else if (Convert.ToInt32(seinCharacter.Abilities.WallSlideWrapper.CurrentState) == 2) {
                FlowLabels["IsOnWall"].Controls["lblIsOnWallState"].Text = "Wall Right";
            } else {
                FlowLabels["IsOnWall"].Controls["lblIsOnWallState"].Text = "No Wall";
            }

            if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ceiling.IsOn) == 1) {
                FlowLabels["OnCeiling"].Controls["lblOnCeilingState"].Text = "Is On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ceiling.WasOn) == 1) {
                FlowLabels["OnCeiling"].Controls["lblOnCeilingState"].Text = "Was On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ceiling.FutureOn) == 1) {
                FlowLabels["OnCeiling"].Controls["lblOnCeilingState"].Text = "Future On";
            }

            if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ground.IsOn) == 1) {
                FlowLabels["OnGround"].Controls["lblOnGroundState"].Text = "Is On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ground.WasOn) == 1) {
                FlowLabels["OnGround"].Controls["lblOnGroundState"].Text = "Was On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.Ground.FutureOn) == 1) {
                FlowLabels["OnGround"].Controls["lblOnGroundState"].Text = "Future On";
            }

            if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallLeft.IsOn) == 1) {
                FlowLabels["OnWallLeft"].Controls["lblOnWallLeftState"].Text = "Is On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallLeft.WasOn) == 1) {
                FlowLabels["OnWallLeft"].Controls["lblOnWallLeftState"].Text = "Was On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallLeft.FutureOn) == 1) {
                FlowLabels["OnWallLeft"].Controls["lblOnWallLeftState"].Text = "Future On";
            }

            if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallRight.IsOn) == 1) {
                FlowLabels["OnWallRight"].Controls["lblOnWallRightState"].Text = "Is On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallRight.WasOn) == 1) {
                FlowLabels["OnWallRight"].Controls["lblOnWallRightState"].Text = "Was On";
            } else if (Convert.ToInt32(seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.WallRight.FutureOn) == 1) {
                FlowLabels["OnWallRight"].Controls["lblOnWallRightState"].Text = "Future On";
            }

            if (seinCharacter.Abilities.BashWrapper.TargetFound == true) {
                if (seinCharacter.Abilities.BashWrapper.Target.CanBash == true) {
                    FlowLabels["Bash"].Controls["lblBashState"].Text = "Can Bash";
                } else {
                    FlowLabels["Bash"].Controls["lblBashState"].Text = "Can't Bash";
                }
            } else {
                FlowLabels["Bash"].Controls["lblBashState"].Text = "No Target";
            }

            if (seinCharacter.Abilities.LeashWrapper.m_lastTargetTime > 0) {
                FlowLabels["Leash"].Controls["lblLeashState"].Text = "Can Leash";
                if (seinCharacter.Abilities.LeashWrapper.isGrabbing == true) {
                    FlowLabels["Leash"].Controls["lblLeashState"].Text += ", Is Grabbing";
                }
            } else {
                FlowLabels["Leash"].Controls["lblLeashState"].Text = "No Target";
                if (seinCharacter.Abilities.LeashWrapper.isGrabbing == true) {
                    FlowLabels["Leash"].Controls["lblLeashState"].Text += ", Is Grabbing";
                }
            }

            if (seinCharacter.Abilities.GrenadeWrapper.m_wasGroundedAfterAirAiming == false) {
                FlowLabels["VGrenadeBash"].Controls["lblVGrenadeBashState"].Text = "Is Primed";
            } else {
                FlowLabels["VGrenadeBash"].Controls["lblVGrenadeBashState"].Text = "Not Primed";
            }

            string edgeString = "";
            if (seinCharacter.Abilities.StandingOnEdgeWrapper.StandingOnEdgeBackwards == true) {
                edgeString  += "Backwards";
            }
            if (seinCharacter.Abilities.StandingOnEdgeWrapper.StandingOnEdgeForwards == true) {
                edgeString += "Forward";
            }
            if (seinCharacter.Abilities.StandingOnEdgeWrapper.StandingOnEdgeForwards == false && seinCharacter.Abilities.StandingOnEdgeWrapper.StandingOnEdgeBackwards == false) {
                edgeString += "No Edge";
            }
            FlowLabels["StandingOnEdge"].Controls["lblStandingOnEdgeState"].Text = edgeString;
            FlowLabels["WallLeftAngle"].Controls["lblWallLeftAngleState"].Text = (seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.m_wallLeftAngle * -1).ToString();
            FlowLabels["WallRightAngle"].Controls["lblWallRightAngleState"].Text = seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement.m_wallRightAngle.ToString();

            StateLabels["AirNoDeceleration"].Text = "AirNoDeceleration: " + seinCharacter.SeinPlatformBehaviour.AirNoDeceleration.m_noDeceleration.ToString();
            StateLabels["SpeedFactor"].Text = "SpeedFactor: " + seinCharacter.SeinPlatformBehaviour.ApplyFrictionToSpeed.SpeedFactor.ToString();
        }
    }
}
