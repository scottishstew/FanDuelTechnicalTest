using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuelTest.BusinessObjects
{
    public class PlayerList
    {
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}
