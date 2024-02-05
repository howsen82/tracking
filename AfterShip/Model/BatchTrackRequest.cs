using System;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class BatchTrackRequest
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// tracking_number, title, order_id,
        /// customer_name, custom_fields, order_id, emails,
        /// smses
        /// </summary>
        [JsonPropertyName("keyword")]
        public string Keyword { get; set; }

        [JsonPropertyName("slug")]
        public string CourierName { get; set; }

        [JsonPropertyName("delivery_time")]
        public int DeliveryTime { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("tag")]
        public StatusTag Tag { get; set; }

        [JsonPropertyName("created_at_min")]
        public DateTime CreatedAtMin { get; set; }

        [JsonPropertyName("created_at_max")]
        public DateTime CreatedAtMax { get; set; }

        /// <summary>
        /// title, order_id, tag,
        /// checkpoints, checkpoint_time, message,
        /// country_name
        /// </summary>
        [JsonPropertyName("fields")]
        public string Fields { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; }
    }
}
