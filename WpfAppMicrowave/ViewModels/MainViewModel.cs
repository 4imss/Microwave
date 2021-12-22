namespace WpfAppMicrowave.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // The image used to display the products in the microwave.
        private string _fillingImage = "../Img/Nothing.png";

        // The background image of the grid.
        private string _gridImage;

        public string GridImage
        {
            get => _gridImage;
            set
            {
                _gridImage = value;
                NotifyPropertyChanged();
            }
        }

        public string FillingImage
        {
            get => _fillingImage;
            set
            {
                _fillingImage = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}