using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RPG.Infrastructure
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class ResourceKeyToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (resourceDictionary == null)
            {
                resourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("/RPG;component/Resource/IconDictionary.xaml", UriKind.RelativeOrAbsolute)
                };
            }

            var key = value as string;

            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            if (resourceDictionary.Contains(key))
            {
                return resourceDictionary[key];
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static ResourceDictionary resourceDictionary;
    }
}