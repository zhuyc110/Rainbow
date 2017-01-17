using System.ComponentModel.Composition;

namespace RPG.View.MainView
{
    /// <summary>
    /// UserEquipment.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(UserEquipmentView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class UserEquipmentView
    {
        [ImportingConstructor]
        public UserEquipmentView()
        {
            InitializeComponent();
        }
    }
}
