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
using Models;
using ViewModels;

namespace TestCrypto
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel("https://api.coingecko.com/api/v3/search/trending");

        
            View.ItemsSource = _viewModel.Currencies;
        }

        private void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            Currency currencyInfo = ((FrameworkElement)sender).DataContext as Currency;           

            InfoPage informationPage = new InfoPage(currencyInfo.ID);

            NavigationService.Navigate(informationPage);
        }

        private void GoToMain(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
        private void GoToConvert(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ConvertPage());
        }

        private void SearchCurrency(object sender, RoutedEventArgs e)
        {

        }
    }
}
