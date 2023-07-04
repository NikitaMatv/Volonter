using Koordibnator.Components;
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

namespace Koordibnator.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPages.xaml
    /// </summary>
    public partial class MainPages : Page
    {
        public MainPages()
        {
            InitializeComponent();
            LvOrders.ItemsSource = App.DB.Order.Where(x => x.Status <= 1 || x.Status == 3).ToList();
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

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
   
                NavigationService.Navigate(new AddEditPages(new Order()));

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LvOrders.ItemsSource = App.DB.Order.Where(x => x.Status <= 1 || x.Status == 3).ToList();
        }

        private void BtEdint_Click(object sender, RoutedEventArgs e)
        {
            var selectOrder = LvOrders.SelectedItem as Order;
            if(selectOrder == null)
            {
                MessageBox.Show("Выберете заказ");
                return;
            }
            if(selectOrder.EmployId == null && selectOrder.Status == 0)
            {
                NavigationService.Navigate(new AddEditPages(selectOrder));
            }
            else
            {
                MessageBox.Show("Этот заказ уже нельзя изменить");
                return;
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            var selectOrder = LvOrders.SelectedItem as Order;
            if (selectOrder == null)
            {
                MessageBox.Show("Выберете заказ");
                return;
            }
            if (selectOrder.EmployId == null && (selectOrder.Status == 0 || selectOrder.Status ==3))
            {

                selectOrder.Status = 2;
                App.DB.SaveChanges();
                LvOrders.ItemsSource = App.DB.Order.Where(x => x.Status <=1 || x.Status == 3).ToList();
            }
            else
            {
                MessageBox.Show("Этот заказ уже нельзя изменить");
                return;
            }
        }
    }
}
