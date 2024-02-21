using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordHackerBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "MTE5OTY2MjQwOTQ0NzY0MTE0OQ.GohuGs.4jUAqnDOseCb1N8poyCoJc2TljtoJNpufl9ARU",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discordClient.MessageCreated += OnMessageCreated;
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs msg)
        {
            if (msg is not null)
            {
                await msg.Message.RespondAsync("HackerBug!");
            }
        }
    }
}
