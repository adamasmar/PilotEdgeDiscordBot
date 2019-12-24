using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxAltimeterModel
    {
        [JsonPropertyName("repr")]
        public string Repr { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("spoken")]
        public string Spoken { get; set; }
    }
}