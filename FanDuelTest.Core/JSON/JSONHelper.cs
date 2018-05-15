using FanDuelTest.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace FanDuelTest.Core.JSON
{
    public class JSONHelper
    {

        public const string PLAYERS_URL = "https://gist.githubusercontent.com/liamjdouglas/bb40ee8721f1a9313c22c6ea0851a105/raw/6b6fc89d55ebe4d9b05c1469349af33651d7e7f1/Player.json";

        /// <summary>
        /// Downloads JSON data using the PLAYERS_URL constant value
        /// </summary>
        /// <returns></returns>
        public static async Task<string> DownloadJSON()
        {
            string retvar = String.Empty;

            HttpClient client = new HttpClient();

            //download player data
            retvar = await client.GetStringAsync(PLAYERS_URL);

            //return json
            return retvar;
        }

        /// <summary>
        /// Deseralizes player json into Playerlist business object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static PlayerList DeserializeJSON(string json)
        {
            //deserialize json parameter into Playerlist object
            var retvar = JsonConvert.DeserializeObject<PlayerList>(json);

            //return playerlist object
            return retvar;

        }

    }
}
