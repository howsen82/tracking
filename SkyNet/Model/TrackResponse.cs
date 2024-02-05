using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SkyNet
{
    public class TrackResponse
    {
        [JsonPropertyName("trackstatus")]
        public List<Track> TrackStatus { get; set; }
    }
}
