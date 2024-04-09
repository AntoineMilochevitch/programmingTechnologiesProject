using NUnit.Framework;
using PTProject.Data;
using System;

namespace PTProject.Test
{
    public class CatalogTest
    {
        private ICatalog _catalog;

        [SetUp]
        public void Setup()
        {
            _catalog = new Catalog();
        }

        [Test]
        public void AddGood_AddsGoodToCatalog()
        {
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            _catalog.AddGood(good.GoodId, good);

            Assert.That(_catalog.GetGood(good.GoodId), Is.EqualTo(good));
        }

        [Test]
        public void RemoveGood_RemovesGoodFromCatalog()
        {
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            _catalog.AddGood(good.GoodId, good);
            _catalog.RemoveGood(good.GoodId);

            Assert.IsNull(_catalog.GetGood(good.GoodId));
        }


        [Test]
        public void GetGood_ReturnsGoodFromCatalog()
        {
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            _catalog.AddGood(good.GoodId, good);

            Assert.That(_catalog.GetGood(good.GoodId), Is.EqualTo(good));
        }

        [Test]
        public void GetCatalog_ReturnsCorrectCatalog()
        {
            // Arrange
            var good1 = new Good { GoodId = 1, Description = "Test Good 1", Quantity = 10, Price = 100 };
            var good2 = new Good { GoodId = 2, Description = "Test Good 2", Quantity = 20, Price = 200 };
            _catalog.AddGood(good1.GoodId, good1);
            _catalog.AddGood(good2.GoodId, good2);

            // Act
            var result = _catalog.GetCatalog();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.ContainsKey(good1.GoodId));
            Assert.IsTrue(result.ContainsKey(good2.GoodId));
            Assert.AreEqual(good1, result[good1.GoodId]);
            Assert.AreEqual(good2, result[good2.GoodId]);
        }
    }
}