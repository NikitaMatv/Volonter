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
    /// Логика взаимодействия для OrderPages.xaml
    /// </summary>
    public partial class OrderPages : Page
    {
        Order contextOrder;
        public OrderPages(Order order)
        {
            InitializeComponent();
            contextOrder = order;
            DataContext = contextOrder;
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            contextOrder.Status = 3;
            contextOrder.EmployId = null;
            App.DB.SaveChanges();
            NavigationService.Navigate(new MainPages());
        }

        private void BtEnd_Click(object sender, RoutedEventArgs e)
        {
            contextOrder.Status = 2;
            App.DB.SaveChanges();
            NavigationService.Navigate(new MainPages());
        }
    }
}
