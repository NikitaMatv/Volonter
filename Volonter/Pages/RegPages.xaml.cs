using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPages.xaml
    /// </summary>
    public partial class RegPages : Page
    { Employ contextEmploy;
        public RegPages(Employ employ)
        {
            InitializeComponent();
            contextEmploy = employ;
            DataContext = contextEmploy;
        }

        private void BtRegEnd_Click(object sender, RoutedEventArgs e)
        {
            if(TbLogin.Text != string.Empty && TbName.Text != String.Empty && TbPassword.Text != string.Empty)
            {
                if(App.DB.Employ.FirstOrDefault(x=> x.Login == TbLogin.Text) != null)
                {
                    MessageBox.Show("Логин уже занят ");
                    return;
                }
                contextEmploy.RoleId = 1;
                App.DB.Employ.Add(contextEmploy);
                App.DB.SaveChanges();
                NavigationService.Navigate(new AutorPages());
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
        }

        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(Regex.IsMatch(e.Text, @"[А-я]") == false)
            {
                e.Handled = true;
            }

        }
    }
}
