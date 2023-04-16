
using DSharpPlus;
using DSharpPlus.CommandsNext;
using SwanticBossBotV2.Commands;

namespace SwanticBossBotV2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "OTQ2NDM1MDcyNzMzNjE0MTUw.YheqWQ.sQ4qNeSW1F9FBVnshEeNPlZVrOQ",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "!" }
            });

            commands.RegisterCommands<SwanticBotCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}