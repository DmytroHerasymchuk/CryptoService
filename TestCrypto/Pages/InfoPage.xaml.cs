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
using System.Diagnostics;
using Models;
using ViewModels;

namespace TestCrypto
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        private InfoViewModel viewModel;
        public InfoPage(string id)
        {
            InitializeComponent();
            viewModel = new InfoViewModel($"https://api.coingecko.com/api/v3/coins/{id}?localization=false&community_data=false&developer_data=false");
            name.Content = viewModel.Currency.Name;
            symbol.Content = viewModel.Currency.Symbol.ToUpper();
            volume.Content = viewModel.Currency.Volume;
            marketCap.Content = viewModel.Currency.MarketCap;
            rank.Content = viewModel.Currency.Rank;
            price.Content = viewModel.Currency.PriceUsd.ToString() + " $";
            change.Content = viewModel.Currency.ChangePercent.ToString() + " %";
            Markets.ItemsSource = viewModel.Currency.Markets;
        }

        private void GoToMain(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainViewModel("https://api.coingecko.com/api/v3/search/trending", "gecko"));
        }
        private void GoToConvert(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ConvertPage());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
