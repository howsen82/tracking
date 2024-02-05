using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class OrderRequest
    {
        [JsonPropertyName("head")]
        public TransactionHeader Header { get; set; }

        [JsonPropertyName("body")]
        public Order Order { get; set; }

        [JsonPropertyName("cargoInfo")]
        public Cargo Cargo { get; set; }

        [JsonPropertyName("addedServices")]
        public List<AddedService> AddedServices { get; set; }
    }
}
