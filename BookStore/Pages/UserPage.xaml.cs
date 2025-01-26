using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Pages
{
    public partial class UserPage : Page
    {
        private int _userId;

        public UserPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (var db = new BookStoreEntities())
            {
                var orders = db.Orders
                    .Where(o => o.UserID == _userId) 
                    .Select(o => new
                    {
                        o.OrderID,
                        o.BookID,
                        o.OrderDate,
                        o.DeliveryAddress
                    })
                    .ToList();

                OrdersDataGrid.ItemsSource = orders;
            }
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MakeOrderPage(_userId));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                LoadOrders();
            }
        }
    }
}