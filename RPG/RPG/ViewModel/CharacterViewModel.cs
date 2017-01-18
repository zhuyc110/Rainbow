using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using RPG.Model;
using RPG.Model.Interfaces;
using RPG.Model.UserProperties;

namespace RPG.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class CharacterViewModel : BindableBase
    {

        public ObservableCollection<IUserProperty> UserProperties { get; }

        [ImportingConstructor]
        public CharacterViewModel([Import] UserBattleState userBattleState)
        {
            UserProperties = userBattleState.UserProperty;
        }

        [Obsolete]
        public CharacterViewModel()
        {
            UserProperties = new ObservableCollection<IUserProperty> { new PropertyHP(new UserState { Level = 10 }) };
        }
    }
}
