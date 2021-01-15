using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.CompilerServices;
using OriWotW.UI;
using System.Text.RegularExpressions;
using Tem.TemClass;

namespace SystemTextJsonSamples {
    public class JsonConverterSingle : JsonConverter<float> {
        public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {

            using (var jsonDoc = JsonDocument.ParseValue(ref reader)) {
                string rawValue = jsonDoc.RootElement.GetRawText();
                return float.Parse(rawValue, CultureInfo.CreateSpecificCulture("en-US"));
            }
           /* typeToConvert = typeof(string);
            string value = reader.GetString();
            return float.Parse(value, CultureInfo.CreateSpecificCulture("en-US"));*/
        }

        public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString("F4", CultureInfo.CreateSpecificCulture("en-US")));
        }
    }
}

namespace OriWotW.RaceStuff {

    public enum RaceState {
        IsRacing = 0,
        FinishedRacing = 1,
        Waiting = 2
    };

    public class RaceSettings {
        private string RaceName = "Race";
        private Vector3 RaceStart;
        private Vector3 RaceFinish;
        public List<Checkpoint> RaceCheckpoints = new List<Checkpoint>();
        private string RacePath = "";
        private Dictionary<string, bool> AbilitiesStates = new Dictionary<string, bool>();// = Enumerable.Repeat(false, 256).ToList();
        private int SeinFacesDirection = 0;
        public string Ability1Bound;
        public string Ability2Bound;
        public string Ability3Bound;
        public EquippedShards ShardsEquipped = new EquippedShards();
        public Dictionary<int, Shard> ShardsInInventory = new Dictionary<int, Shard>();

        static public void SaveRace(RaceSettings race) {
            if (race.RaceName != "Race") {
                RaceSettingsJSON tempJson = new RaceSettingsJSON();
                tempJson.RaceName = race.RaceName;
                tempJson.RaceStart = race.RaceStart.X.ToString(CultureInfo.CreateSpecificCulture("en-US")) + "|" + race.RaceStart.Y.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                tempJson.RaceFinish = race.RaceFinish.X.ToString(CultureInfo.CreateSpecificCulture("en-US")) + "|" + race.RaceFinish.Y.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                tempJson.SeinFacesDirection = race.SeinFacesDirection.ToString();
                tempJson.Ability1Bound = race.Ability1Bound != "" ? race.Ability1Bound : "None";
                tempJson.Ability2Bound = race.Ability2Bound != "" ? race.Ability2Bound : "None";
                tempJson.Ability3Bound = race.Ability3Bound != "" ? race.Ability3Bound : "None";
                tempJson.EquippedShards = race.ShardsEquipped;
                List<Shard> tShards = new List<Shard>();
                foreach (var shard in race.ShardsInInventory) {
                    tShards.Add(shard.Value);
                }
                tempJson.ShardsInInventory = tShards;
                tempJson.AbilitiesStates = race.AbilitiesStates;
                tempJson.RaceCheckpoints = race.RaceCheckpoints;

                string jsonString = JsonSerializer.Serialize(tempJson);
                string pattern = "(\"-?\\d+\\.\\d+\")";
                Regex regex = new Regex(pattern);
                var results = regex.Matches(jsonString);

                foreach (Match result in results) {
                    string old = result.Value;
                    string newS = result.Value.Replace("\"", "");
                    jsonString = jsonString.Replace(old, newS);
                }

                File.WriteAllText(race.RacePath + race.RaceName + ".race", jsonString);
            }
        }

        static public RaceSettings LoadRace() {
            RaceSettings raceSettings = new RaceSettings();

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

                    raceSettings.RacePath = filePath;
                    string jsonString = File.ReadAllText(filePath);
                    RaceSettingsJSON tempSettings = JsonSerializer.Deserialize<RaceSettingsJSON>(jsonString);

                    raceSettings.RaceName = tempSettings.RaceName;
                    var tStart = tempSettings.RaceStart.Split('|');
                    raceSettings.RaceStart.X = float.Parse(tStart[0], CultureInfo.CreateSpecificCulture("en-US"));
                    raceSettings.RaceStart.Y = float.Parse(tStart[1], CultureInfo.CreateSpecificCulture("en-US"));
                    var tFinish = tempSettings.RaceFinish.Split('|');
                    raceSettings.RaceFinish.X = float.Parse(tFinish[0], CultureInfo.CreateSpecificCulture("en-US"));
                    raceSettings.RaceFinish.Y = float.Parse(tFinish[1], CultureInfo.CreateSpecificCulture("en-US"));
                    raceSettings.SeinFacesDirection = int.Parse(tempSettings.SeinFacesDirection);
                    raceSettings.Ability1Bound = tempSettings.Ability1Bound != "" ? tempSettings.Ability1Bound : "None";
                    raceSettings.Ability2Bound = tempSettings.Ability2Bound != "" ? tempSettings.Ability2Bound : "None";
                    raceSettings.Ability3Bound = tempSettings.Ability3Bound != "" ? tempSettings.Ability3Bound : "None";
                    raceSettings.AbilitiesStates = tempSettings.AbilitiesStates;
                    Dictionary<int, Shard> tShards = new Dictionary<int, Shard>();
                    foreach (var shard in tempSettings.ShardsInInventory) {
                        tShards[shard.ShardType] = shard;
                    }
                    raceSettings.ShardsInInventory = tShards;
                    raceSettings.ShardsEquipped = tempSettings.EquippedShards;
                    raceSettings.RaceCheckpoints = tempSettings.RaceCheckpoints;
                }
            }

            return raceSettings;
        }

        static public string ChooseRace() {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\RaceSettings\\";
                openFileDialog.Filter = "race settings (*.race)|*.race";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = openFileDialog.FileName;

                    if (File.Exists(filePath) == false)
                        return null;

                    return filePath;
                }

                return null;
            }
        }

        public void SetRaceName(string raceName) {
            this.RaceName = raceName;
        }

        public string GetRaceName() {
            return this.RaceName;
        }

        public string GetRacePath() {
            return this.RacePath;
        }

        public void SetRacePath(string racePath) {
            this.RacePath = racePath;
        }

        public Dictionary<string, bool> GetAbilitiesStates() {
            return this.AbilitiesStates;
        }

        public void SetAbilitiesStates(Dictionary<string, bool> abilitiesStates) {
            this.AbilitiesStates = abilitiesStates;
        }

        public void SetStart(Vector3 position) {
            this.RaceStart = position;
        }

        public Vector3 GetStart() {
            return this.RaceStart;
        }

        public void SetFinish(Vector3 position) {
            this.RaceFinish = position;
        }

        public Vector3 GetFinish() {
            return this.RaceFinish;
        }

        public void SetFacesDirection(int direction) {
            this.SeinFacesDirection = direction;
        }

        public int GetFacesDirection() {
            return this.SeinFacesDirection;
        }

        public void AddCheckpoint(Vector3 position) {
            Checkpoint checkpoint = new Checkpoint();
            checkpoint.x = position.X;
            checkpoint.y = position.Y;

            this.RaceCheckpoints.Add(checkpoint);
        }

        public void RemoveCheckpoint(Vector3 position) {
            int index = -1;

            for (int i = 0; i < this.RaceCheckpoints.Count(); i++) {
                Checkpoint checkpoint = this.RaceCheckpoints[i];

                if (checkpoint.x == position.X && checkpoint.y == position.Y) {
                    index = i;
                }
            }

            if (index != -1) {
                this.RaceCheckpoints.RemoveAt(index);
            }
        }

        public void RemoveCheckpoint(int index) {
            this.RaceCheckpoints.RemoveAt(index);
        }

        public Checkpoint GetCheckpoint(int index) {
            if (index != -1 && this.RaceCheckpoints.Count >= index)
                return this.RaceCheckpoints[index];

            return new Checkpoint();
        }

        public void SetCheckpointPosition(Vector3 position, Vector3 scale, int index) {
            if (this.RaceCheckpoints.Count >= index) {
                this.RaceCheckpoints[index].x = position.X;
                this.RaceCheckpoints[index].y = position.Y;
                this.RaceCheckpoints[index].w = scale.Y;
                this.RaceCheckpoints[index].h = scale.X;
            }
        }

        public List<Checkpoint> GetCheckpoints() {
            return RaceCheckpoints;
        }
    }
    public class EquippedShards {
        public int Shard1 { get; set; } = 0;
        public int Shard2 { get; set; } = 0;
        public int Shard3 { get; set; } = 0;
        public int Shard4 { get; set; } = 0;
        public int Shard5 { get; set; } = 0;
        public int Shard6 { get; set; } = 0;
        public int Shard7 { get; set; } = 0;
        public int Shard8 { get; set; } = 0;
    }

    public class Checkpoint {
        [JsonConverter(typeof(SystemTextJsonSamples.JsonConverterSingle))]
        public float x { get; set; } = 0.0f;
        [JsonConverter(typeof(SystemTextJsonSamples.JsonConverterSingle))]
        public float y { get; set; } = 0.0f;
        [JsonConverter(typeof(SystemTextJsonSamples.JsonConverterSingle))]
        public float w { get; set; } = 3.0f;
        [JsonConverter(typeof(SystemTextJsonSamples.JsonConverterSingle))]
        public float h { get; set; } = 15.0f;
    }

    public class Shard {
        public bool Active { get; set; } = false;
        public int Level { get; set; } = 0;
        public int MaxLevel { get; set; } = 1;
        public int ShardType { get; set; } = 0;
    }

    public class RaceSettingsJSON {
        public string RaceName { get; set; } = "Race";
        public string RaceStart { get; set; } = "0.0f, 0.0f";
        public string RaceFinish { get; set; } = "0.0f, 0.0f";
        public string SeinFacesDirection { get; set; } = "0";
        public string Ability1Bound { get; set; } = "None";
        public string Ability2Bound { get; set; } = "None";
        public string Ability3Bound { get; set; } = "None";
        public List<Checkpoint> RaceCheckpoints {get;set;} = new List<Checkpoint>();
        public Dictionary<string, bool> AbilitiesStates { get; set; } = new Dictionary<string, bool>();
        public EquippedShards EquippedShards { get; set; } = new EquippedShards();
        public List<Shard> ShardsInInventory { get; set; } = new List<Shard>();
    }
}
