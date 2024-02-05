using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class OrderResponse
    {
        [JsonPropertyName("head")]
        public BaseHeaderResponse Header { get; set; }

        [JsonPropertyName("body")]
        public OrderResult Body { get; set; }
    }
}
