using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class CourierRequest
    {
        [JsonPropertyName("tracking")]
        public CourierNumber Tracking { get; set; }
    }
}
