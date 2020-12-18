using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinDoubleJump {
        [FieldOffset(16)]
        public IntPtr m_CachedPtr;
        [FieldOffset(24)]
        public IntPtr MoonGuid;
        [FieldOffset(32)]
        public IntPtr m_dataResolver;
        [FieldOffset(40)]
        public IntPtr SeinCharacterPreview;
        [FieldOffset(48)]
        public IntPtr m_previewAnimator;
        [FieldOffset(56)]
        public IntPtr IsAllowed;
        [FieldOffset(64)]
        public IntPtr PuppetPrefab;
        [FieldOffset(72)]
        public IntPtr m_characterStatePuppet;
        [FieldOffset(80)]
        public byte DebugStateOutput;
        [FieldOffset(84)]
        public IntPtr m_id;
        [FieldOffset(88)]
        public IntPtr m_sein;
        [FieldOffset(96)]
        public byte m_isActive;
        [FieldOffset(104)]
        public IntPtr m_canBeInterruptedBy;
        [FieldOffset(112)]
        public byte m_canInputBeQueued;
        [FieldOffset(120)]
        public IntPtr CharacterStateUpdateString;
        [FieldOffset(0x98)]
        public float JumpStrength;
        [FieldOffset(0xA0)]
        public IntPtr m_doubleJumpSound;
        [FieldOffset(0xA8)]
        public float m_doubleJumpTime;
        [FieldOffset(0xAC)]
        public byte m_numberOfJumpsAvailable;
        [FieldOffset(0xB0)]
        public float m_remainingLockTime;
        [FieldOffset(0xB4)]
        public bool m_isDoubleJumping;
        [FieldOffset(0xB5)]
        public bool m_isInAirCached;
    }
}
