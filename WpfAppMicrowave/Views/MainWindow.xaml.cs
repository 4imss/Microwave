namespace WpfAppMicrowave.Views
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using Models;
    using ViewModels;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     Makes a private variable with Microwave as the type. <see cref="Models.Microwave" />
        /// </summary>
        private readonly Microwave _microwave;

        /// <summary>
        ///     Base info for timer.
        /// </summary>
        private int _time = 5;

        private DispatcherTimer _timer;

        /// <summary>
        ///     Loads in the window aswell as creating a new instance of the microwave. <see cref="Models.Microwave" />
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Initiate microwave.
            _microwave = new Microwave();
            ((MainViewModel) DataContext).GridImage = "../Img/Microwave-Open.png";
            _microwave.Door = true;
            _microwave.Lights = false;
            _microwave.Cook = false;
            _microwave.Filled = null;
            ChangeColor();
        }

        /// <summary>
        ///     Start the timer countdown to 0.
        /// </summary>
        private void Start_Timer()
        {
            // Timer for cooking.
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        /// <summary>
        ///     Timer conditions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                _time--;
                TBCountDown.Text = "Remaining time: " + string.Format("{1}", _time / 60, _time % 60);
            }
            else
            {
                _timer.Stop();
                ResetSwitch();
                _time = 0;
            }
        }

        /// <summary>
        ///     Reset microwave to initial start up state. <see cref="MainWindow" />
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            // Edit microwave state.
            _microwave.Door = true;
            _microwave.Lights = false;
            _microwave.Cook = false;
            _microwave.Filled = null;
            ((MainViewModel) DataContext).FillingImage = "../Img/Nothing.png";
            ChangeColor();

            // Set time and call upon ResetSwitch function.
            _time = 0;
            ResetSwitch();
            TBCountDown.Text = "Remaining time: 0";
        }

        /// <summary>
        ///     Initial state of the microwave, state after product is finished cooking.. <see cref="MainWindow" />
        /// </summary>
        public void ResetSwitch()
        {
            if (_microwave.Door == false && _microwave.Lights && _microwave.Cook)
            {
                _microwave.Door = true;
                _microwave.Lights = false;
                _microwave.Cook = false;
                // Gives the correct product image depending on what was put inside the microwave.
                switch (_microwave.Filled)
                {
                    case "Rudy":
                        ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-rudy-baked.png";
                        _microwave.Filled = null;
                        break;
                    case "Eye":
                        ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-eyeball-baked.png";
                        _microwave.Filled = null;
                        break;
                    case "Gremlin":
                        ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-gremlin-baked.png";
                        _microwave.Filled = null;
                        break;
                    default:
                        ((MainViewModel) DataContext).FillingImage = "../Img/Nothing.png";
                        _microwave.Filled = null;
                        break;
                }
            }

            ChangeColor();
        }

        /// <summary>
        ///     Closes the door. <see cref="MainWindow" />
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoorSwitch(object sender, EventArgs e)
        {
            if (_microwave.Door && _microwave.Lights == false && _microwave.Cook == false)
            {
                _microwave.Door = false;
                _microwave.Lights = false;
                _microwave.Cook = false;
                ((MainViewModel) DataContext).FillingImage = "../Img/Nothing.png";
            }

            ChangeColor();
        }

        /// <summary>
        ///     Cooks whatever is inside the microwave and starts the countdown timer. <see cref="MainWindow" />
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CookingSwitch(object sender, EventArgs e)
        {
            if (_microwave.Cook == false && _microwave.Door == false && _microwave.Lights == false)
            {
                _microwave.Door = false;
                _microwave.Lights = true;
                _microwave.Cook = true;
                Start_Timer();
            }

            ChangeColor();
        }

        /// <summary>
        ///     Loads in Rudy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadRudy(object sender, EventArgs e)
        {
            if (_microwave.Door && _microwave.Lights == false && _microwave.Cook == false)
            {
                ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-rudy-unbaked.png";
                _microwave.Filled = "Rudy";
                _time = 10;
            }
        }

        /// <summary>
        ///     Loads in eye.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadEye(object sender, EventArgs e)
        {
            if (_microwave.Door && _microwave.Lights == false && _microwave.Cook == false)
            {
                ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-eyeball.png";
                _microwave.Filled = "Eye";
                _time = 5;
            }
        }

        /// <summary>
        ///     Loads in Gremlin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadGremlin(object sender, EventArgs e)
        {
            if (_microwave.Door && _microwave.Lights == false && _microwave.Cook == false)
            {
                ((MainViewModel) DataContext).FillingImage = "../Img/Microwave-gremlin-unbaked.png";
                _microwave.Filled = "Gremlin";
                _time = 30;
            }
        }

        /// <summary>
        ///     Checks if the lights are on or off, if the door is open or closed and if the microwave is or isn't cooking atm.
        /// </summary>
        public void ChangeColor()
        {
            // Check if lights are on or off.
            switch (_microwave.Lights)
            {
                case true:
                    // Check if door is open or closed.
                    switch (_microwave.Door)
                    {
                        case false:
                            // Check if the microwave is or isn't cooking atm.
                            switch (_microwave.Cook)
                            {
                                case true:
                                    ((MainViewModel) DataContext).GridImage = "../Img/Microwave-lights-on-closed.png";
                                    break;
                            }

                            break;
                    }

                    break;
                case false:
                    // Check if door is open or closed.
                    switch (_microwave.Door)
                    {
                        case true:
                            // Check if the microwave is or isn't cooking atm.
                            switch (_microwave.Cook)
                            {
                                case false:
                                    ((MainViewModel) DataContext).GridImage = "../Img/Microwave-open.png";
                                    break;
                            }

                            break;
                        case false:
                            // Check if the microwave is or isn't cooking atm.
                            switch (_microwave.Cook)
                            {
                                case false:
                                    ((MainViewModel) DataContext).GridImage = "../Img/Microwave-closed.png";
                                    break;
                            }

                            break;
                    }

                    break;
            }
        }
    }
}