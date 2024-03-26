using NUnit.Framework;
using PTProject.Data;
using System;
using static PTProject.Data.Catalog;

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
            var good = new Good { Description = "Test Good" };
            _catalog.AddGood(1, good);

            Assert.That(_catalog.GetGood(1), Is.EqualTo(good));
        }

        [Test]
        public void RemoveGood_RemovesGoodFromCatalog()
        {
            var good = new Good { Description = "Test Good" };
            _catalog.AddGood(1, good);
            _catalog.RemoveGood(1);

            Assert.IsNull(_catalog.GetGood(1));
        }

        [Test]
        public void GetGood_ReturnsGoodFromCatalog()
        {
            var good = new Good { Description = "Test Good" };
            _catalog.AddGood(1, good);

            Assert.That(_catalog.GetGood(1), Is.EqualTo(good));
        }
    }
}