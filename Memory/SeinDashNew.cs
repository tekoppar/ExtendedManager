using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinDashNew {
        [FieldOffset(0x120)]
        public byte m_isDashing;
        [FieldOffset(0x121)]
        public byte m_isAirDashing;
        [FieldOffset(0x122)]
        public byte m_allowDash;
    }
}
