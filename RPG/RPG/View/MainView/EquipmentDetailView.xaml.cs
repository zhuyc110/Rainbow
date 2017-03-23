using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    /// EquipmentDetailView.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(EquipmentDetailView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class EquipmentDetailView : IView<EquipmentDetailViewModel>
    {
        public EquipmentDetailViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "装备细节";

        public EquipmentDetailView()
        {
            InitializeComponent();
        }
    }
}