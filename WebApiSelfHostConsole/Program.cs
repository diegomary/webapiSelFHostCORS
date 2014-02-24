using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


 //    Please install Nuget package ->         Microsoft.AspNet.WebApi.OwinSelfHost

namespace WebApiSelfHostConsole
{
    class Program
    {
        private static string baseAddress = "http://localhost:9000/";
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var t = Task.Factory.StartNew(() =>
            {
                using (WebApp.Start<Startup>(url: baseAddress))
                {
                    Console.WriteLine("The Server Web Api has started");
                    mre.WaitOne();
                    Console.WriteLine("The Server Web Api has stopped");
                }
            });
            Console.ReadLine();
            mre.Set();
        }
    }
}
