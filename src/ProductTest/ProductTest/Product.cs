using System;
using System.Text.RegularExpressions;

namespace ProductTest
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        private string name;
        /// <summary>
        /// The description of the product.
        /// </summary>
        private string description;
        /// <summary>
        /// The price of the product.
        /// </summary>
        private double price;
        /// <summary>
        /// How much stock is available.
        /// </summary>
        private int stockAmount;

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stockAmount">How much stock is available.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to change the value of the name, and is more than 30 characters long, or if attempted to give the price or stockAmount a value lesser than 0.</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to change the value of the name to something that has invalid characters, such as special characters(ampersand character excepted).</exception>
        public Product(string name, double price, int stockAmount)
        {
            PriceHistory = new PriceHistory();
            Name = name;
            Price = price;
            StockAmount = stockAmount;
        }

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stockAmount">How much stock is available.</param>
        /// <param name="description">The description of the product.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to change the value of the name, to something with more than 30 characters long, or attempting to change the value of the description to something with more than 500 characters. Thrown when attempting to give the price or stockAmount a value lesser than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to change the value of the name to something that has invalid characters, such as special characters(ampersand character excepted)</exception>
        public Product(string name, double price, int stockAmount, string description) : this(name, price, stockAmount)
        {
            Description = description;
        }

        /// <summary>
        /// Gets or sets the name of the product
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is more than 30 characters.</exception>
        /// <exception cref="ArgumentException">Thrown when the value has invalid characters, such as special characters(ampersand character excepted).</exception>
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
        /// <summary>
        /// Gets or sets the description of the product
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is more than 500 characters.</exception>
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
        /// <summary>
        /// Gets or sets the price of the product
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is less than 0.</exception>
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
        /// <summary>
        /// Gets or sets the stockAmount of the product
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is less than 0.</exception>
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
        /// <summary>
        /// Gets the price history of the product. Setter is private
        /// </summary>
        public PriceHistory PriceHistory { get; }
    }
}