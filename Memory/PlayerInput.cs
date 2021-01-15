using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using System.Runtime.Remoting.Messaging;
using Tem.TemClass;

namespace OriWotW.Memory {
    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct PlayerInputPtr {
        [FieldOffset(0x38)]
        public IntPtr HorizontalAnalogLeft;
        [FieldOffset(0x40)]
        public IntPtr VerticalAnalogLeft;
        [FieldOffset(0x48)]
        public IntPtr HorizontalAnalogRight;
        [FieldOffset(0x50)]
        public IntPtr VerticalAnalogRight;
        [FieldOffset(0x58)]
        public IntPtr HorizontalDigiPad;
        [FieldOffset(0x60)]
        public IntPtr VerticalDigiPad;
        [FieldOffset(0x68)]
        public IntPtr LeftTriggerAxis;
        [FieldOffset(0x70)]
        public IntPtr RightTriggerAxis;
        [FieldOffset(0x78)]
        public IntPtr Down;
        [FieldOffset(0x80)]
        public IntPtr Up;
        [FieldOffset(0x88)]
        public IntPtr Left;
        [FieldOffset(0x90)]
        public IntPtr Right;
        [FieldOffset(0x98)]
        public IntPtr ChargeJump;
        [FieldOffset(0xA0)]
        public IntPtr LeftShoulder;
        [FieldOffset(0xA8)]
        public IntPtr RightShoulder;
        [FieldOffset(0xB0)]
        public IntPtr LeftTrigger;
        [FieldOffset(0xB8)]
        public IntPtr RightTrigger;
        [FieldOffset(0xC0)]
        public IntPtr Select;
        [FieldOffset(0xC8)]
        public IntPtr Start;
        [FieldOffset(0xD0)]
        public IntPtr LeftStick;
        [FieldOffset(0xD8)]
        public IntPtr RightStick;
        [FieldOffset(0xE0)]
        public IntPtr MenuCycleFilter;
        [FieldOffset(0xE8)]
        public IntPtr ActionButtonA;
        [FieldOffset(0xF0)]
        public IntPtr ActionButtonB;
        [FieldOffset(0xF8)]
        public IntPtr ActionButtonX;
        [FieldOffset(0x100)]
        public IntPtr ActionButtonY;
        [FieldOffset(0x108)]
        public IntPtr Cancel;
        [FieldOffset(0x110)]
        public IntPtr MainMenuSaveCopy;
        [FieldOffset(0x118)]
        public IntPtr MainMenuSaveDelete;
        [FieldOffset(0x120)]
        public IntPtr Focus;
        [FieldOffset(0x128)]
        public IntPtr LeaderboardDifficultyFilter;
        [FieldOffset(0x130)]
        public IntPtr Legend;
        [FieldOffset(0x138)]
        public IntPtr Pause;
        [FieldOffset(0x140)]
        public IntPtr KeyboardOnly;
        [FieldOffset(0x148)]
        public IntPtr Interact;
        [FieldOffset(0x150)]
        public IntPtr Jump;
        [FieldOffset(0x158)]
        public IntPtr Ability1;
        [FieldOffset(0x160)]
        public IntPtr Ability2;
        [FieldOffset(0x168)]
        public IntPtr Ability3;
        [FieldOffset(0x170)]
        public IntPtr Glide;
        [FieldOffset(0x178)]
        public IntPtr Grab;
        [FieldOffset(0x180)]
        public IntPtr Dash;
        [FieldOffset(0x188)]
        public IntPtr Burrow;
        [FieldOffset(0x190)]
        public IntPtr Bash;
        [FieldOffset(0x198)]
        public IntPtr Grapple;
        [FieldOffset(0x1A0)]
        public IntPtr DialogueAdvance;
        [FieldOffset(0x1A8)]
        public IntPtr DialogueOption1;
        [FieldOffset(0x1B0)]
        public IntPtr DialogueOption2;
        [FieldOffset(0x1B8)]
        public IntPtr DialogueOption3;
        [FieldOffset(0x1C0)]
        public IntPtr DialogueExit;
        [FieldOffset(0x1C8)]
        public IntPtr OpenMapsShardsInventory;
        [FieldOffset(0x1D0)]
        public IntPtr OpenInventory;
        [FieldOffset(0x1D8)]
        public IntPtr OpenWorldMap;
        [FieldOffset(0x1E0)]
        public IntPtr OpenAreaMap;
        [FieldOffset(0x1E8)]
        public IntPtr OpenShards;
        [FieldOffset(0x1F0)]
        public IntPtr OpenWeaponWheel;
        [FieldOffset(0x1F8)]
        public IntPtr PauseScreen;
        [FieldOffset(0x200)]
        public IntPtr LiveSignIn;
        [FieldOffset(0x208)]
        public IntPtr MapZoomIn;
        [FieldOffset(0x210)]
        public IntPtr MapZoomOut;
        [FieldOffset(0x218)]
        public IntPtr MenuSelect;
        [FieldOffset(0x220)]
        public IntPtr MenuBack;
        [FieldOffset(0x228)]
        public IntPtr MenuClose;
        [FieldOffset(0x230)]
        public IntPtr MenuDown;
        [FieldOffset(0x238)]
        public IntPtr MenuUp;
        [FieldOffset(0x240)]
        public IntPtr MenuLeft;
        [FieldOffset(0x248)]
        public IntPtr MenuRight;
        [FieldOffset(0x250)]
        public IntPtr MenuPageLeft;
        [FieldOffset(0x258)]
        public IntPtr MenuPageRight;
        [FieldOffset(0x260)]
        public IntPtr LeaderboardCycleFilter;
        [FieldOffset(0x268)]
        public IntPtr MapFilter;
        [FieldOffset(0x270)]
        public IntPtr MapDetails;
        [FieldOffset(0x278)]
        public IntPtr MapFocusOri;
        [FieldOffset(0x280)]
        public IntPtr MapFocusObjective;
        [FieldOffset(0x288)]
        public IntPtr LeftClick;
        [FieldOffset(0x290)]
        public IntPtr RightClick;
        [FieldOffset(0x298)]
        public IntPtr m_inputProcessorsPairs;
        [FieldOffset(0x2A0)]
        public IntPtr m_allAxisInput;
        [FieldOffset(0x2B8)]
        public IntPtr m_lastPressedButtonInput;
        [FieldOffset(0x2C0)]
        public int m_lastPressedAxisInput;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct InputButtonProcessor {
        [FieldOffset(0x10)]
        public bool WasPressed;
        [FieldOffset(0x11)]
        public bool IsPressed;
        [FieldOffset(0x12)]
        public bool Used;
        [FieldOffset(0x14)]
        public int k_BackingField;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct KeyCodeButtonInput {
        [FieldOffset(0x18)]
        public int m_keyCode;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct CompoundButtonInputPtr {
        [FieldOffset(0x18)]
        public IntPtr Buttons;
        [FieldOffset(0x20)]
        public int m_lastPressedIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct CompoundAxisInputPtr {
        [FieldOffset(0x18)]
        public IntPtr AxisInputs;
        [FieldOffset(0x20)]
        public int m_lastPressedIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 200, Pack = 1)]
    public struct AxisButtonInput {
        [FieldOffset(0x18)]
        public IntPtr m_axis;
        [FieldOffset(0x20)]
        public int m_axisMode;
        [FieldOffset(0x24)]
        public float m_comparisonValue;
    }

    public class CompoundButtonInput {
        public List<string> Buttons = new List<string>();
        public int m_lastPressedIndex;
        public string BindName = "";
    }

    public enum InputState : int {
        InputWasPressed = 0,
        InputIsPressed = 1,
        InputWasReleased = 2,
        InputIsReleased = 3
    }

    public class InputProcessor {
        public string Key;
        public int KeyIndex;
        public bool IsControllerInput = false;
        public InputButtonProcessor CurrentState;
        public InputButtonProcessor OldState;
        public InputState State = InputState.InputIsReleased;
        public CompoundButtonInput Buttons;

        public void UpdateInput(InputButtonProcessor newState) {
            this.OldState = this.CurrentState;
            this.CurrentState = newState;

            if (newState.IsPressed == false && newState.WasPressed == false && newState.Used == false) {
                this.State = InputState.InputIsReleased;
            } else if (this.OldState.IsPressed == true && this.CurrentState.IsPressed == true) {
                this.State = InputState.InputIsPressed;
            } else if ((this.OldState.WasPressed == true || this.OldState.IsPressed == true) && this.CurrentState.WasPressed == true) {
                this.State = InputState.InputWasReleased;
            } else if ((this.OldState.IsPressed == false || this.OldState.WasPressed == false) && (this.CurrentState.IsPressed == true || this.CurrentState.WasPressed == true) ||
                this.OldState.WasPressed == false && this.CurrentState.IsPressed == true) {
                this.State = InputState.InputWasPressed;
            } else if (this.OldState.WasPressed == true && this.CurrentState.WasPressed == false ||
                this.OldState.IsPressed == false && this.CurrentState.IsPressed == false && this.OldState.WasPressed == false && this.CurrentState.WasPressed == false) {
                this.State = InputState.InputIsReleased;
            } else {
                this.State = InputState.InputIsReleased;
            }
        }

        public void UpdateDirection(InputButtonProcessor newState) {
            this.OldState = this.CurrentState;
            this.CurrentState = newState;

            if (this.CurrentState.IsPressed == true) {
                this.State = InputState.InputWasPressed;
            } else if (this.OldState.IsPressed == true && this.CurrentState.IsPressed == true) {
                this.State = InputState.InputIsPressed;
            } else if (this.CurrentState.IsPressed == false) {
                this.State = InputState.InputWasReleased;
            } else if (this.CurrentState.IsPressed == false && this.CurrentState.WasPressed == false) {
                this.State = InputState.InputIsReleased;
            }
        }
    }

    public class AxisProcessor {
        public string Axis;
        public int KeyIndex;
        public Vector2 CurrentState;
        public Vector2 OldState;
        public InputState StateLeft = InputState.InputIsReleased;
        public InputState StateRight = InputState.InputIsReleased;
        public InputState StateDown = InputState.InputIsReleased;
        public InputState StateUp = InputState.InputIsReleased;

        public void UpdateAxis(float x, float y) {
            this.OldState = this.CurrentState;
            this.CurrentState.X = x;
            this.CurrentState.Y = y;


            //Up down axis
            if (Math.Abs(this.CurrentState.X) < 0.24f && Math.Abs(this.OldState.X) < 0.24f) {
                this.StateDown = InputState.InputIsReleased;
                this.StateUp = InputState.InputIsReleased;
            }
            if (this.OldState.X < 0.24f && this.CurrentState.X > 0.24f) {
                this.StateUp = InputState.InputWasPressed;
                if (this.OldState.X < 0.0f) {
                    this.StateDown = InputState.InputWasReleased;
                }
            }
            if (this.OldState.X > 0.24f && this.CurrentState.X < 0.24f) {
                this.StateUp = InputState.InputWasReleased;
            }
            if (this.OldState.X > -0.24f && this.CurrentState.X < -0.24f) {
                this.StateDown = InputState.InputWasPressed;
                if (this.OldState.X > 0.0f) {
                    this.StateUp = InputState.InputWasReleased;
                }
            }
            if (this.OldState.X < -0.24f && this.CurrentState.X > -0.24f) {
                this.StateDown = InputState.InputWasReleased;
            }
            if (this.CurrentState.X > 0.24f && this.OldState.X > 0.24f) {
                this.StateUp = InputState.InputIsPressed;
            }
            if (this.CurrentState.X < -0.24f && this.OldState.X < -0.24f) {
                this.StateDown = InputState.InputIsPressed;
            }

            //Left right axis
            if (Math.Abs(this.CurrentState.Y) < 0.24f && Math.Abs(this.OldState.Y) < 0.24f) {
                this.StateLeft = InputState.InputIsReleased;
                this.StateRight = InputState.InputIsReleased;
            }
            if (this.OldState.Y < 0.24f && this.CurrentState.Y > 0.24f) {
                this.StateRight = InputState.InputWasPressed;
                if (this.OldState.Y < 0.0f) {
                    this.StateLeft = InputState.InputWasReleased;
                }
            }
            if (this.OldState.Y > 0.24f && this.CurrentState.Y < 0.24f) {
                this.StateRight = InputState.InputWasReleased;
            }
            if (this.OldState.Y > -0.24f && this.CurrentState.Y < -0.24f) {
                this.StateLeft = InputState.InputWasPressed;
                if (this.OldState.Y > 0.0f) {
                    this.StateRight = InputState.InputWasReleased;
                }
            }
            if (this.OldState.Y < -0.24f && this.CurrentState.Y > -0.24f) {
                this.StateLeft = InputState.InputWasReleased;
            }
            if (this.CurrentState.Y > 0.24f && this.OldState.Y > 0.24f) {
                this.StateRight = InputState.InputIsPressed;
            }
            if (this.CurrentState.Y < -0.24f && this.OldState.Y < -0.24f) {
                this.StateLeft = InputState.InputIsPressed;
            }
        }
    }

    public class AxisInputs {
        public AxisProcessor Axis1 = new AxisProcessor();
        public AxisProcessor Axis2 = new AxisProcessor();
        public AxisProcessor DPadDirection1 = new AxisProcessor();
        public AxisProcessor DPadDirection2 = new AxisProcessor();
        public AxisProcessor Axis3 = new AxisProcessor();
        public AxisProcessor Axis4 = new AxisProcessor();
        public Vector2 Mouse;
    }

    public class PlayerInput {
        public Dictionary<string, CompoundButtonInput> SeinButtons = new Dictionary<string, CompoundButtonInput>();
        public Dictionary<IntPtr, InputProcessor> SeinInputs = new Dictionary<IntPtr, InputProcessor>();
        public List<int> PlayerInputs = new List<int>();
        public List<CompoundAxisInputPtr> PlayerAxis = new List<CompoundAxisInputPtr>();
        public int m_lastPressedAxisInput = -1;
        public AxisInputs AxisInputs = new AxisInputs();
        public List<InputProcessor> DirectionalInputs = new List<InputProcessor>();
        public Dictionary<int, string> InputMap = new Dictionary<int, string>() {
            //[107] = "Movement Left",
            //[110] = "Movement Right",
            //[101] = "Movement Down",
            //[104] = "Movement Up",
            [-1] = "Save Copy",
            [15] = "Save Delete",
            [17] = "Interact",
            [20] = "Jump",
            [23] = "Ability 1",
            [26] = "Ability 2",
            [29] = "Ability 3",
            [32] = "Glide",
            [35] = "Grab",
            [38] = "Dash",
            [41] = "Burrow",
            [44] = "Bash",
            [47] = "Grapple",
            //[50] = "Dialogue Advance",
            //[53] = "Dialogue Option 1",
            //[17] = "Dialogue Option 2",
            //[8] = "Dialogue Option 3",
            //[59] = "DialogueExit",
            [62] = "Open Maps Shards Inventory",
            [65] = "Open Inventory",
            [68] = "Open World Map",
            [71] = "Open Area Map",
            [74] = "Open Shards Screen",
            [77] = "Open Weapon Wheel",
            //[59] = "Open Pause Screen", //is this weapon wheel and pause? used to be 59
            [-1] = "Open Live SignIn",
            //[86] = "MapZoomIn",
            //[89] = "MapZoomOut",
            //[92] = "MenuSelect",
            //[95] = "MenuBack",
            //[98] = "MenuClose",
            [-1] = "MenuDown",
            [-1] = "MenuUp",
            [-1] = "MenuLeft",
            [-1] = "MenuRight",
            [-1] = "MenuPageLeft",
            [-1] = "MenuPageRight",
            [-1] = "LeaderboardCycleFilter",
            //[122] = "MapFilter",
            //[125] = "MapDetails",
            [80] = "MapFocusOri",
            [-1] = "MapFocusObjective"
        };
        static public Dictionary<int, string> UnityKeyCodeMap = new Dictionary<int, string>() {
            [97] = "A",
            [48] = "Alpha0",
            [49] = "Alpha1",
            [50] = "Alpha2",
            [51] = "Alpha3",
            [52] = "Alpha4",
            [53] = "Alpha5",
            [54] = "Alpha6",
            [55] = "Alpha7",
            [56] = "Alpha8",
            [57] = "Alpha9",
            [313] = "AltGr",
            [38] = "Ampersand",
            [42] = "Asterisk",
            [64] = "At",
            [98] = "B",
            [96] = "BackQuote",
            [92] = "Backslash",
            [8] = "Backspace",
            [318] = "Break",
            [99] = "C",
            [301] = "CapsLock",
            [94] = "Caret",
            [12] = "Clear",
            [58] = "Colon",
            [44] = "Comma",
            [100] = "D",
            [127] = "Delete",
            [36] = "Dollar",
            [34] = "DoubleQuote",
            [274] = "DownArrow",
            [101] = "E",
            [279] = "End",
            [61] = "Equals",
            [27] = "Escape",
            [33] = "Exclaim",
            [102] = "F",
            [282] = "F1",
            [291] = "F10",
            [292] = "F11",
            [293] = "F12",
            [294] = "F13",
            [295] = "F14",
            [296] = "F15",
            [283] = "F2",
            [284] = "F3",
            [285] = "F4",
            [286] = "F5",
            [287] = "F6",
            [288] = "F7",
            [289] = "F8",
            [290] = "F9",
            [103] = "G",
            [62] = "Greater",
            [104] = "H",
            [35] = "Hash",
            [315] = "Help",
            [278] = "Home",
            [105] = "I",
            [277] = "Insert",
            [106] = "J",
            [107] = "K",
            [256] = "Keypad0",
            [257] = "Keypad1",
            [258] = "Keypad2",
            [259] = "Keypad3",
            [260] = "Keypad4",
            [261] = "Keypad5",
            [262] = "Keypad6",
            [263] = "Keypad7",
            [264] = "Keypad8",
            [265] = "Keypad9",
            [267] = "KeypadDivide",
            [271] = "KeypadEnter",
            [272] = "KeypadEquals",
            [269] = "KeypadMinus",
            [268] = "KeypadMultiply",
            [266] = "KeypadPeriod",
            [270] = "KeypadPlus",
            [108] = "L",
            [308] = "LeftAlt",
            [310] = "LeftApple",
            [276] = "LeftArrow",
            [91] = "LeftBracket",
            [310] = "LeftCommand",
            [306] = "LeftControl",
            [40] = "LeftParen",
            [304] = "LeftShift",
            [311] = "LeftWindows",
            [60] = "Less",
            [109] = "M",
            [319] = "Menu",
            [45] = "Minus",
            [323] = "Mouse0",
            [324] = "Mouse1",
            [325] = "Mouse2",
            [326] = "Mouse3",
            [327] = "Mouse4",
            [328] = "Mouse5",
            [329] = "Mouse6",
            [110] = "N",
            [0] = "None",
            [300] = "Numlock",
            [111] = "O",
            [112] = "P",
            [281] = "PageDown",
            [280] = "PageUp",
            [19] = "Pause",
            [46] = "Period",
            [43] = "Plus",
            [316] = "Print",
            [113] = "Q",
            [63] = "Question",
            [39] = "Quote",
            [114] = "R",
            [13] = "Return",
            [307] = "RightAlt",
            [309] = "RightApple",
            [275] = "RightArrow",
            [93] = "RightBracket",
            [309] = "RightCommand",
            [305] = "RightControl",
            [41] = "RightParen",
            [303] = "RightShift",
            [312] = "RightWindows",
            [115] = "S",
            [302] = "ScrollLock",
            [59] = "Semicolon",
            [47] = "Slash",
            [32] = "Space",
            [317] = "SysReq",
            [116] = "T",
            [9] = "Tab",
            [117] = "U",
            [95] = "Underscore",
            [273] = "UpArrow",
            [118] = "V",
            [119] = "W",
            [120] = "X",
            [121] = "Y",
            [122] = "Z"
        };
        static public Dictionary<int, string> ControllerCodeMap = new Dictionary<int, string>() {
            [0] = "JoypadA",
            [1] = "JoypadX",
            [2] = "JoypadY",
            [3] = "JoypadB",
            [4] = "LeftTrigger",
            [5] = "RightTrigger",
            [6] = "LeftShoulder",
            [7] = "RightShoulder",
            [8] = "LeftStick",
            [9] = "RightStick",
            [10] = "JoypadSelect",
            [11] = "JoypadStart",
            //[101] = "JoypadDown",
            //104] = "JoypadUp",
            //[107] = "JoypadLeft",
            //[110] = "JoypadRight"
        };
        static public List<string> ControllerInputNames = new List<string>() {
            "ActionButtonA",
            "ActionButtonB",
            "ActionButtonX",
            "ActionButtonY",
            "HorizontalAnalogLeft",
            "HorizontalAnalogRight",
            "HorizontalDigiPad",
            "LeftShoulder",
            "LeftStick",
            "LeftTrigger",
            "LeftTriggerAxis",
            "RightShoulder",
            "RightStick",
            "RightTrigger",
            "RightTriggerAxis",
            "VerticalAnalogLeft",
            "VerticalAnalogRight",
            "VerticalDigiPad",
            "Ability1",
            "Ability2",
            "Ability3"
        };
        static public Dictionary<string, string> ControllerInputNamesToJoypad = new Dictionary<string, string>() {
            ["ActionButtonA"] = "ActionButtonA",
            ["ActionButtonB"] = "ActionButtonB",
            ["ActionButtonX"] = "ActionButtonX",
            ["ActionButtonY"] = "ActionButtonY",
            ["HorizontalAnalogLeft"] = "HorizontalAnalogLeft",
            ["HorizontalAnalogRight"] = "HorizontalAnalogRight",
            ["HorizontalDigiPad"] = "HorizontalDigiPad",
            ["LeftShoulder"] = "LeftShoulder",
            ["LeftStick"] = "LeftStick",
            ["LeftTrigger"] = "LeftTrigger",
            ["LeftTriggerAxis"] = "LeftTriggerAxis",
            ["RightShoulder"] = "RightShoulder",
            ["RightStick"] = "RightStick",
            ["RightTrigger"] = "RightTrigger",
            ["RightTriggerAxis"] = "RightTriggerAxis",
            ["VerticalAnalogLeft"] = "VerticalAnalogLeft",
            ["VerticalAnalogRight"] = "VerticalAnalogRight",
            ["VerticalDigiPad"] = "VerticalDigiPad"
    };

        public PlayerInput() {
            /*foreach (var input in this.InputMap) {
                if (input.Key != -1) {
                    InputProcessor newInput = new InputProcessor();
                    newInput.Key = input.Value;
                    newInput.KeyIndex = input.Key;
                    this.SeinInputs.Add(input.Key, newInput);
                }
            }*/
            InputProcessor down = new InputProcessor();
            down.Key = "Movement Down";
            down.KeyIndex = 0;
            down.State = InputState.InputIsReleased;
            InputProcessor left = new InputProcessor();
            left.Key = "Movement Left";
            left.KeyIndex = 1;
            left.State = InputState.InputIsReleased;
            InputProcessor right = new InputProcessor();
            right.Key = "Movement Right";
            right.KeyIndex = 2;
            right.State = InputState.InputIsReleased;
            InputProcessor up = new InputProcessor();
            up.Key = "Movement Up";
            up.KeyIndex = 3;
            up.State = InputState.InputIsReleased;

            this.DirectionalInputs.AddRange(new List<InputProcessor>() { down, left, right, up });
        }

        public void SetInputMap(List<IntPtr> buttonInputs, List<int> buttonInputsIndex, ref PlayerInputPtr playerInputPtr) {
            Type myType = typeof(PlayerInputPtr);
            _FieldInfo[] fields = myType.GetFields();
            this.InputMap.Clear();

            foreach (_FieldInfo field in fields) {
                string fieldName = field.Name;

                if (fieldName != "m_lastPressedAxisInput" && fieldName != "m_lastPressedButtonInput" && fieldName != "m_allAxisInput" && fieldName != "m_inputProcessorsPairs") {
                    IntPtr ptr = (IntPtr)field.GetValue(playerInputPtr);

                    if (buttonInputs.Contains(ptr) == true) {
                        int tI = buttonInputs.IndexOf(ptr);
                        InputProcessor newInput = new InputProcessor();

                        if (PlayerInput.ControllerInputNamesToJoypad.ContainsKey(fieldName) == true)
                            newInput.Key = PlayerInput.ControllerInputNamesToJoypad[fieldName];
                        else
                            newInput.Key = fieldName;

                        newInput.KeyIndex = buttonInputsIndex[tI];
                        newInput.IsControllerInput = PlayerInput.ControllerInputNames.IndexOf(newInput.Key) != -1 ? true : false;
                        this.SeinInputs[ptr] = newInput;
                        this.InputMap.Add(buttonInputsIndex[tI], fieldName);
                    }
                }
            }
        }

        public void UpdateInput(IntPtr ptr, InputButtonProcessor state) {
            if (this.SeinInputs.ContainsKey(ptr) == true) {
                this.SeinInputs[ptr].UpdateInput(state);
            }
        }

        public void UpdateDirection(int index, InputButtonProcessor state) {
            if (this.DirectionalInputs.Count > index) {
                this.DirectionalInputs[index].UpdateDirection(state);
            }
        }

        static public string ReturnKey(IntPtr button, PlayerInputPtr pointers) {
            if (button.Equals(pointers.Ability1) == true) {
                return "Ability1";
            } else if (button.Equals(pointers.Ability2) == true) {
                return "Ability2";
            } else if (button.Equals(pointers.Ability3) == true) {
                return "Ability3";
            } else if (button.Equals(pointers.ActionButtonA) == true) {
                return "ActionButtonA";
            } else if (button.Equals(pointers.ActionButtonB) == true) {
                return "ActionButtonB";
            } else if (button.Equals(pointers.ActionButtonX) == true) {
                return "ActionButtonX";
            } else if (button.Equals(pointers.ActionButtonY) == true) {
                return "ActionButtonY";
            } else if (button.Equals(pointers.Bash) == true) {
                return "Bash";
            } else if (button.Equals(pointers.Burrow) == true) {
                return "Burrow";
            } else if (button.Equals(pointers.Cancel) == true) {
                return "Cancel";
            } else if (button.Equals(pointers.ChargeJump) == true) {
                return "ChargeJump";
            } else if (button.Equals(pointers.Dash) == true) {
                return "Dash";
            } else if (button.Equals(pointers.DialogueAdvance) == true) {
                return "DialogueAdvance";
            } else if (button.Equals(pointers.DialogueExit) == true) {
                return "DialogueExit";
            } else if (button.Equals(pointers.DialogueOption1) == true) {
                return "DialogueOption1";
            } else if (button.Equals(pointers.DialogueOption2) == true) {
                return "DialogueOption2";
            } else if (button.Equals(pointers.DialogueOption3) == true) {
                return "DialogueOption3";
            } else if (button.Equals(pointers.Down) == true) {
                return "Down";
            } else if (button.Equals(pointers.Focus) == true) {
                return "Focus";
            } else if (button.Equals(pointers.Glide) == true) {
                return "Glide";
            } else if (button.Equals(pointers.Grab) == true) {
                return "Grab";
            } else if (button.Equals(pointers.Grapple) == true) {
                return "Grapple";
            } else if (button.Equals(pointers.HorizontalAnalogLeft) == true) {
                return "HorizontalAnalogLeft";
            } else if (button.Equals(pointers.HorizontalAnalogRight) == true) {
                return "HorizontalAnalogRight";
            } else if (button.Equals(pointers.HorizontalDigiPad) == true) {
                return "HorizontalDigiPad";
            } else if (button.Equals(pointers.Interact) == true) {
                return "Interact";
            } else if (button.Equals(pointers.Jump) == true) {
                return "Jump";
            } else if (button.Equals(pointers.KeyboardOnly) == true) {
                return "KeyboardOnly";
            } else if (button.Equals(pointers.LeaderboardDifficultyFilter) == true) {
                return "LeaderboardDifficultyFilter";
            } else if (button.Equals(pointers.Left) == true) {
                return "Left";
            } else if (button.Equals(pointers.LeftShoulder) == true) {
                return "LeftShoulder";
            } else if (button.Equals(pointers.LeftStick) == true) {
                return "LeftStick";
            } else if (button.Equals(pointers.LeftTrigger) == true) {
                return "LeftTrigger";
            } else if (button.Equals(pointers.LeftTriggerAxis) == true) {
                return "LeftTriggerAxis";
            } else if (button.Equals(pointers.Legend) == true) {
                return "Legend";
            } else if (button.Equals(pointers.LiveSignIn) == true) {
                return "LiveSignIn";
            } else if (button.Equals(pointers.MainMenuSaveCopy) == true) {
                return "MainMenuSaveCopy";
            } else if (button.Equals(pointers.MainMenuSaveDelete) == true) {
                return "MainMenuSaveDelete";
            } else if (button.Equals(pointers.MapZoomIn) == true) {
                return "MapZoomIn";
            } else if (button.Equals(pointers.MenuCycleFilter) == true) {
                return "MenuCycleFilter";
            } else if (button.Equals(pointers.OpenAreaMap) == true) {
                return "OpenAreaMap";
            } else if (button.Equals(pointers.OpenInventory) == true) {
                return "OpenInventory";
            } else if (button.Equals(pointers.OpenMapsShardsInventory) == true) {
                return "OpenMapsShardsInventory";
            } else if (button.Equals(pointers.OpenShards) == true) {
                return "OpenShards";
            } else if (button.Equals(pointers.OpenWeaponWheel) == true) {
                return "OpenWeaponWheel";
            } else if (button.Equals(pointers.OpenWorldMap) == true) {
                return "OpenWorldMap";
            } else if (button.Equals(pointers.Pause) == true) {
                return "Pause";
            } else if (button.Equals(pointers.PauseScreen) == true) {
                return "PauseScreen";
            } else if (button.Equals(pointers.Right) == true) {
                return "Right";
            } else if (button.Equals(pointers.RightShoulder) == true) {
                return "RightShoulder";
            } else if (button.Equals(pointers.RightStick) == true) {
                return "RightStick";
            } else if (button.Equals(pointers.RightTrigger) == true) {
                return "RightTrigger";
            } else if (button.Equals(pointers.RightTriggerAxis) == true) {
                return "RightTriggerAxis";
            } else if (button.Equals(pointers.Select) == true) {
                return "Select";
            } else if (button.Equals(pointers.Start) == true) {
                return "Start";
            } else if (button.Equals(pointers.Up) == true) {
                return "Up";
            } else if (button.Equals(pointers.VerticalAnalogLeft) == true) {
                return "VerticalAnalogLeft";
            } else if (button.Equals(pointers.VerticalAnalogRight) == true) {
                return "VerticalAnalogRight";
            } else if (button.Equals(pointers.VerticalDigiPad) == true) {
                return "VerticalDigiPad";
            } else if (button.Equals(pointers.LeftClick) == true) {
                return "Mouse0";
            } else if (button.Equals(pointers.RightClick) == true) {
                return "Mouse2";
            } else if (button.Equals(pointers.MapZoomOut) == true) {
                return "MapZoomOut";
            } else if (button.Equals(pointers.MenuSelect) == true) {
                return "MenuSelect";
            } else if (button.Equals(pointers.MenuBack) == true) {
                return "MenuBack";
            } else if (button.Equals(pointers.MenuClose) == true) {
                return "MenuClose";
            } else if (button.Equals(pointers.MenuDown) == true) {
                return "MenuDown";
            } else if (button.Equals(pointers.MenuUp) == true) {
                return "MenuUp";
            } else if (button.Equals(pointers.MenuLeft) == true) {
                return "MenuLeft";
            } else if (button.Equals(pointers.MenuRight) == true) {
                return "MenuRight";
            } else if (button.Equals(pointers.MenuPageLeft) == true) {
                return "MenuPageLeft";
            } else if (button.Equals(pointers.MenuPageRight) == true) {
                return "MenuPageRight";
            } else if (button.Equals(pointers.LeaderboardCycleFilter) == true) {
                return "LeaderboardCycleFilter";
            } else if (button.Equals(pointers.MapFilter) == true) {
                return "MapFilter";
            } else if (button.Equals(pointers.MapDetails) == true) {
                return "MapDetails";
            } else if (button.Equals(pointers.MapFocusOri) == true) {
                return "MapFocusOri";
            } else if (button.Equals(pointers.MapFocusObjective) == true) {
                return "MapFocusObjective";
            }

            return "";
        }
    }
}

/*
107 = left
101 = down
104 = up
110 = right
113/119/134 = MenuPageLeft   /44/47 JoypadLeftB
89 = MapZoomOut/140/   77/ JoypadLeftTrigger
137/116/ = MenuPageRight    38/41 JoypadRightB
86 = MapZoomIn/146 =     /32/35 JoypadRightTrigger
161 =    /62 JoypadSelect


125 = MapDetails     /2/26/50 JoypadY
95 = MenuBack/98/155     /29/50/59 JoypadB
92 = MenuSelect/152     /20/50 JoypadA
122 = MapFilter/158     /8/17/23/50/53 JoypadX
14 Mouse0
44 Mouse1
38 Mouse2
23 Z
17 X
8 C 
26 E
68 W
107 A
101 S
11 D
77 Q
20 space
38 left shift
17 J
86 right shift
 */