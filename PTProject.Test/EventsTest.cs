using NUnit.Framework.Internal.Execution;
using PTProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Test
{
    internal class EventsTest
    {
        private IEvents _events;

        [SetUp]
        public void Setup()
        {
            _events = new Events();
        }

        [Test]
        public void User_Purchase()
        {

            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 }
            var user = new User { UserId = 1, UserName = "User 1" };

            // Act
            _events.Purchase(user.UserId, good.GoodId);

            // Assert
            Assert.Contains(_events, _events.Purchase());

        }

    
            [Test]
        public void User_Return()
        {
            // Arrange
            var good = new Good { GoodId = 1, Description = "Test Good", Quantity = 10, Price = 100 }
            var user = new User { UserId = 1, UserName = "User 1" };
            _events.Purchase(user.UserId, good.GoodId)

            // Act
            _events.Return(user.UserId, good.GoodId);


            // Assert
            Assert.That(_events, Does.Not.Contain(Event));
        }

    }
}
