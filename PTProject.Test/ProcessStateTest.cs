using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// List of all test
/// Test the return of the correct user count
/// Test the return of the correct good count
/// Test the exception when the purchase is null when we add a purchase
/// Test the exception when the purchase is null when we remove a purchase

namespace PTProject.Test
{
    public class ProcessStateTest
    {
        private ICatalog _catalog;
        private IUsers _users;
        private IProcessState _processState;

        [SetUp]
        public void Setup()
        {
            _catalog = new Catalog();
            _users = new Users();
            _processState = new ProcessState(_catalog, _users);
        }

        /// Test the return of the correct user count
        [Test]
        public void NumberUser_ReturnsCorrectUserCount()
        {
            var user1 = new User { UserId = 1, UserName = "User 1" };
            var user2 = new User { UserId = 2, UserName = "User 2" };
            _users.AddUser(user1);
            _users.AddUser(user2);

            Assert.That(_processState.NumberUser(), Is.EqualTo(2));
        }

        /// Test the return of the correct good count
        [Test]
        public void NumberGood_ReturnsCorrectGoodCount()
        {
            var good1 = new Good { GoodId = 1, Description = "Test Good 1", Quantity = 10, Price = 100 };
            var good2 = new Good { GoodId = 2, Description = "Test Good 2", Quantity = 20, Price = 200 };
            _catalog.AddGood(good1.GoodId, good1);
            _catalog.AddGood(good2.GoodId, good2);

            Assert.That(_processState.NumberGood(good1.GoodId), Is.EqualTo(1));
            Assert.That(_processState.NumberGood(good2.GoodId), Is.EqualTo(1));
        }

        /// Test the exception when the purchase is null when we add a purchase
        [Test]
        public void AddPurchase_ThrowsExceptionWhenPurchaseIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _processState.AddPurchase(null));
        }

        /// Test the exception when the purchase is null when we remove a purchase
        [Test]
        public void RemovePurchase_ThrowsExceptionWhenPurchaseIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _processState.RemovePurchase(null));
        }

    }
}
