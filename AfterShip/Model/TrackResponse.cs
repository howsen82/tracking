using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class TrackResponse
    {
        [JsonPropertyName("meta")]
        public MetaBase Meta { get; set; }

        [JsonPropertyName("data")]
        public Track Data { get; set; }
    }
}
