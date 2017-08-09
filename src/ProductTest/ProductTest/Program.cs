using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Laptop XL", "Crazy fast laptop", 19431, 3);
            Console.WriteLine($"Current product price: {product1.Price}");
            product1.Price = 23000;
            Console.WriteLine($"New price: {product1.Price}");
            product1.Price = 200;
            Console.WriteLine($"New price: {product1.Price}");
            Console.WriteLine($"Highest price registeret: {product1.PriceHistory.HighestPrice}");
            Console.WriteLine($"Lowest price registeret: {product1.PriceHistory.LowestPrice}");
            product1.Price = 35;
            Console.WriteLine($"New lowest price registeret: {product1.PriceHistory.LowestPrice}");

            Seperate();

            // Print price history at date
            DateTime date = DateTime.Today;
            double[] prices = product1.PriceHistory.GetHistoryAtDate(date);
            if(prices.Length > 0)
            {
                Console.WriteLine($"Price history from: {date.ToLongDateString()}");

                for(int i = 0; i < prices.Length; i++)
                {
                    Console.WriteLine(prices[i].ToString("C0"));
                }
            }
            Console.ReadKey();
        }

        private static void Seperate()
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
    }
}
