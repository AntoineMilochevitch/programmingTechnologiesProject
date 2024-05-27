using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Service;

namespace PTProject.ServiceTest
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userService;
        private UnitOfWorkStub _unitOfWorkStub;

        [TestInitialize]
        public void TestInitialize()
        {
            _unitOfWorkStub = new UnitOfWorkStub();
            _userService = new UserService(_unitOfWorkStub);
        }

        [TestMethod]
        public void TestAddUser()
        {
            // Arrange
            var userDTO = new UserDTO { Id = 1, UserName = "User1" };

            // Act
            _userService.AddUser(userDTO);

            // Assert
            var user = _unitOfWorkStub.UserRepository.GetById(userDTO.Id);
            Assert.IsNotNull(user, "User should not be null");
            Assert.AreEqual(userDTO.Id, user.Id);
            Assert.AreEqual(userDTO.UserName, user.UserName);
        }

    }
}
