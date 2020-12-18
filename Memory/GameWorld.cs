using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OriWotW.Memory;

namespace OriWotW.GameWorld {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct GameWorldPtr {
        [FieldOffset(0x0)]
        public IntPtr Instance;
        [FieldOffset(0x38)]
        public IntPtr Areas;
        [FieldOffset(0x40)]
        public IntPtr RuntimeAreas;
        [FieldOffset(0x68)]
        public IntPtr PlayerStats;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct PlayerStats {
        [FieldOffset(0x30)]
        public IntPtr m_state;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RuntimeGameWorldAreaPtr {
        [FieldOffset(0x10)]
        public IntPtr Area;
        [FieldOffset(0x18)]
        public IntPtr Icons;
        [FieldOffset(0x20)]
        public IntPtr CollectableIconStates;
        [FieldOffset(0x58)]
        public float m_collectablesCompletionAmount;
        [FieldOffset(0x5C)]
        public float m_completionAmount;
        [FieldOffset(0x60)]
        public bool m_dirtyCompletionAmount;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct m_state {
        [FieldOffset(40)]
        public IntPtr Stats;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct Stats {
        [FieldOffset(16)]
        public int m_health;
        [FieldOffset(20)]
        public int m_maxHealth;
        [FieldOffset(24)]
        public int m_energy;
        [FieldOffset(28)]
        public int m_maxEnergy;
        [FieldOffset(32)]
        public int m_completion;
        [FieldOffset(36)]
        public int m_hours;
        [FieldOffset(40)]
        public int m_minutes;
        [FieldOffset(44)]
        public int m_seconds;
        [FieldOffset(48)]
        public bool m_completed;
        [FieldOffset(49)]
        public bool m_wasKilled;
        [FieldOffset(50)]
        public bool m_completedWithEverything;
        [FieldOffset(52)]
        public int MinRespawnHealth;
    }

    public class RuntimeArea {
        public string Name = "";
        public float m_collectablesCompletionAmount = 0.0f;
        public float m_completionAmount = 0.0f;
        public bool m_dirtyCompletionAmount = false;
        public List<WorldMapIcon> WorldMapIcons = new List<WorldMapIcon>();

        public float GetCollectablesPercentage(float totalPercentage) {
            int collectedIcons = 0;
            float collectedPercentageAdjusted = 0.0f;
            
            foreach(WorldMapIcon icon in this.WorldMapIcons) {
                if (icon.IsCollected == true) {
                    collectedIcons++;
                    float percValue = 0.0f;

                    switch(icon.Icon) {
                        case 0:
                            percValue = GameWorld.PickupAreaValues[this.Name].Keystone;
                            break;

                        case 17:
                        case 35:
                            percValue = GameWorld.PickupAreaValues[this.Name].SpiritLight50;
                            break;

                        case 24:
                            percValue =  GameWorld.PickupAreaValues[this.Name].Shard;
                            break;

                        case 26:
                            percValue = GameWorld.PickupAreaValues[this.Name].QuestItemPickup;
                            break;

                        case 29:
                            percValue =  GameWorld.PickupAreaValues[this.Name].Ore;
                            break;

                        case 33:
                            percValue = GameWorld.PickupAreaValues[this.Name].HealthCell;
                            break;

                        case 34:
                            percValue = GameWorld.PickupAreaValues[this.Name].EnergyCell;
                            break;
                    }

                    if (totalPercentage + collectedPercentageAdjusted >= 1.0f && (this.Name != "Windtorn Ruins" && this.Name != "Howl's Origin" && this.Name != "willow's end")) {
                        percValue *= MathHelpers.Lerp(0.596666666666667f, 0.544666666666667f, this.m_collectablesCompletionAmount);
                    }

                    collectedPercentageAdjusted += percValue;
                }
            }

            return Math.Min(collectedPercentageAdjusted, 7.1f);// this.m_collectablesCompletionAmount * 7.0f;
        }

        public override string ToString() {
            return this.Name + " - Collectables: " + this.m_collectablesCompletionAmount.ToString() + " - " + (this.m_collectablesCompletionAmount * 7.0f).ToString() + " Completion: " + this.m_completionAmount.ToString() + " Dirty: " + this.m_dirtyCompletionAmount.ToString();
        }
    }

    public class PickupAreaValues {
        public float Keystone = 0.33f;
        public float SpiritLight50 = 0.2f;
        public float SpiritLight100 = 0.33f;
        public float SpiritLight200 = 1.0f;
        public float Ore = 0.2f;
        public float Shard = 0.4f;
        public float EnergyCell = 0.2f;
        public float HealthCell = 0.2f;
        public float QuestItemPickup = 0.33f;

        public PickupAreaValues(float keystone = 0.33f, float sp50 = 0.2f, float sp100 = 0.33f, float sp200 = 1.0f, float ore = 0.2f, float shard = 0.4f, float energy = 0.2f, float health = 0.2f, float quest = 0.33f) {
            this.Keystone = keystone;
            this.SpiritLight50 = sp50;
            this.SpiritLight100 = sp100;
            this.SpiritLight200 = sp200;
            this.Ore = ore;
            this.Shard = shard;
            this.EnergyCell = energy;
            this.HealthCell = health;
            this.QuestItemPickup = quest;
        }
    }

    public class GameWorld {
        public Dictionary<string, RuntimeArea> RuntimeAreas = new Dictionary<string, RuntimeArea>();
        static public Dictionary<string, PickupAreaValues> PickupAreaValues = new Dictionary<string, PickupAreaValues>() {
            ["Inkwater Marsh"] = new PickupAreaValues(keystone: 0.33f, sp50: 0.25f, sp100: 0.25f, sp200: 0.25f, health: 0.25f, energy: 0.25f, ore: 0.25f, shard:0.5f, quest:0.4f),
            ["Kwolok's Hollow"] = new PickupAreaValues(energy: 0.43f, health: 0.43f, ore: 0.43f, sp50: 0.44f, sp100: 0.4f, sp200: 0.4f, shard: 0.5f),
            ["Luma Pools"] = new PickupAreaValues(keystone: 0.4f, sp50: 0.4f, sp100: 0.33f, sp200: 0.33f, health: 0.4f, energy: 0.4f, ore: 0.4f),
            ["Mouldwood Depths"] = new PickupAreaValues(keystone: 0.57f, health: 0.56f, energy: 0.56f, ore: 0.56f, sp50: 0.57f, sp100: 0.5f, sp200: 0.5f),
            ["Silent Woodlands"] = new PickupAreaValues(keystone: 0.5f, health: 0.48f, energy: 0.48f, ore: 0.49f, sp50: 0.49f, sp100: 0.5f, sp200: 0.5f),
            ["The Wellspring"] = new PickupAreaValues(shard: 0.45f, sp50: 0.39f, sp100: 0.33f, sp200: 0.33f, health: 0.39f, energy: 0.39f, ore: 0.39f),
            ["Wellspring Glades"] = new PickupAreaValues(sp50: 0.25f, sp100: 0.27f, sp200: 0.27f, health: 0.25f, energy: 0.25f, ore: 0.27f, shard:0.45f),
            ["willow's end"] = new PickupAreaValues(keystone: 1f, health: 1f, energy: 1f, ore: 1f, sp50: 1f, sp100: 1f, sp200: 1f),
            ["Windswept Wastes"] = new PickupAreaValues(keystone: 0.5f, shard:0.5f, health: 0.38f, energy: 0.38f, ore: 0.38f, sp50: 0.38f, sp100: 0.33f, sp200: 0.33f),
            ["Windtorn Ruins"] = new PickupAreaValues(energy: 4.0f),
            ["Winter Forest"] = new PickupAreaValues(keystone: 0.35f, shard:0.3f, health: 0.25f, energy: 0.25f, ore: 0.25f, sp50: 0.32333333f, sp100: 0.30f, sp200: 0.30f),
            ["Howl's Origin"] = new PickupAreaValues(keystone: 1.2f, shard: 1.56f, quest: 1.0f)
        };
        static public List<string> WorldMapIconType = new List<string>() {
        "Keystone",
        "Mapstone",
        "BreakableWall",
        "BreakableWallBroken",
        "StompableFloor",
        "StompableFloorBroken",
        "EnergyGateTwo",
        "EnergyGateOpen",
        "KeystoneDoorFour",
        "KeystoneDoorOpen",
        "AbilityPedestal",
        "HealthUpgrade",
        "EnergyUpgrade",
        "SavePedestal",
        "AbilityPoint",
        "KeystoneDoorTwo",
        "Invisible",
        "Experience",
        "MapstonePickup",
        "EnergyGateTwelve",
        "EnergyGateTen",
        "EnergyGateEight",
        "EnergyGateSix",
        "EnergyGateFour",
        "SpiritShard",
        "NPC",
        "QuestItem",
        "ShardSlotUpgrade",
        "Teleporter",
        "Ore",
        "QuestStart",
        "QuestEnd",
        "RaceStart",
        "HealthFragment",
        "EnergyFragment",
        "Seed",
        "RaceEnd",
        "Eyestone",
        "Undefined",
        "Undefined",
        "WatermillDoor",
        "TempleDoor",
        "SmallDoor",
        "Shrine",
        "Undefined",
        "Undefined",
        "Undefined",
        "Undefined",
        "Undefined",
        "Undefined",
        "Loremaster",
        "Weaponmaster",
        "Gardener",
        "Mapmaker",
        "Shardtrader",
        "Wanderer",
        "Treekeeper",
        "Builder",
        "Kwolok",
        "Statistician",
        "CreepHeart",
        "Miner",
        "Spiderling",
        "Moki",
        "MokiBrave",
        "MokiAdventurer",
        "MokiArtist",
        "MokiDarkness",
        "MokiFashionable",
        "MokiFisherman",
        "MokiFrozen",
        "MokiKwolokAmulet",
        "MokiSpyglass",
        "Ku",
        "IceFisher",
        "Siira",
        };
        public float totalPercentage = 0;
    }
}
