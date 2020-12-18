using System.Runtime.InteropServices;
namespace OriWotW {
    public enum AbilityType : byte {
        Bash = 0,
        WallJump = 3,
        DoubleJump = 5,
        Launch = 8,
        Feather = 14,
        WaterBreath = 23,
        LightBurst = 51,
        Grapple = 57,
        Flash = 62,
        Spike = 74,
        Regenerate = 77,
        SpiritArc = 97,
        SpiritSmash,
        Torch,
        SpiritEdge,
        Burrow,
        Dash,
        WaterDash = 104,
        SpiritStar = 106,
        Seir = 108,
        Blaze = 115,
        Sentry,
        Flap = 118,
        DamageUpgrade1 = 120,
        DamageUpgrade2
    }
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public struct Ability {
        [FieldOffset(0x10)]
        public AbilityType Type;
        [FieldOffset(0x11)]
        public byte HasAbility;
        [FieldOffset(0x14)]
        public int AbilityLevel;
        [FieldOffset(0x18)]
        public byte UnlockOrder;

        public override string ToString() {
            return $"{Type} = {HasAbility != 0}+{AbilityLevel}";
        }
    }
}