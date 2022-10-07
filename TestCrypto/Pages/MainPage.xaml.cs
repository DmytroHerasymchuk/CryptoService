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
using Services;
using TestCrypto.Pages;
using System.Diagnostics;

namespace TestCrypto
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainViewModel _viewModel;
        private SearchViewModel _searchViewModel;

        public MainPage()
        {
            InitializeComponent();
            //_viewModel = new MainViewModel("https://api.coingecko.com/api/v3/search/trending");
            //View.ItemsSource = _viewModel.Currencies;
            
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
        private async void SearchCurrency(object sender, RoutedEventArgs e)
        {
            
            if (Search.Text!="")
            {
                _searchViewModel = new SearchViewModel($"https://api.coingecko.com/api/v3/search?query={Search.Text.ToLower()}");
                await Task.Delay(3000);
                NavigationService.Navigate(new SearchPage(_searchViewModel));


            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void GetCoincap(object sender, RoutedEventArgs e)
        {
            _viewModel = new MainViewModel("https://api.coincap.io/v2/assets?limit=10" ,"coincap");
            View.ItemsSource = _viewModel.Currencies;
        }
        private void GetGecko(object sender, RoutedEventArgs e)
        {
            _viewModel = new MainViewModel("https://api.coingecko.com/api/v3/search/trending", "gecko");
            View.ItemsSource = _viewModel.Currencies;
        }
    }
}
