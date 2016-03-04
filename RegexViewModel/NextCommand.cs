using System;
using System.Windows.Input;
using RegexHandling;


namespace RegexViewModel
{
    public class NextCommand: ICommand
    {
        #region Fields
        private readonly RegexHandler _regexHandler;
        #endregion


        #region  Constructors & Destructor
        public NextCommand(RegexHandler regexHandler)
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
            return _regexHandler.CanForward;
        }

        public void Execute(object parameter)
        {
            _regexHandler.Forward();
        }
        #endregion
    }
}