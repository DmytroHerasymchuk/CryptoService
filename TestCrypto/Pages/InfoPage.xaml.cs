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
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        Page backPage;
        public InfoPage(Page page, CurrencyInfo currencyInfo, StackPanel navigation)
        {
            InitializeComponent();
            backPage = page;
            name.Text = currencyInfo.Name;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = currencyInfo.Name + "information";
            textBlock.Margin = new Thickness(30, 0, 0, 0);
            

        }

        private void GoToMain(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(backPage);
        }
        private void GoToConvert(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ConvertPage());
        }
    }
}
