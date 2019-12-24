using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PilotEdgeDiscordBot.Models
{
    public partial class AvwxMainModel
    {
        [JsonPropertyName("meta")]
        public AvwxMetaModel Meta { get; set; }

        [JsonPropertyName("altimeter")]
        public AvwxAltimeterModel Altimeter { get; set; }

        [JsonPropertyName("clouds")]
        public List<AvwxCloudModel> Clouds { get; set; }

        [JsonPropertyName("flight_rules")]
        public string FlightRules { get; set; }

        [JsonPropertyName("other")]
        public List<object> Other { get; set; }

        [JsonPropertyName("sanitized")]
        public string Sanitized { get; set; }

        [JsonPropertyName("visibility")]
        public AvwxAltimeterModel Visibility { get; set; }

        [JsonPropertyName("wind_direction")]
        public AvwxAltimeterModel WindDirection { get; set; }

        [JsonPropertyName("wind_gust")]
        public object WindGust { get; set; }

        [JsonPropertyName("wind_speed")]
        public AvwxAltimeterModel WindSpeed { get; set; }

        [JsonPropertyName("raw")]
        public string Raw { get; set; }

        [JsonPropertyName("station")]
        public string Station { get; set; }

        [JsonPropertyName("time")]
        public AvwxTimeModel Time { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("dewpoint")]
        public AvwxAltimeterModel Dewpoint { get; set; }

        [JsonPropertyName("remarks_info")]
        public AvwxRemarksInfoModel RemarksInfo { get; set; }

        [JsonPropertyName("runway_visibility")]
        public List<object> RunwayVisibility { get; set; }

        [JsonPropertyName("temperature")]
        public AvwxAltimeterModel Temperature { get; set; }

        [JsonPropertyName("wind_variable_direction")]
        public List<object> WindVariableDirection { get; set; }

        [JsonPropertyName("units")]
        public AvwxUnitsModel Units { get; set; }
    }
}
