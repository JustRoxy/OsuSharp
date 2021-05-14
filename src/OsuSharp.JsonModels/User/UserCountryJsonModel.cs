﻿using Newtonsoft.Json;

namespace OsuSharp.JsonModels
{
    public class UserCountryJsonModel : JsonModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}