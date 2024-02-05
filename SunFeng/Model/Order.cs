using System;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.SunFeng
{
    public class Order
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("expressType")]
        public int ExpressType { get; set; }

        [JsonPropertyName("isDoCall")]
        public int IsDoCall { get; set; }

        [JsonPropertyName("isGenBillNo")]
        public int IsGeneratedBillNumber { get; set; }

        [JsonPropertyName("isGenElectricPic")]
        public int IsGeneratedElectricPicture { get; set; }

        [JsonPropertyName("needReturnTrackNo")]
        public int NeedReturnTrackingNumber { get; set; }

        [JsonPropertyName("payArea")]
        public string PaymentArea { get; set; }

        [JsonPropertyName("payMethod")]
        public int PaymentMethod { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("sendStartTime")]
        public DateTime StartSendTime { get; set; }

        [JsonPropertyName("consigneeInfo")]
        public Consignee Consignee { get; set; }

        [JsonPropertyName("custId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("deliverInfo")]
        public Delivery Delivery { get; set; }
    }
}
