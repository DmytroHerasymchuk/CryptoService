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
        private ViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new ViewModel("https://api.coincap.io/v2/assets");
            View.ItemsSource = _viewModel.Currencies;
        }

        private void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            CurrencyInfo currencyInfo = ((FrameworkElement)sender).DataContext as CurrencyInfo;           
            TextBlock textBlock = new TextBlock();
            textBlock.Text = currencyInfo.Name + " information";
            textBlock.Margin = new Thickness(30, 0, 0, 0);
            Navigation.Children.Add(textBlock);
            InfoPage informationPage = new InfoPage(this, currencyInfo, Navigation);

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

    }
}
