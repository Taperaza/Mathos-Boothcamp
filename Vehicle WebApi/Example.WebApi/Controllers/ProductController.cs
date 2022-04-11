using Example.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Example.WebApi.Controllers
{
    public class ProductController : ApiController

    {

        static List<Product> repository = new List<Product>()
        {
            new Product (2, "Pc", "USA", true),
            new Product (3, "Mouse", "Kongo", true),
            new Product (4, "KeyBoard", "Croatia", false)
        };
        //Get product by id
        [Route("api/Product/GetNames/{Id}")]
        public List<string> GetNames(int Id)
        {
            List<string> output = new List<string>();
            foreach (var name in repository)
            {
                output.Add(name.ProductName);
            }
            return output;
        }
            //Get product list
            //GET: api/Product
            public List<Product> Get()
            {
                return repository;
            }
            //GET: api/Product/5
            public HttpResponseMessage GetProduct(int id)
            {
                var finder = repository.Find(r => r.Id == id);
                if (repository == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
                }

                return Request.CreateResponse(HttpStatusCode.OK, finder);
            }
            //POST: api/Product
            public void Post(Product product)
            {
                repository.Add(product);

            }
            //PUT: api/Product
            public void Put(int id, string value)
            {

            }



            //DELETE : api/Product/5
            public void Delete(int id)
            {

            }


            public HttpResponseMessage DeleteProduct(int id)
            {
                var productFinder = repository.Find(r => r.Id == id);
                repository.Remove(productFinder);
                if (productFinder != null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"Product number {id} doesn't exist");

                }
                else
                {
                    HttpResponseMessage responseMessageOk = Request.CreateResponse(HttpStatusCode.OK, productFinder);
                    return Request.CreateResponse(HttpStatusCode.OK, $"{productFinder.Id} deleted");
                }

            }
        
    }
}
