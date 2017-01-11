using System.Collections;
using System.Windows;
using System.Windows.Media;

namespace RPG.Controls
{
    /// <summary>
    ///     IconItemHorizontal.xaml 的交互逻辑
    /// </summary>
    public partial class IconItemHorizontal
    {
        public static DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(IconItemHorizontal),
                new PropertyMetadata(default(ImageSource)));

        public static DependencyProperty ItemNameProperty =
            DependencyProperty.Register(nameof(ItemName), typeof(string), typeof(IconItemHorizontal),
                new PropertyMetadata(default(string)));

        public static DependencyProperty ItemContentProperty =
            DependencyProperty.Register(nameof(ItemContent), typeof(string), typeof(IconItemHorizontal),
                new PropertyMetadata(default(string)));

        public static DependencyProperty AdditionalTextProperty =
            DependencyProperty.Register(nameof(AdditionalText), typeof(string), typeof(IconItemHorizontal),
                new PropertyMetadata(default(string)));

        public static DependencyProperty PropertyListProperty =
            DependencyProperty.Register(nameof(PropertyList), typeof(IEnumerable), typeof(IconItemHorizontal),
                new PropertyMetadata(null));

        public IconItemHorizontal()
        {
            InitializeComponent();
        }

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }

        public string ItemContent
        {
            get { return (string)GetValue(ItemContentProperty); }
            set { SetValue(ItemContentProperty, value); }
        }

        public string AdditionalText
        {
            get { return (string)GetValue(AdditionalTextProperty); }
            set { SetValue(AdditionalTextProperty, value); }
        }

        public IEnumerable PropertyList
        {
            get { return (IEnumerable)GetValue(PropertyListProperty); }
            set { SetValue(PropertyListProperty, value); }
        }

    }
}