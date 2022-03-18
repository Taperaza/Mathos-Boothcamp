using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Footwear
    {
        Guid gobj = new Guid();
        public string Brand { get; set; }

        public int Size { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }

        public bool InStock { get; set; }

        protected string ShoeID = Guid.NewGuid().ToString();
    }
}
