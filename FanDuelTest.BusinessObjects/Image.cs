using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuelTest.BusinessObjects
{
    public class Images
    {
        [JsonProperty("default")]
        public DefaultImage DefaultImageInfo { get; set; }
    }
}
