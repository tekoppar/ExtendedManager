using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinSpiritLeashAbilityPtr {
        [FieldOffset(0x370)]
        public bool isGrabbing;
        [FieldOffset(0x3CC)]
        public int m_lastTargetTime;
    }
}
