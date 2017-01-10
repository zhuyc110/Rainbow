using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     SkillsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof (SkillsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class SkillsView : IView<SkillsViewModel>
    {
        [ImportingConstructor]
        public SkillsView()
        {
            InitializeComponent();
        }

        [Import(typeof(SkillsViewModel))]
        public SkillsViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}