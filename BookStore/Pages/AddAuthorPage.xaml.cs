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

        public void AddAuthor(string firstName, string lastName, string patronymic, string bio)
        {
            var newAuthor = new Authors
            {
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                Bio = bio
            };
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentAuthor == null)
                {
                    AddAuthor(FirstNameTextBox.Text, LastNameTextBox.Text, PatronymicTextBox.Text, BioTextBox.Text);
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