using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class Cargo
    {
        [JsonPropertyName("cargo")]
        public string Description { get; set; }
        
        [JsonPropertyName("cargoAmount")]
        public string Amount { get; set; }

        [JsonPropertyName("cargoCount")]
        public string Count { get; set; }

        [JsonPropertyName("cargoIndex")]
        public int Index { get; set; }

        [JsonPropertyName("cargoTotalWeight")]
        public int TotalWeight { get; set; }

        [JsonPropertyName("cargoUnit")]
        public string Unit { get; set; }

        [JsonPropertyName("cargoWeight")]
        public string Weight { get; set; }

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("parcelQuantity")]
        public int ParcelQuantity { get; set; }
    }
}
