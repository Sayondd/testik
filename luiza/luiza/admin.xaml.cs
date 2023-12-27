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
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            dgv.ItemsSource = App.entities.Users.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            add add = new add();
            add.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var rows = dgv.SelectedItem as bd.User;
            if(rows == null)
            {
                MessageBox.Show("выдели строку");
            }
            MessageBoxResult result = MessageBox.Show("удалить?", "Удаление", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                App.entities.Users.Remove(rows);
                App.entities.SaveChanges();
                dgv.ItemsSource = App.entities.Users.ToList();
            }

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var rows = dgv.SelectedItem as bd.User;
            if(rows == null)
            {
                MessageBox.Show("Выдели строку");
            }
            else
            {
                redac redac = new redac(App.entities, rows);
                redac.ShowDialog();
                dgv.ItemsSource = App.entities.Users.ToList();
            }
        }
    }
}
