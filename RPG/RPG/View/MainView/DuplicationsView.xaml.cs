using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// DuplicationsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(DuplicationsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class DuplicationsView : IView<DuplicationsViewModel>
    {
        [Import]
        public DuplicationsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "副本";

        public DuplicationsView()
        {
            InitializeComponent();
        }
    }
}