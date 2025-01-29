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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        public void LoadOrders()
        {
            using (var db = new BookStoreEntities())
            {
                var orders = db.Orders
                    .Select(o => new
                    {
                        o.OrderID,
                        o.UserID,
                        o.BookID,
                        o.OrderDate,
                        o.DeliveryAddress
                    })
                    .ToList();

                OrdersDataGrid.ItemsSource = orders;
            }
        }
    }
}
