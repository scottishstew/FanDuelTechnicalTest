using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuelTest.BusinessObjects
{
    public class DefaultImage
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
