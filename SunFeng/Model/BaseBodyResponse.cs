using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class BaseBodyResponse : TransactionBody
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
