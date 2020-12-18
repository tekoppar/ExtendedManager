using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct WorldMapIconPtr {
        [FieldOffset(0x20)]
        public int Icon;
        [FieldOffset(0x24)]
        public Vector2 Position;
        [FieldOffset(0x30)]
        public IntPtr IsCollectedState;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct State {
        [FieldOffset(0x49)]
        public bool m_value;
    }

    public class WorldMapIcon {
        public int Icon = 16;
        public bool IsCollected = false;
        public string IconType = "Invisible";
        public Vector2 Position;
    }
}
