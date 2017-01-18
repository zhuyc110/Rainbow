using System.ComponentModel.Composition;
using RPG.Infrastructure.Interfaces;
using RPG.ViewModel;

namespace RPG.View.MainView
{
    /// <summary>
    ///     UserEquipment.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(CharacterView))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class CharacterView : IView<CharacterViewModel>
    {
        [ImportingConstructor]
        public CharacterView()
        {
            InitializeComponent();
        }

        [Import]
        public CharacterViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public string Title => "角色";
    }
}