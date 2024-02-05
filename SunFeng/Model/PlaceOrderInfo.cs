using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class PlaceOrderInfo
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
    }
}
