using RPG.ViewModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace RPG.View
{
    /// <summary>
    /// SkillsView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(SkillsView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class SkillsView : UserControl
    {
        [Import(nameof(SkillsViewModel))]
        public SkillsViewModel ViewModel
        {
            set { DataContext = value; }
        }

        [ImportingConstructor]
        public SkillsView()
        {
            InitializeComponent();
        }
    }
}