using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class ResponseHeader
    {
        [JsonPropertyName("head")]
        public BaseHeaderResponse Header { get; set; }

        [JsonPropertyName("body")]
        public BaseBodyResponse Body { get; set; }
    }
}
