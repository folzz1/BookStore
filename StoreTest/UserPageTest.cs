using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;

namespace StoreTest
{
    [TestClass]
    public class UserPageTest
    {
        private UserPage _userPage;
        private int _testUserId = 6;

        [TestInitialize]
        public void Setup()
        {
            _userPage = new UserPage(_testUserId);
        }

        [TestMethod]
        public void TestLoadOrders_PopulatesDataGrid()
        {
            _userPage.LoadOrders();

            var dataGrid = (DataGrid)_userPage.FindName("OrdersDataGrid");
            Assert.IsNotNull(dataGrid.ItemsSource);
            Assert.IsTrue(dataGrid.Items.Count > 0);
        }
    }
}
