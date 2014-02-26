using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSelfHostConsole.Models;

//Browser security prevents a web page from making AJAX requests to another domain.
//This restriction is called the same-origin policy. However, sometimes you might want
//to let other sites call your web API.
//Cross Origin Resource Sharing (CORS) is a W3C standard that allows a server to relax the same-origin policy.
//Using CORS, a server can explicitly allow some cross-origin requests while rejecting others.
//http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api

namespace WebApiSelfHostConsole
{
    [EnableCors(origins: "http://localhost:10367", headers: "*", methods: "*")]  // Change with the address of your cross domain client.
    public class ServiceController : ApiController
    {       
        //GET api/values              Here Get rescues a 
        public IEnumerable<string> Get()
        {
            return new string[] { "Diego", "Maria" };
        }

        public IEnumerable<byte> GetBytes()
        {
            return new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public Person GetPerson()
        {
            Person prs = new Person { Name = "Diego", Email = "diego@dmm888.com", Notes = "The notes for this person" };
            return prs;
        }


        public List<Person> GetPersonList()
        {
            List<Person> lps = new List<Person>();
            Person prs = new Person { Name = "Diego", Email = "diego@dmm888.com", Notes = "The notes for this person" };
            Person prs1 = new Person { Name = "Diego Pluto", Email = "pluto@dmm888.com", Notes = "2 The notes for this person" };
            lps.Add(prs);
            lps.Add(prs1);
            return lps;
        }

        public List<string> GetList()
        {
            List<string> lst = new List<string>();
            lst.Add("Diego Aldo Burlando");
            lst.Add("Maria Valentina");
            lst.Add("Monica mamma di Maria");
            return lst;
        }
        // GET api/values/5       Here Get rescues a specific resource
        public string Get(int id)
        {
            if (!Authenticate()) return "Unauthorized";            
            return "Diego Aldo Burlando";
        }

        private bool Authenticate()
        {
            string base64 = Request.Headers.Authorization.Parameter;
            byte[] cred = Convert.FromBase64String(base64);
            string[] credentials = System.Text.Encoding.ASCII.GetString(cred).Split(':');
            string username = credentials[0];
            string password = credentials[1];
            if (username.Equals("username") && password.Equals("password")) return true; else return false;
        }

        // POST api/values      POST is used to Create a new resource
        public void Post([FromBody]string value)
        {
            string alpha = value;
        }

        // Warning Do Not use more than on  [FromBody] because it doesn't work     
       public string PostEntity(Person personsent)
        {
            Person alpha = personsent;
            return "Post successful";
        }
        // Warning Do Not use more than on  [FromBody] because it doesn't work
        public void PostString([FromBody]string datatosend)
        {
            string alpha = datatosend;
        }
        // POST api/values      POST is used to Create a new resource
        public void PostPerson([FromBody]Person value)
        {
            Person alpha = value;
        }
        // POST api/values      POST is used to Create a new resource
        public void PostPersonList([FromBody] List<Person> value)
        {
            List<Person> alpha = value;
        }


        // POST api/values      POST is used to Create a new resource
        public void PostBytes([FromBody] byte[] value)
        {
            byte[] received = value;
        }


        // PUT api/values/5       PUT is used to update a resource
        public void Put(int id, [FromBody]string value)
        {
            int y = 0;
        }

        // DELETE api/values/5         Obviously PUT is used to delete a resource
        public void Delete(int id)
        {
            int y = 0;
        }

    }
}
