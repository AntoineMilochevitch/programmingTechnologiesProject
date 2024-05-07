using NUnit.Framework.Internal.Execution;
using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// List of all test
/// Test the exception when we try to add an event where the user or the good doesn't exist 
/// Test the purchase event
/// Test the return event
/// Test the exception when we try to purchase a good out of stock

namespace PTProject.Data.Test
{
    public class EventsTest
    {
        private ICatalog? _catalog;
        private IUsers? _users;
        private IEvents _events;
        private ProcessState? processState;

        [SetUp]
        public void Setup()
        {
            _catalog = new Catalog();
            _users = new Users();
            _events = new Events(_catalog, _users,processState);
        }

        /// Test the exception when we try to add an event where the user or the good doesn't exist 
        [Test]
        public void Purchase_ThrowsExceptionWhenUserOrGoodNotFound()
        {
            Assert.Throws<ArgumentException>(() => _events.Purchase(1, 1));
        }

        /// Test the purchase event
        [Test]
        public void User_Purchase()
        {

            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            var user = new User { UserId = 1, UserName = "User 1" };
            _catalog?.AddGood(good.GoodId, good);
            _users?.AddUser(user);

            // Act
            _events.Purchase(user.UserId, good.GoodId);

            // Assert
            Assert.That(good.Quantity, Is.EqualTo(9));
        }

        /// Test the return event <summary>

        [Test]
        public void User_Return()
        {
            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 };
            var user = new User { UserId = 1, UserName = "User 1" };
            _catalog?.AddGood(good.GoodId, good);
            _users?.AddUser(user);
            _events.Purchase(user.UserId, good.GoodId);

            // Act
            _events.Return(user.UserId, good.GoodId);


            // Assert
            Assert.That(good.Quantity, Is.EqualTo(10));
        }

        /// Test the exception when we try to purchase a good out of stock
        [Test]
        public void BuyGood_ThrowsExceptionWhenGoodOutOfStock()
        {
            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 0, Price = 100 };
            var user = new User { UserId = 1, UserName = "User 1" };
            _catalog?.AddGood(good.GoodId, good);
            _users?.AddUser(user);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _events.Purchase(user.UserId, good.GoodId));
            Assert.That(ex.Message, Is.EqualTo("Good is out of stock"));
        }
    }
}
