using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class AddressInfo
    {
        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("contact")]
        public string Contact { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("mobile")]
        public string Mobile { get; set; }

        [JsonPropertyName("shipperCode")]
        public string ShipperCode { get; set; }
        
        [JsonPropertyName("tel")]
        public string Telephone { get; set; }
    }
}
