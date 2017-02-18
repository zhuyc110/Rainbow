using System;
using System.Globalization;
using System.Windows.Data;

namespace RPG.Resource
{
    [ValueConversion(typeof(int), typeof(int?))]
    public class IntToNullableIntConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var valueInt = (int)value;
            int? result = valueInt;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueInt = value as int?;
            if (valueInt.HasValue)
            {
                return valueInt.Value;
            }
            return 0;
        }

        #endregion
    }
}