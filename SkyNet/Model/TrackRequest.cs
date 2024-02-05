using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SkyNet
{
    public class TrackRequest
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}
