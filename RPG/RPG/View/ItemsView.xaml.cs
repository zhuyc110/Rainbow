using RPG.ViewModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace RPG.View
{
    /// <summary>
    /// ItemsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(ItemsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class ItemsView : UserControl
    {
        [Import(nameof(ItemsViewModel))]
        public ItemsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public ItemsView()
        {
            InitializeComponent();
        }
    }
}