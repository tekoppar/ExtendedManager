using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinBashPtr {
        [FieldOffset(216)]
        public IntPtr Target;
        [FieldOffset(372)]
        public bool IsBashing;
    }

    public class SeinBash {
        public bool TargetFound = false;
        public SeinTarget Target;
        public bool IsBashing;
    }
}
