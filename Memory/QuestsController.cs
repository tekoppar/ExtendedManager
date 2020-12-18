using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct QuestsControllerPtr {
        [FieldOffset(32)]
        public IntPtr Quests;
        [FieldOffset(96)]
        public IntPtr m_quests;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct QuestPtr {
        [FieldOffset(24)]
        public IntPtr MoonGuid;
        [FieldOffset(32)]
        public IntPtr NameMessageProvider;
        [FieldOffset(48)]
        public IntPtr DescriptionMessageProvider;
        [FieldOffset(72)]
        public Vector2 Position;
        [FieldOffset(120)]
        public int StateOffset;
        [FieldOffset(128)]
        public IntPtr m_resolvedUberState;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct m_resolvedUberState {
        [FieldOffset(24)]
        public IntPtr m_id;
        [FieldOffset(48)]
        public IntPtr Group;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct QuestUberGroup {
        [FieldOffset(24)]
        public IntPtr m_id;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RunetimeQuestPtr {
        [FieldOffset(16)]
        public IntPtr MoonGuid;
        [FieldOffset(24)]
        public int Type;
        [FieldOffset(28)]
        public int m_stateOffset;
        [FieldOffset(32)]
        public int m_state;
        [FieldOffset(40)]
        public IntPtr m_uberState;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct m_UberState {
        [FieldOffset(28)]
        public int DefaultValue;
        [FieldOffset(56)]
        public int m_value;
    }

    public class MoonGuid {
        public uint A;
        public uint B;
        public uint C;
        public uint D;

        public override string ToString() {
            return this.A.ToString() + this.B.ToString() + this.C.ToString() + this.D.ToString();
        }
    }

    public class RunetimeQuest {
        public MoonGuid MoonGuid;
        public int Type;
        public int m_stateOffset;
        public int m_state;
        public int StateOffset;
        public m_UberState uberState;
    }

    public class Quest {
        public MoonGuid MoonGuid;
        public string Name;
        public string Description;
        public Vector2 Position;
        public int StateOffset;
        public uint UberID = 0;
        public uint UberGroupID = 0;
    }

    public class MasterQuest {
        public Dictionary<string, Quest> SubQuests = new Dictionary<string, Quest>();
        public Dictionary<string, RunetimeQuest> SubRunetimeQuests = new Dictionary<string, RunetimeQuest>();
        public List<string> MoonGuids = new List<string>();
        public int QuestState = 0;
        public int TotalQuestState = 0;
        public string QuestName = "";
        public uint UberID = 0;
        public uint UberGroupID = 0;

        public void UpdateQuestState() {
            this.QuestState = this.SubRunetimeQuests[this.MoonGuids[0]].m_state;
            this.QuestName = this.SubQuests[this.MoonGuids[0]].Name;
            this.UberID = this.SubQuests[this.MoonGuids[0]].UberID;
            this.UberGroupID = this.SubQuests[this.MoonGuids[0]].UberGroupID;
        }

        public bool GetQuestProgression() {
            return this.QuestState > this.TotalQuestState;
        }

        public bool ProgressQuest() {
            return this.QuestState < this.TotalQuestState + 1;
        }
    }

    public class QuestsController {
        public Dictionary<string, Quest> Quests = new Dictionary<string, Quest>();
        public Dictionary<string, RunetimeQuest> RunetimeQuests = new Dictionary<string, RunetimeQuest>();
        public Dictionary<string, MasterQuest> MasterQuests = new Dictionary<string, MasterQuest>();
        public List<string> MasterQuestsGuid = new List<string>();
        public static Dictionary<string, float> QuestProgressValues = new Dictionary<string, float>() {
            ["Guardian of the Marsh"] = 0.0f,
            ["The Silent Teeth"] = 0.0f,
            ["Fallen Friend"] = 0.0f,
            ["Beneath Shifting Sands"] = 0.0f,
            ["Breaking the Mould"] = 3.86f,
            ["Lost in Paradise"] = 0.25f,
            ["The Highest Reach"] = 0.25f,
            ["The Missing Key"] = 0.0f,
            ["Into the Burrows"] = 0.86f,
            ["The Lost Compass"] = 0.5f,
            ["A Little Braver"] = 0.5f,
            ["Family Reunion"] = 0.86f,
            ["The Tree Keeper"] = 0.5f,
            ["A Diamond in the Rough"] = 1.16f,
            ["Hand to Hand"] = 2.86f,
            ["Into the Darkness"] = 0.5f,
            ["Kwolok's Wisdom"] = 0.86f,
            ["The Silent Map"] = 1.16f,
            ["Rumor"] = 0.0f,
            ["Rebuilding the Glades"] = 0.5f,
            ["Regrowing the Glades"] = 0.5f
        };

        public void FillMasterQuests() {
            foreach (var quest in this.Quests) {
                if (this.MasterQuests.ContainsKey(quest.Value.Name) == true) {
                    this.MasterQuests[quest.Value.Name].SubQuests.Add(quest.Key, quest.Value);
                    this.MasterQuests[quest.Value.Name].SubRunetimeQuests.Add(quest.Key, this.RunetimeQuests[quest.Key]);
                    this.MasterQuests[quest.Value.Name].MoonGuids.Add(quest.Key);
                    this.MasterQuests[quest.Value.Name].TotalQuestState++;
                    this.MasterQuests[quest.Value.Name].UpdateQuestState();
                } else {
                    MasterQuest masterQuest = new MasterQuest();
                    masterQuest.SubQuests.Add(quest.Key, quest.Value);
                    if (this.RunetimeQuests.ContainsKey(quest.Key) == true) {
                        masterQuest.SubRunetimeQuests.Add(quest.Key, this.RunetimeQuests[quest.Key]);
                    }
                    masterQuest.MoonGuids.Add(quest.Key);
                    masterQuest.TotalQuestState++;
                    masterQuest.UpdateQuestState();
                    this.MasterQuestsGuid.Add(quest.Value.Name);
                    this.MasterQuests.Add(quest.Value.Name, masterQuest);
                }
            }
        }

        public float GetAllQuestProgress() {
            float progress = 0.0f;

            foreach (string s in this.MasterQuestsGuid) {
                if (this.MasterQuests[s].GetQuestProgression()) {
                    progress += QuestsController.QuestProgressValues[this.MasterQuests[s].QuestName];
                }
            }

            return progress;
        }
        
        public string ProgressQuestLinear() {
            foreach (string s in this.MasterQuestsGuid) {
                if (this.MasterQuests[s].ProgressQuest() == true) {
                    return s;
                }
            }
            return null;
        }

        public string GetQuestByName(string name) {
            foreach (string s in this.MasterQuestsGuid) {
                if (this.MasterQuests[s].QuestName == name) {
                    return s;
                }
            }
            return null;
        }

        public string GetAllQuestStates() {
            string states = "";
            foreach (string s in this.MasterQuestsGuid) {
                this.MasterQuests[s].UpdateQuestState();
                states += this.MasterQuests[s].QuestName + ": " + this.MasterQuests[s].QuestState + "/" + this.MasterQuests[s].TotalQuestState + " - " + this.MasterQuests[s].UberGroupID.ToString() + " - " + this.MasterQuests[s].UberID.ToString() + Environment.NewLine;
            }
            return states;
        }
    }
}
