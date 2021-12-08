using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace FGGBot
{
    public class Word
    {
        public string text { get; set; }
        public IWebDriver driver { get; set; }
        public Word() 
        {
            this.text = null;
        }

        public Word(string text) 
        {
            this.text = text;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Url = "https://glossary.infil.net/?t=" + text;
        }

        public string GetDefiniton() 
        {
            string definition = null;
            var multipleDefinitions = driver.FindElements(By.ClassName("subname"));
            var definitionElement = driver.FindElements(By.ClassName("def"));
            Console.WriteLine(text);

            if (multipleDefinitions.Count > 0)
            {
                string matchingWord = null;
                int i = 0;
                bool noMatch = true;

                do
                {
                    matchingWord = multipleDefinitions[i].Text;
                    matchingWord = matchingWord.Replace("Also known as: ", "");
                    if (string.Equals(text, matchingWord, StringComparison.OrdinalIgnoreCase))
                    {
                        noMatch = false;
                        var linkElement = driver.FindElements(By.ClassName("linkToTerm"));
                        var linkAttribute = linkElement[i].GetAttribute("href");
                        driver.Url = linkAttribute;
                        multipleDefinitions = driver.FindElements(By.ClassName("def"));
                        definition = multipleDefinitions[0].Text;
                        i = multipleDefinitions.Count;
                    }

                    i++;

                } while (noMatch || i < multipleDefinitions.Count);

            }
            else if (definitionElement.Count > 0)
            {
                definition = definitionElement[0].Text;
            }
            else 
            {
                definition = "No available definition for that word";
            }

            return definition;
        }
    }
}
