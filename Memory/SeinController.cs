using System;
using System.Runtime.InteropServices;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinControllerPtr {
        [FieldOffset(0x38)]
        public bool IgnoreControllerInput;
        [FieldOffset(0x78)]
        public bool IsSuspended;
    }

    public class SeinController {
        public bool IgnoreControllerInput;
        public bool IsSuspended;
    }
}
