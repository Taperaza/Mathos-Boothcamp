using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.WebApi.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Shipping { get; set; }
        public Product(int id, string productname, string shipping, bool isactive)
        {
            Id = id;
            ProductName = productname;
            IsActive = isactive;
            Shipping = shipping;
        }
    }
}