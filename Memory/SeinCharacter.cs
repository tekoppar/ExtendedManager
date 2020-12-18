using System;
using System.Runtime.InteropServices;

namespace OriWotW.Memory {
    public struct SeinCharacterPtr {
        public IntPtr m_CachedPtr;
        public IntPtr LogicCycle;
        public IntPtr Abilities;
        public IntPtr ComboMoves;
        public IntPtr Spells;
        public IntPtr Controller;
        public IntPtr CutsceneBlocked;
        public IntPtr CutsceneMovement;
        public IntPtr DoorHandler;
        public IntPtr SoulFlame;
        public IntPtr Inventory;
        public IntPtr ForceController;
        public IntPtr Input;
        public IntPtr Level;
        public IntPtr Energy;
        public IntPtr Mortality;
        public IntPtr PickupHandler;
        public IntPtr PlatformBehaviour;
        public IntPtr PlayerAbilities;

        public SeinCharacterPtr(SeinCharacterPtrV1V2 val) {
            this.m_CachedPtr = val.m_CachedPtr;
            this.Abilities = val.Abilities;
            this.ComboMoves = val.ComboMoves;
            this.Controller = val.Controller;
            this.CutsceneBlocked = val.CutsceneBlocked;
            this.CutsceneMovement = val.CutsceneMovement;
            this.DoorHandler = val.DoorHandler;
            this.Energy = val.Energy;
            this.ForceController = val.ForceController;
            this.Input = val.Input;
            this.Inventory = val.Inventory;
            this.Level = val.Level;
            this.LogicCycle = val.LogicCycle;
            this.Mortality = val.Mortality;
            this.PickupHandler = val.PickupHandler;
            this.PlatformBehaviour = val.PlatformBehaviour;
            this.PlayerAbilities = val.PlayerAbilities;
            this.SoulFlame = val.SoulFlame;
            this.Spells = val.Spells;
        }
        public SeinCharacterPtr(SeinCharacterPtrV3V4 val) {
            this.m_CachedPtr = val.m_CachedPtr;
            this.Abilities = val.Abilities;
            this.ComboMoves = val.ComboMoves;
            this.Controller = val.Controller;
            this.CutsceneBlocked = val.CutsceneBlocked;
            this.CutsceneMovement = val.CutsceneMovement;
            this.DoorHandler = val.DoorHandler;
            this.Energy = val.Energy;
            this.ForceController = val.ForceController;
            this.Input = val.Input;
            this.Inventory = val.Inventory;
            this.Level = val.Level;
            this.LogicCycle = val.LogicCycle;
            this.Mortality = val.Mortality;
            this.PickupHandler = val.PickupHandler;
            this.PlatformBehaviour = val.PlatformBehaviour;
            this.PlayerAbilities = val.PlayerAbilities;
            this.SoulFlame = val.SoulFlame;
            this.Spells = val.Spells;
        }
    }
    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinCharacterPtrV1V2 {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(0x18)]
        public IntPtr LogicCycle;
        [FieldOffset(0x20)]
        public IntPtr Abilities;
        [FieldOffset(0x28)]
        public IntPtr ComboMoves;
        [FieldOffset(0x30)]
        public IntPtr Spells;
        [FieldOffset(0x38)]
        public IntPtr Controller;
        [FieldOffset(0x40)]
        public IntPtr CutsceneBlocked;
        [FieldOffset(0x48)]
        public IntPtr CutsceneMovement;
        [FieldOffset(0x50)]
        public IntPtr DoorHandler;
        [FieldOffset(0x58)]
        public IntPtr SoulFlame;
        [FieldOffset(0x60)]
        public IntPtr Inventory;
        [FieldOffset(0x68)]
        public IntPtr ForceController;
        [FieldOffset(0x70)]
        public IntPtr Input;
        [FieldOffset(0x78)]
        public IntPtr Level;
        [FieldOffset(0x80)]
        public IntPtr Energy;
        [FieldOffset(0x88)]
        public IntPtr Mortality;
        [FieldOffset(0x90)]
        public IntPtr PickupHandler;
        [FieldOffset(0x98)]
        public IntPtr PlatformBehaviour;
        [FieldOffset(0xA0)]
        public IntPtr PlayerAbilities;
    }
    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinCharacterPtrV3V4 {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(0x30)]
        public IntPtr LogicCycle;
        [FieldOffset(0x38)]
        public IntPtr Abilities;
        [FieldOffset(0x40)]
        public IntPtr ComboMoves;
        [FieldOffset(0x48)]
        public IntPtr Spells;
        [FieldOffset(0x50)]
        public IntPtr Controller;
        [FieldOffset(0x58)]
        public IntPtr CutsceneBlocked;
        [FieldOffset(0x60)]
        public IntPtr CutsceneMovement;
        [FieldOffset(0x68)]
        public IntPtr DoorHandler;
        [FieldOffset(0x70)]
        public IntPtr SoulFlame;
        [FieldOffset(0x78)]
        public IntPtr Inventory;
        [FieldOffset(0x80)]
        public IntPtr ForceController;
        [FieldOffset(0x88)]
        public IntPtr Input;
        [FieldOffset(0x90)]
        public IntPtr Level;
        [FieldOffset(0x98)]
        public IntPtr Energy;
        [FieldOffset(0xA0)]
        public IntPtr Mortality;
        [FieldOffset(0xA8)]
        public IntPtr PickupHandler;
        [FieldOffset(0xB0)]
        public IntPtr PlatformBehaviour;
        [FieldOffset(0xB8)]
        public IntPtr PlayerAbilities;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinInputPtr {
        [FieldOffset(0x10)]
        public IntPtr Down;
        [FieldOffset(0x18)]
        public IntPtr Left;
        [FieldOffset(0x20)]
        public IntPtr Right;
        [FieldOffset(0x28)]
        public IntPtr Up;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinMortalityPtr {
        [FieldOffset(0x10)]
        public IntPtr DamageReciever;
        [FieldOffset(0x18)]
        public IntPtr Health;
        [FieldOffset(0x20)]
        public IntPtr CrushDetector;
        [FieldOffset(0x28)]
        public IntPtr ZonesProperties;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinHealthControllerPtr {
        [FieldOffset(0x44)]
        public float m_amountCached;
        [FieldOffset(0x4C)]
        public float m_maxHealthCached;
        [FieldOffset(0x54)]
        public float m_actualMaxHealthCached;
        [FieldOffset(0x58)]
        public float m_overMaxHealthBoost;
        [FieldOffset(0x60)]
        public float m_baseMaxHealthCached;
        [FieldOffset(0x68)]
        public float VisualMinAmount;
        [FieldOffset(0x6C)]
        public float VisualMaxAmount;
    }

    public class SeinInput {
        public InputButtonProcessor Down;
        public InputButtonProcessor Left;
        public InputButtonProcessor Right;
        public InputButtonProcessor Up;
    }

    public class SeinCharacter {
        public IntPtr m_CachedPtr;
        public IntPtr LogicCycle;
        public SeinAbilities Abilities;
        public SeinPlatformBehaviour SeinPlatformBehaviour;
        public SeinPlatformMovement PlatformMovement;
        public SeinInput Input;
        public PlayerAbilities PlayerAbilities = new PlayerAbilities();
        public SeinControllerPtr SeinController;
        public GameWorld.Stats Stats;
        public SeinInventory SeinInventory = new SeinInventory();
    }
}
