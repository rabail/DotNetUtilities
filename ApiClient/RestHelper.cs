using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient
{
    public class RestHelper
    {
        string server;
        RestClient client;

        public RestHelper(string _serverAdd)
        {
            server = _serverAdd;
            client = new RestClient(new Uri(_serverAdd));
        }

        public string BuildGetRequest(string resource, JArray parameters, JArray headers)
        {
            RestRequest request = BuildRequest(resource, parameters, headers);

            IRestResponse response;

            response = client.Execute(request);

            return response.Content;
        }

        public T BuildGetRequest<T>(string resource, ArgWrapper parameters, ArgWrapper headers) where T :new()
        {
            RestRequest request = BuildRequest(resource, parameters.argArray, headers.argArray);

            IRestResponse<T> response;

            response = client.Execute<T>(request);

            return response.Data;
        }

        private static RestRequest BuildRequest(string resource, JArray parameters, JArray headers)
        {
            var request = new RestRequest(resource, Method.GET);

            foreach (var item in headers)
            {
                request.AddHeader(item["key"].ToString(), item["Value"].ToString());
            }

            foreach (var item in parameters)
            {
                request.AddParameter(item["key"].ToString(), item["Value"].ToString());
            }

            return request;
        }
    }
}
