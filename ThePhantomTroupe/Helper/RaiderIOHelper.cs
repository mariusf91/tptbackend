using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ThePhantomTroupe.Models;

namespace ThePhantomTroupe.Helper
{
    public class RaiderIOHelper
    {
        readonly string baseUrl = "https://raider.io/api/v1/{0}/{1}?region=eu&realm=draenor&name={2}";

        public RaiderIOCharacter GetCharacter(string name)
        {
            var url = string.Format(baseUrl, "characters", "profile", name);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<RaiderIOCharacter>(result);
            }

        }
    }
}