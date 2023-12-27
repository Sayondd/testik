using luiza.bd;
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
using System.Windows.Shapes;

namespace luiza
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
            {
                pass.Text = passb.Password;
                pass.Visibility = Visibility.Visible;
                passb.Visibility = Visibility.Hidden;
            }
            else
            {
                passb.Password = pass.Text;
                pass.Visibility = Visibility.Hidden;
                passb.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.entities.Users.Any(a => a.logins == login.Text))
            {
                MessageBox.Show("Дэбил");
            }
            else
            {
                if (pass.MaxLength >= 8 && passb.MaxLength >= 8)
                {
                    MessageBox.Show("Пароль короткий");
                }
                else
                {
                    bd.User entities1 = new bd.User { logins = login.Text, passwords = passb.Password, idRole = 3 };
                    App.entities.Users.Add(entities1);
                    App.entities.SaveChanges();
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }
        }
    }
}
