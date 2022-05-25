using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriWotW.UI.Playback {

    public enum PlaybackKeyCode {
        LMOUSE = 0x01,
        RMOUSE = 0x02,
        SPACEBAR = 0x20,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        LSHIFT = 0xA0
    };

    public class PlaybackInput {
        public PlaybackKeyCode InputCode;
        public int StartFrame = 0;
        public int Length = 0;
        public int WaitAfter = 0;
        public int WaitBefore = 0;
        public bool KeyUp = false;

        public PlaybackInput(PlaybackKeyCode keyCode, int startFrame, int length, int waitAfter = 0) {
            this.InputCode = keyCode;
            this.StartFrame = startFrame;
            this.Length = length;
            this.WaitAfter = waitAfter;
        }
    }
}
