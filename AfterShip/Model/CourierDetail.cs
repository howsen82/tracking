using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class CourierDetail
    {
        [JsonPropertyName("slug")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("other_name")]
        public string OtherName { get; set; }

        [JsonPropertyName("web_url")]
        public string WebURL { get; set; }

        [JsonPropertyName("required_fields")]
        public List<string> RequiredFields { get; set; }

        [JsonPropertyName("optional_fields")]
        public List<string> OptionalFields { get; set; }
    }
}
