using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     ItemsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof (ItemsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class ItemsView : IView<ItemsViewModel>
    {
        public ItemsView()
        {
            InitializeComponent();
        }

        [Import(typeof(ItemsViewModel))]
        public ItemsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "物品";
    }
}