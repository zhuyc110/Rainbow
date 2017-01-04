using System.ComponentModel.Composition;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     ItemsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof (ItemsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class ItemsView
    {
        public ItemsView()
        {
            InitializeComponent();
        }

        [Import(nameof(ItemsViewModel))]
        public ItemsViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}