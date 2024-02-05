using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class CourierNumber
    {
        [JsonPropertyName("tracking_number")]
        public string Number { get; set; }

        [JsonPropertyName("tracking_postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("tracking_ship_date")]
        public string ShipDate { get; set; }

        [JsonPropertyName("tracking_account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("slug")]
        public List<string> CourierProvider { get; set; }
    }
}
