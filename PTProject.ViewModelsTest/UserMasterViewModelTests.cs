using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Presentation.ViewModels;
using PTProject.Presentation.Models;
using System.Linq;

namespace PTProject.ViewModelsTest
{
    [TestClass]
    public class UserMasterViewModelTests
    {
        private UserMasterViewModel _viewModel;
        private UserServiceStub _userServiceStub;

        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceStub = new UserServiceStub();
            UserModel userModel = new UserModel(_userServiceStub);
            _viewModel = new UserMasterViewModel(userModel);
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
    }
}
