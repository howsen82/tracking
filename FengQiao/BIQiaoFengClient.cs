using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BISolutions.Tracking.FengQiao
{
    public class BIQiaoFengClient
    {
        #region Field
        private HttpClient client;
        #endregion

        public BIQiaoFengClient()
        {
            client = new HttpClient() { BaseAddress = new Uri(BITrackingConstants.SkyNet.BaseAddress) };
        }
    }
}
