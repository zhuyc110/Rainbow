using System.ComponentModel.Composition;
using System.Windows.Controls;
using RPG.ViewModel;

namespace RPG.View
{
    /// <summary>
    ///     SkillsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof (SkillsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class SkillsView
    {
        [ImportingConstructor]
        public SkillsView()
        {
            InitializeComponent();
        }

        [Import(nameof(SkillsViewModel))]
        public SkillsViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}