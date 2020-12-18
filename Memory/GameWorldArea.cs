using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct GameWorldAreaPtr {
        [FieldOffset(24)]
        public IntPtr Icons;
        [FieldOffset(56)]
        public IntPtr AreaNameString;
        [FieldOffset(264)]
        public IntPtr ZoneScalingData;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct ZoneScalingDataPtr {
        [FieldOffset(48)]
        public int WaterDamage;
        [FieldOffset(52)]
        public int DamageColliderDamage;
        [FieldOffset(56)]
        public int CreepWallHealth;
        [FieldOffset(60)]
        public int DestructableWallHealth;
        [FieldOffset(64)]
        public int RedirectWallHealth;
        [FieldOffset(68)]
        public int DefaultZoneDifficulty;
        [FieldOffset(80)]
        public IntPtr Enemies;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct EntityScalingDataPtr {
        [FieldOffset(32)]
        public IntPtr Name;
        [FieldOffset(52)]
        public float BaseHealth;
        [FieldOffset(56)]
        public int NumberOfExperienceOrbs;
        [FieldOffset(60)]
        public float HeartLootChance;
        [FieldOffset(64)]
        public float EnergyLootChance;
        [FieldOffset(68)]
        public int Category;
        [FieldOffset(72)]
        public IntPtr Scaling;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct Scaling {
        [FieldOffset(16)]
        public IntPtr Difficulty;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct EntityDifficultyScalingData {
        [FieldOffset(16)]
        public float HealthMultiplier;
        [FieldOffset(20)]
        public float DamageMultiplier;
        [FieldOffset(24)]
        public float ExperienceMultiplier;
        [FieldOffset(28)]
        public int HeartLootCount;
        [FieldOffset(32)]
        public int EnergyLootCount;
    }

    public class EntityScalingData {
        public string Name = "";
        public float BaseHealth = 0;
        public int NumberOfExperienceOrbs = 0;
        public float HeartLootChance = 0.0f;
        public float EnergyLootChance = 0.0f;
        public int Category = 0;
        public List<EntityDifficultyScalingData> Scaling = new List<EntityDifficultyScalingData>();
    }

    public class ZoneScalingData {
        public int WaterDamage = 0;
        public int DamageColliderDamage = 0;
        public int CreepWallHealth = 0;
        public int DestructableWallHealth = 0;
        public int RedirectWallHealth = 0;
        public int DefaultZoneDifficulty = 0;
        public List<EntityScalingData> Enemies = new List<EntityScalingData>();
    }

    public class GameWorldArea {
        public string AreaNameString;
        public ZoneScalingData ZoneScalingData = new ZoneScalingData();

        public string LogAreaData() {
            string logData = "";
            logData += this.AreaNameString + Environment.NewLine +
                "\tCreepWallHealth: " + this.ZoneScalingData.CreepWallHealth.ToString() + Environment.NewLine +
                "\tWaterDamage: " + this.ZoneScalingData.WaterDamage.ToString() + Environment.NewLine +
                "\tRedirectWallHealth: " + this.ZoneScalingData.RedirectWallHealth.ToString() + Environment.NewLine +
                "\tDestructableWallHealth: " + this.ZoneScalingData.DestructableWallHealth.ToString() + Environment.NewLine +
                "\tDefaultZoneDifficulty: " + this.ZoneScalingData.DefaultZoneDifficulty.ToString() + Environment.NewLine +
                "\tDamageColliderDamage: " + this.ZoneScalingData.DamageColliderDamage.ToString() + Environment.NewLine;

            logData += Environment.NewLine + "\tEnemies" + Environment.NewLine;

            foreach (EntityScalingData data in this.ZoneScalingData.Enemies) {
                logData += "\t\tName: " + data.Name + Environment.NewLine +
                    "\t\tBaseHealth: " + data.BaseHealth.ToString() + Environment.NewLine +
                    "\t\tNumberOfExperienceOrbs: " + data.NumberOfExperienceOrbs.ToString() + Environment.NewLine +
                    "\t\tHeartLootChance: " + data.HeartLootChance.ToString() + Environment.NewLine +
                    "\t\tEnergyLootChance: " + data.EnergyLootChance.ToString() + Environment.NewLine +
                    "\t\tCategory: " + data.Category.ToString() + Environment.NewLine;

                logData += Environment.NewLine + "\t\tDifficulty Scaling" + Environment.NewLine;

                foreach (EntityDifficultyScalingData scaleData in data.Scaling) {
                    logData += "\t\t\tDamageMultiplier: " + scaleData.DamageMultiplier.ToString() + Environment.NewLine +
                        "\t\t\tEnergyLootCount: " + scaleData.EnergyLootCount.ToString() + Environment.NewLine +
                        "\t\t\tExperienceMultiplier: " + scaleData.ExperienceMultiplier.ToString() + Environment.NewLine +
                        "\t\t\tHealthMultiplier: " + scaleData.HealthMultiplier.ToString() + Environment.NewLine +
                        "\t\t\tHeartLootCount: " + scaleData.HeartLootCount.ToString() + Environment.NewLine + Environment.NewLine;
                }
                logData += Environment.NewLine;
            }

            return logData;
        }
    }
}
