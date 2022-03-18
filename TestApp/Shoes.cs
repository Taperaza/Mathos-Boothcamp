using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Shoes : Footwear
    {

        public void DisplayId()
        {
            Console.WriteLine(ShoeID);
        }
        public void Stock()
        {
            if (InStock == false)
            {
                Console.WriteLine("Shoes are not available");
            }
            else
            {
                Console.WriteLine("Shoes are available");
            }
        }
    }
    
    
    
}
