using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct SeinJump {
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
        public float BackflipJumpHeight;
        [FieldOffset(0x9C)]
        public float CrouchJumpHeight;
        [FieldOffset(0xA0)]
        public float DurationSinceLastOnGroundThatWeCanStillJump;
        [FieldOffset(0xA4)]
        public float FirstJumpHeight;
        [FieldOffset(0xA8)]
        public float JumpIdleHeight;
        [FieldOffset(0xAC)]
        public float JumpImpulse;
        [FieldOffset(0xB0)]
        public int m_currentJumpingMaterial;
        [FieldOffset(0xB4)]
        public float SecondJumpHeight;
        [FieldOffset(0xB8)]
        public float ThirdJumpHeight;
        [FieldOffset(0xC0)]
        public IntPtr SeinEffects;
        [FieldOffset(0xC8)]
        public float m_bunnyHopTimeRemaining;
        [FieldOffset(0xCC)]
        public int m_jumpIdleNumber;
        [FieldOffset(0xD0)]
        public int m_runningJumpNumber;
        [FieldOffset(0xD4)]
        public byte m_spriteMirrorLock;
        [FieldOffset(0xD8)]
        public float m_timeWeCanJumpRemaining;
        [FieldOffset(0xE0)]
        public IntPtr m_shouldJumpMoving;
        [FieldOffset(0xE8)]
        public IntPtr onAnimationEnd;
        [FieldOffset(0xF0)]
        public IntPtr m_directionFlipTransitionAction;
        [FieldOffset(0xF8)]
        public int m_previousDirection;
        [FieldOffset(0xFC)]
        public byte BackingField;
        [FieldOffset(0x100)]
        public IntPtr m_currentFlipAnimation;
        [FieldOffset(0x120)]
        public float m_timeSinceLastJump;
        [FieldOffset(0x128)]
        public IntPtr OnJumpEvent;
        [FieldOffset(0x130)]
        public IntPtr m_useGenericJumpFlipTransitionAsDefault;
    }
}
