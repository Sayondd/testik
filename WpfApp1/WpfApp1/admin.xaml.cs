using System;
using System.Collections;
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
using WpfApp1.db;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            DGV.ItemsSource = App.entities.Users.ToList();

        }
        int idE;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.aaaEntities entities = new db.aaaEntities();//создание нового контекста данных
            var id = DGV.SelectedItem as db.User;//переменную-выделенную приравниваем к типу employee
            idE = id.id;//получаем id сотрудника

            if (id == null)//Если никакая строка не выделена, выводим сообщение
            {
                MessageBox.Show("Не выбрана ни одна строка для удаления!");
                return;
            }
            //выводим сообщение с кнопками и получаем результат нажатой кнопки
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данные специалиста",
            "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)//если нажата кнопка да 
            {
                App.entities.Users.Remove(App.entities.Users.Find(idE));//удаление выделенной строки
                App.entities.SaveChanges();//сохранение изменений в БД
                DGV.ItemsSource = entities.Users.ToList();//обновляем список сотрудников
            }
        }
    }
}
