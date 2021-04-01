﻿using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BridgeMonitory.Models
{
    public class HoraireList
    {
        [JsonPropertyName("boat_name")]
        public string BoatName { get; set; }

        [JsonPropertyName("closing_type")]
        public string ClosingType { get; set; }

        [JsonPropertyName("closing_date")]
        public DateTime ClosingDate { get; set; }

        [JsonPropertyName("reopening_date")]
        public DateTime ReopeningDate { get; set; }
    }
}
