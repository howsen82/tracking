using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class PlaceOrderRequest
    {
        [JsonPropertyName("head")]
        public TransactionHeader Header { get; set; }

        [JsonPropertyName("body")]
        public PlaceOrder Order { get; set; }
    }
}
