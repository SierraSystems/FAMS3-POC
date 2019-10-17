using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using System.Threading.Tasks;

namespace JobManager.APIClient.Helper
{
   public  class HttpClient
    {
        readonly FlurlClient Client;
        const int HTTP_REQUEST_TIMEOUT = 60;
        public HttpClient ()
        {
            Client = new FlurlClient();
        }

        public async Task<T> Get<T>(string path, string key = null,object queryParams = null, object headers = null, object cookies = null)
        {

            try
            {
                return await new Flurl.Url(path).SetQueryParams(queryParams ?? new { }).WithClient(Client).WithTimeout(HTTP_REQUEST_TIMEOUT).WithCookies(cookies ?? new { })
                               .WithHeaders(headers ?? new { })
                                .WithHeader("Token", key)
                    .GetAsync().ReceiveJson<T>();
            }
            catch (TaskCanceledException ex)
            {
                throw ex;
          
            }
        }


    }
}
