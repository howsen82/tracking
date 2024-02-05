using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SkyNet
{
    public class Item
    {
        [JsonPropertyName("AWBNo")]
        public string AirwayBillNo { get; set; }
    }
}
