using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using RPG.Model;

namespace RPG.Resource
{
    [ValueConversion(typeof (MonsterClass), typeof (Brush))]
    public class MonsterClassToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = (MonsterClass) value;
            if (key.HasFlag(MonsterClass.Elite))
            {
                return Brushes.Orange;
            }
            if (key.HasFlag(MonsterClass.Variation))
            {
                return Brushes.Purple;
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}