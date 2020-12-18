using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace OriWotW.UberController {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct UberStateValueStore {
        [FieldOffset(0x18)]
        public IntPtr m_groupMap;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct UberStateValueGroup {
        [FieldOffset(0x18)]
        public IntPtr m_id;
        [FieldOffset(0x20)]
        public IntPtr m_objectStateMap;
        [FieldOffset(0x28)]
        public IntPtr m_boolStateMap;
        [FieldOffset(0x30)]
        public IntPtr m_floatStateMap;
        [FieldOffset(0x38)]
        public IntPtr m_intStateMap;
        [FieldOffset(0x40)]
        public IntPtr m_byteStateMap;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct PedestalState {
        [FieldOffset(0x10)]
        public bool HasGameBeenSaved;
        [FieldOffset(0x11)]
        public bool IsTeleporterActive;
    }

    public class UberPedestal {
        public uint ID = 0;
        public string Name = "";
        public bool HasGameBeenSaved = false;
        public bool IsTeleporterActive = false;
    }

    public class UberBool {
        public uint ID = 0;
        public string Name = "";
        public bool Value = false;
    }

    public class UberFloat {
        public uint ID = 0;
        public string Name = "";
        public float Value = 0;
    }

    public class UberInt {
        public uint ID = 0;
        public string Name = "";
        public int Value = 0;
    }

    public class UberByte {
        public uint ID = 0;
        public string Name = "";
        public byte Value = 0;
    }

    public enum UberStateType : int {
        Pedestal = 0,
        Bool = 1,
        Float = 2,
        Int = 3,
        Byte = 4
    };

    public class UberStateGroup {
        public uint ID = 0;
        public string Name = "";
        public List<UberPedestal> PedestalStates = new List<UberPedestal>();
        public List<UberBool> BoolStates = new List<UberBool>();
        public List<UberFloat> FloatStates = new List<UberFloat>();
        public List<UberInt> IntStates = new List<UberInt>();
        public List<UberByte> ByteStates = new List<UberByte>();

        public int GetUberIndex(uint uberId, UberStateType type = 0) {
            switch (type) {
                case UberController.UberStateType.Pedestal:
                    for (var i = 0; i < this.PedestalStates.Count; i++) {
                        if (this.PedestalStates[i].ID == uberId) {
                            return i;
                        }
                    }
                    break;

                case UberController.UberStateType.Bool:
                    for (var i = 0; i < this.BoolStates.Count; i++) {
                        if (this.BoolStates[i].ID == uberId) {
                            return i;
                        }
                    }
                    break;

                case UberController.UberStateType.Float:
                    for (var i = 0; i < this.FloatStates.Count; i++) {
                        if (this.FloatStates[i].ID == uberId) {
                            return i;
                        }
                    }
                    break;

                case UberController.UberStateType.Int:
                    for (var i = 0; i < this.IntStates.Count; i++) {
                        if (this.IntStates[i].ID == uberId) {
                            return i;
                        }
                    }
                    break;

                case UberController.UberStateType.Byte:
                    for (var i = 0; i < this.ByteStates.Count; i++) {
                        if (this.ByteStates[i].ID == uberId) {
                            return i;
                        }
                    }
                    break;
            }

            return -1;
        }
    }

    public class UberStateController {
        public List<UberStateGroup> UberGroups = new List<UberStateGroup>();

        public int GetUberGroupIndex(uint uberGroupId) {
            for (int i = 0; i < this.UberGroups.Count; i++) {
                if (this.UberGroups[i].ID == uberGroupId) {
                    return i;
                }
            }
            return -1;
        }

        public UberStateGroup GetUberStateGroup(uint uberGroupId) {
            for (int i = 0; i < this.UberGroups.Count; i++) {
                if (this.UberGroups[i].ID == uberGroupId) {
                    return this.UberGroups[i];
                }
            }
            return null;
        }
    }
}
