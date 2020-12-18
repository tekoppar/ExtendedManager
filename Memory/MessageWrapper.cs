using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct TranslatedMessage {
        [FieldOffset(32)]
        public IntPtr Messages;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct MessagesPtr {
        [FieldOffset(16)]
        public IntPtr English;
    }

    public class Messages {
        public string English = "";
    }
}
