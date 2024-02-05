using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BISolutions.Tracking.SunFeng
{
    public class BIShunFengClient : BIBaseRequest
    {
        #region Field
        private HttpClient client;
        #endregion

        #region Method
        #region Token
        async public Task<string> GetAccessTokenAsync(string messageId)
        {
            using (var client = new HttpClient())
            {
                var requestUri = string.Format($"{BITrackingConstants.ShunFeng.BaseAddress}{BITrackingConstants.ShunFeng.AuthorizePublicEndpoint}", ClientId, ClientSecret);
                var body = new RequestHeader
                {
                    Header = new TransactionHeader
                    {
                        TransactionType = "301",
                        MessageId = DateTime.Now.ToString("yyyyMMdd") + messageId
                    },
                    Body = new TransactionBody() { }
                };

                var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
                request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request).ConfigureAwait(false);

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

                var token = JsonSerializer.Deserialize<ResponseHeader>(content);
                AccessToken = token?.Body.AccessToken;
                RefreshToken = token?.Body.RefreshToken;
                AcquireTime = DateTime.Now;

                return token?.Body.AccessToken;
            }
        }

        async public Task<string> GetRefreshTokenAsync()
        {
            using (var client = new HttpClient())
            {
                var requestUri = string.Format($"{BITrackingConstants.ShunFeng.BaseAddress}{BITrackingConstants.ShunFeng.RefreshTokenEndpoint}", ClientId, ClientSecret);

                var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
                var response = await client.SendAsync(request).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    var exception = new Exception("Failed to refresh token. " + response.StatusCode);
                    exception.Data["HttpAuthenticationHeader"] = response.Headers.WwwAuthenticate;
                    throw exception;
                }

                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                string refreshToken = RefreshToken;
                var token = JsonSerializer.Deserialize<ResponseHeader>(content);
                token.Body.RefreshToken = refreshToken;

                return token.Body.AccessToken;
            }
        }
        #endregion

        #region Operation
        async public Task<OrderResponse> PlaceOrderAsync(string messageId, Order order, Cargo cargo, List<AddedService> service)
        {
            var requestUri = string.Format(BITrackingConstants.ShunFeng.OrderEndpoint, ClientId, ClientSecret);
            var body = new OrderRequest
            {
                Header = new TransactionHeader
                {
                    TransactionType = "200",
                    MessageId = DateTime.Now.ToString("yyyyMMdd") + messageId
                },
                Order = order,
                Cargo  = cargo,
                AddedServices = service
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var response = await SendRequestAsync(request).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<OrderResponse>(json);
        }

        async public Task<PlaceOrderEnquiryResponse> PlaceOrderEnquiryAsync(string messageId, PlaceOrder order)
        {
            var requestUri = string.Format(BITrackingConstants.ShunFeng.OrderEndpoint, ClientId, ClientSecret);
            var body = new PlaceOrderRequest
            {
                Header = new TransactionHeader
                {
                    TransactionType = "201",
                    MessageId = DateTime.Now.ToString("yyyyMMdd") + messageId,
                    Code = "EX_CODE_OPENAPI_0200"
                },
                Order = order
            };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var response = await SendRequestAsync(request).ConfigureAwait(false);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<PlaceOrderEnquiryResponse>(json);
        }
        #endregion

        #region Internal
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
        {
            var response = await client.SendAsync(request).ConfigureAwait(false);

            // Check for token refresh
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                bool performTokenRefresh = false;

                try
                {
#if (Newtonsoft)
                    JObject jObject = JObject.Parse(responseContent);
                    var errorObject = jObject["error"];
                    var firstError = errorObject["errors"][0];
                    performTokenRefresh = firstError["reason"].Value<string>() == "authError";
#else
                    using (JsonDocument document = JsonDocument.Parse(responseContent))
                    {
                        var root = document.RootElement;
                        var error = root.GetProperty("error");

                        if (root.TryGetProperty("errors", out JsonElement errorElement))
                        {
                            var err = errorElement.GetString();
                            if (errorElement.TryGetProperty("reason", out var reason))
                            {
                                performTokenRefresh = reason.GetString() == "authError";
                            }
                        }
                    }
#endif
                }
                catch (Exception exception)
                {
                    throw new Exception("Failed to determine failure. " + exception);
                }

                if (performTokenRefresh)
                {
                    // The access token is expired. Refresh the token, then re-issue the request.
                    await this.GetRefreshTokenAsync().ConfigureAwait(false);

                    // Re-add the access token now that it has been refreshed.
                    var newRequest = await request.CloneString().ConfigureAwait(false);
                    //newRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", GetAuthorizationCode());

                    response = await this.client.SendAsync(newRequest).ConfigureAwait(false);
                }
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                try
                {
#if (Newtonsoft)
                    JObject jObject = JObject.Parse(responseContent);
                    var code = (int)jObject["error_code"];
                    var message = (string)jObject["error_msg"];

                    throw new Exception(message);
#else
                    using (JsonDocument document = JsonDocument.Parse(responseContent))
                    {
                        var root = document.RootElement;
                        var error = root.GetProperty("error_code");
                        string message = string.Empty;

                        if (root.TryGetProperty("error_code", out JsonElement errorCode))
                        {
                            var code = errorCode.GetInt32();
                        }
                        if (root.TryGetProperty("error_msg", out JsonElement errorMsg))
                        {
                            message = errorMsg.GetString();
                            throw new Exception(message);
                        }

                        throw new Exception(message);
                    }
#endif
                }
                //catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
                //{
                //    throw new Exception("Failed to determine failure1. " + ex);
                //}
                catch (Exception exception)
                {
                    throw new Exception("Failed to determine failure. " + exception.Message);
                }
            }

            // Any failures (including those from re-issuing after a refresh) will be handled here
            if (!response.IsSuccessStatusCode)
            {
                var exception = new Exception("Live exception");
                exception.Data["HttpStatusCode"] = response.StatusCode;
                exception.Data["Content"] = response.Content.ReadAsStringAsync().Result;
                throw exception;
            }

            return response;
        }
        #endregion
        #endregion

        public BIShunFengClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;

            client = new HttpClient() { BaseAddress = new Uri(BITrackingConstants.ShunFeng.BaseAddress) };
        }
    }
}
