using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RPG.Resource.Converters
{
    [ValueConversion(typeof(string), typeof(ImageSource))]
    public class ResourceKeyToImageConverter : IValueConverter
    {
        public ResourceKeyToImageConverter()
        {
            if (resourceDictionary == null)
            {
                resourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/RPG;component/Resource/IconDictionary.xaml", UriKind.RelativeOrAbsolute)
                };
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = value as string;

            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            if (!resourceDictionary.Contains(key))
            {
                return null;
            }

            var result = resourceDictionary[key] as ImageSource;
            if (result.CanFreeze)
            {
                result.Freeze();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static ResourceDictionary resourceDictionary;
    }
}