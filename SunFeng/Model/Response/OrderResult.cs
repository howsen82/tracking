using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class OrderResult
    {
        [JsonPropertyName("filterLevel")]
        public string FilterLevel { get; set; }
        
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
        
        [JsonPropertyName("orderTriggerCondition")]
        public string OrderTriggerCondition { get; set; }
        
        [JsonPropertyName("remarkCode")]
        public string RemarkCode { get; set; }
    }
}
