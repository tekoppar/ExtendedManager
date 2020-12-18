using System;
using System.Runtime.InteropServices;
namespace OriWotW {
    public enum ControlScheme {
        Controller = 0,
        KeyboardAndMouse = 1,
        Keyboard = 2,
        Switch = 3
    }

    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 1)]
    public struct GameSettings {
        [FieldOffset(0x0)]
        public IntPtr Instance;
        [FieldOffset(0xD0)]
        public ControlScheme m_currentControlSchemes;
        [FieldOffset(0xC4)]
        public IntPtr m_unlockedCutscenes;
        [FieldOffset(0xE4)]
        public IntPtr m_hudEnabled;
        [FieldOffset(0x90)]
        public IntPtr m_language;
    }
}
