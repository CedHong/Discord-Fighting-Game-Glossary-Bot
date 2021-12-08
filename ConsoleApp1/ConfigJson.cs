using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FGGBot
{
    public class ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
