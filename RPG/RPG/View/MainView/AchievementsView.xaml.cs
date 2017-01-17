using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// AchievementsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(AchievementsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class AchievementsView : IView<AchievementsViewModel>
    {
        public AchievementsView()
        {
            InitializeComponent();
        }

        [Import(typeof(AchievementsViewModel))]
        public AchievementsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "成就";
    }
}