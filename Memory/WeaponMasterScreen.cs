using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct WeaponMasterScreenPtr {
        [FieldOffset(0xE8)]
        public IntPtr Upgrades;
        [FieldOffset(0xF0)]
        public IntPtr WeaponMasterItems;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct UpgradeAbilityItemPtr {
        [FieldOffset(0x18)]
        public IntPtr Name;
        [FieldOffset(0x28)]
        public IntPtr UpgradeLevel;
        [FieldOffset(0x39)]
        public int AcquiredAbilityType;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct UpgradeLevel {
        [FieldOffset(0x41)]
        public bool HasUpgrade;
    }

    public class UpgradeAbilityItem {
        public string Name = "";
        public bool HasUpgrade = false;
        public int AcquiredAbilityType = 0;

        public override string ToString() {
            return this.Name + " - Upgraded: " + this.HasUpgrade.ToString() + " Type: " + this.AcquiredAbilityType.ToString();
        }
    }

    public class WeaponMasterScreen {
        public List<UpgradeAbilityItem> Upgrades = new List<UpgradeAbilityItem>();

        public Tuple<int, int> GetUpgradeProgression() {
            int progress = 0;
            int totalUpgradeable = 0;

            foreach(UpgradeAbilityItem item in this.Upgrades) {
                if (item.AcquiredAbilityType == 255 && item.Name != "Fast Travel") {
                    totalUpgradeable++;
                    if (item.HasUpgrade == true) {
                        progress++;
                    }
                }
            }

            return new Tuple<int, int>(progress, totalUpgradeable);
        }

        public override string ToString() {
            string upgrades = "";
            foreach (UpgradeAbilityItem item in this.Upgrades) {
                upgrades += item.ToString() + Environment.NewLine;
            }
            return upgrades;
        }
    }
}
