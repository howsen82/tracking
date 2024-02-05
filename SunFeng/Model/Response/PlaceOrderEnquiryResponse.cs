using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class PlaceOrderEnquiryResponse
    {
        [JsonPropertyName("head")]
        public BaseHeaderResponse Header { get; set; }

        [JsonPropertyName("body")]
        public PlaceOrderInfo Body { get; set; }
    }
}
