using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class AddBookPage : Page
    {
        private BookStoreEntities _context;
        private Books _currentBook;

        public AddBookPage()
        {
            InitializeComponent();
            _context = new BookStoreEntities();
            LoadAuthors();
            LoadGenres();
        }

        public AddBookPage(Books book) : this()
        {
            _currentBook = book;
            TitleTextBox.Text = book.Title;
            AuthorComboBox.SelectedValue = book.AuthorID;
            GenreComboBox.SelectedValue = book.GenreID;
            PriceTextBox.Text = book.Price.ToString();
            StockTextBox.Text = book.Stock.ToString();
        }

        private void LoadAuthors()
        {
            using (var db = new BookStoreEntities())
            {
                var authors = db.Authors.Select(a => new
                {
                    a.AuthorID,
                    FullName = a.LastName
                }).ToList();

                AuthorComboBox.ItemsSource = authors;
                AuthorComboBox.DisplayMemberPath = "FullName";
                AuthorComboBox.SelectedValuePath = "AuthorID";
            }
        }

        private void LoadGenres()
        {
            using (var db = new BookStoreEntities())
            {
                var genres = db.Genres.Select(g => new
                {
                    g.GenreID,
                    g.GenreName
                }).ToList();

                GenreComboBox.ItemsSource = genres;
                GenreComboBox.DisplayMemberPath = "GenreName";
                GenreComboBox.SelectedValuePath = "GenreID";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                AuthorComboBox.SelectedValue == null ||
                GenreComboBox.SelectedValue == null ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(StockTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть положительным числом.");
                return;
            }

            if (!int.TryParse(StockTextBox.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Количество должно быть положительным целым числом.");
                return;
            }

            if (_currentBook == null)
            {
                var newBook = new Books
                {
                    Title = TitleTextBox.Text,
                    AuthorID = (int)AuthorComboBox.SelectedValue,
                    GenreID = (int)GenreComboBox.SelectedValue,
                    Price = price,
                    Stock = stock
                };
                _context.Books.Add(newBook);
            }
            else
            {
                var bookToUpdate = _context.Books.Find(_currentBook.BookID);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = TitleTextBox.Text;
                    bookToUpdate.AuthorID = (int)AuthorComboBox.SelectedValue;
                    bookToUpdate.GenreID = (int)GenreComboBox.SelectedValue;
                    bookToUpdate.Price = price;
                    bookToUpdate.Stock = stock;
                }
            }

            _context.SaveChanges();
            NavigationService.GoBack();
        }
    }
}