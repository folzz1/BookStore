using System;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class AddAuthorPage : Page
    {
        private BookStoreEntities _context;
        private Authors _currentAuthor;

        public AddAuthorPage()
        {
            InitializeComponent();
            _context = new BookStoreEntities();
        }

        public AddAuthorPage(Authors author) : this()
        {
            _currentAuthor = author;
            FirstNameTextBox.Text = author.FirstName;
            LastNameTextBox.Text = author.LastName;
            PatronymicTextBox.Text = author.Patronymic;
            BioTextBox.Text = author.Bio;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentAuthor == null)
                {
                    var newAuthor = new Authors
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        Patronymic = PatronymicTextBox.Text,
                        Bio = BioTextBox.Text
                    };
                    _context.Authors.Add(newAuthor);
                }
                else
                {
                    var authorToUpdate = _context.Authors.Find(_currentAuthor.AuthorID);
                    if (authorToUpdate != null)
                    {
                        authorToUpdate.FirstName = FirstNameTextBox.Text;
                        authorToUpdate.LastName = LastNameTextBox.Text;
                        authorToUpdate.Patronymic = PatronymicTextBox.Text;
                        authorToUpdate.Bio = BioTextBox.Text;
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
}