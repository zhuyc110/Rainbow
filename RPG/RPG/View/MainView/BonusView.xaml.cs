using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// BonusView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(BonusView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class BonusView : IView<BonusViewModel>
    {
        [Import]
        public BonusViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "礼包";

        public BonusView()
        {
            InitializeComponent();
        }
    }
}