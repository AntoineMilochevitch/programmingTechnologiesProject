using NUnit.Framework;
using PTProject.Data;
using System;

/// List of all test
/// Test to add a new good in the catalog with an id and a name good
/// Test to remove a good of the catalog
/// Test to verify that different catalogs can be created
/// Test the case when we add a quantity of a good that already exist
/// Test the exception item is null

namespace PTProject.Data.Test
{
    public class CatalogTest
    {
        private ICatalog _catalog;

        [SetUp]
        public void Setup()
        {
            _catalog = new Catalog();
        }
        private Good CreateDefaultGood()
        {
            return new Good { GoodId = 1, Description = "Default Good", Quantity = 10, Price = 100 };
        }

        [Test]
        /// Test to add a new good in the catalog with an id and a name good
        public void AddGood_AddsGoodToCatalog()
        {
            var good = CreateDefaultGood();
            _catalog.AddGood(good.GoodId, good);

            Assert.That(_catalog.GetGood(good.GoodId), Is.EqualTo(good));
        }

        /// Test to remove a good of the catalog
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

        /// Test to verify that different catalogs can be created
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
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.IsTrue(result.ContainsKey(good1.GoodId));
            Assert.IsTrue(result.ContainsKey(good2.GoodId));
            Assert.That(result[good1.GoodId], Is.EqualTo(good1));
            Assert.That(result[good2.GoodId], Is.EqualTo(good2));
        }

        /// Test the case when we add a quantity of a good that already exist
        [Test]
        public void AddItem_ThrowsExceptionWhenItemAlreadyExists()
        {
            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            _catalog.AddGood(good.GoodId, good);


            // Act & Assert
            _catalog.AddGood(good.GoodId, good);
            Assert.That(good.Quantity, Is.EqualTo(11));
        }

        /// Test the exception item is null
        [Test]
        public void AddItem_ThrowsExceptionWhenItemIsNull()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _catalog.AddGood(1, null));
            Assert.That(ex.ParamName, Is.EqualTo("good"));
            Assert.That(ex.Message, Does.Contain("Good cannot be null"));
        }

    }
}