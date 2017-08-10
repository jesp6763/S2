using System;
using System.Text.RegularExpressions;

namespace ProductTest
{
    public class Product
    {
        private string name; // The name of the product
        private string description; // The product description
        private double price; // The price of the product
        private int stockAmount; // How much stock is available

        public Product(string name, double price, int stockAmount)
        {
            PriceHistory = new PriceHistory();
            Name = name;
            Price = price;
            StockAmount = stockAmount;
        }

        public Product(string name, double price, int stockAmount, string description) : this(name, price, stockAmount)
        {
            Description = description;
        }

        public string Name
        {
            get => name;
            set
            {
                if (Regex.IsMatch(value, @"^[ A-Za-z0-9&]+$"))
                {
                    if (value.Length <= 30)
                    {
                        name = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (value.Length <= 500)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value >= 0)
                {
                    PriceHistory.CommitPrice(value);
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int StockAmount
        {
            get => stockAmount;
            set
            {
                if (stockAmount >= 0)
                {
                    stockAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public PriceHistory PriceHistory { get; }
    }
}