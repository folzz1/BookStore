using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace StoreTest
{
    [TestClass]
    public class MakeOrderTest
    {
        private MakeOrderPage _makeOrderPage;
        private int _testUserId = 6;

        [TestInitialize]
        public void Setup()
        {
            _makeOrderPage = new MakeOrderPage(_testUserId);
        }

        [TestMethod]
        public void TestLoadBooks_PopulatesListView()
        {
    
            _makeOrderPage.LoadBooks();

            var listView = (ListView)_makeOrderPage.FindName("BooksListView");
            Assert.IsNotNull(listView.ItemsSource);
            Assert.IsTrue(listView.Items.Count > 0);
        }

        [TestMethod]
        public void TestCheckSelectedBooksAndAdres()
        {
            List<int> _selectedBookIds = new List<int>();
            _selectedBookIds.Add(1);
            _selectedBookIds.Add(2);
            var res = _makeOrderPage.ValidateOrder("adress", _selectedBookIds);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestCheckNoSelectedBooksAndAdres()
        {
            List<int> _selectedBookIds = new List<int>();
            var res = _makeOrderPage.ValidateOrder("", _selectedBookIds);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void PlaceOrder_SuccessfulOrder_ReturnsTrue()
        {
            string deliveryAddress = "Adres";
            List<int> selectedBookIds = new List<int> { 4, 5 };

            bool result = _makeOrderPage.PlaceOrder(deliveryAddress, selectedBookIds);

            Assert.IsTrue(result);
        }

    }
}
