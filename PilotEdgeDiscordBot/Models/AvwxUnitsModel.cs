using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxUnitsModel
    {
        [JsonPropertyName("altimeter")]
        public string Altimeter { get; set; }

        [JsonPropertyName("altitude")]
        public string Altitude { get; set; }

        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public string WindSpeed { get; set; }
    }
}