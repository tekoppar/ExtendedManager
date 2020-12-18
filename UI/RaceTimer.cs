using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Text;
using OriWotW.Properties;
using System.Runtime.InteropServices;

namespace OriWotW.UI {
    public partial class RaceTimer : Form {
        private Thread timerLoop;
        private Stopwatch sw = new Stopwatch();
        public string Time = "0:00.00";

        public RaceTimer() {
            InitializeComponent();

            this.lblTimer.Font = this.GetMoonFont(36.0f);
            this.StartUpdateLoop();
        }

        public void StartUpdateLoop() {
            if (timerLoop != null) { return; }

            this.sw.Start();
            timerLoop = new Thread(UpdateLoop);
            timerLoop.IsBackground = true;
            timerLoop.Priority = ThreadPriority.AboveNormal;
            timerLoop.Start();
        }

        public void UpdateLoop() {
            while (timerLoop != null) {
                try {
                    this.UpdateTimer();
                    /*
                    if (
                    != hooked) {
                        lastHooked = hooked;
                        this.Invoke((Action)delegate () { lblNote.Visible = !hooked; });
                    }*/
                    this.Invoke((Action)delegate () { lblTimer.Text = this.Time; });
                } catch { }
                Thread.Sleep(5);
            }
        }

        public void UpdateTimer() {
            long ms = this.sw.ElapsedMilliseconds;
            double minutes = Math.Floor(ms / (1000.0f * 60.0f) % 60);
            double seconds = Math.Floor(ms / 1000.0f % 60);
            double milliseconds = ms % 1000;

            this.Time = minutes.ToString("0") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("000");
        }

        public Font GetMoonFont(float fontSize = 12.0f) {
            PrivateFontCollection _fonts = new PrivateFontCollection();

            byte[] fontData = OriWotW.Properties.Resources.Moon_custom;

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);

            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            _fonts.AddMemoryFont(fontPtr, fontData.Length);

            Marshal.FreeCoTaskMem(fontPtr);

            return new Font(_fonts.Families[0], fontSize);
        }
    }
}
