using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class CourierResponse
    {
        [JsonPropertyName("meta")]
        public MetaBase Meta { get; set; }

        [JsonPropertyName("data")]
        public Courier Data { get; set; }
    }
}
