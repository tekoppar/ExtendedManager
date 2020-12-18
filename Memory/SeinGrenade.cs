using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinGrenadePtr {
        [FieldOffset(0x1FD)]
        public bool m_wasGroundedAfterAirAiming;
    }
}
