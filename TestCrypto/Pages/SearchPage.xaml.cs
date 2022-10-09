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

namespace TestCrypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage(SearchViewModel searchViewModel)
        {
            InitializeComponent();
            View.ItemsSource = searchViewModel.Currencies.Result;
            if (searchViewModel.Currencies.Result.Count == 0)
            {              
                NotFound.Text = "Not Found";    
            }
        }

        private async void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            Currency currencyInfo = ((FrameworkElement)sender).DataContext as Currency;

            InfoViewModel infoViewModel = new InfoViewModel($"https://api.coingecko.com/api/v3/coins/{currencyInfo.ID}?localization=false&community_data=false&developer_data=false");
            await Task.Delay(2000);
            InfoPage informationPage = new InfoPage(infoViewModel);

            NavigationService.Navigate(informationPage);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
