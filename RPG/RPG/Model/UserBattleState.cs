using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.Model
{
    [Export(typeof(UserBattleState))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UserBattleState : BindableBase
    {
        [ImportMany(typeof(IBattleProperty))]
        public ObservableCollection<IBattleProperty> UserProperty { get; set; }

        [ImportingConstructor]
        public UserBattleState()
        {

        }
    }
}
