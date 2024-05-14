using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTProject.Data;
using System;

namespace PTProject.Logic.Test
{
    public class TestDataRepository : IDataRepository
    {
        public void AddGood(int id, IGood good) { }

        public void AddPurchase(IPurchase purchase) { }

        public void AddUser(IUser user) { }

        public IGood? GetGood(int id)
        {
            return id == 1 ? new Good { GoodId = 1 } : null;
        }

        public List<IPurchase> GetPurchases()
        {
            return new List<IPurchase>();
        }

        public IUser? GetUser(int id)
        {
            return id == 1 ? new User { UserId = 1 } : null;
        }

        public int NumberGood(int goodId)
        {
            return goodId == 1 ? 1 : 0;
        }

        public int NumberUser()
        {
            return 1;
        }

        public void Purchase(int userId, int goodId) { }

        public bool RemoveGood(int id)
        {
            return id == 1;
        }

        public bool RemovePurchase(IPurchase purchase)
        {
            return purchase != null;
        }

        public void RemoveUser(IUser user) { }

        public void Return(int userId, int goodId) { }
    }

    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void GetUser_UserExists_ReturnsUser()
        {
            // Arrange
            var testDataRepository = new TestDataRepository();
            var testUserId = 1;
            var dataService = new DataService(testDataRepository);

            // Act
            var result = dataService.GetUser(testUserId);

            // Assert
            Assert.AreEqual(testUserId, result.UserId);
        }

        // Add similar tests for the other methods of DataService class
    }
}