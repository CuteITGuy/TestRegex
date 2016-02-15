using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ValueConverters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullityToVisibilityConverter: IValueConverter
    {
        #region Fields
        private Visibility _valueWhenNull = Visibility.Collapsed;
        private Visibility _valueWhenNotNull = Visibility.Visible; 
        #endregion


        #region Properties
        public Visibility ValueWhenNull
        {
            get { return _valueWhenNull; }
            set { _valueWhenNull = value; }
        }

        public Visibility ValueWhenNotNull
        {
            get { return _valueWhenNotNull; }
            set { _valueWhenNotNull = value; }
        }
        #endregion


        #region Methods
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? ValueWhenNull : ValueWhenNotNull;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
        #endregion
    }
}
