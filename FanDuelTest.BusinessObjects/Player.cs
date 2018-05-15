using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuelTest.BusinessObjects
{
    public class Player
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("fppg")]
        public double? FPPG { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("injured")]
        public bool Injured { get; set; }

        [JsonProperty("injury_details")]
        public string InjuryDetails { get; set; }

        [JsonProperty("injury_status")]
        public string InjuryStatus { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("played")]
        public int? Played { get; set; }
        
        [JsonProperty("player_card_url")]
        public string PlayerCardURL { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("removed")]
        public bool Removed { get; set; }

        [JsonProperty("salary")]
        public int Salary { get; set; }

        [JsonProperty("starting_order")]
        public object StartingOrder { get; set; }


        public string FullName {  get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
