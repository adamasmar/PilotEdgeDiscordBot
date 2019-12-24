using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace PilotEdgeDiscordBot.Modules
{
    public class DiscordBotSetup
    {
        private DiscordSocketClient _discordSocketClient;
        private CommandService _commandService;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _discordSocketClient = new DiscordSocketClient();
            _commandService = new CommandService();
            _services = new ServiceCollection().AddSingleton(_discordSocketClient).AddSingleton(_commandService)
                .BuildServiceProvider();

            _discordSocketClient.Log += DiscordSocketClient_Log;
            await RegisterCommandsAsync();
            await _discordSocketClient.LoginAsync(TokenType.Bot, ApiKeysHelper.ApiKeysModelDeserialized().DiscordBotToken);
            await _discordSocketClient.StartAsync();
            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            _discordSocketClient.MessageReceived += DiscordSocketClient_MessageReceivedAsync;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private static Task DiscordSocketClient_Log(LogMessage arg)
        {
            Console.WriteLine(arg.Message);
            return Task.CompletedTask;
        }

        private async Task DiscordSocketClient_MessageReceivedAsync(SocketMessage arg)
        {
            if (arg is SocketUserMessage socketUserMessage)
            {
                var context = new SocketCommandContext(_discordSocketClient, socketUserMessage);
                if (socketUserMessage.Author.IsBot) return;

                var argumentPosition = 0;

                if (socketUserMessage.HasStringPrefix("-", ref argumentPosition))
                {
                    var result = await _commandService.ExecuteAsync(context, argumentPosition, _services);
                    if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
