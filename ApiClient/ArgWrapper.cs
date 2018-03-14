using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClient
{
    public class ArgWrapper
    {
        public JArray argArray;

        public ArgWrapper()
        {
            argArray = new JArray();
        }

        public void Add(string key, string value)
        {
            argArray.Add(new JObject { new JProperty("key", key), new JProperty("value", value) });
        }
    }
}
