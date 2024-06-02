using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Presentation.ViewModels;
using PTProject.Presentation.Models;
using System.Linq;
using System;

namespace PTProject.ViewModelsTest
{
    [TestClass]
    public class UserMasterViewModelTests
    {
        private UserMasterViewModel _viewModel;
        private UserServiceStub _userServiceStub;
        private static Random _random = new Random();


        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceStub = new UserServiceStub();
            UserModel userModel = new UserModel(_userServiceStub);
            _viewModel = new UserMasterViewModel(userModel);
        }
        private User GenerateUser()
        {
            int randomId = _random.Next(1, 100);
            string randomUserName = GenerateRandomUserName();
            return new User { Id = randomId, UserName = randomUserName };
        }
        private string GenerateRandomUserName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        [TestMethod]
        public void TestAddUser()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "User1" };

            // Act
            _viewModel.AddUser(user.UserName);

            // Assert
            var users = _viewModel.Users;
            Assert.AreEqual(1, users.Count);
            Assert.AreEqual(user.Id, users.First().Id);
            Assert.AreEqual(user.UserName, users.First().UserName);
        }

        [TestMethod]
        public void TestAddUser2()
        {
            // Arrange
            var user = GenerateUser();

            // Act
            _viewModel.AddUser(user.UserName);

            // Assert
            var users = _viewModel.Users;
            Assert.AreEqual(1, users.Count);
            Assert.AreEqual(user.UserName, users.First().UserName);
            Assert.AreEqual(user.Id, users.First().Id);


        }

    }
}
