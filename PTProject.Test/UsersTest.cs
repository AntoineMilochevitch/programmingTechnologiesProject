using NUnit.Framework;
using PTProject.Data;

namespace PTProject.Test
{
    public class Tests
    {
        private Users _users;

        [SetUp]
        public void Setup()
        {
            _users = new Users();
        }

        [Test]
        public void AddUser_AddsUserToList()
        {
            // Arrange
            var user = new Users.User { UserId = 1, UserName = "User 1", UserEmail = "user1@example.com" };

            // Act
            _users.AddUser(user);

            // Assert
            bool userExists = false;
            foreach (var u in _users.GetUsers())
            {
                if (u.UserId == user.UserId && u.UserName == user.UserName && u.UserEmail == user.UserEmail)
                {
                    userExists = true;
                    break;
                }
            }
            Assert.IsTrue(userExists);
            Assert.AreEqual(1, _users.GetUsers().Count);
        }

        [Test]
        public void RemoveUser_RemovesUserFromList()
        {
            // Arrange
            var user = new Users.User { UserId = 1, UserName = "User 1", UserEmail = "user1@example.com" };
            _users.AddUser(user);

            // Act
            var result = _users.RemoveUser(user);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, _users.GetUsers().Count);
        }

        [Test]
        public void GetUsers_ReturnsCorrectUsers()
        {
            // Arrange
            var user1 = new Users.User { UserId = 1, UserName = "User 1", UserEmail = "user1@example.com" };
            var user2 = new Users.User { UserId = 2, UserName = "User 2", UserEmail = "user2@example.com" };
            _users.AddUser(user1);
            _users.AddUser(user2);

            // Act
            var result = _users.GetUsers();

            // Assert
            Assert.AreEqual(2, result.Count);
            bool user1Exists = false;
            bool user2Exists = false;
            foreach (var u in result)
            {
                if (u.UserId == user1.UserId && u.UserName == user1.UserName && u.UserEmail == user1.UserEmail)
                {
                    user1Exists = true;
                }
                if (u.UserId == user2.UserId && u.UserName == user2.UserName && u.UserEmail == user2.UserEmail)
                {
                    user2Exists = true;
                }
            }
            Assert.IsTrue(user1Exists);
            Assert.IsTrue(user2Exists);
        }

    }
}