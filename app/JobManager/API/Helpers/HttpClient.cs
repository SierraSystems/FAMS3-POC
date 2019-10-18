using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace JobManager.API.Helpers
{
   public  class HttpClient
    {
        private readonly FlurlClient _client;
        private const int HttpRequestTimeout = 10;
        public HttpClient ()
        {
            _client = new FlurlClient();
        }

        public async Task<T> Get<T>(string baseUrl, string path, string key = null,object queryParams = null, object headers = null, object cookies = null)
        {
            return await new Url(baseUrl)
                .AppendPathSegment(path)
                .SetQueryParams(queryParams ?? new { })
                .WithClient(_client)
                .WithTimeout(HttpRequestTimeout)
                .WithCookies(cookies ?? new { })
                .WithHeaders(headers ?? new { })
                .GetAsync().ReceiveJson<T>();
        }

        public async Task<T> Post<T>(string baseUrl, string path, object payload = null, string key = null, object queryParams = null, object headers = null, object cookies = null)
        {
        
                return  await new Url(baseUrl)
                    .AppendPathSegment(path)
                    .SetQueryParams(queryParams ?? new { })
                    .WithClient(_client)
                    .WithTimeout(HttpRequestTimeout)
                    .WithCookies(cookies ?? new { })
                    .WithHeaders(headers ?? new { })
                    .PostJsonAsync(payload ?? new object()).ReceiveJson<T>();
            
          
        }

    }
}
