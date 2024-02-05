using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class PlaceOrder
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("mailNo")]
        public string MailNumbering { get; set; }

        [JsonPropertyName("origincode")]
        public string OriginCode { get; set; }

        [JsonPropertyName("destcode")]
        public string DestinationCode { get; set; }

        [JsonPropertyName("filterResult")]
        public string FilterResult { get; set; }

        [JsonPropertyName("returnTrackingNo")]
        public string TrackingNumber { get; set; }
    }
}
