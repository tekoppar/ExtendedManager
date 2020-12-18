using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 62, Pack = 1)]
    public struct CharacterState {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(24)]
        public IntPtr MoonGuid;
        [FieldOffset(0x38)]
        public byte m_dataResolver;
        [FieldOffset(0x40)]
        public byte SeinCharacterPreview;
        [FieldOffset(0x48)]
        public byte m_previewAnimator;
        [FieldOffset(0x50)]
        public byte IsAllowed;
        [FieldOffset(0x58)]
        public byte PuppetPrefab;
        [FieldOffset(0x60)]
        public byte m_characterStatePuppet;
        [FieldOffset(0x68)]
        public byte DebugStateOutput;
        [FieldOffset(0x6C)]
        public IntPtr m_id;
        [FieldOffset(0x70)]
        public IntPtr m_sein;
    }

    [StructLayout(LayoutKind.Explicit, Size = 9, Pack = 1)]
    public struct CharacterStateWrapper {
        [FieldOffset(16)]
        public byte HasState;
        [FieldOffset(24)]
        public IntPtr State;
    }
}
