using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void TextBoxLogin_Changed(object sender, RoutedEventArgs e)
        {
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var user = ValidateUserCredentials(username, password);

            if (user == null)
            {
                return; // Сообщения об ошибках уже обработаны в ValidateUserCredentials
            }

            MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            switch (user.RoleID)
            {
                case 1:
                    NavigationService.Navigate(new AdminPage());
                    break;
                case 2:
                    NavigationService.Navigate(new UserPage(user.UserID));
                    break;
            }
        }

        public Users ValidateUserCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            using (var db = new BookStoreEntities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                if (user.PasswordHash != password)
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }

                return user;
            }
        }
    }
}