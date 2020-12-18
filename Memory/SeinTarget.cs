using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinTarget {
        [FieldOffset(0x5A)]
        public bool CanBash;
        [FieldOffset(0x62)]
        public byte CanBeLeashed;
    }
}
