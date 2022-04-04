﻿using Newtonsoft.Json;

namespace OsuSharp.JsonModels;

public class CursorJsonModel : JsonModel
{
    [JsonProperty("approved_date")]
    public string ApprovedDate { get; set; } = null!;

    [JsonProperty("_id")]
    public string Id { get; set; } = null!;
}