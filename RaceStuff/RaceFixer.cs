using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriWotW.UI;

namespace OriWotW.RaceStuff {
    public partial class RaceFixer : Form {
        public RaceFixer() {
            InitializeComponent();
        }

        private void but1_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "RaceSettings\\";
                openFileDialog.Filter = "race settings (*.race)|*.race";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

FileErrorBrowseAgain:
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;

                    if (Path.HasExtension(filePath) == false)
                        goto FileErrorBrowseAgain;

                    if (Path.GetExtension(filePath) != ".race")
                        goto FileErrorBrowseAgain;

                    if (File.Exists(filePath) == false)
                        goto FileErrorBrowseAgain;

                    string text = File.ReadAllText(filePath);

                    string regexPattern = "(\"ShardsInInventory\":\\[).*(\\]{1})";
                    Regex regex = new Regex(regexPattern);
                    Match match = regex.Match(text);
                    string found = match.Value;
                    string foundT = found;
                    found = found.Replace("\"ShardsInInventory\":[", "");
                    found = found.Replace("]", "");
                    var splits = found.Split(',');
                    string newshards = "\"ShardsInInventory\":[";
                    int index = 0;
                    foreach (var s in splits) {
                        if (RaceEditor.ShardMaxLevel.ContainsKey(index) == true) {
                            newshards += "{\"Active\":" + s + ",\"Level\":0,\"MaxLevel\":" + RaceEditor.ShardMaxLevel[index].ToString() + ",\"ShardType\":" + ((int)(ShardType)index).ToString() + "},";
                        }
                        index++;
                    }

                    newshards = newshards.Substring(0, newshards.Length - 1);
                    newshards += "]";
                    text = text.Replace(foundT, newshards);
                    File.WriteAllText(filePath, text);
                }
            }
        }
    }
}
