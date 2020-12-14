﻿using Newtonsoft.Json;
using System;

namespace OsuSharp.Entities
{
    public sealed class KudosuHistory
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("action")]
        public KudosuAction Action { get; internal set; }

        [JsonProperty("amount")]
        public long Amount { get; internal set; }

        //todo: make enum
        [JsonProperty("model")]
        public string Model { get; internal set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; internal set; }

        [JsonProperty("giver")]
        public Optional<KudosuGiver> Giver { get; internal set; }

        [JsonProperty("post")]
        public Optional<KudosuPost> Post { get; internal set; }

        internal KudosuHistory()
        {

        }
    }
}