using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialDesignInXamlToolkit_DialogHost_Focus
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string lastInput;

        public string LastInput 
        { 
            get => lastInput;

            set
            {
                lastInput = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
