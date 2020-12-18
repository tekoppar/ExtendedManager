using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct PlayerAbilitiesPtr {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(0x30)]
        public IntPtr StateDescriptor;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct StateDescriptorPtr {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(24)]
        public IntPtr m_id;
        [FieldOffset(32)]
        public IntPtr m_awakeName;
        [FieldOffset(40)]
        public IntPtr m_EditorValue;
        [FieldOffset(0x30)]
        public IntPtr m_state;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct m_statePtr {
        [FieldOffset(0x10)]
        public IntPtr Abilities;
        [FieldOffset(0x18)]
        public IntPtr Inventory;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct Inventory {
        [FieldOffset(0x10)]
        public IntPtr m_inventory;
        [FieldOffset(0x18)]
        public IntPtr m_bindings;
        [FieldOffset(0x28)]
        public int m_keystones;
        [FieldOffset(0x2C)]
        public int m_mapStones;
        [FieldOffset(0x30)]
        public int m_experience;
        [FieldOffset(0x34)]
        public int m_ore;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct InventoryItemPtr {
        [FieldOffset(0x10)]
        public int m_type;
        [FieldOffset(0x14)]
        public bool m_isNew;
        [FieldOffset(0x15)]
        public bool m_gained;
    }

    public class SeinInventory {
        public int Keystones = 0;
        public int Mapstones = 0;
        public int SpiritLight = 0;
        public int Ore = 0;
    }

    public class InventoryItem {
        public InventoryItemPtr Inventory;
        public string Name;

        public override string ToString() {
            return this.Name + " - " + this.Inventory.m_type.ToString() + " - " + this.Inventory.m_gained.ToString();
        }
    }

    public class PlayerAbilities {
        public Dictionary<string, InventoryItem> AbilityBindings = new Dictionary<string, InventoryItem>();
        public List<InventoryItem> AbilityList = new List<InventoryItem>();
        public Dictionary<int, InventoryItem> Inventory = new Dictionary<int, InventoryItem>();
        public Dictionary<int, string> TypeToAbilityName = new Dictionary<int, string>() {
            [2019] = "Launch",
            [1002] = "Spirit Edge",
            [1001] = "Spirit Arc",
            [2012] = "Spike",
            [1000] = "Spirit Smash",
            [2015] = "Spirit Star",
            [2010] = "Light Burst",
            [2013] = "Regenerate",
            [3005] = "Flap",
            [2016] = "Blaze",
            [2004] = "Flash",
            [2017] = "Sentry",
            [3004] = "Double Jump",
            [4000] = "Dash",
            [3000] = "Bash",
            [3001] = "Leash",
            [4002] = "Glide",
            [3002] = "Burrow",
            [4004] = "Water Dash",
            [4007] = "Damage Upgrade A",
            [4008] = "Damage Upgrade B",
            [2018] = "Golden Sein"
        };

        public Tuple<float, int> GetTreeProgress() {
            float progress = 0.0f;
            List<int> trees = new List<int>() { 4007, 4008, 4004, 3004, 4000, 3002, 3001, 3000, 2019, 2013, 2010, 1002, 1001, 2004 };

            foreach (int tree in trees) {
                if (this.Inventory.ContainsKey(tree) == true) {
                    InventoryItem item = this.Inventory[tree];

                    if (item.Inventory.m_gained == true) {
                        if (item.Name == "Damage Upgrade A" || item.Name == "Damage Upgrade B") {
                            progress += 0.5f;
                        } else {
                            progress += 1.0f;
                        }
                    }
                } 
            }

            return new Tuple<float, int>(progress, trees.Count - 1);
        }

        public string GetInventoryItems() {
            string items = "";

            foreach (var item in this.Inventory) {
                items += item.Value.ToString() + Environment.NewLine;
            }

            return items;
        }
    }
}
