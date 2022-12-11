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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditServicePage(null));
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.Service.Remove((sender as Button).DataContext as Service);
                _context.SaveChanges();
                LVServices.ItemsSource = _context.Service.ToList();
                MessageBox.Show("Сервис был удален?", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Что то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditServicePage((sender as Button).DataContext as Service));
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _currentService = _context.Service.ToList(); //Поиск
            {
                _currentService = _currentService.FindAll(x => x.Title.Contains(SearchBox.Text));
                LVServices.ItemsSource = _currentService;
            }
        }
    }
}
