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
using ViewModels;
using Models;

namespace TestCrypto
{
    /// <summary>
    /// Логика взаимодействия для ConvertPage.xaml
    /// </summary>
    public partial class ConvertPage : Page
    {
        private ConverterViewModel viewModel;
        public ConvertPage(ConverterViewModel converterViewModel)
        {
            InitializeComponent();
            viewModel = converterViewModel;
            GetNames(converterViewModel);
        }

        private void GetNames(ConverterViewModel converterViewModel)
        {
            First.ItemsSource = converterViewModel.Currencies.Result;
            
            Second.ItemsSource = converterViewModel.Currencies.Result;
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            if (First.SelectedItem != null && Second.SelectedItem != null && (FirstInput.Text != "" || SecondInput.Text != ""))
            {
                viewModel.FirstCurrency = First.SelectedItem as CurrencyRate;
                viewModel.SecondCurrency = Second.SelectedItem as CurrencyRate;
                viewModel.Convert(System.Convert.ToDecimal(FirstInput.Text));
                SecondInput.Text = viewModel.Converted.ToString();
            }

        }

        private void SecondInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ",")
            {
                if (!((TextBox)sender).Text.Contains(","))
                {
                    approvedDecimalPoint = true;
                }
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
            {
                e.Handled = true;
            }
        }

        private void FirstInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool approvedDecimalPoint = false;

            if (e.Text == ",")
            {
                if (!((TextBox)sender).Text.Contains(","))
                {
                    approvedDecimalPoint = true;
                }
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
            {
                e.Handled = true;
            }
        }

        private void SwapCurrencies(object sender, RoutedEventArgs e)
        {
            if (First.SelectedItem != null && Second.SelectedItem != null)
            {
                CurrencyRate currencyRate = First.SelectedItem as CurrencyRate;
                First.SelectedItem = Second.SelectedItem;
                Second.SelectedItem = currencyRate;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
