using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest
{
    class PriceHistory
    {
        // This is the highest registered price
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
        // This is the lowest registered price
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

        private Dictionary<DateTime, List<double>> prices;
        public Dictionary<DateTime, List<double>> Prices
        {
            get
            {
                if(prices == null)
                {
                    Prices = new Dictionary<DateTime, List<double>>();
                }
                return prices;
            }
            set
            {
                prices = value;
            }
        }

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
        /// <paramref name="date"/>
        /// </summary>
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