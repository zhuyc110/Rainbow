using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Export(typeof (UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase
    {
        [ImportingConstructor]
        public UserBattleState()
        {
        }

        [ImportMany(typeof (IBattleProperty))]
        public ObservableCollection<IBattleProperty> UserProperty { get; set; }
    }
}