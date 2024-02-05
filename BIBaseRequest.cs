using System;

namespace BISolutions.Tracking
{
    public class BIBaseRequest
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime AcquireTime { get; set; }
    }
}
