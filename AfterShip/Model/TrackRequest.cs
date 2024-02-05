using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class TrackRequest
    {
        /// <summary>
        /// tracking_postal_code,tracking_ship_date,tracking_account_number,
        /// tracking_key,tracking_origin_country,tracking_destination_country,
        /// tracking_state,title,order_id,tag,checkpoints,
        /// checkpoint_time, message, country_name
        /// </summary>
        [JsonPropertyName("fields")]
        public string Fields { get; set; }

        /// <summary>
        /// china-ems
        /// china-post
        /// </summary>
        [JsonPropertyName("lang")]
        public string Language { get; set; }
    }
}
