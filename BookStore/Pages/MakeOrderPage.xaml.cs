using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class MakeOrderPage : Page
    {
        private int _userId;
        private List<int> _selectedBookIds = new List<int>();

        public MakeOrderPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadBooks();
        }

        public void LoadBooks()
        {
            using (var db = new BookStoreEntities())
            {
                var books = db.Books
                    .Select(b => new
                    {
                        b.BookID,
                        b.Title,
                        AuthorLastName = b.Authors.LastName,
                        GenreName = b.Genres.GenreName
                    })
                    .ToList();

                BooksListView.ItemsSource = books;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var book = checkBox.DataContext;
            var bookId = (int)book.GetType().GetProperty("BookID").GetValue(book);

            if (!_selectedBookIds.Contains(bookId))
            {
                _selectedBookIds.Add(bookId);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var book = checkBox.DataContext;
            var bookId = (int)book.GetType().GetProperty("BookID").GetValue(book);

            _selectedBookIds.Remove(bookId);
        }

        public bool ValidateOrder(string deliveryAddress, List<int> selectedBookIds)
        {
            return !string.IsNullOrWhiteSpace(deliveryAddress) && selectedBookIds.Any();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateOrder(DeliveryAddressTextBox.Text, _selectedBookIds))
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одну книгу и введите адрес доставки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PlaceOrder(DeliveryAddressTextBox.Text, _selectedBookIds))
            {
                MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
        }

        public bool PlaceOrder(string deliveryAddress, List<int> selectedBookIds)
        {
            try
            {
                using (var db = new BookStoreEntities())
                {
                    foreach (var bookId in selectedBookIds)
                    {
                        var order = new Orders
                        {
                            UserID = _userId,
                            BookID = bookId,
                            OrderDate = DateTime.Now,
                            DeliveryAddress = deliveryAddress
                        };
                        db.Orders.Add(order);
                    }

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}