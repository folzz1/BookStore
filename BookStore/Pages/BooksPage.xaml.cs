using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class BooksPage : Page
    {
        public BooksPage()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var db = new BookStoreEntities())
            {
                var books = db.Books
                    .Select(b => new
                    {
                        b.BookID,
                        b.Title,
                        AuthorName = b.Authors.LastName,
                        GenreName = b.Genres.GenreName,
                        b.Price,
                        b.Stock
                    })
                    .ToList();

                BooksDataGrid.ItemsSource = books;
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var db = new BookStoreEntities())
            {
                var bookToDelete = db.Books.Find(bookId);
                if (bookToDelete != null)
                {
                    db.Books.Remove(bookToDelete);
                    db.SaveChanges();
                }
            }
            LoadBooks();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBookPage());
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int bookId)
            {
                using (var db = new BookStoreEntities())
                {
                    var book = db.Books.Find(bookId);
                    NavigationService.Navigate(new AddBookPage(book));
                }
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is var selectedBook && selectedBook != null)
            {
                int bookId = (int)((dynamic)selectedBook).BookID;
                DeleteBook(bookId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                LoadBooks();
            }
        }
    }
}