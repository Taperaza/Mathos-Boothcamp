using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.WebApi.Models
{
    public class Buyer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public Buyer(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}