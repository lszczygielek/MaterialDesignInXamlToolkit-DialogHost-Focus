using MaterialDesignThemes.Wpf;
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

namespace MaterialDesignInXamlToolkit_DialogHost_Focus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new ViewModel();
            DataContext = viewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // await DialogHost.Show(string.Empty);
            var abc = new ViewModel { LastInput = viewModel.LastInput };

            var result = await DialogHost.Show(
                //new ViewModel { LastInput = viewModel.LastInput },
                abc,
                (object sender, DialogClosingEventArgs args) =>
                {
                    if (args.Parameter is bool isConfirmed && !isConfirmed)
                    {
                        return;
                        
                    }
                    else
                    {
                        viewModel.LastInput = ((ViewModel)args.Session.Content).LastInput;
                    }
                });
        }
    }
}
