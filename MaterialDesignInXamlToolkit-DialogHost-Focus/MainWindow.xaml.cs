using MaterialDesignThemes.Wpf;
using System.Windows;

namespace MaterialDesignInXamlToolkit_DialogHost_Focus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel updateSourceTriggerOnPropertyChangedViewModel;
        private ViewModel updateSourceTriggerOnLostFocusViewModel;

        public MainWindow()
        {
            InitializeComponent();

            updateSourceTriggerOnLostFocusViewModel = new ViewModel();
            OnLostFocusExample.DataContext = updateSourceTriggerOnLostFocusViewModel;

            updateSourceTriggerOnPropertyChangedViewModel = new ViewModel();
            OnPropertyChangedExample.DataContext = updateSourceTriggerOnPropertyChangedViewModel;
        }

        private async void OnLostFocusExampleButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await DialogHost.Show(
                new ViewModel { LastInput = updateSourceTriggerOnLostFocusViewModel.LastInput },
                "OnLostFocusExample",
                (object sender, DialogClosingEventArgs args) =>
                {
                    if (args.Parameter is bool isConfirmed && !isConfirmed)
                    {
                        return;
                        
                    }
                    else
                    {
                        updateSourceTriggerOnLostFocusViewModel.LastInput = ((ViewModel)args.Session.Content).LastInput;
                    }
                });
        }

        private async void OnPropertyChangedExampleButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await DialogHost.Show(
                new ViewModel { LastInput = updateSourceTriggerOnPropertyChangedViewModel.LastInput },
                "OnPropertyChangedExample",
                (object sender, DialogClosingEventArgs args) =>
                {
                    if (args.Parameter is bool isConfirmed && !isConfirmed)
                    {
                        return;

                    }
                    else
                    {
                        updateSourceTriggerOnPropertyChangedViewModel.LastInput = ((ViewModel)args.Session.Content).LastInput;
                    }
                });
        }
    }
}
