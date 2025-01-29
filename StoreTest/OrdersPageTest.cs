using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;

namespace StoreTest
{
    [TestClass]
    public class OrdersPageTest
    {
        private OrdersPage _ordersPage;

        [TestInitialize]
        public void Setup()
        {
            _ordersPage = new OrdersPage();
        }

        [TestMethod]
        public void TestLoadOrders_PopulatesDataGrid()
        {
            _ordersPage.LoadOrders();

            var dataGrid = (DataGrid)_ordersPage.FindName("OrdersDataGrid");
            Assert.IsNotNull(dataGrid.ItemsSource);
            Assert.IsTrue(dataGrid.Items.Count > 0);
        }
    }
}