using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

//processing JSON here using Http, Tasks, and Json
namespace WeatherApp
{
    class DataService
    {
        //string param for query using Http client object
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            //client object holding queryString to deserialize JSON object
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            //if data exists, asynchronously deserialize each object from JSON
            //until fulfilled
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            //data stored deserialized JSON data for display use
            return data;
        }
    }
}
