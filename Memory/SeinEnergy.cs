using System;
using System.Runtime.InteropServices;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 88, Pack = 1)]
    public struct SeinEnergy {
        [FieldOffset(0x38)]
        public Single MinEnergyPercentAfterRespawn;
        [FieldOffset(0x3C)]
        public Single MinVisual;
        [FieldOffset(0x40)]
        public Single MaxVisual;
        [FieldOffset(0x44)]
        public Single BaseMaxEnergyCap;
        [FieldOffset(0x48)]
        public bool m_energyDirty;
        [FieldOffset(0x4C)]
        public Single m_energyCached;
        [FieldOffset(0x50)]
        public Single m_maxEnergyCached;
        [FieldOffset(0x54)]
        public bool m_maxEnergDirty;
        [FieldOffset(0x58)]
        public Single m_actualMaxEnergyCached;
        [FieldOffset(0x5C)]
        public bool m_actualMaxEnergyDirty;
        [FieldOffset(0x5D)]
        public bool m_baseMaxEnergyDirty;
        [FieldOffset(0x60)]
        public Single m_baseMaxEnergyCached;
        [FieldOffset(0x64)]
        public bool m_energyCostMultiplierDirty;
        [FieldOffset(0x68)]
        public Single m_energyCostMultiplierCached;
        [FieldOffset(0x6C)]
        public Single m_maxEnergyBonus;
    }
}
