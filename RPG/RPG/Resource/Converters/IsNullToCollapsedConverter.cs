using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RPG.Resource.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class IsNullToCollapsedConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}