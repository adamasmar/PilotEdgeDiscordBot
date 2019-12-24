using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;

namespace PilotEdgeDiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("atis")]
        public async Task GetAtisAsync(string icao)
        {
            var pilotEdgeAtisModels = await PilotEdgeHelper.GetLatestPilotEdgeAtisModelsAsync();
            var pilotEdgeAtisModelResult = pilotEdgeAtisModels.FirstOrDefault(x => icao != null && x.Icao == icao.ToUpper());

            var avwxAtisModelsResult = await AvwxHelpers.GetAvwxMetarTaskAsync(icao);

            if (pilotEdgeAtisModelResult != null)
            {
                var message = await Context.Channel.SendMessageAsync($@"```{pilotEdgeAtisModelResult.Text}```");
                await message.AddReactionAsync(PilotEdgeHelper.AlphabetEmojiDictionary
                    .FirstOrDefault(x => x.Key == pilotEdgeAtisModelResult.Letter).Value);
                await message.AddReactionAsync(PilotEdgeHelper.FlightConditionEmojiDictionary
                    .FirstOrDefault(x => x.Key == avwxAtisModelsResult.FlightRules).Value);
            }
            else
            {
                await ReplyAsync(
                    $@"No PilotEdge ATIS was found for ``{icao.ToUpper()}``. Attempting to get METAR instead...");
                await GetMetarAsync(icao);
            }
        }

        [Command("metar")]
        public async Task GetMetarAsync(string icao)
        {
            var avwxAtisModelResult = await AvwxHelpers.GetAvwxMetarTaskAsync(icao);
            if (avwxAtisModelResult.Raw != null)
            {
                var message = await Context.Channel.SendMessageAsync($@"```{avwxAtisModelResult.Raw}```");
                await message.AddReactionAsync(PilotEdgeHelper.FlightConditionEmojiDictionary
                    .FirstOrDefault(x => x.Key == avwxAtisModelResult.FlightRules).Value);
            }
            else
            {
                await ReplyAsync(
                    $@"No METAR found for ``{icao.ToUpper()}``!");
            }
        }
    }
}
