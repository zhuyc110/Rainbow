using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// EquipmentView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(EquipmentView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class EquipmentView : IView<EquipmentViewModel>
    {
        public EquipmentView()
        {
            InitializeComponent();
        }

        [Import(typeof(EquipmentViewModel))]
        public EquipmentViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "装备";
    }
}