using System;
using System.IO;
using System.Text.Json;
using PilotEdgeDiscordBot.Models;
using PilotEdgeDiscordBot.Modules;

namespace PilotEdgeDiscordBot
{
    internal class Program//
    {
        public static string ApiKeysPath;

        private static void Main()
        {
            try
            {
                InitializeProgram();
            }
            catch (Exception)
            {
                File.Delete(ApiKeysPath);
                Console.WriteLine(@"There was an issue with your getting your API tokens. Follow the prompts to reenter them and we can give it another shot.");
                try
                {
                    InitializeProgram();
                }
                catch (Exception)
                {
                    File.Delete(ApiKeysPath);
                    Console.WriteLine(
                        @"There was an error attempting to set up your tokens. The program will now invalidate the API key file and close. When you start up next time, you may attempt to reenter the API keys.");
                }
            }
        }

        private static void InitializeProgram()
        {
            SetUpApiKeys();
            new DiscordBotSetup().RunBotAsync().GetAwaiter().GetResult();
        }

        private static void SetUpApiKeys()
        {
            var apiConfigRootPath = $@"{Directory.GetCurrentDirectory()}\JsonConfigFiles\";
            const string apiConfigFileName = "ApiKeys.json";
            ApiKeysPath = $@"{apiConfigRootPath}\{apiConfigFileName}";

            if (File.Exists(ApiKeysPath)) return;

            var apiKeysModel = new ApiKeysModel();

            while (true)
            {
                Console.WriteLine(@"Enter Discord Bot API Key");
                var userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput)) continue;
                apiKeysModel.DiscordBotToken = userInput;
                break;
            }

            while (true)
            {
                Console.WriteLine(@"Enter Avwx API Key");
                var userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput)) continue;
                apiKeysModel.AvwxToken = userInput;
                break;
            }

            var apiKeysModelSerialize = JsonSerializer.Serialize(apiKeysModel);
            Directory.CreateDirectory(apiConfigRootPath);
            using var streamWriter = new StreamWriter(ApiKeysPath, true);
            streamWriter.WriteLine(apiKeysModelSerialize);
            streamWriter.Close();
        }
    }
}
