using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class BaseHeaderResponse : TransactionHeader
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
