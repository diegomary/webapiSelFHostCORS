using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi
{
    class Program
    {
        static void Main(string[] args)
        {           
           // Preparation
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000");
        

            // Get String by id           
            var getresponse = client.GetAsync("/api/service/get/9").Result;
            if (getresponse.IsSuccessStatusCode)
            {
                string str = getresponse.Content.ReadAsAsync<string>().Result.ToString();            
            }
            // Get string array            
            var getresponse1 = client.GetAsync("/api/service/get/").Result;
            if (getresponse1.IsSuccessStatusCode)
            {
                IEnumerable<string> strarray = getresponse1.Content.ReadAsAsync<IEnumerable<string>>().Result;
            }

            // Get entity            
            var getresponse2 = client.GetAsync("/api/service/getperson/").Result;
            if (getresponse2.IsSuccessStatusCode)
            {
               Person prs = getresponse2.Content.ReadAsAsync<Person>().Result;
            }

            // Get collection of entities            
            var getresponse3 = client.GetAsync("/api/service/getpersonlist/").Result;
            if (getresponse3.IsSuccessStatusCode)
            {
              List<Person> prs = getresponse3.Content.ReadAsAsync<List<Person>>().Result;
            }
            
            //Post String
            var postresponse = client.PostAsJsonAsync("/api/service/post/", "This is a test").Result;
            if (postresponse.IsSuccessStatusCode)
            {
            }         
           // Post String
            var postresponse1 = client.PostAsync<string>("/api/service/post/", "This is a test",new JsonMediaTypeFormatter()).Result;
            if (postresponse1.IsSuccessStatusCode)
            {
            }
            // Post Entity
            Person psr = new Person { Name = "Pippone", Email = "Bestiole", Notes = "La Belle" };
            var postresponse2 = client.PostAsync<Person>("/api/service/postperson/", psr, new JsonMediaTypeFormatter()).Result;
            if (postresponse2.IsSuccessStatusCode)
            {
            }
            // Post collection of Entities
            Person psr1 = new Person { Name = "Pippone", Email = "Bestiole", Notes = "La Belle" };
            Person psr2 = new Person { Name = "Topoline", Email = "cucco@palla.com", Notes = "lots of things" };
            List<Person> lp = new List<Person>() { psr1, psr2 };
            var postresponse3 = client.PostAsync<List<Person>>("/api/service/postpersonlist/", lp, new JsonMediaTypeFormatter()).Result;
            if (postresponse3.IsSuccessStatusCode)
            {
            }
            // Post a byte array
            var btarr = new byte[] {1,2,3,4,5,6,7,8,9,34,35,77,88 };
            var postresponse4 = client.PostAsync<byte[]>("/api/service/postbytes/", btarr, new JsonMediaTypeFormatter()).Result;
            if (postresponse4.IsSuccessStatusCode)
            {
            }

            //*********************************************************************
            Console.ReadLine();
        }
    }
}
