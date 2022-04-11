using System;
using Example.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace Example.WebApi.Controllers
{
    public class BuyerController : ApiController
    {
        static List<Buyer> buyers = new List<Buyer>()
        {
            new Buyer (1, "Sam Smith", "USA" )
        };
        [System.Web.Http.Route("api/buyers/GetBuyer/buyerId")]
        [System.Web.Mvc.HttpGet]
        public List<string> GetBuyer(int buyerId)
        {
            List<string> output = new List<string>();
            foreach (var name in buyers)
            {
                output.Add(name.Name);
            }
            return output;
        }
        // GET: api/Buyer
        public List<Buyer> Get()
        {
            return buyers;
        }
        // GET: api/Buyer/5
        public Buyer Get(int id)
        {
            return buyers.Where(x => x.Id == id).FirstOrDefault();
        }
        // POST: api/Buyer
        public void Post(Buyer val)
        {
            buyers.Add(val);
        }
        // PUT: api/Buyer/5
        public void Put(int id, string value)
        {
        }
        // DELETE: api/Buyer/5
        public void Delete(int id)
        {
        }
    }
}
