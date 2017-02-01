using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPG.Controls
{
    /// <summary>
    /// NameBoard.xaml 的交互逻辑
    /// </summary>
    public partial class NameBoard
    {
        public NameBoard()
        {
            InitializeComponent();
        }

        public static DependencyProperty BoardTitleProperty =
            DependencyProperty.Register(nameof(BoardTitle), typeof(string), typeof(NameBoard), new PropertyMetadata("怪物称号"));

        public static DependencyProperty BoardNameProperty =
            DependencyProperty.Register(nameof(BoardName), typeof(string), typeof(NameBoard), new PropertyMetadata("怪物名称"));

        public string BoardTitle
        {
            get { return (string)GetValue(BoardTitleProperty); }
            set { SetValue(BoardTitleProperty, value); }
        }

        public string BoardName
        {
            get { return (string)GetValue(BoardNameProperty); }
            set { SetValue(BoardNameProperty, value); }
        }
    }
}
