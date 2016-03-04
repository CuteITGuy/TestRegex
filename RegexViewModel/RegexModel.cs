using System.Windows.Input;
using RegexHandling;


namespace RegexViewModel
{
    public class RegexModel
    {
        #region  Constructors & Destructor
        public RegexModel()
        {
            NextCommand = new NextCommand(RegexHandler);
            PreviousCommand = new PreviousCommand(RegexHandler);
        }
        #endregion


        #region  Properties & Indexers
        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }
        public RegexHandler RegexHandler { get; set; } = new RegexHandler();
        #endregion
    }
}