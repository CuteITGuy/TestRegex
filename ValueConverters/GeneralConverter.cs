using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ValueConverters.Impl;

namespace ValueConverters
{
    public class GeneralConverter : IValueConverter
    {
        #region Properties
        public GeneralDictionary ConvertMapping { get; set; }
        public GeneralDictionary ConvertBackMapping { get; set; }
        public object DefaultConvertResult { get; set; }
        public object DefaultConvertBackResult { get; set; }
        public object NullConvertResult { get; set; }
        public object NullConvertBackResult { get; set; }
        #endregion


        #region Methods
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null
                ? NullConvertResult
                : ConvertMapping == null || !ConvertMapping.ContainsKey(value)
                    ? DefaultConvertResult
                    : ConvertMapping[value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null
                ? NullConvertBackResult
                : ConvertBackMapping == null || !ConvertBackMapping.ContainsKey(value)
                    ? DefaultConvertBackResult
                    : ConvertBackMapping[value];
        }
        #endregion
    }
}
