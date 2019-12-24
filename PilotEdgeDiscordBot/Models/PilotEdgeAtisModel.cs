using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class PilotEdgeAtisModel
    {
        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("has_d_atis")]
        public bool HasDAtis { get; set; }

        [JsonPropertyName("letter")]
        public string Letter { get; set; }

        [JsonPropertyName("metar")]
        public string Metar { get; set; }

        [JsonPropertyName("arriving_runways")]
        public string ArrivingRunways { get; set; }

        [JsonPropertyName("departing_runways")]
        public string DepartingRunways { get; set; }

        [JsonPropertyName("approaches")]
        public string Approaches { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
