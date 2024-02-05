using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class MetaBase
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
