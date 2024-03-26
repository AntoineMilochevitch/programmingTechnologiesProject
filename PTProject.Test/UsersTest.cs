using NUnit.Framework;
using PTProject.Data;

namespace PTProject.Test
{
    public class UserTest
    {
        private IUsers _users;

        [SetUp]
        public void Setup()
        {
            _users = new Users();
        }

        [Test]
        public void AddUser_AddsUserToList()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1", UserType = "actor" };

            // Act
            _users.AddUser(user);

            // Assert
            bool userExists = false;
            foreach (var u in _users.GetUsers())
            {
                if (u.UserId == user.UserId && u.UserName == user.UserName && u.UserType == user.UserType)
                {
                    userExists = true;
                    break;
                }
            }
            Assert.IsTrue(userExists);
            Assert.Contains(user, _users.GetUsers());
        }

        [Test]
        public void RemoveUser_RemovesUserFromList()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1", UserType = "actor" };
            _users.AddUser(user);

            // Act
            _users.RemoveUser(user);

            // Assert
            Assert.That(_users.GetUsers(), Does.Not.Contain(user));
        }

        [Test]
        public void GetUsers_ReturnsCorrectUsers()
        {
            // Arrange
            var user1 = new User { UserId = 1, UserName = "User 1", UserType = "actor" };
            var user2 = new User { UserId = 2, UserName = "User 2", UserType = "supplier" };
            _users.AddUser(user1);
            _users.AddUser(user2);

            // Act
            var result = _users.GetUsers();

            // Assert
            bool user1Exists = false;
            bool user2Exists = false;
            foreach (var u in result)
            {
                if (u.UserId == user1.UserId && u.UserName == user1.UserName && u.UserType == user1.UserType)
                {
                    user1Exists = true;
                }
                if (u.UserId == user2.UserId && u.UserName == user2.UserName && u.UserType == user2.UserType)
                {
                    user2Exists = true;
                }
            }
            Assert.IsTrue(user1Exists);
            Assert.IsTrue(user2Exists);
        }

    }
}