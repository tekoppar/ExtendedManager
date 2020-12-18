using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace OriWotW {
    public enum ShardType : byte {
        Overcharge = 1,
        TripleJump,
        Wingclip,
        Bounty,
        Swap,
        Magnet = 8,
        Splinter,
        Reckless = 13,
        Quickshot,
        Resilience = 18,
        LightHarvest,
        Vitality = 22,
        LifeHarvest,
        EnergyHarvest = 25,
        Energy,
        LifePact,
        LastStand,
        Secret = 30,
        UltraBash = 32,
        UltraGrapple,
        Overflow,
        Thorn,
        Catalyst,
        Turmoil = 38,
        Sticky,
        Finesse,
        SpiritSurge,
        Lifeforce = 43,
        Deflector,
        Fracture = 46,
        Arcing
    }
    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
    public struct Shard {
        [FieldOffset(0x10)]
        public ShardType Type;
        [FieldOffset(0x14)]
        public int Level;
        [FieldOffset(0x18)]
        public byte IsNew;
        [FieldOffset(0x19)]
        public byte Gained;
        [FieldOffset(0x1A)]
        public byte EquipOnStart;
        [FieldOffset(0x1C)]
        public int Index;

        public override string ToString() {
            return $"{Type} = {Gained != 0}+{Level}";
        }
    }
}