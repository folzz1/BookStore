using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class AuthorsPage : Page
    {
        public AuthorsPage()
        {
            InitializeComponent();
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            using (var db = new BookStoreEntities())
            {
                var authors = db.Authors
                    .Select(a => new
                    {
                        a.AuthorID,
                        a.FirstName,
                        a.LastName,
                        a.Patronymic,
                        a.Bio
                    })
                    .ToList();

                AuthorsDataGrid.ItemsSource = authors;
            }
        }

        public void DeleteAuthor(int authorId)
        {
            using (var db = new BookStoreEntities())
            {
                var authorToDelete = db.Authors.Find(authorId);
                if (authorToDelete != null)
                {
                    db.Authors.Remove(authorToDelete);
                    db.SaveChanges();
                }
            }
            LoadAuthors();
        }

        private void DeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDataGrid.SelectedItem is var selectedAuthor && selectedAuthor != null)
            {
                int authorId = (int)((dynamic)selectedAuthor).AuthorID;
                DeleteAuthor(authorId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите автора для удаления.");
            }
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAuthorPage());
        }

        private void EditAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int authorId)
            {
                using (var db = new BookStoreEntities())
                {
                    var author = db.Authors.Find(authorId);
                    NavigationService.Navigate(new AddAuthorPage(author));
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                LoadAuthors();
            }
        }
    }
}