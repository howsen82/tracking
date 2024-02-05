using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class Checkpoint
    {
        [JsonPropertyName("slug")]
        public string CourierProvider { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("country_iso3")]
        public string CountryISO { get; set; }

        [JsonPropertyName("tag")]
        public StatusTag Tag { get; set; }

        [JsonPropertyName("subtag")]
        public string Subtag { get; set; }

        [JsonPropertyName("subtag_message")]
        public string SubtagMessage { get; set; }

        [JsonPropertyName("checkpoint_time")]
        public string CheckpointTime { get; set; }

        [JsonPropertyName("coordinates")]
        public List<string> Coordinates { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}
