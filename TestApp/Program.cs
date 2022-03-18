using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shoes shoeobj = new Shoes();

            Console.WriteLine("1) Sport Footwear");
            Console.WriteLine("2) Classy Footwear");
            Console.WriteLine("3) Quit");

            Console.WriteLine("Num:");
            int InputNum = Convert.ToInt32(Console.ReadLine());

            switch (InputNum)
            {
                case 1:

                    shoeobj.Brand = "Nike";
                    shoeobj.Price = 500;
                    shoeobj.Color = "Black";
                    shoeobj.InStock = true;
                    Console.WriteLine("Shoe information\n");
                    Console.WriteLine("Shoe brand: " + shoeobj.Brand + "\n" + "Shoe price: " + shoeobj.Price + "\n" + "Shoe color: " + shoeobj.Color);
                    shoeobj.Stock();

                    break;

                case 2:

                    shoeobj.Brand = "Lacoste";
                    shoeobj.Price = 700;
                    shoeobj.Color = "White";
                    shoeobj.InStock = false;
                    Console.WriteLine("Shoe information\n");
                    Console.WriteLine("Shoe brand: " + shoeobj.Brand + "\n" + "Shoe price: " + shoeobj.Price + "\n" + "Shoe color: " + shoeobj.Color);
                    shoeobj.Stock();

                    break;

                case 3:

                    break;




            }
            Console.ReadLine();

        }   
           
    }
}
