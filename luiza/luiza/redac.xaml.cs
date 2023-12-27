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
    /// Логика взаимодействия для redac.xaml
    /// </summary>
    public partial class redac : Window
    {
        bd.Entities1 entities1;
        int id;
        public redac(bd.Entities1 entities1, bd.User user)
        {
            InitializeComponent();
            roles.ItemsSource = App.entities.Roles.Select(c => c.rol).ToList();
            this.entities1 = entities1;
            this.DataContext = user;
            id = user.id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = App.entities.Users.FirstOrDefault(c=> c.id == id);
            int idroles = App.entities.Roles.Where(c=>c.rol ==roles.Text ).Select(c => c.id).FirstOrDefault();
            user.idRole = idroles;
            App.entities.SaveChanges();
        }
    }
}
