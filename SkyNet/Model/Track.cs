using System;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SkyNet
{
    public class Track
    {
        [JsonPropertyName("Order_No")]
        public string OrderNo { get; set; }

        [JsonPropertyName("Tracking_No")]
        public string TrackingNo { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("Delivery_Date")]
        public DateTime DeliveryDate { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Location")]
        public string Location { get; set; }

        [JsonPropertyName("DeliveryDate")]
        public string DeliverDate { get; set; }

        [JsonPropertyName("DeliveryTime")]
        public string DeliverTime { get; set; }
    }
}
