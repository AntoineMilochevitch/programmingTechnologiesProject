using NUnit.Framework;
using PTProject.Data;


/// List of all test
/// Add an user of the users list
/// Remove an user of the users list
/// Test to verify that different users can be created
/// Test to verify that different users can be created and that we can return the correct user
/// Return null if the user doesn't exist
/// Test the exception of user already exist
/// Test the exception user is null

namespace PTProject.Data.Test
{
    public class UserTest
    {
        private IUsers _users;

        [SetUp]
        public void Setup()
        {
            _users = new Users();
        }

        /// Add an user of the users list
        [Test]
        public void AddUser_AddsUserToList()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1"};

            // Act
            _users.AddUser(user);

            // Assert
            Assert.Contains(user, _users.GetAllUsers());
        }

        /// Remove an user of the users list
        [Test]
        public void RemoveUser_RemovesUserFromList()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1" };
            _users.AddUser(user);

            // Act
            _users.RemoveUser(user);

            // Assert
            Assert.That(_users.GetAllUsers(), Does.Not.Contain(user));
        }

        /// Test to verify that different users can be created
        [Test]
        public void GetUsers_ReturnsCorrectUsers()
        {
            // Arrange
            var user1 = new User { UserId = 1, UserName = "User 1" };
            var user2 = new User { UserId = 2, UserName = "User 2" };
            _users.AddUser(user1);
            _users.AddUser(user2);

            // Act
            var result = _users.GetAllUsers();

            // Assert
            Assert.Contains(user1, result);
            Assert.Contains(user2, result); 
        }

        /// Test to verify that different users can be created and that we can return the correct user
        [Test]
        public void GetUser_ReturnsCorrectUser()
        {
            // Arrange
            var user1 = new User { UserId = 1, UserName = "User 1" };
            var user2 = new User { UserId = 2, UserName = "User 2" };
            _users.AddUser(user1);
            _users.AddUser(user2);

            // Act
            var result1 = _users.GetUser(user1.UserId);
            var result2 = _users.GetUser(user2.UserId);

            // Assert
            Assert.That(result1, Is.EqualTo(user1));
            Assert.That(result2, Is.EqualTo(user2));
        }

        /// Return null if the user doesn't exist
        [Test]
        public void GetUser_ReturnsNullForNonexistentUser()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1" };
            _users.AddUser(user);

            // Act
            var result = _users.GetUser(999); // ID that doesn't exist

            // Assert
            Assert.IsNull(result);
        }

        /// Test the exception of user already exist
        [Test]
        public void AddUser_ThrowsExceptionWhenUserAlreadyExists()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "User 1" };
            _users.AddUser(user);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _users.AddUser(user));
            Assert.That(ex.Message, Is.EqualTo("User already exists"));
        }

        /// Test the exception user is null
        [Test]
        public void AddUser_ThrowsExceptionWhenUserIsNull()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _users.AddUser(null));
            Assert.That(ex.ParamName, Is.EqualTo("user"));
            Assert.That(ex.Message, Does.Contain("User cannot be null"));
        }
    }
}