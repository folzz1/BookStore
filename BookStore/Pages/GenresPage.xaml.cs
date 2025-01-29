using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class GenresPage : Page
    {
        public GenresPage()
        {
            InitializeComponent();
            LoadGenres();
        }

        private void LoadGenres()
        {
            using (var db = new BookStoreEntities())
            {
                var genres = db.Genres
                    .Select(g => new
                    {
                        g.GenreID,
                        g.GenreName
                    })
                    .ToList();

                GenresDataGrid.ItemsSource = genres;
            }
        }

        public void DeleteGenre(int genreId)
        {
            using (var db = new BookStoreEntities())
            {
                var genreToDelete = db.Genres.Find(genreId);
                if (genreToDelete != null)
                {
                    db.Genres.Remove(genreToDelete);
                    db.SaveChanges();
                }
            }
            LoadGenres();
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddGenrePage());
        }

        private void EditGenre_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int genreId)
            {
                using (var db = new BookStoreEntities())
                {
                    var genre = db.Genres.Find(genreId);
                    NavigationService.Navigate(new AddGenrePage(genre));
                }
            }
        }

        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            if (GenresDataGrid.SelectedItem is var selectedGenre && selectedGenre != null)
            {
                int genreId = (int)((dynamic)selectedGenre).GenreID;
                DeleteGenre(genreId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите жанр для удаления.");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                LoadGenres();
            }
        }
    }
}