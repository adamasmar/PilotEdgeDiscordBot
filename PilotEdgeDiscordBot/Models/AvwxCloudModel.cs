using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxCloudModel
    {
        [JsonPropertyName("repr")]
        public string Repr { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("altitude")]
        public long Altitude { get; set; }

        [JsonPropertyName("modifier")]
        public object Modifier { get; set; }

        [JsonPropertyName("direction")]
        public object Direction { get; set; }
    }
}