using NUnit.Framework;
using PTProject.Data;
using System;
using static PTProject.Data.Catalog;

namespace PTProject.Test
{
    public class CatalogTest
    {
        private Catalog catalog;

        [SetUp]
        public void Setup()
        {
            catalog = new Catalog();
        }

        [Test]
        public void AddGood_AddsGoodToCatalog()
        {
            var good = new Good { Description = "Test Good" };
            catalog.AddGood(1, good);

            Assert.That(catalog.GetGood(1), Is.EqualTo(good));
        }

        [Test]
        public void RemoveGood_RemovesGoodFromCatalog()
        {
            var good = new Good { Description = "Test Good" };
            catalog.AddGood(1, good);
            catalog.RemoveGood(1);

            Assert.IsNull(catalog.GetGood(1));
        }

        [Test]
        public void GetGood_ReturnsGoodFromCatalog()
        {
            var good = new Good { Description = "Test Good" };
            catalog.AddGood(1, good);

            Assert.That(catalog.GetGood(1), Is.EqualTo(good));
        }

        [Test]
        public void AddGood_ThrowsException_WhenGoodIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => catalog.AddGood(1, null));
        }
    }
}