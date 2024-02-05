using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class RequestHeader
    {
        [JsonPropertyName("head")]
        public TransactionHeader Header { get; set; }

        [JsonPropertyName("body")]
        public TransactionBody Body { get; set; }
    }
}
