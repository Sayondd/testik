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
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Window
    {
        public add()
        {
            InitializeComponent();
            roles.ItemsSource = App.entities.Roles.Select(c => c.rol).ToList();
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idRoles = App.entities.Roles.Where(c => c.rol == roles.Text).Select(c => c.id).FirstOrDefault();
            bd.User entities1 = new bd.User { logins = login.Text,passwords = pass.Text, idRole = idRoles};
            App.entities.Users.Add(entities1);
            App.entities.SaveChanges();
            admin main = new admin();
            main.Show();
            this.Close();
        }
    }
}
