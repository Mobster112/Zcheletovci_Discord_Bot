﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Zcheletovci_Discord_Bot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        [Command("about")]
        public async Task About()
        {
            var embed = new EmbedBuilder();
            embed.WithAuthor(new EmbedAuthorBuilder
            {
                Name = "Zcheletovci Bot",
                IconUrl = "https://cdn.discordapp.com/avatars/427814230117580810/d9dd5153d54e5bf1c33892503c96b560.png",
            });
            embed.WithColor(100, 0, 200);
            embed.WithTitle("About the Zcheletovci Bot");
            embed.WithDescription("This bot is meant to be used in the SS Zcheletovci Total Autism™ Discord server");
            embed.AddField(new EmbedFieldBuilder
            {
                Name = "Built by",
                Value = MentionUtils.MentionUser(261217297039884300),
                IsInline = false
            });
            embed.AddField(new EmbedFieldBuilder
            {
                Name = "Built using",
                Value = "Microsoft Visual Studio C#",
                IsInline = false
            });
            embed.WithFooter(new EmbedFooterBuilder
            {
                IconUrl = "https://cdn.discordapp.com/attachments/387541466815135746/467015804819603486/Marok_Navija.png",
                Text = "Marko Maršić ©"
            });
            embed.WithTimestamp(new DateTimeOffset(new DateTime(2018, 7, 23, 14, 00, 00)));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("silence")]
        public async Task Silence()
        {
            int numMuted = 0;
            List<string> mutedUsers = new List<string>();

            var channels = Context.Guild.VoiceChannels;
            foreach (var channel in channels)
            {
                if (channel.Users.Contains(Context.User))
                {
                    foreach(var user in channel.Users)
                    {
                        if(user.Id != Context.User.Id)
                        {
                            mutedUsers.Add(user.Mention);
                            await (user as IGuildUser)?.ModifyAsync(x =>
                            {
                                x.Mute = true;
                                numMuted++;
                            });
                        }
                    }
                    break;
                }
            }
            string msg = String.Format("{0} users have been muted:\n", numMuted);

            int i = 1;

            foreach(var user in mutedUsers)
            {
                msg += String.Format("{0}.) {1}\n", i, user);
                i++;
            }

            await Context.Channel.SendMessageAsync(msg);
        }

        [Command("unmute")]
        public async Task Unmute()
        {
            foreach (var user in Context.Guild.Users)
            {
                if (user.IsMuted)
                {
                    await (user as IGuildUser)?.ModifyAsync(x =>
                    {
                        x.Mute = false;
                    });
                }
            }

            await Context.Channel.SendMessageAsync("Unmuted everyone!");
        }
    }
}