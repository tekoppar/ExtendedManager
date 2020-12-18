using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinAbilitiesPtr {
        [FieldOffset(16)]
        public IntPtr DoubleJumpWrapper;
        [FieldOffset(24)]
        public IntPtr JumpWrapper;
        [FieldOffset(32)]
        public IntPtr WallJumpWrapper;
        [FieldOffset(40)]
        public IntPtr ChargeJumpChargingWrapper;
        [FieldOffset(112)]
        public IntPtr WallSlideWrapper;
        [FieldOffset(152)]
        public IntPtr DashNewWrapper;
        [FieldOffset(208)]
        public IntPtr BashWrapper;
        [FieldOffset(264)]
        public IntPtr StandingOnEdgeWrapper;
        [FieldOffset(344)]
        public IntPtr GrenadeWrapper;
        [FieldOffset(368)]
        public IntPtr LeashWrapper;
    }

    public class SeinAbilities {
        public SeinDoubleJump DoubleJumpWrapper;
        public SeinJump JumpWrapper;
        public IntPtr WallJumpWrapper;
        public IntPtr ChargeJumpChargingWrapper;
        public SeinWallSlide WallSlideWrapper;
        public SeinDashNew DashNewWrapper;
        public SeinBash BashWrapper;
        public SeinStandingOnEdgePtr StandingOnEdgeWrapper;
        public SeinGrenadePtr GrenadeWrapper;
        public SeinSpiritLeashAbilityPtr LeashWrapper;
    }
}
