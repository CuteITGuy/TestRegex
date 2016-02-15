using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace MarkupExtensions
{
    public class EnumValuesExtension: MarkupExtension
    {
        #region Fields
        private Type _enumType;
        #endregion


        #region Constructors
        public EnumValuesExtension(Type enumType)
        {
            _enumType = enumType;
        }
        #endregion


        #region Methods
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (!_enumType.IsEnum) return DependencyProperty.UnsetValue;
            return Enum.GetValues(_enumType);
        }
        #endregion
    }
}
