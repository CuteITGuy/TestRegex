using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace RegexHandling
{
    public class RegexHandler: INotifyPropertyChanged
    {
        #region Fields
        private const string CAN_BACKWARD_NAME = "CanBackward";
        private const string CAN_FORWARD_NAME = "CanForward";
        private IEnumerable<string> _capturedGroups;
        private string _error;
        private string _input;
        private MatchCollection _matches;
        private int _matchIndex = -1;
        private RegexMode _mode = RegexMode.Match;
        private RegexOptions _options;
        private string _pattern;
        private string _replacement;
        private string _result;
        private IEnumerable<string> _splittedStrings;
        #endregion


        #region  Properties & Indexers
        public bool CanBackward => _matches != null && _matchIndex > 0 && _matchIndex <= _matches.Count;

        public bool CanForward => _matches != null && _matchIndex >= -1 && _matchIndex < _matches.Count - 1;

        public IEnumerable<string> CapturedGroups
        {
            get { return _capturedGroups; }
            private set { SetProperty(ref _capturedGroups, value); }
        }

        public string Error
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }

        public string Input
        {
            get { return _input; }
            set
            {
                SetProperty(ref _input, value);
                ApplyRegex();
            }
        }

        public RegexMode Mode
        {
            get { return _mode; }
            set
            {
                SetProperty(ref _mode, value);
                ApplyRegex();
            }
        }

        public RegexOptions Options
        {
            get { return _options; }
            set
            {
                SetProperty(ref _options, value);
                ApplyRegex();
            }
        }

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                SetProperty(ref _pattern, value);
                ApplyRegex();
            }
        }

        public string Replacement
        {
            get { return _replacement; }
            set
            {
                SetProperty(ref _replacement, value);
                ApplyRegex();
            }
        }

        public string Result
        {
            get { return _result; }
            private set { SetProperty(ref _result, value); }
        }

        public IEnumerable<string> SplittedStrings
        {
            get { return _splittedStrings; }
            set { SetProperty(ref _splittedStrings, value); }
        }
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Methods
        public void Backward()
        {
            if (CanBackward)
            {
                _matchIndex -= 1;
                SetResults();
            }
        }

        public void Forward()
        {
            if (CanForward)
            {
                _matchIndex += 1;
                SetResults();
            }
        }
        #endregion


        #region Implementation
        private void ApplyRegex()
        {
            RestoreState();
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(Pattern)) return;

            try
            {
                switch (Mode)
                {
                    case RegexMode.Match:
                        ApplyRegexMatch();
                        break;
                    case RegexMode.Split:
                        ApplyRegexSplit();
                        break;
                    case RegexMode.Replace:
                        ApplyRegexReplace();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (Exception exc)
            {
                Error = exc.Message;
            }
        }

        private void ApplyRegexMatch()
        {
            _matches = Regex.Matches(Input, Pattern, Options);
            Forward();
        }

        private void ApplyRegexReplace()
        {
            Result = Regex.Replace(Input, Pattern, Replacement);
            NotifyForwardBackward();
        }

        private void ApplyRegexSplit()
        {
            SplittedStrings = Regex.Split(Input, Pattern);
            NotifyForwardBackward();
        }

        private void NotifyForwardBackward()
        {
            NotifyPropertyChanged(CAN_FORWARD_NAME);
            NotifyPropertyChanged(CAN_BACKWARD_NAME);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RestoreState()
        {
            Error = null;
            _matches = null;
            _matchIndex = -1;
            Result = null;
            CapturedGroups = null;
            SplittedStrings = null;
        }

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        private void SetResults()
        {
            if (_matches != null && _matchIndex >= 0 && _matchIndex < _matches.Count)
            {
                var match = _matches[_matchIndex];
                Result = match.Value;
                CapturedGroups = match.Groups.OfType<Group>().Select(g => g.Value);
                NotifyForwardBackward();
            }
            else
            {
                Result = "";
                CapturedGroups = null;
            }
        }
        #endregion
    }
}