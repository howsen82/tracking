using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class Courier
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("couriers")]
        public List<CourierDetail> Details { get; set; }
    }
}
