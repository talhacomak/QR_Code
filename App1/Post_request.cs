using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class Post_request
    {

        public async Task<String> AccessTheWebAsync(string url, string[] key, string[] data)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("APP_VERSION", "1.0.0");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("admin", "admin");
            JObject jo = new JObject();
            for(int i=0; i<key.Length; i++)
            {
                jo.Add(key[i], data[i]);
            }
            var content = JsonConvert.SerializeObject(jo);
            await client.PostAsync(url, new StringContent(content));
            Task<string> getStringTask = client.GetStringAsync(url);
            string urlContents = await getStringTask;
            return urlContents;
        }
    }
}
