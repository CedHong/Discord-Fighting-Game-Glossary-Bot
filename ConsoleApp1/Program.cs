using System;
using System.Configuration;

namespace FGGBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();

            //var word = new Word("Canadian Burst");
            //string text = word.GetDefiniton();
            //Console.WriteLine(text);

        }
    }
}
