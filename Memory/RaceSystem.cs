using System;
using System.Runtime.InteropServices;
namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RaceSystemPtr {
        [FieldOffset(0)]
        public IntPtr instance;
        [FieldOffset(40)]
        public IntPtr m_timer;
        [FieldOffset(320)]
        public IntPtr Context;
        [FieldOffset(336)]
        public IntPtr m_states;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct m_timer {
        [FieldOffset(24)]
        public float ElapsedTime;
        [FieldOffset(28)]
        public float PersonalBestTime;
        [FieldOffset(32)]
        public float BestTime;
        [FieldOffset(36)]
        public float TimeLimit;
        [FieldOffset(40)]
        public float TimeToBeat;
        [FieldOffset(44)]
        public float PreviousElapsedTime;
        [FieldOffset(76)]
        public bool m_startedRace;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RaceCountdownStatePtr {
        [FieldOffset(24)]
        public bool m_countdownFinished;
        [FieldOffset(32)]
        public IntPtr m_countdownTimeline;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct MoonTimeline {
        [FieldOffset(48)]
        public bool PlayState;
        [FieldOffset(180)]
        public bool StartMode;
        [FieldOffset(184)]
        public float CurrentTime;
        [FieldOffset(232)]
        public bool m_isFinished;
        [FieldOffset(256)]
        public bool m_markerInitialized;
        [FieldOffset(257)]
        public bool m_contentEnd;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RaceContext {
        [FieldOffset(24)]
        public IntPtr Configuration;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RaceConfiguration {
        [FieldOffset(24)]
        public IntPtr Race;
        [FieldOffset(32)]
        public IntPtr Handler;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct MoonRace {
        [FieldOffset(104)]
        public IntPtr m_startTransform;
        [FieldOffset(120)]
        public IntPtr m_endTransform;
        [FieldOffset(176)]
        public IntPtr CountdownTimeline;
        [FieldOffset(232)]
        public IntPtr StartZoneChecker;
        [FieldOffset(240)]
        public IntPtr EndZoneChecker;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct RaceHandler {
        [FieldOffset(48)]
        public Vector2 m_oriStartRacePosition;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct ObjectInsideZoneChecker {
        [FieldOffset(24)]
        public Rect m_bounds;
        [FieldOffset(40)]
        public IntPtr ExternalTransform;
        [FieldOffset(48)]
        public Vector2 Size;
        [FieldOffset(56)]
        public Vector2 Anchor;
        [FieldOffset(64)]
        public float checkResultDelay;
        [FieldOffset(68)]
        public IntPtr EditorColor;
        [FieldOffset(88)]
        public bool OnlyTriggerIfGrounded;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct Rect {
        [FieldOffset(0)]
        public float m_XMin;
        [FieldOffset(4)]
        public float m_YMin;
        [FieldOffset(8)]
        public float m_Width;
        [FieldOffset(12)]
        public float m_Height;
    }

    public class RaceSystem {
        public m_timer Timer;
        public MoonTimeline CountdownTimeline;
    }
}
