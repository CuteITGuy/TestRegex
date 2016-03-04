using System;
using System.Windows.Input;
using RegexHandling;


namespace RegexViewModel
{
    public class PreviousCommand: ICommand
    {
        #region Fields
        private readonly RegexHandler _regexHandler;
        #endregion


        #region  Constructors & Destructor
        public PreviousCommand(RegexHandler regexHandler)
        {
            _regexHandler = regexHandler;
        }
        #endregion


        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion


        #region Methods
        public bool CanExecute(object parameter)
        {
            return _regexHandler.CanBackward;
        }

        public void Execute(object parameter)
        {
            _regexHandler.Forward();
        }
        #endregion
    }
}