using System.Runtime.InteropServices;
namespace OriWotW {
    [StructLayout(LayoutKind.Explicit, Size = 35, Pack = 1)]
    public struct PlayerUberStateStats {
        [FieldOffset(0x10)]
        public float Health;
        [FieldOffset(0x14)]
        public int MaxHealth;
        [FieldOffset(0x18)]
        public float Energy;
        [FieldOffset(0x1C)]
        public float MaxEnergy;
        [FieldOffset(0x20)]
        public int Completion;
        [FieldOffset(0x24)]
        public int Hours;
        [FieldOffset(0x28)]
        public int Minutes;
        [FieldOffset(0x2C)]
        public int Seconds;
        [FieldOffset(0x30)]
        public bool Completed;
        [FieldOffset(0x31)]
        public bool WasKilled;
        [FieldOffset(0x32)]
        public bool CompletedWithEverything;

        public override string ToString() {
            return $"{Hours:00}:{Minutes:00}:{Seconds} Completion: {Completion}%";
        }
    }
}