using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BISolutions.Tracking.SkyNet
{
    public class BISkyNetClient
    {
        #region Field
        private HttpClient client;
        #endregion

        #region Properties
        public string Token { get; set; }
        #endregion

        #region Method
        #region Operation
        async public Task<TrackResponse> TrackItemAsync(List<Item> items)
        {
            var requestUri = BITrackingConstants.SkyNet.TrackEndpoint;
            var body = new StringContent(JsonSerializer.Serialize(new TrackRequest { Token = Token, Items = items }), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            var response = await SendRequestAsync(request).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<TrackResponse>(content);
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
                    //await this.GetRefreshTokenAsync().ConfigureAwait(false);

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

        public BISkyNetClient(string token)
        {
            Token = token;

            client = new HttpClient() { BaseAddress = new Uri(BITrackingConstants.SkyNet.BaseAddress) };
        }
    }
}
