using System.Windows;
using RegexHandling;


namespace TestRegex
{
    public partial class MainWindow
    {
        #region Fields
        private readonly RegexHandler _regexInfo = new RegexHandler();
        #endregion


        #region  Constructors & Destructor
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _regexInfo;
        }
        #endregion


        #region Event Handlers
        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            _regexInfo.Forward();
        }

        private void cmdPrevious_Click(object sender, RoutedEventArgs e)
        {
            _regexInfo.Backward();
        }
        #endregion
    }
}