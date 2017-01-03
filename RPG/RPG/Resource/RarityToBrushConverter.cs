using RPG.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RPG.Resource
{
    [ValueConversion(typeof(Rarity), typeof(Brush))]
    internal class RarityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = (Rarity)value;
            return _dict[key];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static readonly Dictionary<Rarity, Brush> _dict = new Dictionary<Rarity, Brush>
        {
            {Rarity.Normal, Brushes.Gray },
            {Rarity.Rare, Brushes.Blue },
            {Rarity.Epic, Brushes.Purple },
            {Rarity.Legend, Brushes.Orange },
        };
    }
}