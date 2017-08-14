using System;

namespace ProductTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Laptop XL", 19431, 3, "Crazy fast laptop!");
            Console.WriteLine($"Name: {product1.Name}\nDescription: {product1.Description}\nPrice: {product1.Price}\nStock available: {product1.StockAmount}");
            Console.WriteLine(double.MaxValue.ToString());
            Seperate();
            Console.WriteLine($"Changes done to product: {product1.Name}");
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
