using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductTest
{
    /// <summary>
    /// Information about a product's price history
    /// </summary>
    public class PriceHistory
    {
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        public PriceHistory()
        {
            Prices = new Dictionary<DateTime, List<double>>();
        }

        /// <summary>
        /// Gets the highest price registered in the product's price history
        /// </summary>
        public double HighestPrice
        {
            get
            {
                double result = default(double);
                for(int i = 0; i < Prices.Count; i++)
                {
                    for(int j = 0; j < Prices.ElementAt(i).Value.Count; j++)
                    {
                        result = Math.Max(Prices.ElementAt(i).Value[j], result); // Returns the highest number between the two
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets the lowest price registered in the product's price history
        /// </summary>
        public double LowestPrice
        {
            get
            {
                double result = double.MaxValue;
                for(int i = 0; i < Prices.Count; i++)
                {
                    for(int j = 0; j < Prices.ElementAt(i).Value.Count; j++)
                    {
                        result = Math.Min(Prices.ElementAt(i).Value[j], result); // Returns the lowest number between the two
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets or sets prices history
        /// </summary>
        public Dictionary<DateTime, List<double>> Prices { get; set; }

        /// <summary>
        /// Registers the price change
        /// </summary>
        /// <param name="price">The price to add to the history</param>
        public void CommitPrice(double price)
        {
            DateTime dateTime = DateTime.Today;

            if(Prices.ContainsKey(dateTime))
            {
                Prices[dateTime].Add(price);
            }
            else
            {
                Prices.Add(dateTime, new List<double> { price });
            }
        }

        /// <summary>
        /// Returns all price changes from the specified date, in order
        /// </summary>
        /// <param name="date">The date of the price changes</param>
        /// <returns>An array of price changes from the specified date, in order</returns>
        public double[] GetHistoryAtDate(DateTime date)
        {
            if(Prices.ContainsKey(date))
            {
                return Prices[date].ToArray();
            }

            return null;
        }
    }
}