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
    /// Логика взаимодействия для AddEditPages.xaml
    /// </summary>
    public partial class AddEditPages : Page
    {
        Order contextOrder;
        public AddEditPages(Order order)
        {
            InitializeComponent();
            contextOrder = order;
            DataContext = contextOrder;
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            contextOrder.Status = 0;
            if(contextOrder.Id == 0)
            App.DB.Order.Add(contextOrder);
            App.DB.SaveChanges();
            NavigationService.Navigate(new MainPages());
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages());
        }
    }
}
