namespace BISolutions.Tracking
{
    public class BITrackingConstants
    {
        public class ShunFeng
        {
            public const string BaseAddress = "https://open-prod.sf-express.com/";
            public const string SandboxAddress = "https://open-sbox.sf-express.com/";

            private const string Prefix = "public/v1.0";

            public const string AuthorizePublicEndpoint = "public/v1.0/security/access_token/sf_appid/{0}/sf_appkey/{1}";
            public const string AuthorizeRestEndpoint = "rest/v1.0/security/access_token/sf_appid/{0}/sf_appkey/{1}";
            public const string QueryAccessTokenEndpoint = Prefix + "/security/access_token/query/sf_appid/{0}/sf_appkey/{1}";

            public const string RefreshTokenEndpoint = "public/v1.0/security/refresh_token/sf_appid/{0}/sf_appkey/{1}";
            private const string Suffix = "access_token/{0}/sf_appid/{1}/sf_appkey/{2}";

            public const string OrderEndpoint = Prefix + "/order/" + Suffix;
            public const string OrderQueryEndpoint = Prefix + "/order/query/" + Suffix;
            public const string FilterEndpoint = Prefix + "/filter/" + Suffix;
            public const string RouteQueryEndpoint = Prefix + "/route/query/" + Suffix;
            public const string RouteIncrementQueryEndpoint = Prefix + "/route/inc/query/" + Suffix;
            public const string AirwayBillEndpoint = Prefix + "/waybill/image/" + Suffix;
            public const string BasicProductQueryEndpoint = Prefix + "/product/basic/query/" + Suffix;
            public const string AdditionalProductQueryEndpoint= Prefix + "/product/additional/query/" + Suffix;
            public const string OrderPagingEndpoint = Prefix + "/express/order/" + Suffix;
        }

        public class SkyNet
        {
            public const string APIKey = "7f027dc3-205a-4591-a271-d8969f1aa2da";
            public const string BaseAddress = "http://api.skynetict.com/";

            public const string TrackEndpoint = "api/SkynetTrack/";
        }

        public class AfterShip
        {
            public const string BaseAddress = "https://api.aftership.com/v4";

            public const string CourierEndpoint = "/couriers";
            public const string AllCouriersEndpoint = "/couriers/all";
            public const string DetectCourierEndpoint = "/couriers/detect";

            public const string TrackBatchEndpoint = "/trackings";
            public const string TrackEndpoint = "/trackings/{0}/{1}";
        }
    }
}
