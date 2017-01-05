using RPG.Model;
using System.Windows;
using System.Windows.Media;

namespace RPG.Controls
{
    /// <summary>
    /// IconItem.xaml 的交互逻辑
    /// </summary>
    public partial class IconItem
    {
        public static DependencyProperty AmountProperty =
            DependencyProperty.Register(nameof(Amount), typeof(int), typeof(IconItem), new PropertyMetadata(default(int)));

        public static DependencyProperty ShowAmountProperty =
            DependencyProperty.Register(nameof(ShowAmount), typeof(bool), typeof(IconItem), new PropertyMetadata(default(bool)));

        public static DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(IconItem), new PropertyMetadata(default(ImageSource)));

        public static DependencyProperty ItemNameProperty =
            DependencyProperty.Register(nameof(ItemName), typeof(string), typeof(IconItem), new PropertyMetadata(default(string)));

        public static DependencyProperty RarityProperty =
            DependencyProperty.Register(nameof(Rarity), typeof(Rarity), typeof(IconItem), new PropertyMetadata(default(Rarity)));

        public int Amount
        {
            get { return (int)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public bool ShowAmount
        {
            get { return (bool)GetValue(ShowAmountProperty); }
            set { SetValue(ShowAmountProperty, value); }
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