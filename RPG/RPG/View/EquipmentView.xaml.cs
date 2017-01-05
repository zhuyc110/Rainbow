using RPG.ViewModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace RPG.View
{
    /// <summary>
    /// EquipmentView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(EquipmentView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class EquipmentView : UserControl
    {
        public EquipmentView()
        {
            InitializeComponent();
        }

        [Import(nameof(EquipmentViewModel))]
        public EquipmentViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}