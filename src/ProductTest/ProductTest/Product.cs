using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest
{
    class Product
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value.Length <= 30)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public string Description { get; set; }
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                PriceHistory.CommitPrice(value);
                price = value;
            }
        }

        public int StockAmount { get; set; }
        public PriceHistory PriceHistory { get; }

        public Product(string name, string description, double price, int stockAmount)
        {
            PriceHistory = new PriceHistory();
            Name = name;
            Description = description;
            Price = price;
            StockAmount = stockAmount;
        }
    }
}