using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxTimeModel
    {
        [JsonPropertyName("repr")]
        public string Repr { get; set; }

        [JsonPropertyName("dt")]
        public string Dt { get; set; }
    }
}