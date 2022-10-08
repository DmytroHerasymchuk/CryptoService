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

        public InfoPage(InfoViewModel infoViewModel)
        {
            InitializeComponent();
                 
            name.Content = infoViewModel.Currency.Result.Name;
            
            symbol.Content = infoViewModel.Currency.Result.Symbol.ToUpper();
            
            volume.Content = infoViewModel.Currency.Result.Volume;
            
            marketCap.Content = infoViewModel.Currency.Result.MarketCap;
            
            rank.Content = infoViewModel.Currency.Result.Rank;
            
            price.Content = infoViewModel.Currency.Result.PriceUsd.ToString() + " $";
            
            change.Content = infoViewModel.Currency.Result.ChangePercent.ToString() + " %";
            
            Markets.ItemsSource = infoViewModel.Currency.Result.Markets;
        }

        private void GoToMain(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MainViewModel("https://api.coingecko.com/api/v3/search/trending"));
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
