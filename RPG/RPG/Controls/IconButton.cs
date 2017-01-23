using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RPG.Controls
{
    public class IconButton : Button
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(IconButton),
                new PropertyMetadata(default(ImageSource)));

        public static readonly DependencyProperty ContextRowProperty =
            DependencyProperty.Register(nameof(ContextRow), typeof(int), typeof(IconButton),
                new PropertyMetadata(default(int)));

        public ImageSource ImageSource
        {
            get { return (ImageSource) GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public int ContextRow
        {
            get { return (int)GetValue(ContextRowProperty); }
            set { SetValue(ContextRowProperty, value); }
        }
    }
}