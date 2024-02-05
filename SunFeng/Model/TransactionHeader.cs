using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class TransactionHeader
    {
        [JsonPropertyName("transType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("transMessageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
