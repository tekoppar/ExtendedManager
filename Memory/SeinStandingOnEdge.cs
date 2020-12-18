using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinStandingOnEdgePtr {
        [FieldOffset(0xB0)]
        public bool StandingOnEdgeBackwards;
        [FieldOffset(0xB1)]
        public bool StandingOnEdgeForwards;
    }
}
