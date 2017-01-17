using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    ///     BackpackView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(BackpackView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class BackpackView : IView<BackpackViewModel>
    {
        public BackpackView()
        {
            InitializeComponent();
        }

        [Import]
        public BackpackViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "物品";
    }
}