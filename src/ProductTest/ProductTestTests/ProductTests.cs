using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductTest;
using System;
using System.Collections.Generic;

namespace ProductTest.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void PriceHistory_CommitPrice()
        {
            double expected = 140.0d;
            Product product1 = new Product("Logitech G27", 1500.0d, 99);
            product1.Price = 140.0d;
            List<double> prices = product1.PriceHistory.Prices[DateTime.Today];
            Assert.AreEqual(prices[prices.Count - 1], expected);
        }

        [TestMethod]
        public void PriceHistory_GetHistoryAtDate()
        {
            double[] expected = { 1500.0d, 140.0d, 593.0d, 842.0d, 1292.0d };

            Product product1 = new Product("Logitech G27", 1500.0d, 99);
            product1.Price = 140.0d;
            product1.Price = 593.0d;
            product1.Price = 842.0d;
            product1.Price = 1292.0d;
            double[] prices = product1.PriceHistory.Prices[DateTime.Today].ToArray();
            CollectionAssert.AreEqual(expected, prices);
        }
    }
}