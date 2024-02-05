using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BISolutions.Tracking.AfterShip
{
    public class TrackInfo
    {
        [JsonPropertyName("id")]
        public string TrackingId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime Created { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime Updated { get; set; }

        [JsonPropertyName("last_updated_at")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonPropertyName("slug")]
        public string Provider { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("android")]
        public List<string> Android { get; set; }

        [JsonPropertyName("custom_fields")]
        public string CustomFields { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }

        [JsonPropertyName("delivery_time")]
        public int DeliveryTime { get; set; }

        [JsonPropertyName("destination_country_iso3")]
        public string DestinationCountryISO { get; set; }

        [JsonPropertyName("courier_destination_country_iso3")]
        public string CourierDestinationCountryISO { get; set; }

        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }

        [JsonPropertyName("expected_delivery")]
        public DateTime? ExpectedDelivery { get; set; }

        [JsonPropertyName("ios")]
        public List<string> iOS { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("order_id_path")]
        public string OrderIdPath { get; set; }

        [JsonPropertyName("origin_country_iso3")]
        public string OriginCountryISO { get; set; }

        [JsonPropertyName("shipment_package_count")]
        public int PackageCount { get; set; }

        [JsonPropertyName("shipment_pickup_date")]
        public DateTime? PickupDate { get; set; }

        [JsonPropertyName("shipment_delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [JsonPropertyName("shipment_type")]
        public string ShipmentType { get; set; }

        [JsonPropertyName("shipment_weight")]
        public int ShipmentWeight { get; set; }

        [JsonPropertyName("shipment_weight_unit")]
        public string ShipmentWeightUnit { get; set; }

        [JsonPropertyName("signed_by")]
        public string SignedBy { get; set; }

        [JsonPropertyName("smses")]
        public List<string> SMSes { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("tag")]
        public StatusTag Tag { get; set; }

        [JsonPropertyName("subtag")]
        public string SubTag { get; set; }

        [JsonPropertyName("subtag_message")]
        public string SubTagMessage { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("tracked_count")]
        public int TrackedCount { get; set; }

        [JsonPropertyName("last_mile_tracking_supported")]
        public bool? LastMileTrackingSupported { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("unique_token")]
        public string UniqueToken { get; set; }

        [JsonPropertyName("checkpoints")]
        public List<Checkpoint> Checkpoints { get; set; }

        [JsonPropertyName("subscribed_smses")]
        public List<string> SubscribedSMSes { get; set; }

        [JsonPropertyName("subscribed_emails")]
        public List<string> SubscribedEmails { get; set; }

        [JsonPropertyName("return_to_sender")]
        public bool ReturnToSender { get; set; }

        [JsonPropertyName("tracking_account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("tracking_origin_country")]
        public string OriginCountry { get; set; }

        [JsonPropertyName("tracking_destination_country")]
        public string DestinationCountry { get; set; }

        [JsonPropertyName("tracking_key")]
        public string Key { get; set; }

        [JsonPropertyName("tracking_postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("tracking_ship_date")]
        public DateTime? ShipDate { get; set; }

        [JsonPropertyName("tracking_state")]
        public string State { get; set; }

        [JsonPropertyName("order_promised_delivery_date")]
        public string OrderPromisedDeliveryDate { get; set; }

        [JsonPropertyName("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonPropertyName("pickup_location")]
        public string PickupLocation { get; set; }

        [JsonPropertyName("pickup_note")]
        public string PickupNote { get; set; }
    }
}
