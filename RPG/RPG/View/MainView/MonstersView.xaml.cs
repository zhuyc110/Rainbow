using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// MonstersView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(MonstersView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class MonstersView : IView<MonstersViewModel>
    {
        public MonstersView()
        {
            InitializeComponent();
        }

        public MonstersViewModel ViewModel { set { DataContext = value; } }
        public string Title => "怪物";
    }
}
