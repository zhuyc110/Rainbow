using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    /// NavigationView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(NavigationView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class NavigationView : IView<NavigationViewModel>
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        [Import(typeof(NavigationViewModel))]
        public NavigationViewModel ViewModel { set { DataContext = value; } }

        public string Title => "导航";
    }
}
