using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestApiWithAuthorization
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000");
            string credentials = String.Format("{0}:{1}", "username11", "password");
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);
            var responsemessage = client.GetAsync("/api/service/get/9").Result;
            if (responsemessage.IsSuccessStatusCode)
            {
                string str = responsemessage.Content.ReadAsAsync<string>().Result.ToString();
            }         
        }
    }
}
