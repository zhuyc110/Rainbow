using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    ///     Interaction logic for BattleView.xaml
    /// </summary>
    [Export(typeof (BattleView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class BattleView : IView<BattleViewModel>
    {
        public BattleView()
        {
            InitializeComponent();
        }

        public BattleViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "战斗";
    }
}