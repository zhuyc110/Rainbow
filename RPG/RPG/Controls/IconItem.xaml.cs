using RPG.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RPG.Controls
{
    /// <summary>
    /// IconItem.xaml 的交互逻辑
    /// </summary>
    public partial class IconItem : UserControl
    {
        public static DependencyProperty AmountProperty =
            DependencyProperty.Register(nameof(Amount), typeof(int), typeof(IconItem), new FrameworkPropertyMetadata(0));

        public static DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(IconItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static DependencyProperty ItemNameProperty =
            DependencyProperty.Register(nameof(ItemName), typeof(string), typeof(IconItem), new FrameworkPropertyMetadata(""));

        public static DependencyProperty RarityProperty =
            DependencyProperty.Register(nameof(Rarity), typeof(Rarity), typeof(IconItem), new FrameworkPropertyMetadata(Rarity.Normal, FrameworkPropertyMetadataOptions.AffectsRender));

        public int Amount
        {
            get { return (int)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
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

        public Rarity Rarity
        {
            get { return (Rarity)GetValue(RarityProperty); }
            set { SetValue(RarityProperty, value); }
        }

        public IconItem()
        {
            InitializeComponent();
        }
    }
}