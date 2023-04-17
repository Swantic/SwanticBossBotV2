using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SwanticBossBotV2.Commands
{
    internal class SwanticBotCommands : BaseCommandModule
    {
        

        [Command("BossRequirements"), Description("Shows all boss requirements")]
        public async Task Requirements(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Required Stats",
                Description =
                    $"Nlucid Requirements are 22k Main Stat and 540 AF\n" +
                    $"Nwill Requirements are 22k Main Stat, Level 250 and 1140 AF\n" +
                    $"The Hlucid Requirements are 3T BA\n" +
                    $"The Hwill Requirements are 3T BA\n"
            };
            await ctx.RespondAsync(embed);
        }

        [Command("addTime"), Description("Adds time in seconds  Example: !addTime day 100")]
        public async Task Poll(CommandContext ctx, [Description("Amount")] string amount,
            [Description("Base time")] int time)
        {

            if (amount == "Hour" || amount == "hour")
            {
                time += 3600;
            }
            else if ((amount == "halfhour" || amount == "Halfhour"))
            {
                time += 1800;
            }
            else if ((amount == "day" || amount == "Day"))
            {
                time += 86400;
            }
            else if ((amount == "week" || amount == "Week"))
            {
                time += 604800;
            }
            else if ((amount == "Month" || amount == "Month"))
            {
                time += 2629743;
            }
            else if ((amount == "Year" || amount == "Year"))
            {
                time += 31556926;
            }

            DateTimeOffset swantic = new DateTimeOffset();
            var embed = new DiscordEmbedBuilder
            {
                Title = "Time Extender",
                Description = $"New time is {time}"
            };
            await ctx.RespondAsync(embed);
        }


        [Command("GenerateTimes"), Description("Generates list of times starting at Maplestory reset 0 Example: !GenerateTimes -1(Number of hours from reset), 1(Number of hours to generate), 1 (1 hours interval add .5 to do every half hour), 5/1/2008(Date to Generate) Copy: !GenerateTimes -1 5 1 5/1/2008")]
        public async Task GenerateTimes(CommandContext ctx, [Description("StartTime")] double startTime,
            [Description("Number of repetitions")] int timeSpan, [Description("Interval")] double interval, [Description("BossDay")] string bossingDay)
        {
            int spamproc = 0;
            DateTime DateofRun = DateTime.Parse(bossingDay);
            DateofRun = DateofRun.AddHours(startTime);
            DateofRun = DateTime.SpecifyKind(DateofRun, DateTimeKind.Utc);
            DateTimeOffset datetimeconversionstart = DateofRun;
            DateTime MapletimeStart = DateTime.UtcNow;
            for (double i = 0; i < timeSpan; i+= interval)
            {
                if (spamproc<20)
                {
                    DateTimeOffset datetimeconversionend = datetimeconversionstart.AddHours(i);
                    await ctx.Channel.SendMessageAsync("<t:" + datetimeconversionend.ToUnixTimeSeconds().ToString() + ":f>");
                    spamproc++;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("The bot is spamming the discord and will not complete the command.");
                    return;
                }

            }
            
        }
        [Command("GenerateTimes"), Description("GeneratesExample of time for Times")]
        public async Task GenerateTimes(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Generates list of times starting at Maplestory reset 0 Example: !GenerateTimes -1(Number of hours from reset), 1(Number of hours to generate), 1 (1 hours interval add .5 to do every half hour), 5/1/2008(Date to Generate) Copy: !GenerateTimes -1 5 1 5/1/2008");
            
        }
    }
}
