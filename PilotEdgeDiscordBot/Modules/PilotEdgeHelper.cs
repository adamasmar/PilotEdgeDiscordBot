using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Discord;
using PilotEdgeDiscordBot.Models;

namespace PilotEdgeDiscordBot.Modules
{
    public class PilotEdgeHelper
    {
        public static async Task<PilotEdgeAtisModel[]> GetLatestPilotEdgeAtisModelsAsync()
        {
            var jsonFile = await DownloadJsonTask("https://www.pilotedge.net/atis/all.json");

            var pilotEdgeAtisModels = JsonSerializer.Deserialize<PilotEdgeAtisModel[]>(jsonFile);
            return pilotEdgeAtisModels;
        }

        public static async Task<string> DownloadJsonTask(string url)
        {
            try
            {
                using var client = new HttpClient();
                using var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception exception)
            {
                return $@"Error downloading PilotEdge data{Environment.NewLine}{exception.Message}";
            }

            return null;
        }

        public static Dictionary<string, Emoji> AlphabetEmojiDictionary = new Dictionary<string, Emoji>
        {
            { "A", new Emoji("\uD83C\uDDE6")},
            { "B", new Emoji("\uD83C\uDDE7")},
            { "C", new Emoji("\uD83C\uDDE8")},
            { "D", new Emoji("\uD83C\uDDE9")},
            { "E", new Emoji("\uD83C\uDDEA")},
            { "F", new Emoji("\uD83C\uDDEB")},
            { "G", new Emoji("\uD83C\uDDEC")},
            { "H", new Emoji("\uD83C\uDDED")},
            { "I", new Emoji("\uD83C\uDDEE")},
            { "J", new Emoji("\uD83C\uDDEF")},
            { "K", new Emoji("\uD83C\uDDF0")},
            { "L", new Emoji("\uD83C\uDDF1")},
            { "M", new Emoji("\uD83C\uDDF2")},
            { "N", new Emoji("\uD83C\uDDF3")},
            { "O", new Emoji("\uD83C\uDDF4")},
            { "P", new Emoji("\uD83C\uDDF5")},
            { "Q", new Emoji("\uD83C\uDDF6")},
            { "R", new Emoji("\uD83C\uDDF7")},
            { "S", new Emoji("\uD83C\uDDF8")},
            { "T", new Emoji("\uD83C\uDDF9")},
            { "U", new Emoji("\uD83C\uDDFA")},
            { "V", new Emoji("\uD83C\uDDFB")},
            { "W", new Emoji("\uD83C\uDDFC")},
            { "X", new Emoji("\uD83C\uDDFD")},
            { "Y", new Emoji("\uD83C\uDDFE")},
            { "Z", new Emoji("\uD83C\uDDFF")}
        };

        public static Dictionary<string, Emoji> FlightConditionEmojiDictionary = new Dictionary<string, Emoji>
        {
            {"VFR", new Emoji("\uD83D\uDFE2")},
            {"MVFR", new Emoji("\uD83D\uDD35")},
            {"IFR", new Emoji("\uD83D\uDD34")},
            {"LIFR", new Emoji("\uD83D\uDFE3")}
        };
    }
}
