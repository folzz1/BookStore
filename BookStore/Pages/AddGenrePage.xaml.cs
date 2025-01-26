using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class AddGenrePage : Page
    {
        private BookStoreEntities _context;
        private Genres _currentGenre;

        public AddGenrePage()
        {
            InitializeComponent();
            _context = new BookStoreEntities();
        }

        public AddGenrePage(Genres genre) : this()
        {
            _currentGenre = genre;
            GenreNameTextBox.Text = genre.GenreName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentGenre == null)
            {
                var newGenre = new Genres
                {
                    GenreName = GenreNameTextBox.Text
                };
                _context.Genres.Add(newGenre);
            }
            else
            {
                var genreToUpdate = _context.Genres.Find(_currentGenre.GenreID);
                if (genreToUpdate != null)
                {
                    genreToUpdate.GenreName = GenreNameTextBox.Text;
                }
            }

            _context.SaveChanges();
            NavigationService.GoBack();
        }
    }
}