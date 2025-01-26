using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ViewAuthors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorsPage());
        }

        private void ViewGenres_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GenresPage());
        }

        private void ViewBooks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BooksPage());
        }

        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersPage());
        }
    }
}
