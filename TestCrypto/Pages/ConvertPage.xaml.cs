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
            //List<string> names = new List<string>();
            //foreach (Currency currency in converterViewModel.Currencies.Result)
            //{
            //    names.Add(currency.Name);
            //}
            First.ItemsSource = converterViewModel.Currencies.Result;
            Second.ItemsSource = converterViewModel.Currencies.Result;

        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            viewModel.FirstCurrency = First.SelectedItem as Currency;
            viewModel.SecondCurrency = Second.SelectedItem as Currency;
            viewModel.Convert(System.Convert.ToDecimal(FirstInput.Text));
            SecondInput.Text = viewModel.Converted.ToString();
        }

        private void SecondInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }

        private void FirstInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }

        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
    }
}
