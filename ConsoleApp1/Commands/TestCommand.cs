using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace FGGBot.Commands
{
    public class TestCommand: BaseCommandModule
    {
        [Command("define")]
        [Description("Grabs definition of a word from infil fighting game glossary")]
        public async Task Define(CommandContext ctx, [Description("First Part of Fighting Game Term")] string word1, [Description("First Part of Fighting Game Term")] string word2)
        {
            DiscordEmbedBuilder message = new DiscordEmbedBuilder();
            string term = word1 + " " + word2;
            Word word = new Word(term);
            string definition = word.GetDefiniton();
            message.WithAuthor(term);
            message.WithDescription(definition);
            await ctx.Channel.SendMessageAsync(message).ConfigureAwait(false);
        }

        [Command("define")]
        [Description("Grabs definition of a word from infil fighting game glossary")]
        public async Task Define(CommandContext ctx, [Description("Fighting Game Term")] string term)
        {
            DiscordEmbedBuilder message = new DiscordEmbedBuilder();
            Word word = new Word(term);
            string definition = word.GetDefiniton();
            message.WithAuthor(term);
            message.WithDescription(definition);
            await ctx.Channel.SendMessageAsync(message).ConfigureAwait(false);
        }
    }
}
