using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OriWotW.GameWorld;
using OriWotW.Memory;
using OriWotW.UberController;
using Tem.TemClass;

namespace OriWotW {
    public partial class MemoryManager {
        private static ProgramPointer Characters = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.Characters.SetCurrentCharacter", 0x9b),
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B0D????????F6812701000002740E83B9D8000000007505E8????????33D2488BCBE8????????488B05????????488B88B8000000C641040133C9", 0x3b, 0x0),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.Characters.SetCurrentCharacter", 0x9b),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B0D????????F6812701000002740E83B9D8000000007505E8????????33D2488BCBE8????????488B05????????488B88B8000000C641040133C9", 0x3b, 0x0),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.Characters.SetCurrentCharacter", 0x15c),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "488B80B80000004C8B40084D85C0743D488B15????????B90C000000E8????????488BF84885DB743C488B4B304885C9742D33D2E8????????4885C0741B48897818488B5C24504883C4405FC3", -0x4, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.Characters.SetCurrentCharacter", 0x15c),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "488B80B80000004C8B40084D85C0743D488B15????????B90C000000E8????????488BF84885DB743C488B4B304885C9742D33D2E8????????4885C0741B48897818488B5C24504883C4405FC3", -0x4, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.Characters.SetCurrentCharacter", 0x15c),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "488B80B80000004C8B40084D85C0743D488B15????????B90C000000E8????????488BF84885DB743C488B4B304885C9742D33D2E8????????4885C0741B48897818488B5C24504883C4405FC3", -0x4, 0x0));
        private static ProgramPointer GameWorld = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.GameWorld.Awake", 0x79),
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B80000004C8931498B4E??498B46??4885C00F84????????4885C90F84????????4C8B05????????8B5018E8????????458BFD418BD5498B4E", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.GameWorld.Awake", 0x79),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B80000004C8931498B4E??498B46??4885C00F84????????4885C90F84????????4C8B05????????8B5018E8????????458BFD418BD5498B4E", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.GameWorld.Awake", 0x79),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B80000004C8931498B4E??498B46??4885C00F84????????4885C90F84????????4C8B05????????8B5018E8????????458BFD418BD5498B4E", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.GameWorld.Awake", 0x79),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B80000004C8931498B4E??498B46??4885C00F84????????4885C90F84????????4C8B05????????8B5018E8????????458BFD418BD5498B4E", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.GameWorld.Awake", 0xa7),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "4C8BDC55565741544155415641574883EC5049C743A8FEFFFFFF49895B104C8BE933ED", 0xa7, 0x0));
        private static ProgramPointer PlayerUberStateGroup = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.Seinlevel.get_PartialHealthContainers", 0x68),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "488B05????????488B88B8000000488B014885C0742C488B48184885C9741D33D2E8????????4885C07423488B40184885C074148B40384883C448C3", 0x3, 0x0));
        private static ProgramPointer TitleScreenManager = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.TitleScreenManager.Awake", 0x97),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B8000000488928488B05", 0x35, 0x0));
        private static ProgramPointer GameStateMachine = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.GameStateMachine.get_Instance", 0x6f),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B1D????????488B83B8000000488B004885C00F85C6000000488BCBE8????????488B43604885C074278B08E8", 0x14, 0x0));
        private static ProgramPointer GameController = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.GameController.Initialize", 0xc6),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.GameController.Initialize", 0xc6),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.GameController.Initialize", 0xc3),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "014C8975288B04244883EC20488D4C24308B0148894D20C785C0000000FFFFFFFF488B05????????F6802701000002741883B8D800000000750F488BC8", 0x45, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.GameController.Initialize", 0xc3),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "014C8975288B04244883EC20488D4C24308B0148894D20C785C0000000FFFFFFFF488B05????????F6802701000002741883B8D800000000750F488BC8", 0x45, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.GameController.Initialize", 0xc3),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "014C8975288B04244883EC20488D4C24308B0148894D20C785C0000000FFFFFFFF488B05????????F6802701000002741883B8D800000000750F488BC8", 0x45, 0x0));
        private static ProgramPointer ScenesManager = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.ScenesManager.Awake", 0x75),
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488931488B1D????????488BCBE8????????488B43604885C074278B08E8????????483B05????????7517", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.ScenesManager.Awake", 0x75),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488931488B1D????????488BCBE8????????488B43604885C074278B08E8????????483B05????????7517", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.ScenesManager.Awake", 0x76),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488931488B1D????????488BCBE8????????488B43604885C074278B08E8????????483B05????????7517", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.ScenesManager.Awake", 0x76),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488931488B1D????????488BCBE8????????488B43604885C074278B08E8????????483B05????????7517", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.ScenesManager.Awake", 0x76),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488931488B1D????????488BCBE8????????488B43604885C074278B08E8????????483B05????????7517", 0x14, 0x0));
        private static ProgramPointer UberStateController = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__uberSerialization.UberStateController.get_Instance", 0x90),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B1D????????F6832701000002741883BBD800000000750F488BCBE8????????488B1D????????488B83B800000048837828000F85", 0x35, 0x0));
        private static ProgramPointer UberStateCollection = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__uberSerialization.UberStateCollection.get_Instance", 0x8b),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__uberSerialization.UberStateCollection.get_Instance", 0x8b),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__uberSerialization.UberStateCollection.GetGroup", 0x73),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "9033C9FF15????????90C605????????01488B0D????????F6812701000002740E83B9D8000000007505E8????????33C9E8????????4885C07469488B58384885DB745A", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__uberSerialization.UberStateCollection.GetGroup", 0x73),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "9033C9FF15????????90C605????????01488B0D????????F6812701000002740E83B9D8000000007505E8????????33C9E8????????4885C07469488B58384885DB745A", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__uberSerialization.UberStateCollection.GetGroup", 0x73),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B0D????????F6812701000002740E83B9D8000000007505E8????????33C9E8????????4885C07469488B58384885DB745A", 0x14, 0x0));
        private static ProgramPointer DifficultyController = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.ConfirmChangingDifficulty.Perform", 0xdf),
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488B094885C9747B4533C08B5338E8????????807B29007531C6432901488B05", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.ConfirmChangingDifficulty.Perform", 0xdf),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488B094885C9747B4533C08B5338E8????????807B29007531C6432901488B05", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.ConfirmChangingDifficulty.Perform", 0xdf),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488B094885C974694533C08B5320E8????????488B05????????4885C07518", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.ConfirmChangingDifficulty.Perform", 0xdf),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488B094885C974694533C08B5320E8????????488B05????????4885C07518", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.ConfirmChangingDifficulty.Perform", 0xdf),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????488B88B8000000488B094885C974694533C08B5320E8????????488B05????????4885C07518", 0x14, 0x0));
        private static ProgramPointer NoPausePatch = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.None, "__mainWisp.GameController.OnApplicationFocus", 0x1b),
            new FindPointerSignature(PointerVersion.All, AutoDeref.None, "4C8BDC565741564883EC5049C743C8FEFFFFFF49895B1049896B18??????488BF14533F6443835????????754B488B05????????4C6380C0000000488B05????????418B8C00????????418B9400????????4D8973D04D8973D84D8973E04D8D43D0E8????????9033C9FF15????????90C605????????0180BE????????000F85????????4084ED0F85????????33C9E8????????4885C00F84????????33D2488BC8E8????????84C07561", 0x1b, 0x0));
        private static ProgramPointer FrameCounter = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.GameController.FixedUpdate", 0x1c5),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.GameController.FixedUpdate", 0x1c5),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.GameController.FixedUpdate", 0x1c8),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "80780A007538488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B8000000FF0033C9", 0x2a, 0x0),
            new FindIl2Cpp(PointerVersion.P1, AutoDeref.Single, "__mainWisp.GameController.FixedUpdate", 0x1c8),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "80780A007538488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B8000000FF0033C9", 0x2a, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.GameController.FixedUpdate", 0x1c8),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "80780A007538488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B8000000FF0033C9", 0x2a, 0x0));
        private static ProgramPointer CheatsHandler = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.P4, AutoDeref.Single, "__mainWisp.CheatsHandler.Awake", 0x7e),
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B80000004C89??488B0D", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P3, AutoDeref.Single, "__mainWisp.CheatsHandler.Awake", 0x7e),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B80000004C89??488B0D", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.P2, AutoDeref.Single, "__mainWisp.CheatsHandler.Awake", 0x7e),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B80000004C89??488B0D", 0x14, 0x0),
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.CheatsHandler.Awake", 0x7a),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B80000004C89??488B0D", 0x14, 0x0));
        private static ProgramPointer DebugControls = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.AdvancedDebugMenuPage.DebugControlsSetter", 0x8e));
        private static ProgramPointer RaceSystem = new ProgramPointer("GameAssembly.dll",
            new FindIl2Cpp(PointerVersion.All, AutoDeref.Single, "__mainWisp.RaceSystem.get_CurrentStateTime", 0x8f),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "4885C00F8499000000488B80280100004885C00F849B00000048837820007675488B0D????????F6812701000002740E83B9D8000000007505E8", 0x23, 0x0));
        private static ProgramPointer GameSettings = new ProgramPointer("GameAssembly.dll",
            new FindPointerSignature(PointerVersion.P4, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B800000048893833D2488BCF", 0x14, 0x0),
            new FindPointerSignature(PointerVersion.P3, AutoDeref.Single, "9033C9FF15????????90C605????????01488B05????????F6802701000002741883B8D800000000750F488BC8E8????????488B05????????488B80B800000048893833D2488BCF", 0x14, 0x0),
            new FindPointerSignature(PointerVersion.P2, AutoDeref.Single, "448975E848C745EC??000000C645F400488D4DC8E8????????488905????????4885C00F84????????FFD0C64718014889471033C9E8????????4533C08BD0488BCFE8", 0x4a, 0x0),
            new FindPointerSignature(PointerVersion.P1, AutoDeref.Single, "448975E848C745EC??000000C645F400488D4DC8E8????????488905????????4885C00F84????????FFD0C64718014889471033C9E8????????4533C08BD0488BCFE8", 0x4a, 0x0),
            new FindPointerSignature(PointerVersion.All, AutoDeref.Single, "448975E848C745EC??000000C645F400488D4DC8E8????????488905????????4885C00F84????????FFD0C64718014889471033C9E8????????4533C08BD0488BCFE8", 0x4a, 0x0));
        public static PointerVersion Version { get; set; } = PointerVersion.All;
        public Process Program { get; set; }
        public Module64 UnityPlayer { get; set; }
        public Module64 GameAssembly { get; set; }
        public bool IsHooked { get; set; }
        public DateTime LastHooked { get; set; }
        public ControlScheme LastControlScheme { get; set; }
        public int ControllerCounter { get; set; } = 0;
        public bool ControllerWasSame { get; set; } = true;
        private bool? noPausePatched = null;
        private bool? debugEnabled = null;
        private FPSTimer fpsTimer = new FPSTimer(200, 15);
        private static Dictionary<long, UberState> uberIDLookup = null;

        public MemoryManager() {
            LastHooked = DateTime.MinValue;
        }
        public string GamePointers() {
            return string.Concat(
                $"CHR: {(ulong)Characters.GetPointer(Program):X} ",
                $"GW: {(ulong)GameWorld.GetPointer(Program):X} ",
                $"PUS: {(ulong)PlayerUberStateGroup.GetPointer(Program):X} ",
                $"TSM: {(ulong)TitleScreenManager.GetPointer(Program):X} ",
                $"GSM: {(ulong)GameStateMachine.GetPointer(Program):X} ",
                $"GC: {(ulong)GameController.GetPointer(Program):X} ",
                $"SM: {(ulong)ScenesManager.GetPointer(Program):X} ",
                $"USC: {(ulong)UberStateController.GetPointer(Program):X} ",
                $"USL: {(ulong)UberStateCollection.GetPointer(Program):X} ",
                $"DC: {(ulong)DifficultyController.GetPointer(Program):X} ",
                $"NP: {(ulong)NoPausePatch.GetPointer(Program):X} ",
                $"FC: {(ulong)FrameCounter.GetPointer(Program):X} ",
                $"CH: {(ulong)CheatsHandler.GetPointer(Program):X} ",
                $"DC: {(ulong)DebugControls.GetPointer(Program):X} ",
                $"RS: {(ulong)RaceSystem.GetPointer(Program):X} ",
                $"GS: {(ulong)GameSettings.GetPointer(Program):X} "
            );
        }
        public float RaceTime() {
            //RaceSystem.Instance.m_timer.ElapsedTime
            int m_timer = Version <= PointerVersion.P2 ? 0x28 : 0x40;
            int m_elapsedTime = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            return RaceSystem.Read<float>(Program, 0xb8, 0x0, m_timer, m_elapsedTime);
        }
        public float LastRaceTime() {
            //RaceSystem.Instance.Context.LastRaceTime
            int m_Context = Version <= PointerVersion.P2 ? 0x140 : 0x168;
            int lastRaceTime = Version <= PointerVersion.P2 ? 0x104 : 0x114;
            return RaceSystem.Read<float>(Program, 0xb8, 0x0, m_Context, lastRaceTime);
        }
        public float PersonalBestTime() {
            //RaceSystem.Instance.m_timer.PersonalBestTime
            int m_timer = Version <= PointerVersion.P2 ? 0x28 : 0x40;
            int m_personalBestTime = Version <= PointerVersion.P2 ? 0x1c : 0x34;
            return RaceSystem.Read<float>(Program, 0xb8, 0x0, m_timer, m_personalBestTime);
        }
        public bool DebugEnabled() {
            //CheatsHandler.Instance.DebugEnabled
            int m_debugEnabled = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            return CheatsHandler.Read<bool>(Program, 0xb8, 0x0, m_debugEnabled);
        }
        public void EnableDebug(bool enable) {
            if (!debugEnabled.HasValue || enable != debugEnabled.Value) {
                if (CheatsHandler.GetPointer(Program) == IntPtr.Zero) { return; }

                // Disable infinite energy - Characters.sein.Energy.InfiniteEnergy
                int energy = Version <= PointerVersion.P2 ? 0x80 : 0x98;
                Characters.Write<bool>(Program, false, 0xb8, 0x10, energy, 0x0, 0xb8, 0x0);

                DebugControls.Write<bool>(Program, enable, 0xb8, 0x8);
                //CheatsHandler.Instance.DebugEnabled
                int m_debugEnabled = Version <= PointerVersion.P2 ? 0x20 : 0x38;
                CheatsHandler.Write<bool>(Program, enable, 0xb8, 0x0, m_debugEnabled);
                //CheatsHandler.DebugWasEnabled/DebugAlwaysEnabled
                CheatsHandler.Write<short>(Program, enable ? (short)0x0101 : (short)0x0, 0xb8, 0x8);

                debugEnabled = enable;
            }
        }
        public string Patches() {
            return "NoPause: " + (!noPausePatched.HasValue ? "No Value" : noPausePatched.ToString()) + " Debug: " + DebugEnabled().ToString();
        }
        public bool NoPauseEnabled() {
            return NoPausePatch.Read<int>(Program) == 0x4890C5FF;
        }
        public void PatchNoPause(bool patch) {
            if (!noPausePatched.HasValue || patch != noPausePatched.Value) {
                if (NoPausePatch.GetPointer(Program) == IntPtr.Zero) { return; }

                if (patch) {
                    NoPausePatch.Write(Program, new byte[] { 0xFF, 0xC5, 0x90 });
                } else {
                    NoPausePatch.Write(Program, new byte[] { 0x0F, 0xB6, 0xEA });
                }
                noPausePatched = patch;
            }
        }
        public long FrameCount() {
            float frameCount = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x04798D30, 0xb8, 0x0, 0 + 0x1f0);
            long frameCount1 = (long)(frameCount * 1000.0f);
            return frameCount1;// 0x38);// FrameCounter.Read<int>(Program, 0xb8, 0x0);
        }
        public float FPS() {
            return 1000.0f / (MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x04798D30, 0xb8, 0x0, 0x0 + 0x4C) * 1000.0f); //fpsTimer.FPS;
        }
        public int Difficulty() {
            //DifficultyController.Instance.Difficulty
            int m_difficulty = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            return DifficultyController.Read<int>(Program, 0xb8, 0x0, m_difficulty);
        }
        public void SetDifficulty(int difficulty) {
            //DifficultyController.Instance.Difficulty
            int m_difficulty = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            DifficultyController.Write<int>(Program, difficulty, 0xb8, 0x0, m_difficulty);
        }
        public PlayerUberStateStats PlayerStats() {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Stats
            int playerUberState = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            return Characters.Read<PlayerUberStateStats>(Program, 0xb8, 0x10, 0xb8, playerUberState, 0x30, 0x28, 0x0);
        }
        /*public Stats PlayerStats() {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Stats
            return PlayerUberStateGroup.Read<Stats>(Program, 0xb8, 0x0, 0x18, 0x30, 0x28, 0x10);
        }*/
        public void SetPlayerStats(PlayerUberStateStats stats) {
            PlayerUberStateGroup.Write<PlayerUberStateStats>(Program, stats, 0xb8, 0x0, 0x18, 0x30, 0x28, 0x10);
        }
        public int Keystones() {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Inventory.m_keystones
            return PlayerUberStateGroup.Read<int>(Program, 0xb8, 0x0, 0x18, 0x30, 0x18, 0x28);
        }
        public void SetKeystones(int count) {
            PlayerUberStateGroup.Write<int>(Program, count, 0xb8, 0x0, 0x18, 0x30, 0x18, 0x28);
        }
        public int Ore() {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Inventory.m_ore
            return PlayerUberStateGroup.Read<int>(Program, 0xb8, 0x0, 0x18, 0x30, 0x18, 0x34);
        }
        public Vector3 Position() {
            //Characters.Sein.PlatformBehaviour.PlatformMovement.m_prevPosition
            SeinCharacterPtr sein = GetSeinPtr();

            switch (Version) {
                case PointerVersion.P1: return MemoryReader.Read<Vector3>(Program, sein.PlatformBehaviour, 0x18, 0xD0);
                case PointerVersion.P2: return MemoryReader.Read<Vector3>(Program, sein.PlatformBehaviour, 0x18, 0xD0);
                case PointerVersion.P3: return MemoryReader.Read<Vector3>(Program, sein.PlatformBehaviour, 0x18, 0xE8);
                case PointerVersion.P4: return MemoryReader.Read<Vector3>(Program, sein.PlatformBehaviour, 0x30, 0xE8);
            }
            return new Vector3(0, 0, 0);
        }
        public void DisableInfiniteEnergy() {
            MemoryReader.Write<bool>(Program, GameAssembly.BaseAddress, false, 0x4455DB0, 0x0);
        }
        public void LockPlayer() {
            SeinCharacterPtr seinCharacterPtr = GetSeinPtr();
            //SeinControllerPtr seinControllerPtr = MemoryReader.Read<SeinControllerPtr>(Program, seinCharacterPtr.Controller);
            MemoryReader.Write<bool>(Program, seinCharacterPtr.Controller, true, 0x20);
        }

        public void UnlockPlayer() {
            SeinCharacterPtr seinCharacterPtr = GetSeinPtr();
            //SeinControllerPtr seinControllerPtr = MemoryReader.Read<SeinControllerPtr>(Program, seinCharacterPtr.Controller);
            MemoryReader.Write<bool>(Program, seinCharacterPtr.Controller, false, 0x20);
        }
        public string CurrentScene() {
            //Scenes.Manager.m_currentScene.Scene
            //int m_currentScene = FindIl2CppOffset.GetOffset(Program, "__mainWisp.ScenesManager.m_currentScene");
            int m_currentScene = Version < PointerVersion.P1 ? 0x180 : Version <= PointerVersion.P2 ? 0x190 : 0x1b8;
            return ScenesManager.Read(Program, 0xb8, 0x0, m_currentScene, 0x10, 0x0);
        }
        public AreaType PlayerArea() {
            //GameWorld.CurrentArea.Area.WorldMapAreaUniqueID
            int currentArea = Version <= PointerVersion.P2 ? 0x30 : 0x48;
            int worldMapAreaUniqueID = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            return GameWorld.Read<AreaType>(Program, 0xb8, 0x0, currentArea, 0x10, worldMapAreaUniqueID);
        }
        public double ElapsedTime() {
            //GameController.Instance.Timer.CurrentTime
            int m_timer = Version <= PointerVersion.P2 ? 0x28 : 0x40;
            int m_currentTime = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            return GameController.Read<double>(Program, 0xb8, 0x0, m_timer, m_currentTime);
        }
        public bool Dead() {
            //Characters.Sein.Mortality.DamageReciever.m_died
            int mortality = Version <= PointerVersion.P2 ? 0x88 : 0xa0;
            int m_died = Version <= PointerVersion.P2 ? 0xe4 : 0x110;
            return Characters.Read<bool>(Program, 0xb8, 0x10, mortality, 0x10, m_died);
        }
        public bool IsRacing() {
            RaceSystemPtr raceSystem = MemoryReader.Read<RaceSystemPtr>(Program, GameAssembly.BaseAddress, 0x047354E0, 0xb8, 0x0, 0x40, 0x0);
            m_timer timer = MemoryReader.Read<m_timer>(Program, raceSystem.m_timer);
            return timer.m_startedRace;
        }
        public GameState GameState() {
            //GameStateMachine.m_instance.CurrentState
            return GameStateMachine.Read<GameState>(Program, 0xb8, 0x0, 0x10);
        }
        public Screen TitleScreen() {
            //TitleScreenManager.Instance.m_currentScreen
            int m_currentScreen = Version <= PointerVersion.P2 ? 0xb8 : 0xf0;
            return (Screen)TitleScreenManager.Read<int>(Program, 0xb8, 0x0, m_currentScreen);
        }
        public ControlScheme GetControlScheme() {
            switch (Version) {
                case PointerVersion.P1:
                case PointerVersion.P2: return MemoryReader.Read<ControlScheme>(Program, GameAssembly.BaseAddress, 0x4475D30, 0xb8, 0x0, 0x94);
                case PointerVersion.P3:
                case PointerVersion.P4: return MemoryReader.Read<ControlScheme>(Program, GameAssembly.BaseAddress, 0x0478D378, 0xb8, 0x00, 0xD0);
            }
            return ControlScheme.KeyboardAndMouse;
        }
        public RuntimeGameWorldAreaPtr GetRuntimeGameArea() {
            switch (Version) {
                case PointerVersion.P1:
                case PointerVersion.P2: return MemoryReader.Read<RuntimeGameWorldAreaPtr>(Program, GameAssembly.BaseAddress, 0x444D080, 0xb8, 0x0, 0x48, 0x0);
                case PointerVersion.P3:
                case PointerVersion.P4: return MemoryReader.Read<RuntimeGameWorldAreaPtr>(Program, GameAssembly.BaseAddress, 0x04783850, 0xb8, 0x0, 0x48, 0x0);
            }
            return new RuntimeGameWorldAreaPtr();
        }
        public bool IsLoadingGame(GameState state) {
            ControlScheme currentControlScheme = GetControlScheme();
            if (LastControlScheme != currentControlScheme) {
                ControllerCounter = 0;
            }
            LastControlScheme = currentControlScheme;
            ControllerCounter++;

            if (FrameCounter.GetPointer(Program) != IntPtr.Zero && fpsTimer.FPSShort == 0 && ControllerCounter > 30) {
                return true;
            }

            //int m_isLoadingGame = FindIl2CppOffset.GetOffset(Program, "__mainWisp.GameController.m_isLoadingGame");
            int m_isLoadingGame = Version < PointerVersion.P1 ? 0x103 : Version <= PointerVersion.P2 ? 0x10b : 0x123;
            //GameController.FreezeFixedUpdate || GameController.Instance.m_isLoadingGame
            if (GameController.Read<bool>(Program, 0xb8, 0xa) || GameController.Read<bool>(Program, 0xb8, 0x0, m_isLoadingGame)) {
                return true;
            }
            return (state == OriWotW.GameState.TitleScreen || state == OriWotW.GameState.StartScreen) && CurrentScene() == "wotwTitleScreen";
        }
        private void PopulateUberStates() {
            uberIDLookup = new Dictionary<long, UberState>();
            //UberStateCollection.Instance.m_descriptorsArray
            IntPtr descriptors = UberStateCollection.Read<IntPtr>(Program, 0xb8, 0x10, 0x20);
            //.Count
            int descriptorsCount = Program.Read<int>(descriptors, 0x18);
            byte[] data = Program.Read(descriptors + 0x20, descriptorsCount * 0x8);
            for (int i = 0; i < descriptorsCount; i++) {
                //.m_descriptorsArray[i]
                IntPtr descriptor = (IntPtr)BitConverter.ToUInt64(data, i * 0x8);

                UberStateType type = UberStateType.SerializedBooleanUberState;
                Enum.TryParse<UberStateType>(Program.ReadAscii(descriptor, 0x0, 0x10, 0x0), out type);

                int groupOffset = 0x38;
                switch (type) {
                    case UberStateType.SerializedByteUberState:
                    case UberStateType.SerializedIntUberState:
                    case UberStateType.SavePedestalUberState: groupOffset = 0x30; break;
                    case UberStateType.PlayerUberStateDescriptor: groupOffset = 0x40; break;
                    case UberStateType.CountUberState:
                    case UberStateType.BooleanUberState:
                    case UberStateType.ByteUberState:
                    case UberStateType.IntUberState:
                    case UberStateType.ConditionUberState: continue;
                }

                //.m_descriptorsArray[i].ID.m_id
                int id = Program.Read<int>(descriptor, 0x18, 0x10);
                //.m_descriptorsArray[i].Name
                IntPtr namePtr = Program.Read<IntPtr>(descriptor, 0x10, 0x48);
                string name = string.Empty;
                if (namePtr != IntPtr.Zero) {
                    name = Program.ReadAscii(namePtr);
                } else {
                    name = Program.ReadAscii(descriptor, 0x10, 0x50);
                }

                //.m_descriptorsArray[i].Group.ID.m_id
                int groupID = Program.Read<int>(descriptor, groupOffset, 0x18, 0x10);
                //.m_descriptorsArray[i].Group.Name
                namePtr = Program.Read<IntPtr>(descriptor, groupOffset, 0x10, 0x48);
                string groupName = string.Empty;
                if (namePtr != IntPtr.Zero) {
                    groupName = Program.ReadAscii(namePtr);
                } else {
                    groupName = Program.ReadAscii(descriptor, groupOffset, 0x10, 0x50);
                }
                UberState uberState = new UberState() { Type = type, ID = id, Name = name, GroupID = groupID, GroupName = groupName };
                uberIDLookup.Add(((long)groupID << 32) | (long)id, uberState);
            }
        }
        public Dictionary<long, UberState> GetUberStates() {
            if (uberIDLookup == null) {
                PopulateUberStates();
            }

            UpdateUberState();

            return uberIDLookup;
        }
        public void UpdateUberState(UberState uberState = null) {
            //UbserStateController.m_currentStateValueStore.m_groupMap
            IntPtr groups = UberStateController.Read<IntPtr>(Program, 0xb8, 0x40, 0x18);
            //.Count
            int groupCount = Program.Read<int>(groups, 0x20);
            //.Values
            groups = Program.Read<IntPtr>(groups, 0x18);
            byte[] groupsData = Program.Read(groups + 0x20, groupCount * 0x18);

            bool updateAll = uberState == null;
            for (int i = 0; i < groupCount; i++) {
                //.Values[i].m_id.m_id
                IntPtr group = (IntPtr)BitConverter.ToUInt64(groupsData, 0x10 + (i * 0x18));
                byte[] groupData = Program.Read(group + 0x18, 48);
                long groupID = Program.Read<int>((IntPtr)BitConverter.ToUInt64(groupData, 0), 0x10);

                if (!updateAll && groupID != uberState.GroupID) { continue; }

                //.Values[i].m_objectStateMap
                IntPtr map = (IntPtr)BitConverter.ToUInt64(groupData, 8);
                //.Values[i].m_objectStateMap.Count
                int mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsObjectType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_objectStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            if (uberState.Type == UberStateType.SavePedestalUberState) {
                                uberState.Value.Byte = Program.Read<byte>((IntPtr)BitConverter.ToUInt64(data, 0x10 + (j * 0x18)), 0x11);
                            } else {
                                //playerUberStateDescriptor
                            }
                        }
                    }
                }

                //.Values[i].m_boolStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 16);
                //.Values[i].m_boolStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsBoolType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_boolStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            uberState.Value.Bool = data[0x10 + (j * 0x18)] != 0;
                        }
                    }
                }

                //.Values[i].m_floatStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 24);
                //.Values[i].m_floatStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsFloatType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_floatStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            uberState.Value.Float = BitConverter.ToSingle(data, 0x10 + (j * 0x18));
                        }
                    }
                }

                //.Values[i].m_intStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 32);
                //.Values[i].m_intStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsIntType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_intStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            uberState.Value.Int = BitConverter.ToInt32(data, 0x10 + (j * 0x18));
                        }
                    }
                }

                //.Values[i].m_byteStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 40);
                //.Values[i].m_byteStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsByteType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_byteStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            uberState.Value.Byte = data[0x10 + (j * 0x18)];
                        }
                    }
                }
            }
        }

        public void SetUberState(UberState uberState = null) {
            //UbserStateController.m_currentStateValueStore.m_groupMap
            IntPtr groups = UberStateController.Read<IntPtr>(Program, 0xb8, 0x40, 0x18);
            //.Count
            int groupCount = Program.Read<int>(groups, 0x20);
            //.Values
            groups = Program.Read<IntPtr>(groups, 0x18);
            byte[] groupsData = Program.Read(groups + 0x20, groupCount * 0x18);

            bool updateAll = uberState == null;
            for (int i = 0; i < groupCount; i++) {
                //.Values[i].m_id.m_id
                IntPtr group = (IntPtr)BitConverter.ToUInt64(groupsData, 0x10 + (i * 0x18));
                byte[] groupData = Program.Read(group + 0x18, 48);
                long groupID = Program.Read<int>((IntPtr)BitConverter.ToUInt64(groupData, 0), 0x10);

                if (!updateAll && groupID != uberState.GroupID) { continue; }

                //.Values[i].m_objectStateMap
                IntPtr map = (IntPtr)BitConverter.ToUInt64(groupData, 8);
                //.Values[i].m_objectStateMap.Count
                int mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsObjectType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_objectStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            if (uberState.Type == UberStateType.SavePedestalUberState) {
                                uberState.Value.Byte = Program.Read<byte>((IntPtr)BitConverter.ToUInt64(data, 0x10 + (j * 0x18)), 0x11);
                            } else {
                                //playerUberStateDescriptor
                            }
                        }
                    }
                }

                //.Values[i].m_boolStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 16);
                //.Values[i].m_boolStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsBoolType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_boolStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            Program.Write(map + 0x20, uberState.Value, 0x10 + (j * 0x18));
                            uberState.Value.Bool = data[0x10 + (j * 0x18)] != 0;
                        }
                    }
                }

                //.Values[i].m_floatStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 24);
                //.Values[i].m_floatStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsFloatType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_floatStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            Program.Write(map + 0x20, uberState.Value, 0x10 + (j * 0x18));
                            uberState.Value.Float = BitConverter.ToSingle(data, 0x10 + (j * 0x18));
                        }
                    }
                }

                //.Values[i].m_intStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 32);
                //.Values[i].m_intStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsIntType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_intStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);
                        //Program.Write(map + 0x20, uberState.Value, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            Program.Write(map + 0x20, uberState.Value, 0x10 + (j * 0x18));
                            uberState.Value.Int = BitConverter.ToInt32(data, 0x10 + (j * 0x18));
                        }
                    }
                }

                //.Values[i].m_byteStateMap
                map = (IntPtr)BitConverter.ToUInt64(groupData, 40);
                //.Values[i].m_byteStateMap.Count
                mapCount = Program.Read<int>(map, 0x20);
                if (mapCount > 0 && (updateAll || uberState.IsByteType)) {
                    map = Program.Read<IntPtr>(map, 0x18);
                    byte[] data = Program.Read(map + 0x20, mapCount * 0x18);
                    for (int j = 0; j < mapCount; j++) {
                        //.Values[i].m_byteStateMap.Keys[j]
                        long id = BitConverter.ToInt32(data, j * 0x18);

                        if (!updateAll && id != uberState.ID) { continue; }

                        if (!updateAll || uberIDLookup.TryGetValue((groupID << 32) | id, out uberState)) {
                            Program.Write(map + 0x20, uberState.Value, 0x10 + (j * 0x18));
                            uberState.Value.Byte = data[0x10 + (j * 0x18)];
                        }
                    }
                }
            }
        }

        public bool HasAbility(AbilityType type) {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Abilities.m_abilitiesList
            int playerUberState = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            IntPtr abilities = PlayerUberStateGroup.Read<IntPtr>(Program, 0xb8, 0x0, playerUberState, 0x30, 0x10, 0x18);
            //.Count
            int count = Program.Read<int>(abilities, 0x18);
            //.Items
            abilities = Program.Read<IntPtr>(abilities, 0x10);
            byte[] data = Program.Read(abilities + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                //.Items[i]
                Ability ability = Program.Read<Ability>((IntPtr)BitConverter.ToUInt64(data, i * 0x8), 0x10);
                if (ability.Type == type) {
                    return ability.HasAbility == 1;
                }
            }
            return false;
        }
        public Dictionary<AbilityType, Ability> PlayerAbilities() {
            Dictionary<AbilityType, Ability> currentAbilities = new Dictionary<AbilityType, Ability>();
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Abilities.m_abilitiesList
            int playerUberState = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            IntPtr abilities = PlayerUberStateGroup.Read<IntPtr>(Program, 0xb8, 0x0, playerUberState, 0x30, 0x10, 0x18);
            //.Count
            int count = Program.Read<int>(abilities, 0x18);
            //.Items
            abilities = Program.Read<IntPtr>(abilities, 0x10);
            byte[] data = Program.Read(abilities + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                //.Items[i]
                Ability ability = Program.Read<Ability>((IntPtr)BitConverter.ToUInt64(data, i * 0x8), 0x10);
                if (Enum.IsDefined(typeof(AbilityType), ability.Type)) {
                    currentAbilities[ability.Type] = ability;
                }
            }
            return currentAbilities;
        }
        public bool HasShard(ShardType type, int level) {
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Shards.m_shardsList
            int playerUberState = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            IntPtr shards = PlayerUberStateGroup.Read<IntPtr>(Program, 0xb8, 0x0, playerUberState, 0x30, 0x20, 0x18);
            //.Count
            int count = Program.Read<int>(shards, 0x18);
            //.Items
            shards = Program.Read<IntPtr>(shards, 0x10);
            byte[] data = Program.Read(shards + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                //.Items[i]
                Shard shard = Program.Read<Shard>((IntPtr)BitConverter.ToUInt64(data, i * 0x8), 0x10);
                if (shard.Type == type) {
                    return shard.Gained == 1 && (level == 0 || shard.Level == level);
                }
            }
            return false;
        }
        public Dictionary<ShardType, Shard> PlayerShards() {
            Dictionary<ShardType, Shard> currentShards = new Dictionary<ShardType, Shard>();
            //PlayerUberStateGroup.Instance.PlayerUberState.m_state.Shards.m_shardsList
            int playerUberState = Version <= PointerVersion.P2 ? 0x18 : 0x30;
            IntPtr shards = PlayerUberStateGroup.Read<IntPtr>(Program, 0xb8, 0x0, playerUberState, 0x30, 0x20, 0x18);
            //.Count
            int count = Program.Read<int>(shards, 0x18);
            //.Items
            shards = Program.Read<IntPtr>(shards, 0x10);
            byte[] data = Program.Read(shards + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                //.Items[i]
                Shard shard = Program.Read<Shard>((IntPtr)BitConverter.ToUInt64(data, i * 0x8), 0x10);
                if (Enum.IsDefined(typeof(ShardType), shard.Type)) {
                    currentShards[shard.Type] = shard;
                }
            }
            return currentShards;
        }
        public SeinEnergy ReadEnergy() {
            SeinCharacterPtr sein = GetSeinPtr();
            return MemoryReader.Read<SeinEnergy>(Program, sein.Energy);
        }

        public SeinHealthControllerPtr ReadHealth() {
            SeinCharacterPtr sein = GetSeinPtr();
            SeinMortalityPtr Mortality = MemoryReader.Read<SeinMortalityPtr>(Program, sein.Mortality);
            return MemoryReader.Read<SeinHealthControllerPtr>(Program, Mortality.Health);
        }

        public SeinCharacterPtr GetSeinPtr() {
            switch (Version) {
                case PointerVersion.P1: return new SeinCharacterPtr(MemoryReader.Read<SeinCharacterPtrV1V2>(Program, GameAssembly.BaseAddress, 0x441DCA0, 0xb8, 0x0 + 0x10));
                case PointerVersion.P2: return new SeinCharacterPtr(MemoryReader.Read<SeinCharacterPtrV1V2>(Program, GameAssembly.BaseAddress, 0x441DCA0, 0xb8, 0x0 + 0x10));
                case PointerVersion.P3: return new SeinCharacterPtr(MemoryReader.Read<SeinCharacterPtrV3V4>(Program, GameAssembly.BaseAddress, 0x047340C0, 0xb8, 0x0 + 0x10, 0x0));
                case PointerVersion.P4: return new SeinCharacterPtr(MemoryReader.Read<SeinCharacterPtrV3V4>(Program, GameAssembly.BaseAddress, 0x047340C0, 0xb8, 0x0 + 0x10, 0x0));
            }
            return new SeinCharacterPtr();
        }

        public CompoundButtonInput GetButtons(IntPtr ptr) {
            CompoundButtonInput buttons = new CompoundButtonInput();

            int count = MemoryReader.Read<int>(Program, ptr, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                int keyCode = Program.Read<int>((IntPtr)BitConverter.ToUInt64(data, i * 0x8), 0x10);
                buttons.Buttons.Add(keyCode.ToString());
            }

            return buttons;
        }

        public void ReadPlayerInputs(ref PlayerInput playerInput) {
            PlayerInputPtr playerInputPtr = MemoryReader.Read<PlayerInputPtr>(Program, GameAssembly.BaseAddress, 0x04750E20, 0xb8, 0x0, 0x0);
            int count = MemoryReader.Read<int>(Program, playerInputPtr.m_inputProcessorsPairs, 0x18, 0x18) * 3;
            IntPtr ptr = MemoryReader.Read<IntPtr>(Program, playerInputPtr.m_inputProcessorsPairs, 0x18);
            List<IntPtr> buttonInputs = new List<IntPtr>();
            List<int> buttonInputsIndex = new List<int>();

            CompoundButtonInputPtr test;
            string name;
            IntPtr ptrC1;
            IntPtr ptrC2;
            for (int i = 0; i < count; i += 3) {
                ptrC1 = Program.Read<IntPtr>(ptr + 0x20 + ((i + 1) * 0x8));
                name = PlayerInput.ReturnKey(ptrC1, playerInputPtr);
                test = Program.Read<CompoundButtonInputPtr>(ptrC1);

                CompoundButtonInput but = new CompoundButtonInput();
                but.m_lastPressedIndex = test.m_lastPressedIndex;
                but.BindName = name;

                int sizeC2 = MemoryReader.Read<int>(Program, test.Buttons, 0x18);
                ptrC2 = MemoryReader.Read<IntPtr>(Program, test.Buttons, 0x10);
                for (int i2 = 0; i2 < sizeC2; i2++) {
                    int keyCode = MemoryReader.Read<int>(Program, ptrC2, 0x20 + i2 * 0x8, 0x18);
                    if (i2 >= 4 && PlayerInput.ControllerCodeMap.ContainsKey(keyCode) == true) { //is always controller input
                        but.Buttons.Add(PlayerInput.ControllerCodeMap[keyCode]);
                    } else {
                        if (PlayerInput.ControllerCodeMap.ContainsKey(keyCode) == true || PlayerInput.UnityKeyCodeMap.ContainsKey(keyCode) == false && PlayerInput.ControllerInputNames.IndexOf(name) != -1) {
                            but.Buttons.Add(PlayerInput.ControllerCodeMap[keyCode]);
                        } else if (PlayerInput.UnityKeyCodeMap.ContainsKey(keyCode) == true) {
                            but.Buttons.Add(PlayerInput.UnityKeyCodeMap[keyCode]);
                        } else {
                            IntPtr ptrC3 = Program.Read<IntPtr>(ptrC2 + 0x20 + i2 * 0x8);
                            AxisButtonInput axis = Program.Read<AxisButtonInput>(ptrC3);
                            int iAxis = Program.Read<int>(axis.m_axis, 0x18);

                            if (axis.m_comparisonValue == 0.5f) {
                                if (iAxis == 5) {
                                    but.Buttons.Add("JoypadDpadUp");
                                } else if (iAxis == 1) {
                                    but.Buttons.Add("JoypadLeftStickUp");
                                } else if (iAxis == 4) {
                                    but.Buttons.Add("JoypadDpadRight");
                                } else if (iAxis == 0) {
                                    but.Buttons.Add("JoypadLeftStickRight");
                                }
                            } else if (axis.m_comparisonValue == -0.5f) {
                                if (iAxis == 5) {
                                    but.Buttons.Add("JoypadDpadDown");
                                } else if (iAxis == 1) {
                                    but.Buttons.Add("JoypadLeftStickDown");
                                } else if (iAxis == 4) {
                                    but.Buttons.Add("JoypadDpadLeft");
                                } else if (iAxis == 0) {
                                    but.Buttons.Add("JoypadLeftStickLeft");
                                }
                            } else {
                                but.Buttons.Add(keyCode.ToString());
                            }
                        }
                    }
                }
                if (playerInput.SeinButtons.ContainsKey(name)) {
                    playerInput.SeinButtons[name] = but;
                } else {
                    playerInput.SeinButtons.Add(name, but);
                }

                //get input state
                if (playerInput.SeinInputs.Count > 0) {
                    InputButtonProcessor input = MemoryReader.Read<InputButtonProcessor>(Program, MemoryReader.Read<IntPtr>(Program, ptr + 0x20 + ((i + 2) * 0x8)));
                    IntPtr buttonPtr = Program.Read<IntPtr>(ptr + 0x20 + ((i + 1) * 0x8), 0x0);
                    playerInput.UpdateInput(buttonPtr, input);
                }

                if (playerInput.SeinInputs.Count == 0) {
                    IntPtr buttonPtr = Program.Read<IntPtr>(ptr + 0x20 + ((i + 1) * 0x8), 0x0);
                    buttonInputs.Add(buttonPtr);
                    buttonInputsIndex.Add(i + 1);
                }
            }

            if (playerInput.SeinInputs.Count == 0)
                playerInput.SetInputMap(buttonInputs, buttonInputsIndex, ref playerInputPtr);

            SeinCharacterPtr seinCharacterPtr = GetSeinPtr();
            SeinInputPtr seinInputPtr = MemoryReader.Read<SeinInputPtr>(Program, seinCharacterPtr.Input);
            InputButtonProcessor down = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Down);
            InputButtonProcessor left = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Left);
            InputButtonProcessor right = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Right);
            InputButtonProcessor up = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Up);
            float axisY1 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x28); //Core.Input
            float axisX1 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x2C); //Core.Input
            float axisY2 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x20); //Core.Input
            float axisX2 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x24); //Core.Input
            int dPadDirectionY = MemoryReader.Read<int>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x10); //Core.Input
            int dPadDirectionX = MemoryReader.Read<int>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x14); //Core.Input
            int dPadDirectionY2 = MemoryReader.Read<int>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x18); //Core.Input
            int dPadDirectionX2 = MemoryReader.Read<int>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x1C); //Core.Input
            float axisY3 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x20); //Core.Input
            float axisX3 = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x24); //Core.Input
            float axis2Y = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x28); //Core.Input
            float axis2X = MemoryReader.Read<float>(Program, GameAssembly.BaseAddress, 0x0474D8E0, 0xb8, 0x2C); //Core.Input

            playerInput.AxisInputs.Axis1.UpdateAxis(axisX1, axisY1);
            playerInput.AxisInputs.Axis2.UpdateAxis(axisX2, axisY2);
            playerInput.AxisInputs.Axis3.UpdateAxis(axisX3, axisY3);
            playerInput.AxisInputs.Axis4.UpdateAxis(axis2X, axis2Y);
            playerInput.AxisInputs.DPadDirection1.UpdateAxis(dPadDirectionX, dPadDirectionY);
            playerInput.AxisInputs.DPadDirection2.UpdateAxis(dPadDirectionX2, dPadDirectionY2);

            playerInput.UpdateDirection(0, down);
            playerInput.UpdateDirection(1, left);
            playerInput.UpdateDirection(2, right);
            playerInput.UpdateDirection(3, up);

            CompoundAxisInputPtr leftAxis = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.LeftTriggerAxis);
            CompoundAxisInputPtr rightAxis = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.RightTriggerAxis);
            CompoundAxisInputPtr hPad = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.HorizontalDigiPad);
            CompoundAxisInputPtr vPad = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.VerticalDigiPad);
            CompoundAxisInputPtr hALeft = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.HorizontalAnalogLeft);
            CompoundAxisInputPtr hARight = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.HorizontalAnalogRight);
            CompoundAxisInputPtr vALeft = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.VerticalAnalogLeft);
            CompoundAxisInputPtr vARight = MemoryReader.Read<CompoundAxisInputPtr>(Program, playerInputPtr.VerticalAnalogRight);

            playerInput.PlayerAxis.Clear();
            playerInput.PlayerAxis.AddRange(new List<CompoundAxisInputPtr> { leftAxis, rightAxis, hPad, vPad, hALeft, hARight, vALeft, vARight });
            playerInput.m_lastPressedAxisInput = playerInputPtr.m_lastPressedAxisInput;
        }

        public List<CompoundButtonInput> GenerateBindingsMap() {
            PlayerInputPtr playerInputPtr = MemoryReader.Read<PlayerInputPtr>(Program, GameAssembly.BaseAddress, 0x04750E20, 0xb8, 0x0, 0x0);
            Type myType = typeof(PlayerInputPtr);
            _FieldInfo[] fields = myType.GetFields();
            List<CompoundButtonInput> allBinds = new List<CompoundButtonInput>();

            foreach (_FieldInfo field in fields) {
                string fieldName = field.Name;
                CompoundButtonInput compoundButtonInput = new CompoundButtonInput();

                if (fieldName != "m_lastPressedAxisInput" && fieldName != "m_lastPressedButtonInput" && fieldName != "m_allAxisInput" && fieldName != "m_inputProcessorsPairs") {
                    IntPtr ptr = (IntPtr)field.GetValue(playerInputPtr);
                    compoundButtonInput.BindName = PlayerInput.ReturnKey(ptr, playerInputPtr);

                    int sizeC2 = MemoryReader.Read<int>(Program, ptr, 0x18, 0x18);
                    IntPtr ptrC2 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18, 0x10);
                    for (int i2 = 0; i2 < sizeC2; i2++) {
                        int keyCode = MemoryReader.Read<int>(Program, ptrC2, 0x20 + i2 * 0x8, 0x18);

                        if (i2 >= 4 && PlayerInput.ControllerCodeMap.ContainsKey(keyCode) == true) { //is always controller input
                            compoundButtonInput.Buttons.Add(PlayerInput.ControllerCodeMap[keyCode]);
                        } else {
                            if (PlayerInput.ControllerCodeMap.ContainsKey(keyCode) == true || PlayerInput.UnityKeyCodeMap.ContainsKey(keyCode) == false && PlayerInput.ControllerInputNames.IndexOf(compoundButtonInput.BindName) != -1) {
                                compoundButtonInput.Buttons.Add(PlayerInput.ControllerCodeMap[keyCode]);
                            } else if (PlayerInput.UnityKeyCodeMap.ContainsKey(keyCode) == true) {
                                compoundButtonInput.Buttons.Add(PlayerInput.UnityKeyCodeMap[keyCode]);
                            } else {
                                compoundButtonInput.Buttons.Add(keyCode.ToString());
                            }
                        }
                    }
                    allBinds.Add(compoundButtonInput);
                }
            }

            return allBinds;
        }

        public SeinCharacter ReadCharacter() {
            SeinCharacterPtr seinCharacterPtr = GetSeinPtr();
            SeinAbilitiesPtr seinAbilitiesPtr = MemoryReader.Read<SeinAbilitiesPtr>(Program, seinCharacterPtr.Abilities);
            CharacterStateWrapper tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.DoubleJumpWrapper);
            SeinDoubleJump djump = MemoryReader.Read<SeinDoubleJump>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.JumpWrapper);
            SeinJump jump = MemoryReader.Read<SeinJump>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.WallSlideWrapper);
            SeinWallSlide wallSlide = MemoryReader.Read<SeinWallSlide>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.DashNewWrapper);
            SeinDashNew dash = MemoryReader.Read<SeinDashNew>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.BashWrapper);
            SeinBashPtr bashPtr = MemoryReader.Read<SeinBashPtr>(Program, tTemp.State);
            SeinTarget seinTarget = MemoryReader.Read<SeinTarget>(Program, bashPtr.Target);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.LeashWrapper);
            SeinSpiritLeashAbilityPtr leash = MemoryReader.Read<SeinSpiritLeashAbilityPtr>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.GrenadeWrapper);
            SeinGrenadePtr seinGrenadePtr = MemoryReader.Read<SeinGrenadePtr>(Program, tTemp.State);

            tTemp = MemoryReader.Read<CharacterStateWrapper>(Program, seinAbilitiesPtr.StandingOnEdgeWrapper);
            SeinStandingOnEdgePtr seinStandingOnEdgePtr = MemoryReader.Read<SeinStandingOnEdgePtr>(Program, tTemp.State);


            PlatformBehaviourPtr platformBehaviourPtr = MemoryReader.Read<PlatformBehaviourPtr>(Program, seinCharacterPtr.PlatformBehaviour);
            SeinPlatformMovementPtr seinPlatformMovementPtr = MemoryReader.Read<SeinPlatformMovementPtr>(Program, platformBehaviourPtr.PlatformMovement);
            IsOnCollisionState ceiling = MemoryReader.Read<IsOnCollisionState>(Program, seinPlatformMovementPtr.Ceiling);
            IsOnCollisionState ground = MemoryReader.Read<IsOnCollisionState>(Program, seinPlatformMovementPtr.Ground);
            IsOnCollisionState wallLeft = MemoryReader.Read<IsOnCollisionState>(Program, seinPlatformMovementPtr.WallLeft);
            IsOnCollisionState wallRight = MemoryReader.Read<IsOnCollisionState>(Program, seinPlatformMovementPtr.WallRight);


            CharacterAirNoDecelerationPtr airNoDecelerationPtr = MemoryReader.Read<CharacterAirNoDecelerationPtr>(Program, platformBehaviourPtr.AirNoDeceleration);
            CharacterApplyFrictionToSpeedPtr applyFrictionToSpeedPtr = MemoryReader.Read<CharacterApplyFrictionToSpeedPtr>(Program, platformBehaviourPtr.ApplyFrictionToSpeed);


            CharacterVisuals visuals = MemoryReader.Read<CharacterVisuals>(Program, platformBehaviourPtr.Visuals);
            SeinSpriteRotationController spriteRotater = MemoryReader.Read<SeinSpriteRotationController>(Program, visuals.SpriteRotater);


            SeinInputPtr seinInputPtr = MemoryReader.Read<SeinInputPtr>(Program, seinCharacterPtr.Input);
            InputButtonProcessor down = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Down);
            InputButtonProcessor left = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Left);
            InputButtonProcessor right = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Right);
            InputButtonProcessor up = MemoryReader.Read<InputButtonProcessor>(Program, seinInputPtr.Up);


            SeinControllerPtr seinControllerPtr = MemoryReader.Read<SeinControllerPtr>(Program, seinCharacterPtr.Controller);


            GameWorld.GameWorldPtr gameWorld = MemoryReader.Read<GameWorld.GameWorldPtr>(Program, GameAssembly.BaseAddress, 0x04783850, 0xb8, 0x0);
            GameWorld.PlayerStats playerStats = MemoryReader.Read<GameWorld.PlayerStats>(Program, gameWorld.PlayerStats);
            GameWorld.m_state m_state = MemoryReader.Read<GameWorld.m_state>(Program, playerStats.m_state);
            GameWorld.Stats stats = MemoryReader.Read<GameWorld.Stats>(Program, m_state.Stats);


            SeinCharacter seinCharacter = new SeinCharacter();
            SeinAbilities seinAbilities = new SeinAbilities();
            seinAbilities.DoubleJumpWrapper = djump;
            seinAbilities.JumpWrapper = jump;
            seinAbilities.DashNewWrapper = dash;
            seinAbilities.WallSlideWrapper = wallSlide;
            seinAbilities.GrenadeWrapper = seinGrenadePtr;
            seinAbilities.StandingOnEdgeWrapper = seinStandingOnEdgePtr;
            seinCharacter.Stats = stats;

            SeinBash bash = new SeinBash();
            if ((long)bashPtr.Target != 0) {
                bash.TargetFound = true;
            }
            bash.Target = seinTarget;
            bash.IsBashing = bashPtr.IsBashing;
            seinAbilities.BashWrapper = bash;
            seinAbilities.LeashWrapper = leash;
            seinCharacter.Abilities = seinAbilities;

            SeinPlatformBehaviour seinPlatformBehaviour = new SeinPlatformBehaviour();
            seinCharacter.SeinPlatformBehaviour = seinPlatformBehaviour;

            AirNoDeceleration airNoDeceleration = new AirNoDeceleration();
            seinCharacter.SeinPlatformBehaviour.AirNoDeceleration = airNoDeceleration;
            seinCharacter.SeinPlatformBehaviour.AirNoDeceleration.m_noDeceleration = airNoDecelerationPtr.m_noDeceleration;

            ApplyFrictionToSpeed applyFrictionToSpeed = new ApplyFrictionToSpeed();
            seinCharacter.SeinPlatformBehaviour.ApplyFrictionToSpeed = applyFrictionToSpeed;
            seinCharacter.SeinPlatformBehaviour.ApplyFrictionToSpeed.SpeedFactor = applyFrictionToSpeedPtr.SpeedFactor;

            SeinPlatformMovement seinPlatformMovement = new SeinPlatformMovement();
            seinPlatformMovement.Ceiling = ceiling;
            seinPlatformMovement.Ground = ground;
            seinPlatformMovement.WallLeft = wallLeft;
            seinPlatformMovement.WallRight = wallRight;
            seinPlatformMovement.GroundNormal = seinPlatformMovementPtr.GroundNormal;
            seinPlatformMovement.CeilingNormal = seinPlatformMovementPtr.CeilingNormal;
            seinPlatformMovement.WallLeftNormal = seinPlatformMovementPtr.WallLeftNormal;
            seinPlatformMovement.WallRightNormal = seinPlatformMovementPtr.WallRightNormal;
            seinPlatformMovement.m_localSpeed = seinPlatformMovementPtr.m_localSpeed;
            seinPlatformMovement.HeadAgainstWall = seinPlatformMovementPtr.HeadAgainstWall;
            seinPlatformMovement.FeetAgainstWall = seinPlatformMovementPtr.FeetAgainstWall;
            seinPlatformMovement.HeadWallNormal = seinPlatformMovementPtr.HeadWallNormal;
            seinPlatformMovement.FeetWallNormal = seinPlatformMovementPtr.FeetWallNormal;
            seinPlatformMovement.GroundRayNormal = seinPlatformMovementPtr.GroundRayNormal;
            seinPlatformMovement.m_climblableWallTimer = seinPlatformMovementPtr.m_climblableWallTimer;
            seinPlatformMovement.AdditiveLocalSpeed = seinPlatformMovementPtr.AdditiveLocalSpeed;
            seinPlatformMovement.m_wallLeftAngle = spriteRotater.m_wallLeftAngle;
            seinPlatformMovement.m_wallRightAngle = spriteRotater.m_wallRightAngle;
            seinCharacter.SeinPlatformBehaviour.SeinPlatformMovement = seinPlatformMovement;

            SeinInput seinInput = new SeinInput();
            seinInput.Down = down;
            seinInput.Left = left;
            seinInput.Right = right;
            seinInput.Up = up;

            seinCharacter.Input = seinInput;

            PlayerAbilitiesPtr playerAbilitiesPtr = MemoryReader.Read<PlayerAbilitiesPtr>(Program, seinCharacterPtr.PlayerAbilities);
            StateDescriptorPtr stateDescriptorPtr = MemoryReader.Read<StateDescriptorPtr>(Program, playerAbilitiesPtr.StateDescriptor);
            m_statePtr m_StatePtr = MemoryReader.Read<m_statePtr>(Program, stateDescriptorPtr.m_state);
            Inventory inventory = MemoryReader.Read<Inventory>(Program, m_StatePtr.Inventory);

            SeinInventory seinInventory = new SeinInventory();
            seinInventory.Keystones = inventory.m_keystones;
            seinInventory.Mapstones = inventory.m_mapStones;
            seinInventory.Ore = inventory.m_ore;
            seinInventory.SpiritLight = inventory.m_experience;
            seinCharacter.SeinInventory = seinInventory;

            int count = MemoryReader.Read<int>(Program, inventory.m_bindings, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, inventory.m_bindings, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                InventoryItemPtr inventoryItem = Program.Read<InventoryItemPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                InventoryItem item = new InventoryItem();

                string abilityName = "";
                if (seinCharacter.PlayerAbilities.TypeToAbilityName.ContainsKey(inventoryItem.m_type) == true) {
                    abilityName = seinCharacter.PlayerAbilities.TypeToAbilityName[inventoryItem.m_type];
                } else {
                    abilityName = inventoryItem.m_type.ToString();
                }

                item.Name = abilityName;
                item.Inventory = inventoryItem;

                if (seinCharacter.PlayerAbilities.AbilityBindings.ContainsKey(abilityName) == false) {
                    seinCharacter.PlayerAbilities.AbilityBindings.Add(abilityName, item);
                    if (seinCharacter.PlayerAbilities.AbilityList.Count <= i) {
                        seinCharacter.PlayerAbilities.AbilityList.Add(item);
                    } else {
                        seinCharacter.PlayerAbilities.AbilityList[i] = item;
                    }
                }
            }

            count = MemoryReader.Read<int>(Program, inventory.m_inventory, 0x10, 0x18);
            ptr1 = MemoryReader.Read<IntPtr>(Program, inventory.m_inventory, 0x10);
            data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                InventoryItemPtr inventoryItem = Program.Read<InventoryItemPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                InventoryItem item = new InventoryItem();

                string abilityName = "";
                if (seinCharacter.PlayerAbilities.TypeToAbilityName.ContainsKey(inventoryItem.m_type) == true) {
                    abilityName = seinCharacter.PlayerAbilities.TypeToAbilityName[inventoryItem.m_type];
                } else {
                    abilityName = inventoryItem.m_type.ToString();
                }

                item.Name = abilityName;
                item.Inventory = inventoryItem;

                if (seinCharacter.PlayerAbilities.Inventory.ContainsKey(inventoryItem.m_type) == false) {
                    seinCharacter.PlayerAbilities.Inventory.Add(inventoryItem.m_type, item);
                }
            }

            seinCharacter.SeinController = seinControllerPtr;

            return seinCharacter;
        }

        public GameWorld.GameWorld GetGameCompletionByArea() {
            GameWorld.GameWorld gameWorld = new GameWorld.GameWorld();
            GameWorld.GameWorldPtr gameWorldPtr = MemoryReader.Read<GameWorld.GameWorldPtr>(Program, GameAssembly.BaseAddress, 0x04783850, 0xb8, 0x0);
            List<RuntimeArea> runtimeAreas = new List<RuntimeArea>();

            int count = MemoryReader.Read<int>(Program, gameWorldPtr.RuntimeAreas, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, gameWorldPtr.RuntimeAreas, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                RuntimeGameWorldAreaPtr runtimeAreaPtr = Program.Read<RuntimeGameWorldAreaPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                GameWorldAreaPtr gameWorldAreaPtr = MemoryReader.Read<GameWorldAreaPtr>(Program, runtimeAreaPtr.Area);
                RuntimeArea runtimeArea = new RuntimeArea();
                runtimeArea.m_collectablesCompletionAmount = runtimeAreaPtr.m_collectablesCompletionAmount;
                runtimeArea.m_completionAmount = runtimeAreaPtr.m_completionAmount;
                runtimeArea.m_dirtyCompletionAmount = runtimeAreaPtr.m_dirtyCompletionAmount;
                runtimeArea.Name = GetGameWorldArea(gameWorldAreaPtr).AreaNameString;
                runtimeArea.WorldMapIcons = GetCollectibleIcons(gameWorldAreaPtr.Icons);

                gameWorld.RuntimeAreas.Add(runtimeArea.Name, runtimeArea);
            }

            return gameWorld;
        }

        public List<WorldMapIcon> GetCollectibleIcons(IntPtr ptr) {
            List<WorldMapIcon> collectibleIcons = new List<WorldMapIcon>();

            int count = MemoryReader.Read<int>(Program, ptr, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                WorldMapIconPtr worldMapIconPtr = Program.Read<WorldMapIconPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));

                WorldMapIcon worldMapIcon = new WorldMapIcon();
                worldMapIcon.Icon = worldMapIconPtr.Icon;
                worldMapIcon.Position = worldMapIconPtr.Position;

                if (worldMapIconPtr.IsCollectedState != IntPtr.Zero) {
                    State isCollectedState = MemoryReader.Read<State>(Program, worldMapIconPtr.IsCollectedState);
                    worldMapIcon.IsCollected = isCollectedState.m_value;

                    if (OriWotW.GameWorld.GameWorld.WorldMapIconType.Count > worldMapIconPtr.Icon) {
                        worldMapIcon.IconType = OriWotW.GameWorld.GameWorld.WorldMapIconType[worldMapIconPtr.Icon];
                    } else {
                        worldMapIcon.IconType = "Invisible";
                    }
                }

                collectibleIcons.Add(worldMapIcon);
            }

            return collectibleIcons;
        }

        /*public RuntimeArea GetRuntimeArea(IntPtr ptr) {
            ZoneScalingDataPtr zoneScalingDataPtr = MemoryReader.Read<ZoneScalingDataPtr>(Program, ptr.);
        }*/

        public List<GameWorldArea> GetGameWorldAreas() {
            List<GameWorldArea> areas = new List<GameWorldArea>();
            GameWorld.GameWorldPtr gameWorld = MemoryReader.Read<GameWorld.GameWorldPtr>(Program, GameAssembly.BaseAddress, 0x04783850, 0xb8, 0x0);  //GameWorld

            int count = MemoryReader.Read<int>(Program, gameWorld.Areas, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, gameWorld.Areas, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                GameWorldAreaPtr gameWorldAreaPtr = Program.Read<GameWorldAreaPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                areas.Add(GetGameWorldArea(gameWorldAreaPtr));
            }

            return areas;
        }

        public GameWorldArea GetGameWorldArea(GameWorldAreaPtr gameWorldAreaPtr) {
            GameWorldArea newArea = new GameWorldArea();
            newArea.AreaNameString = MemoryReader.ReadString(Program, gameWorldAreaPtr.AreaNameString);

            ZoneScalingDataPtr zoneScalingDataPtr = MemoryReader.Read<ZoneScalingDataPtr>(Program, gameWorldAreaPtr.ZoneScalingData);
            ZoneScalingData zoneData = new ZoneScalingData();
            zoneData.CreepWallHealth = zoneScalingDataPtr.CreepWallHealth;
            zoneData.DamageColliderDamage = zoneScalingDataPtr.DamageColliderDamage;
            zoneData.DefaultZoneDifficulty = zoneScalingDataPtr.DefaultZoneDifficulty;
            zoneData.DestructableWallHealth = zoneScalingDataPtr.DestructableWallHealth;
            zoneData.RedirectWallHealth = zoneScalingDataPtr.RedirectWallHealth;
            zoneData.WaterDamage = zoneScalingDataPtr.WaterDamage;
            zoneData.Enemies = GetEntityScaling(zoneScalingDataPtr.Enemies);

            newArea.ZoneScalingData = zoneData;
            return newArea;
        }

        public List<EntityScalingData> GetEntityScaling(IntPtr ptr) {
            List<EntityScalingData> entityList = new List<EntityScalingData>();

            int count = MemoryReader.Read<int>(Program, ptr, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x10);
            byte[] data = Program.Read(ptr + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                EntityScalingData newEntity = new EntityScalingData();
                EntityScalingDataPtr entityScalingDataPtr = Program.Read<EntityScalingDataPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));

                newEntity.Name = MemoryReader.ReadString(Program, entityScalingDataPtr.Name);
                newEntity.BaseHealth = entityScalingDataPtr.BaseHealth;
                newEntity.Category = entityScalingDataPtr.Category;
                newEntity.EnergyLootChance = entityScalingDataPtr.EnergyLootChance;
                newEntity.HeartLootChance = entityScalingDataPtr.HeartLootChance;
                newEntity.NumberOfExperienceOrbs = entityScalingDataPtr.NumberOfExperienceOrbs;
                IntPtr scalingPtr = MemoryReader.Read<IntPtr>(Program, entityScalingDataPtr.Scaling, 0x10);
                newEntity.Scaling = GetEntityDifficultyScalingData(scalingPtr);

                entityList.Add(newEntity);
            }
            return entityList;
        }

        public List<EntityDifficultyScalingData> GetEntityDifficultyScalingData(IntPtr ptr) {
            List<EntityDifficultyScalingData> entityScalingData = new List<EntityDifficultyScalingData>();

            int count = MemoryReader.Read<int>(Program, ptr, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x20);
            byte[] data = Program.Read(ptr + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                EntityDifficultyScalingData entityScalingDataPtr = Program.Read<EntityDifficultyScalingData>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                entityScalingData.Add(entityScalingDataPtr);
            }

            return entityScalingData;
        }

        public WeaponMasterScreen GetWeaponMasterScreen() {
            WeaponMasterScreenPtr weaponMasterScreenPtr = MemoryReader.Read<WeaponMasterScreenPtr>(Program, GameAssembly.BaseAddress, 0x0445CE00, 0x40, 0xB8, 0x0, 0x20, 0x10, 0x20, 0x0);
            WeaponMasterScreen weaponMasterScreen = new WeaponMasterScreen();

            int count = MemoryReader.Read<int>(Program, weaponMasterScreenPtr.Upgrades, 0x18);
            byte[] data = Program.Read(weaponMasterScreenPtr.Upgrades + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                UpgradeAbilityItemPtr upgradeAbilityItemPtr = Program.Read<UpgradeAbilityItemPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                UpgradeLevel upgradeLevel = MemoryReader.Read<UpgradeLevel>(Program, upgradeAbilityItemPtr.UpgradeLevel);
                UpgradeAbilityItem upgradeAbilityItem = new UpgradeAbilityItem();
                Messages messages = GetMessage(upgradeAbilityItemPtr.Name);
                upgradeAbilityItem.Name = messages.English;
                upgradeAbilityItem.HasUpgrade = upgradeLevel.HasUpgrade;
                upgradeAbilityItem.AcquiredAbilityType = upgradeAbilityItemPtr.AcquiredAbilityType;

                weaponMasterScreen.Upgrades.Add(upgradeAbilityItem);
            }

            return weaponMasterScreen;
        }

        public QuestsControllerPtr GetQuestsControllerPtr() {
            return MemoryReader.Read<QuestsControllerPtr>(Program, GameAssembly.BaseAddress, 0x0440CBA0, 0x98, 0x8, 0x68, 0x40, 0xB8, 0x0, 0x0);
        }

        public QuestsController GetQuests() {
            QuestsControllerPtr questsControllerPtr = GetQuestsControllerPtr();
            QuestsController questsController = new QuestsController();
            questsController.Quests = GetQuests(questsControllerPtr.Quests);
            questsController.RunetimeQuests = GetRunetimeQuests(questsControllerPtr.m_quests);

            return questsController;
        }

        public Dictionary<string, Quest> GetQuests(IntPtr ptr) {
            Dictionary<string, Quest> questPtrs = new Dictionary<string, Quest>();

            int count = MemoryReader.Read<int>(Program, ptr, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                QuestPtr questPtr = Program.Read<QuestPtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                m_resolvedUberState resolvedUberState = Program.Read<m_resolvedUberState>(questPtr.m_resolvedUberState);
                QuestUberGroup questUberGroup = Program.Read<QuestUberGroup>(resolvedUberState.Group);
                Quest quest = new Quest();
                quest.MoonGuid = GetMoonGuid(questPtr.MoonGuid);
                Messages name = GetMessage(questPtr.NameMessageProvider);
                quest.Name = name.English;
                Messages description = GetMessage(questPtr.DescriptionMessageProvider);
                quest.Description = description.English;
                quest.Position = questPtr.Position;
                quest.StateOffset = questPtr.StateOffset;
                quest.UberID = Program.Read<uint>(resolvedUberState.m_id, 0x10);
                quest.UberGroupID = Program.Read<uint>(questUberGroup.m_id, 0x10);

                questPtrs.Add(quest.MoonGuid.ToString(), quest);
            }

            return questPtrs;
        }

        public Dictionary<string, RunetimeQuest> GetRunetimeQuests(IntPtr ptr) {
            Dictionary<string, RunetimeQuest> runetimeQuests = new Dictionary<string, RunetimeQuest>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x18, 0x18) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                if ((i + 1) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    if (ptrC1 != IntPtr.Zero) {
                        RunetimeQuestPtr runetimeQuestPtr = Program.Read<RunetimeQuestPtr>(ptrC1);
                        RunetimeQuest runetimeQuest = new RunetimeQuest();
                        runetimeQuest.MoonGuid = GetMoonGuid(runetimeQuestPtr.MoonGuid);
                        runetimeQuest.m_state = runetimeQuestPtr.m_state;
                        runetimeQuest.m_stateOffset = runetimeQuestPtr.m_stateOffset;
                        runetimeQuest.uberState = MemoryReader.Read<m_UberState>(Program, runetimeQuestPtr.m_uberState);

                        runetimeQuests.Add(runetimeQuest.MoonGuid.ToString(), runetimeQuest);
                    }
                }
            }

            return runetimeQuests;
        }

        public void UpdateQuestState(int state, string moonGuidS) {
            QuestsControllerPtr questsControllerPtr = GetQuestsControllerPtr();
            int count = MemoryReader.Read<int>(Program, questsControllerPtr.m_quests, 0x18, 0x18) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, questsControllerPtr.m_quests, 0x18);

            for (int i = 0; i < count; i++) {
                if ((i + 1) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));

                    if (ptrC1 != IntPtr.Zero) {
                        RunetimeQuestPtr runetimeQuestPtr = Program.Read<RunetimeQuestPtr>(ptrC1);
                        MoonGuid moonGuid = GetMoonGuid(runetimeQuestPtr.MoonGuid);

                        if (moonGuidS.Equals(moonGuid.ToString()) == true) {
                            MemoryReader.Write<int>(Program, ptrC1, state, 0x20);
                        }
                    }
                }
            }
        }

        public UberStateValueStore GetUberStateValueStore() {
            return MemoryReader.Read<UberStateValueStore>(Program, GameAssembly.BaseAddress, 0x04760018, 0xb8, 0x0, 0x40);
        }

        public UberStateController GetUberStateController() {
            UberStateValueStore uberStateValueStore = GetUberStateValueStore();
            UberStateController uberController = new UberStateController();

            int count = MemoryReader.Read<int>(Program, uberStateValueStore.m_groupMap, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, uberStateValueStore.m_groupMap, 0x18);

            //byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                if ((i + 1) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    if (ptrC1 != IntPtr.Zero) {
                        UberStateValueGroup uberStateValueGroup = Program.Read<UberStateValueGroup>(ptrC1);
                        UberStateGroup uberStateGroup = new UberStateGroup();

                        uberStateGroup.ID = Program.Read<uint>(uberStateValueGroup.m_id, 0x10);
                        uberStateGroup.Name = Uber.UberStateLUT.UberGroupLUT[Convert.ToInt32(uberStateGroup.ID)];
                        uberStateGroup.BoolStates = GetUberBools(uberStateValueGroup.m_boolStateMap, Convert.ToInt32(uberStateGroup.ID));
                        uberStateGroup.ByteStates = GetUberBytes(uberStateValueGroup.m_byteStateMap, Convert.ToInt32(uberStateGroup.ID));
                        uberStateGroup.FloatStates = GetUberFloats(uberStateValueGroup.m_floatStateMap, Convert.ToInt32(uberStateGroup.ID));
                        uberStateGroup.IntStates = GetUberInts(uberStateValueGroup.m_intStateMap, Convert.ToInt32(uberStateGroup.ID));
                        uberStateGroup.PedestalStates = GetUberPedestals(uberStateValueGroup.m_objectStateMap, Convert.ToInt32(uberStateGroup.ID));

                        uberController.UberGroups.Add(uberStateGroup);
                    }
                }
            }

            return uberController;
        }

        public void SetUberState(int uberGroupIndex, int uberIndex, bool value) {
            UberStateValueStore uberStateValueStore = GetUberStateValueStore();
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, uberStateValueStore.m_groupMap, 0x18);
            IntPtr ptr2 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x20 + ((uberGroupIndex * 3) * 0x8) + 0x10);
            UberStateValueGroup uberStateValueGroup = Program.Read<UberStateValueGroup>(ptr2);
            IntPtr ptr3 = MemoryReader.Read<IntPtr>(Program, uberStateValueGroup.m_boolStateMap + 0x18);
            MemoryReader.Write<bool>(Program, ptr3 + 0x20 + ((uberIndex * 3) * 0x8) + 0x10, value);
        }

        public void SetUberState(int uberGroupIndex, int uberIndex, float value) {
            UberStateValueStore uberStateValueStore = GetUberStateValueStore();
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, uberStateValueStore.m_groupMap, 0x18);
            IntPtr ptr2 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x20 + ((uberGroupIndex * 3) * 0x8) + 0x10);
            UberStateValueGroup uberStateValueGroup = Program.Read<UberStateValueGroup>(ptr2);
            IntPtr ptr3 = MemoryReader.Read<IntPtr>(Program, uberStateValueGroup.m_floatStateMap + 0x18);
            MemoryReader.Write<float>(Program, ptr3 + 0x20 + ((uberIndex * 3) * 0x8) + 0x10, value);
        }

        public void SetUberState(int uberGroupIndex, int uberIndex, int value) {
            UberStateValueStore uberStateValueStore = GetUberStateValueStore();
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, uberStateValueStore.m_groupMap, 0x18);
            IntPtr ptr2 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x20 + ((uberGroupIndex * 3) * 0x8) + 0x10);
            UberStateValueGroup uberStateValueGroup = Program.Read<UberStateValueGroup>(ptr2);
            IntPtr ptr3 = MemoryReader.Read<IntPtr>(Program, uberStateValueGroup.m_intStateMap + 0x18);
            MemoryReader.Write<int>(Program, ptr3 + 0x20 + ((uberIndex * 3) * 0x8) + 0x10, value);
        }

        public void SetUberState(int uberGroupIndex, int uberIndex, byte value) {
            UberStateValueStore uberStateValueStore = GetUberStateValueStore();
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, uberStateValueStore.m_groupMap, 0x18);
            IntPtr ptr2 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x20 + ((uberGroupIndex * 3) * 0x8) + 0x10);
            UberStateValueGroup uberStateValueGroup = Program.Read<UberStateValueGroup>(ptr2);
            IntPtr ptr3 = MemoryReader.Read<IntPtr>(Program, uberStateValueGroup.m_byteStateMap + 0x18);
            MemoryReader.Write<byte>(Program, ptr3 + 0x20 + ((uberIndex * 3) * 0x8) + 0x10, value);
        }

        public List<UberPedestal> GetUberPedestals(IntPtr ptr, int UberGroup = 192) {
            List<UberPedestal> pedestals = new List<UberPedestal>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            uint uberId = 0;
            for (int i = 0; i < count; i++) {
                if ((i + 2) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    uberId = Program.Read<uint>(ptrC1, 0x10);
                } else if ((i + 1) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    if (ptrC1 != IntPtr.Zero) {
                        PedestalState uberStateValueGroup = Program.Read<PedestalState>(ptrC1);
                        UberPedestal pedestal = new UberPedestal();
                        pedestal.ID = uberId;
                        pedestal.Name = Uber.UberStateLUT.UberLUT[UberGroup][Convert.ToInt32(pedestal.ID)];
                        pedestal.IsTeleporterActive = uberStateValueGroup.IsTeleporterActive;
                        pedestal.HasGameBeenSaved = uberStateValueGroup.HasGameBeenSaved;

                        pedestals.Add(pedestal);
                    }
                }
            }

            return pedestals;
        }

        public List<UberBool> GetUberBools(IntPtr ptr, int UberGroup = 192) {
            List<UberBool> uberBools = new List<UberBool>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            uint uberId = 0;
            for (int i = 0; i < count; i++) {
                if ((i + 2) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    uberId = Program.Read<uint>(ptrC1, 0x10);
                } else if ((i + 1) % 3 == 0 && i != 0) {
                    UberBool uberBool = new UberBool();
                    uberBool.ID = uberId;
                    uberBool.Name = Uber.UberStateLUT.UberLUT[UberGroup][Convert.ToInt32(uberBool.ID)];
                    uberBool.Value = Program.Read<bool>(ptr1 + 0x20 + (i * 0x8));

                    uberBools.Add(uberBool);
                }
            }

            return uberBools;
        }

        public List<UberFloat> GetUberFloats(IntPtr ptr, int UberGroup = 192) {
            List<UberFloat> uberFloats = new List<UberFloat>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            uint uberId = 0;
            for (int i = 0; i < count; i++) {
                if ((i + 2) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    uberId = Program.Read<uint>(ptrC1, 0x10);
                } else if ((i + 1) % 3 == 0 && i != 0) {
                    UberFloat uberFloat = new UberFloat();
                    uberFloat.ID = uberId;
                    uberFloat.Name = Uber.UberStateLUT.UberLUT[UberGroup][Convert.ToInt32(uberFloat.ID)];
                    uberFloat.Value = Program.Read<float>(ptr1 + 0x20 + (i * 0x8));

                    uberFloats.Add(uberFloat);
                }
            }

            return uberFloats;
        }

        public List<UberInt> GetUberInts(IntPtr ptr, int UberGroup = 192) {
            List<UberInt> uberInts = new List<UberInt>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            uint uberId = 0;
            for (int i = 0; i < count; i++) {
                if ((i + 2) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    uberId = Program.Read<uint>(ptrC1, 0x10);
                } else if ((i + 1) % 3 == 0 && i != 0) {
                    UberInt uberInt = new UberInt();
                    uberInt.ID = uberId;
                    uberInt.Name = Uber.UberStateLUT.UberLUT[UberGroup][Convert.ToInt32(uberInt.ID)];
                    uberInt.Value = Program.Read<int>(ptr1 + 0x20 + (i * 0x8));

                    uberInts.Add(uberInt);
                }
            }

            return uberInts;
        }

        public List<UberByte> GetUberBytes(IntPtr ptr, int UberGroup = 192) {
            List<UberByte> uberBytes = new List<UberByte>();
            int count = MemoryReader.Read<int>(Program, ptr, 0x20) * 3;
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr, 0x18);

            uint uberId = 0;
            for (int i = 0; i < count; i++) {
                if ((i + 2) % 3 == 0 && i != 0) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    uberId = Program.Read<uint>(ptrC1, 0x10);
                } else if ((i + 1) % 3 == 0 && i != 0) {
                    UberByte uberByte = new UberByte();
                    uberByte.ID = uberId;
                    uberByte.Name = Uber.UberStateLUT.UberLUT[UberGroup][Convert.ToInt32(uberByte.ID)];
                    uberByte.Value = Program.Read<byte>(ptr1 + 0x20 + (i * 0x8));

                    uberBytes.Add(uberByte);
                }
            }

            return uberBytes;
        }

        public MoonGuid GetMoonGuid(IntPtr ptr) {
            MoonGuid moonGuid = new MoonGuid();
            uint A = Program.Read<uint>(ptr + 0x10);
            moonGuid.A = A;
            uint B = Program.Read<uint>(ptr + 0x14);
            moonGuid.B = B;
            uint C = Program.Read<uint>(ptr + 0x18);
            moonGuid.C = C;
            uint D = Program.Read<uint>(ptr + 0x1C);
            moonGuid.D = D;
            return moonGuid;
        }

        public Messages GetMessage(IntPtr ptr) {
            Messages messages = new Messages();

            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, ptr + 0x20);
            ptr1 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x10);
            ptr1 = MemoryReader.Read<IntPtr>(Program, ptr1 + 0x20);
            MessagesPtr messagesPtr = MemoryReader.Read<MessagesPtr>(Program, ptr1);
            messages.English = MemoryReader.ReadString(Program, messagesPtr.English);

            return messages;
        }

        public RaceSystemPtr GetRacePtr() {
            RaceSystemPtr raceSystemPtr = MemoryReader.Read<RaceSystemPtr>(Program, GameAssembly.BaseAddress, 0x047354E0, 0xb8, 0x0);// 0x0148FDA0, 0x0, 0x30, 0x160, 0xE0, 0x60, 0x138, 0x0); //0x0148FDA0
            /*if (raceSystemPtr.m_timer == IntPtr.Zero) {
                raceSystemPtr = MemoryReader.Read<RaceSystemPtr>(Program, GameAssembly.BaseAddress, 0x0449A978, 0xAC0, 0x40, 0x440, 0x18, 0xB8, 0x40, 0x0);
            }
            if (raceSystemPtr.m_timer == IntPtr.Zero) {
                raceSystemPtr = MemoryReader.Read<RaceSystemPtr>(Program, UnityPlayer.BaseAddress, 0x014A6FC8, 0x60, 0x98, 0x0, 0x748, 0xB8, 0x40, 0x0);
            }*/
            return raceSystemPtr;
        }

        public void GetRaceSystem(ref RaceSystem raceSystem) {
            RaceSystemPtr raceSystemPtr = GetRacePtr();
            m_timer raceTimer = MemoryReader.Read<m_timer>(Program, raceSystemPtr.m_timer);
            raceSystem.Timer = raceTimer;

            RaceContext raceContext = MemoryReader.Read<RaceContext>(Program, raceSystemPtr.Context);
            RaceConfiguration raceConfiguration = MemoryReader.Read<RaceConfiguration>(Program, raceContext.Configuration);
            MoonRace moonRace = MemoryReader.Read<MoonRace>(Program, raceConfiguration.Race);

            int count = MemoryReader.Read<int>(Program, raceSystemPtr.m_states, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, raceSystemPtr.m_states, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                if (i == 6) {
                    RaceCountdownStatePtr raceCountdownState = Program.Read<RaceCountdownStatePtr>((IntPtr)BitConverter.ToUInt64(data, i * 0x8));
                    raceSystem.CountdownTimeline = MemoryReader.Read<MoonTimeline>(Program, raceCountdownState.m_countdownTimeline);
                }
            }
        }

        public void StartRace() {
            RaceSystemPtr raceSystemPtr = GetRacePtr();
            RaceContext raceContext = MemoryReader.Read<RaceContext>(Program, raceSystemPtr.Context);
            RaceConfiguration raceConfiguration = MemoryReader.Read<RaceConfiguration>(Program, raceContext.Configuration);
            MoonRace moonRace = MemoryReader.Read<MoonRace>(Program, raceConfiguration.Race);

            int count = MemoryReader.Read<int>(Program, raceSystemPtr.m_states, 0x10, 0x18);
            IntPtr ptr1 = MemoryReader.Read<IntPtr>(Program, raceSystemPtr.m_states, 0x10);
            byte[] data = Program.Read(ptr1 + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                if (i == 6) {
                    IntPtr ptrC1 = Program.Read<IntPtr>(ptr1 + 0x20 + (i * 0x8));
                    Program.Write<IntPtr>(ptrC1, moonRace.CountdownTimeline, 0x20);
                }
            }

            ObjectInsideZoneChecker startZoneChecker = MemoryReader.Read<ObjectInsideZoneChecker>(Program, moonRace.StartZoneChecker);

            Program.Write<float>(moonRace.StartZoneChecker + 0x18, -659.0f, 0x0);
            Program.Write<float>(moonRace.StartZoneChecker + 0x18, -4244.0f, 0x4);
            Program.Write<float>(moonRace.StartZoneChecker + 0x30, -659.0f, 0x0);
            Program.Write<float>(moonRace.StartZoneChecker + 0x30, -4244.0f, 0x4);
            Program.Write<float>(raceConfiguration.Race + 0x148, -659.0f, 0x0);
            Program.Write<float>(raceConfiguration.Race + 0x148, -4235.0f, 0x4);
            //Program.Write<float>(moonRace.StartZoneChecker, 0.0f, 0x18, 0x8);
            //Program.Write<float>(moonRace.StartZoneChecker, 0.0f, 0x18, 0xC);

            //Program.Write<bool>(moonRace.CountdownTimeline, true, 0x30); //PlayState
            //Program.Write<bool>(moonRace.CountdownTimeline, true, 0xB4); //StartMode
            Program.Write<float>(moonRace.CountdownTimeline, 0, 0xB8); //CurrentTime
            Program.Write<bool>(moonRace.CountdownTimeline, false, 0xE8); //m_isFinished
            Program.Write<bool>(moonRace.CountdownTimeline, true, 0x100); //m_markerInitialized
            Program.Write<bool>(moonRace.CountdownTimeline, false, 0x101); //m_contentEnd
        }

        public float MapCompletion(AreaType areaType = AreaType.None) {
            float totalCompletion = 0;

            int worldMapAreaUniqueID = Version <= PointerVersion.P2 ? 0x20 : 0x38;
            int runtimeAreas = Version <= PointerVersion.P2 ? 0x28 : 0x40;
            int m_completionAmount = Version <= PointerVersion.P1 ? 0x34 : 0x5c;

            //GameWorld.RuntimeAreas
            IntPtr areas = GameWorld.Read<IntPtr>(Program, 0xb8, 0x0, runtimeAreas);
            //.Count
            int count = Program.Read<int>(areas, 0x18);
            //.Items
            areas = Program.Read<IntPtr>(areas, 0x10);
            byte[] data = Program.Read(areas + 0x20, count * 0x8);
            for (int i = 0; i < count; i++) {
                IntPtr area = (IntPtr)BitConverter.ToUInt64(data, i * 0x8);
                if (areaType != AreaType.None) {
                    //.Items[i].Area.WorldMapAreaUniqueID
                    AreaType type = Program.Read<AreaType>(area, 0x10, worldMapAreaUniqueID);
                    if (type == areaType) {
                        //.Items[i].m_completionAmount
                        return Program.Read<float>(area, m_completionAmount) * 100f;
                    }
                } else {
                    //.Items[i].m_completionAmount
                    totalCompletion += Program.Read<float>(area, m_completionAmount);
                }
            }
            return totalCompletion * 100f / (count == 0 ? 1 : count);
        }
        public bool HookProcess() {
            IsHooked = Program != null && !Program.HasExited;
            if (!IsHooked && DateTime.Now > LastHooked.AddSeconds(1)) {
                LastHooked = DateTime.Now;

                Process[] processes = Process.GetProcessesByName("OriWotW");
                Program = processes != null && processes.Length > 0 ? processes[0] : null;

                if (Program == null) {
                    processes = Process.GetProcessesByName("OriAndTheWillOfTheWisps");
                    Program = processes != null && processes.Length > 0 ? processes[0] : null;
                }

                if (Program == null) {
                    processes = Process.GetProcessesByName("OriAndTheWillOfTheWisps-PC");
                    Program = processes != null && processes.Length > 0 ? processes[0] : null;
                }

                if (Program != null && !Program.HasExited) {
                    MemoryReader.Update64Bit(Program);
                    FindIl2Cpp.InitializeIl2Cpp(Program);
                    Module64 module = Program.Module64("GameAssembly.dll");
                    UnityPlayer = Program.Module64("UnityPlayer.dll");
                    GameAssembly = Program.Module64("GameAssembly.dll");
                    MemoryManager.Version = PointerVersion.All;
                    if (GameAssembly != null) {
                        switch (GameAssembly.MemorySize) {
                            case 77447168: MemoryManager.Version = PointerVersion.P1; break;
                            case 77844480: MemoryManager.Version = PointerVersion.P2; break;
                            case 81121280: MemoryManager.Version = PointerVersion.P3; break;
                            default: MemoryManager.Version = PointerVersion.P4; break;
                        }
                    }
                    uberIDLookup = null;
                    noPausePatched = null;
                    debugEnabled = null;
                    IsHooked = true;
                    fpsTimer.Reset();
                }
            }

            fpsTimer.Update(IsHooked ? (int)FrameCount() : 0);
            return IsHooked;
        }
        public void Dispose() {
            if (Program != null) {
                Program.Dispose();
            }
        }
    }
}