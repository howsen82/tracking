using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class AddedService
    {
        [JsonPropertyName("CUSTID")]
        public string CustomerId { get; set; }

        [JsonPropertyName("COD")]
        public string COD { get; set; }

        [JsonPropertyName("INSURE")]
        public string Insure { get; set; }

        [JsonPropertyName("MSG")]
        public string Message { get; set; }

        [JsonPropertyName("PKFREE")]
        public string PackageFree { get; set; }

        [JsonPropertyName("SINSURE")]
        public string SpecialInsure { get; set; }

        [JsonPropertyName("SDELIVERY")]
        public string SpecialDelivery { get; set; }

        [JsonPropertyName("SADDSERVICE")]
        public string SpecialAddedService { get; set; }
    }
}
