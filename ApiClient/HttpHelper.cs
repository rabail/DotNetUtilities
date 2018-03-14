using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class HttpHelper
    {
        public HttpHelper()
        {
        }

        private async Task<string> ReadInput(string _apiPath)
        {
            string input = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage reader = await client.GetAsync(_apiPath))
                    {
                        input = await reader.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return input;
        }

        public async Task<string> GetApiResponse(string _apiPath)
        {
            string response = await ReadInput(_apiPath);
            return response;
        }

        public async Task<T> GetApiResponse<T>(string _apiPath)
        {
            T responseOject = JsonConvert.DeserializeObject<T>(await ReadInput(_apiPath));
            return responseOject;
        }
    }
}
