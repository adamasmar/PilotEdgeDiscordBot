using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxRemarksInfoModel
    {
        [JsonPropertyName("dewpoint_decimal")]
        public AvwxAltimeterModel DewpointDecimal { get; set; }

        [JsonPropertyName("temperature_decimal")]
        public AvwxAltimeterModel TemperatureDecimal { get; set; }
    }
}