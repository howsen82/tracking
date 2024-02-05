using System;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.OAuth2
{
    public class BIShunFengToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("acquire_time")]
        public DateTime AcquireTime { get; set; }
    }
}
