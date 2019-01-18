using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThePhantomTroupe.Models
{
    [BsonIgnoreExtraElements]
    public class RaiderIOCharacter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("active_spec_name")]
        public string ActiveSpecName { get; set; }

        [JsonProperty("active_spec_role")]
        public string ActiveSpecRole { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("achievement_points")]
        public string AchievementPoints { get; set; }

        [JsonProperty("honorable_kills")]
        public string HonorableKills { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("realm")]
        public string Realm { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }
    }
}