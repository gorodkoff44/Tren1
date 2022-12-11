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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Service _currentService = new Service();
        public AddEditServicePage(Service selectedService)
        {
            InitializeComponent();
            if (selectedService != null)
            {
                _currentService = selectedService;
            }
            DataContext = _currentService;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tren1Entities.GetContext().Service.Add(_currentService);
            }
            catch
            {
                MessageBox.Show("Ошибка GetContext().Service.Add");
            }
            try
            {
                Tren1Entities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено успешно", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка GetContext().SaveChanges()");
            }
        }
    }
}
