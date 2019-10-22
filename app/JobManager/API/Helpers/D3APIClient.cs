using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;


namespace JobManager.API.Helpers
{

        public class DynamicsApiClient
        {
            private readonly int timeout = int.Parse(ConfigurationManager.AppSettings["ConnectionSettings:Timeout"]);
            private String accessToken;
            private readonly String adfsOauth2Uri = ConfigurationManager.AppSettings["Authentication:Dynamics:OAuthUrl"]; // ADFS OAUTH2 URI - usually /adfs/oauth2/token on STS
            private readonly String applicationGroupResource = ConfigurationManager.AppSettings["Authentication:Dynamics:ResourceUrl"]; // ADFS 2016 Application Group resource (URI)
            private readonly String applicationGroupClientId = ConfigurationManager.AppSettings["Authentication:Dynamics:ClientId"]; // ADFS 2016 Application Group Client ID
            private readonly String applicationGroupSecret = ConfigurationManager.AppSettings["Authentication:Dynamics:Secret"]; // ADFS 2016 Application Group Secret
            private readonly String serviceAccountUsername = ConfigurationManager.AppSettings["Authentication:Dynamics:Username"]; // Service account username
            private readonly String serviceAccountPassword = ConfigurationManager.AppSettings["Authentication:Dynamics:Password"]; // Service account password
            private readonly int tokenTimeout = int.Parse(ConfigurationManager.AppSettings["ConnectionSettings:TokenTimeout"]); // Time out of access token in minutes
          
            private DateTime tokenExpiry = new DateTime();
            public DynamicsApiClient()
            {
                accessToken = GetToken();
            }

            /// <summary>
            /// The generic patch for dynamics.
            /// To re-enable reuslt return use:
            ///     client.DefaultRequestHeaders.Add("Prefer", "return=representation");
            ///     client.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=\"OData.Community.Display.V1.FormattedValue\"");
            /// </summary>
            /// <param name="endpoint">entity that will be upserted</param>
            /// <param name="data">payload for dynamics</param>
            /// <returns>
            /// The response from dynamics
            /// </returns>
            public HttpResponseMessage SendDataToDynamics(String endpoint, Object data)
            {
                UpdateToken();
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = new TimeSpan(0, timeout, 0);

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, endpoint)
                    {
                        Version = new Version(1, 1),
                        Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
                    };
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    client.DefaultRequestHeaders.Add("OData-Version", "4.0");


                HttpResponseMessage httpResponseMessage = client.SendAsync(httpRequestMessage).Result;
                    return httpResponseMessage;
                }
            }
            /// <summary>
            /// Acquire access token from dynamics
            /// </summary>
            /// <returns>
            /// access token for accessing dynamics
            /// </returns>
            private String GetToken()
            {
                
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = new TimeSpan(0, timeout, 0);
                    client.DefaultRequestHeaders.Add("client-request-id", Guid.NewGuid().ToString());
                    client.DefaultRequestHeaders.Add("return-client-request-id", "true");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("resource", applicationGroupResource),
                        new KeyValuePair<string, string>("client_id", applicationGroupClientId),
                        new KeyValuePair<string, string>("client_secret", applicationGroupSecret),
                        new KeyValuePair<string, string>("username", serviceAccountUsername),
                        new KeyValuePair<string, string>("password", serviceAccountPassword),
                        new KeyValuePair<string, string>("scope", "openid"),
                        new KeyValuePair<string, string>("response_mode", "form_post"),
                        new KeyValuePair<string, string>("grant_type", "password")
                     };
                // This will also set the content type of the request
                FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);
                // send the request to the ADFS server
                HttpResponseMessage httpResponseMessage = client.PostAsync(adfsOauth2Uri, content).Result;
                    var _responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    // response should be in JSON format.
                    try
                    {
                    Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(_responseContent);

                    tokenExpiry = DateTime.Now;
                        return result["access_token"];
                    }
                    catch (Exception e)
                    {
                        throw new ApiException(System.Net.HttpStatusCode.BadRequest, e.Message + " " + _responseContent, e);
                    }
                }
            }
            /// <summary>
            /// Get request for dynamics data
            /// </summary>
            /// <param name="endpoint">Entity api</param>
            /// <returns>Query results</returns>
            public JObject EntityGet(String endpoint)
            {
                UpdateToken();
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = new TimeSpan(0, timeout, 0);
                    client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                    client.DefaultRequestHeaders.Add("OData-Version", "4.0");
                    client.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=\"*\"");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                String strResponse = client.GetStringAsync(endpoint).Result;
                JObject jObject = JObject.Parse(strResponse);

                    return jObject;
                }
            }
            /// <summary>
            /// Perform dyanmics batch opertation
            /// </summary>
            /// <param name="content">The constructed batch</param>
            /// <param name="endpoint">Dynamics batch endpoint</param>
            /// <returns>Result of batch</returns>
            public HttpResponseMessage SendBatchToDynamicsComplex(MultipartContent content, String endpoint)
            {
                UpdateToken();
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Patch, new Uri(endpoint));

                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    if (content != null)
                    {
                        request.Content = content;
                    }

                HttpResponseMessage httpResponseMessage = client.SendAsync(request).Result;

                    return httpResponseMessage;
                }
            }
            /// <summary>
            /// Refresh token if necessary
            /// </summary>
            private void UpdateToken()
            {
                if (String.IsNullOrEmpty(accessToken) || tokenExpiry == DateTime.MinValue || (DateTime.Now - tokenExpiry).TotalMinutes >= tokenTimeout)
                {
           
                    accessToken = GetToken();
                }
            }
        }
    
}
