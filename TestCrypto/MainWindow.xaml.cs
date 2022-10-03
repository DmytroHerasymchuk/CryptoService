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

namespace TestCrypto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
        }
        private void GoToConvertPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConvertPage();
        }

        private void GoToMainPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage();
        }
    }
}
