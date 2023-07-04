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
using Volonter.Components;

namespace Volonter.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPages.xaml
    /// </summary>
    public partial class MainPages : Page
    {
        public MainPages()
        {
            InitializeComponent();
            LvOrders.ItemsSource = App.DB.Order.Where(x => x.EmployId == null && x.Status == 0).ToList();
            var Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 30);
            Timer.Start();
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorPages());
            App.AutorEmploy = null;
        }

        private void BtAccept_Click(object sender, RoutedEventArgs e)
        {
            var order = (sender as Button).DataContext as Order;
            order.Status = 1;
            order.EmployId = App.AutorEmploy.Id;
            App.DB.SaveChanges();
            NavigationService.Navigate(new OrderPages(order));
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LvOrders.ItemsSource = App.DB.Order.Where(x => x.EmployId == null && x.Status == 0).ToList();
        }
    }
}
