using System.IO;
using System.Text.Json;
using PilotEdgeDiscordBot.Models;

namespace PilotEdgeDiscordBot.Modules
{
    internal class ApiKeysHelper
    {
        public static ApiKeysModel ApiKeysModelDeserialized()
        {
            if (!File.Exists(Program.ApiKeysPath)) return null;
            using var streamReader = new StreamReader(Program.ApiKeysPath);
            var pilotEdgeAtisModels = JsonSerializer.Deserialize<ApiKeysModel>(streamReader.ReadLine());
            return pilotEdgeAtisModels;
        }
    }
}
