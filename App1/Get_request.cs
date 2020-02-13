using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App1
{
    public class Get_request
    {
        public string urlContents;
        public async Task<String> AccessTheWebAsync(string url)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("APP_VERSION", "1.0.0");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your_authorization_token_string");
            Task<string> getStringTask = client.GetStringAsync(url);
            urlContents = await getStringTask;
            return urlContents;
        }
    }
}