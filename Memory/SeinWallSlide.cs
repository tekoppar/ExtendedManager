using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinWallSlide {
        [FieldOffset(0x98)]
        public byte CurrentState;
    }
}
