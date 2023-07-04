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
    /// Логика взаимодействия для AutorPages.xaml
    /// </summary>
    public partial class AutorPages : Page
    {
        public AutorPages()
        {
            InitializeComponent();
        }

        private void BtAutor_Click(object sender, RoutedEventArgs e)
        {
            if (App.DB.Employ.FirstOrDefault(x => x.Login == TbLogin.Text) != null)
            {
                Employ empl = App.DB.Employ.FirstOrDefault(x => x.Login == TbLogin.Text);
                if (empl.Password == PbPassword.Password)
                {
                    if (empl.RoleId == 2)
                    {
                        App.AutorEmploy = empl;                      
                        NavigationService.Navigate(new MainPages());
                    }
                    else
                    {
                        MessageBox.Show("Приложение только для координатора");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show(" Неверный пароль  ");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя нету");
                return;
            }
        }   
    }
}
