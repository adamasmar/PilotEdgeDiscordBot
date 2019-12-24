using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxMetaModel
    {
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
    }
}