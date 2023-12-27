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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для red.xaml
    /// </summary>
    public partial class red : Window
    {
        public red()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.entities.Users.Any(x => x.logins == login.Text))
            {
                MessageBox.Show("Ты тупой?");
            }
            else
            {
                db.User user = new db.User { logins = login.Text, passwords = passb.Password, idRole = 3 };
                App.entities.Users.Add(user);
                App.entities.SaveChanges();
                MessageBox.Show("ТЫ ЕБЛАН");
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            if (check.IsChecked == true)
            {
                pass.Text = passb.Password;
                passb.Visibility = Visibility.Hidden;
                pass.Visibility = Visibility.Visible;
            }
            else
            {
                passb.Password = pass.Text;
                passb.Visibility = Visibility.Visible;
                pass.Visibility = Visibility.Hidden;
            }
        }
    }
    
}
