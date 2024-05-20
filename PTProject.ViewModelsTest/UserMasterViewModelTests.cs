using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.ViewModels;
using System.Collections.Generic;


namespace PTProject.ViewModelsTest
{

    [TestClass]
    public class UserMasterViewModelTests
    {
        private List<PTProject.Presentation.Models.User> GenerateRandomUsers(int count)
        {
            var users = new List<PTProject.Presentation.Models.User>();
            for (int i = 0; i < count; i++)
            {
                users.Add(new PTProject.Presentation.Models.User { UserId = i, UserName = $"User{i}" });
            }
            return users;
        }

        private List<PTProject.Presentation.Models.User> GenerateSpecificUsers()
        {
            return new List<PTProject.Presentation.Models.User>
    {
        new PTProject.Presentation.Models.User { UserId = 1, UserName = "Alice" },
        new PTProject.Presentation.Models.User { UserId = 2, UserName = "Bob" },
    };
        }

        [TestMethod]
        public void LoadUsers_LoadsCorrectUsers()
        {
            // Arrange
            var userService = new UserServiceStub(GenerateSpecificUsers());
            var viewModel = new UserMasterViewModel(userService);

            // Act
            viewModel.LoadUsers();

            // Assert
            Assert.AreEqual(2, viewModel.Users.Count);
            Assert.AreEqual("Alice", viewModel.Users[0].UserName);
            Assert.AreEqual("Bob", viewModel.Users[1].UserName);
        }

        [TestMethod]
        public void AddUser_AddsUserToUsers()
        {
            // Arrange
            var userService = new UserServiceStub(GenerateRandomUsers(2));
            var viewModel = new UserMasterViewModel(userService);

            // Act
            viewModel.AddUser("Charlie");

            // Assert
            Assert.AreEqual(3, viewModel.Users.Count);
            Assert.AreEqual("Charlie", viewModel.Users[2].UserName);
        }
    }
}

