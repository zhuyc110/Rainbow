using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace RPG.View
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(MainPage))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}