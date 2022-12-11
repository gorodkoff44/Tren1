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

namespace Tren1_Gorodkov
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private Tren1Entities _context = new Tren1Entities();
        public HomePage()
        {
            InitializeComponent();
            LVServices.ItemsSource = _context.Service.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            //if (LVServices.SelectedItem == null)
            //{
            //    MessageBox.Show("Не выбран объект для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            try
            {
                //_context.Service.Remove((Service)LVServices.SelectedItem);
                _context.Service.Remove((sender as Button).DataContext as Service);
               // sender as Button).DataContext as Sklad
                _context.SaveChanges();
                LVServices.ItemsSource = _context.Service.ToList();

            }
            catch
            {
                MessageBox.Show("Что то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
