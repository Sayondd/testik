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
using WpfApp1.db;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            roli.ItemsSource = App.entities.Roles.Select(c => c.rol).ToList();
        }
        int Attempts;

        private void CheckBox_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var use = App.entities.Users.FirstOrDefault(x => x.logins == login.Text && (x.passwords == passb.Password || x.passwords == pass.Text));
            if (passb.Password == "" && login.Text == "")
            {
                MessageBox.Show("Не все данные заполнены");
            }
            else
            {
                if (use != null)
                {
                    switch (use.idRole)
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
                    Attempts++;
                    UsersFalse();
                }
            }
            
            
        }
        public void UsersFalse()//Блок неверной капчи
        {
            if (Attempts == 1 || Attempts == 2)
            {
                MessageBoxResult result = MessageBox.Show("Неверно введёт логин или пароль.\nПроверьте введённые вами данные!",
                    "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (Attempts >= 3)
            {
                MessageBox.Show("idi naxui");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            red red = new red();
            red.Show();
            this.Close();
        }
    }
}
