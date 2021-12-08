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
        [Command("ping")]
        [Description("Returns pong")]
        public async Task Ping(CommandContext ctx) 
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Adds 2 numbers")]
        public async Task Add(CommandContext ctx, [Description("First Number")] int numOne, [Description("Second Number")] int numTwo)
        {
            await ctx.Channel.SendMessageAsync((numOne + numTwo).ToString()).ConfigureAwait(false);
        }

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
