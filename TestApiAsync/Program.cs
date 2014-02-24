using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TestApiAsync.Models;

namespace TestApiAsync
{
    class Program
    {
        static void Main(string[] args)
        {            
            DoAsync();
            Console.WriteLine("Performing Asyncronous work...");        
            Console.ReadLine();
        }


        private static async void DoAsync()
        {           
            // an Asyncronous method returns to the caller when there's  an await. In this method we have two awaits,
            // this means that the asyncronous method returns twice to the caller that is the Main method. The fact that it returns
            // to the caller gives responsiveness.            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000");
          
            
            // Get String by id           
            var taskresponse = await client.GetAsync("/api/service/get/9");
            // it is here that the control is passed to main with the promise to elaborate taskresponse when it is completed           
            if (taskresponse.IsSuccessStatusCode)
            {
                string result = await taskresponse.Content.ReadAsAsync<string>();
                Console.WriteLine(result);
            }


            // Get Entity          
            var taskresponse1 = await client.GetAsync("/api/service/getpersonlist/");
            // it is here that the control is passed to main with the promise to elaborate taskresponse when it is completed           
            if (taskresponse1.IsSuccessStatusCode)
            {
                List<Person> listresult = await taskresponse1.Content.ReadAsAsync<List<Person>>();              
                foreach(Person pr in listresult)
                {
                    Console.WriteLine(pr.Name);
                    Console.WriteLine(pr.Email);
                    Console.WriteLine(pr.Notes);
                }               
            }

        }


    }
}
