using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public class ApiKeysModel
    {
        [JsonPropertyName("discordBotToken")]
        public string DiscordBotToken { get; set; }
        [JsonPropertyName("avwxToken")]
        public string AvwxToken { get; set; }
    }
}
