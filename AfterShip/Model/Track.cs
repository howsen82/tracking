using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class Track
    {
        [JsonPropertyName("page")]
        public int PageNumber { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("keyword")]
        public string Keyword { get; set; }

        [JsonPropertyName("slug")]
        public string CourierName { get; set; }

        [JsonPropertyName("origin")]
        public List<string> Origin { get; set; }

        [JsonPropertyName("destination")]
        public List<string> Destination { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("fields")]
        public string Fields { get; set; }

        [JsonPropertyName("created_at_min")]
        public DateTime CreatedAtMin { get; set; }

        [JsonPropertyName("created_at_max")]
        public DateTime CreatedAtMax { get; set; }

        [JsonPropertyName("last_updated_at")]
        public DateTime? LastUpdated { get; set; }

        [JsonPropertyName("return_to_sender")]
        public List<string> ReturnSenders { get; set; }

        [JsonPropertyName("courier_destination_country_iso3")]
        public List<string> CourierDestinationCountry { get; set; }

        [JsonPropertyName("trackings")]
        public List<TrackInfo> Trackings { get; set; }
    }
}
