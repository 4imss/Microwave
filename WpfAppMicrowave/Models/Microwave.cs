namespace WpfAppMicrowave.Models
{
    using System.ComponentModel;

    /// <summary>
    ///     A new object called a microwave.
    /// </summary>
    public class Microwave : INotifyPropertyChanged
    {
        private bool _cook;
        private bool _door;
        private string _filled;
        private bool _lights;

        /// <summary>
        ///     Gets or Sets the microwave lights.
        /// </summary>
        public bool Lights
        {
            get => _lights;
            set
            {
                _lights = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or Sets the microwave door.
        /// </summary>
        public bool Door
        {
            get => _door;
            set
            {
                _door = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or Sets the microwave cooking mode.
        /// </summary>
        public bool Cook
        {
            get => _cook;
            set
            {
                _cook = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or Sets whether the microwave has something inside of it or not.
        /// </summary>
        public string Filled
        {
            get => _filled;
            set
            {
                _filled = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     On property changed event method.
        /// </summary>
        /// <param name="propertyName">The property name that has been changed.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}