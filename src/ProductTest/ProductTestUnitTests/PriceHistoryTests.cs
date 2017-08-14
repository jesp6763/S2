using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Tests
{
    [TestClass()]
    public class PriceHistoryTests
    {
        [TestMethod()]
        public void PriceHistory_CommitPrice()
        {
            // Test succeeds if the expected price is registered to the price history of todays date
            double expected = 140.0d;

            Product product1 = new Product("Logitech G27", 1500.0d, 99) { Price = expected };
            List<double> prices = product1.PriceHistory.Prices[DateTime.Today];
            Assert.AreEqual(prices[prices.Count - 1], expected);
        }

        [TestMethod()]
        public void PriceHistory_GetHistoryAtDateTest()
        {
            // Test succeeds if the expected results is the same as the prices from PriceHistory of todays date
            double[] expected = { 1500.0d, 140.0d, 593.0d, 842.0d, 1292.0d };

            Product product1 = new Product("Logitech G27", 1500.0d, 99) { Price = 140.0d };
            product1.Price = 593.0d;
            product1.Price = 842.0d;
            product1.Price = 1292.0d;
            double[] prices = product1.PriceHistory.Prices[DateTime.Today].ToArray();
            CollectionAssert.AreEqual(expected, prices);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PriceHistory_PriceTest()
        {
            // Test succeeds if exception 'ArgumentOutOfRangeException is thrown. Reason being thrown: Price is less than 0
            Product product1 = new Product("Logitech G27", -400d, 99);
        }
    }
}