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

        public MainPage()
        {
            InitializeComponent();          
        }

        private async void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            Currency currencyInfo = ((FrameworkElement)sender).DataContext as Currency;

            InfoViewModel infoViewModel = new InfoViewModel($"https://api.coingecko.com/api/v3/coins/{currencyInfo.ID}?localization=false&community_data=false&developer_data=false");
            await Task.Delay(2000);
            InfoPage informationPage = new InfoPage(infoViewModel);

            NavigationService.Navigate(informationPage);
        }

        private void GoToMain(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Refresh();
        }
        private async void SearchCurrency(object sender, RoutedEventArgs e)
        {
            
            if (Search.Text!="")
            {
                SearchViewModel searchViewModel = new SearchViewModel($"https://api.coingecko.com/api/v3/search?query={Search.Text.ToLower()}");
                await Task.Delay(5000);
                NavigationService.Navigate(new SearchPage(searchViewModel));
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private async void GetTrands(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = new MainViewModel("https://api.coingecko.com/api/v3/search/trending");
            await Task.Delay(2000);
            View.ItemsSource = viewModel.Currencies.Result;
        }

        private void DarkMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Dark";
            Properties.Settings.Default.Save();
        }

        private void LightMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Light";
            Properties.Settings.Default.Save();
        }

        private async void GoToConverter(object sender, RoutedEventArgs e)
        {
            ConverterViewModel converterViewModel = new ConverterViewModel("https://api.coingecko.com/api/v3/exchange_rates");
            await Task.Delay(2000);
            NavigationService.Navigate(new ConvertPage(converterViewModel));
        }
    }
}
