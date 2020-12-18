using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct PlatformBehaviourPtr {
        [FieldOffset(0x30)]
        public IntPtr PlatformMovement;
        [FieldOffset(0x70)]
        public IntPtr AirNoDeceleration;
        [FieldOffset(0x80)]
        public IntPtr ApplyFrictionToSpeed;
        [FieldOffset(0x90)]
        public IntPtr Visuals;
    }

    [StructLayout(LayoutKind.Explicit, Size = 400, Pack = 1)]
    public struct SeinPlatformMovementPtr {
        [FieldOffset(0x38)]
        public IntPtr Ceiling;
        [FieldOffset(0x40)]
        public IntPtr Ground;
        [FieldOffset(0x48)]
        public IntPtr WallLeft;
        [FieldOffset(0x50)]
        public IntPtr WallRight;
        [FieldOffset(0x58)]
        public Vector3 CeilingNormal;
        [FieldOffset(0x64)]
        public Vector3 GroundNormal;
        [FieldOffset(0x70)]
        public Vector3 WallRightNormal;
        [FieldOffset(0x7C)]
        public Vector3 WallLeftNormal;
        [FieldOffset(0x9C)]
        public Vector3 m_localSpeed;
        [FieldOffset(0x17C)]
        public byte HeadAgainstWall;
        [FieldOffset(0x17D)]
        public byte FeetAgainstWall;
        [FieldOffset(0x180)]
        public Vector3 HeadWallNormal;
        [FieldOffset(0x18C)]
        public Vector3 FeetWallNormal;
        [FieldOffset(0x1A4)]
        public Vector3 GroundRayNormal;
        [FieldOffset(0x2C4)]
        public float m_climblableWallTimer;
        [FieldOffset(0x2F8)]
        public Vector2 AdditiveLocalSpeed;
    }

    [StructLayout(LayoutKind.Explicit, Size = 19, Pack = 1)]
    public struct CharacterAirNoDecelerationPtr {
        [FieldOffset(0xA0)]
        public bool m_noDeceleration;
    }

    [StructLayout(LayoutKind.Explicit, Size = 19, Pack = 1)]
    public struct CharacterApplyFrictionToSpeedPtr {
        [FieldOffset(0xA0)]
        public Vector2 SpeedFactor;
    }

    [StructLayout(LayoutKind.Explicit, Size = 19, Pack = 1)]
    public struct IsOnCollisionState {
        [FieldOffset(0x10)]
        public bool WasOn;
        [FieldOffset(0x11)]
        public bool IsOn;
        [FieldOffset(0x12)]
        public bool FutureOn;
    }

    [StructLayout(LayoutKind.Explicit, Size = 19, Pack = 1)]
    public struct CharacterVisuals {
        [FieldOffset(0x28)]
        public IntPtr SpriteRotater;
    }

    [StructLayout(LayoutKind.Explicit, Size = 19, Pack = 1)]
    public struct SeinSpriteRotationController {
        [FieldOffset(0xD0)]
        public float m_wallLeftAngle;
        [FieldOffset(0xD4)]
        public float m_wallRightAngle;
    }

    public class SeinPlatformBehaviour {
        public SeinPlatformMovement SeinPlatformMovement;
        public AirNoDeceleration AirNoDeceleration;
        public ApplyFrictionToSpeed ApplyFrictionToSpeed;
    }

    public class AirNoDeceleration {
        public bool m_noDeceleration;
    }

    public class ApplyFrictionToSpeed {
        public Vector2 SpeedFactor;
    }

    public class SeinPlatformMovement {
        public IsOnCollisionState Ceiling;
        public IsOnCollisionState Ground;
        public IsOnCollisionState WallLeft;
        public IsOnCollisionState WallRight;
        public Vector3 CeilingNormal;
        public Vector3 GroundNormal;
        public Vector3 WallRightNormal;
        public Vector3 WallLeftNormal;
        public Vector3 m_localSpeed;
        public byte HeadAgainstWall;
        public byte FeetAgainstWall;
        public Vector3 HeadWallNormal;
        public Vector3 FeetWallNormal;
        public Vector3 GroundRayNormal;
        public float m_climblableWallTimer;
        public Vector2 AdditiveLocalSpeed;
        public float m_wallLeftAngle;
        public float m_wallRightAngle;
    }
}
