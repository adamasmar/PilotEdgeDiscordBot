using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PilotEdgeDiscordBot.Models;

namespace PilotEdgeDiscordBot.Modules
{
    internal class AvwxHelpers
    {
        public static async Task<AvwxMainModel> GetAvwxMetarTaskAsync(string icao)
        {
            try
            {
                using var httpClient = new HttpClient { BaseAddress = new Uri("https://avwx.rest/api/") };
                if (!httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization",
                    ApiKeysHelper.ApiKeysModelDeserialized().AvwxToken)) return null;
                using var response = await httpClient.GetAsync(@$"metar/{icao}");

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    File.Delete(Program.ApiKeysPath);
                    Console.WriteLine(
                        @"There was an error with your Avwx authorization token. To streamline its correction, both Discord Bot and Avwx keys have been deleted and the application will now close. When you next restart the application, you will be provided an opportunity to enter the corrected API keys.");
                    Environment.Exit(0);
                }

                var responseData = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<AvwxMainModel>(responseData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
