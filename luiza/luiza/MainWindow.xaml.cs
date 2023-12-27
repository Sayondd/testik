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

namespace luiza
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
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
            var user = App.entities.Users.FirstOrDefault(x => x.logins == login.Text && (x.passwords == pass.Text || x.passwords == passb.Password));
            if (user != null)
            {
                switch (user.idRole)
                {
                    case 1:
                        admin admin = new admin();
                        admin.Show();
                        this.Close();
                        break;
                    case 2:
                        nach nach = new nach();
                        nach.Show();
                        this.Close();
                        break;
                    case 3:
                        prod prod = new prod();
                        prod.Show();
                        this.Close();
                        break;

                }
            }
            else
            {
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reg reg = new reg();
            reg.Show();
            this.Close();
        }
    }
}
