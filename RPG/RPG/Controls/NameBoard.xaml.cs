using System.Windows;

namespace RPG.Controls
{
    /// <summary>
    ///     NameBoard.xaml 的交互逻辑
    /// </summary>
    public partial class NameBoard
    {
        public static DependencyProperty BoardTitleProperty =
            DependencyProperty.Register(nameof(BoardTitle), typeof(string), typeof(NameBoard),
                new PropertyMetadata("称号"));

        public static DependencyProperty HpPercentageProperty =
            DependencyProperty.Register(nameof(HpPercentage), typeof(int), typeof(NameBoard), new PropertyMetadata(100));

        public static DependencyProperty BoardNameProperty =
            DependencyProperty.Register(nameof(BoardName), typeof(string), typeof(NameBoard),
                new PropertyMetadata("名称"));

        public NameBoard()
        {
            InitializeComponent();
        }

        public string BoardTitle
        {
            get { return (string) GetValue(BoardTitleProperty); }
            set { SetValue(BoardTitleProperty, value); }
        }

        public string BoardName
        {
            get { return (string) GetValue(BoardNameProperty); }
            set { SetValue(BoardNameProperty, value); }
        }

        public int HpPercentage
        {
            get { return (int) GetValue(HpPercentageProperty); }
            set { SetValue(HpPercentageProperty, value); }
        }
    }
}