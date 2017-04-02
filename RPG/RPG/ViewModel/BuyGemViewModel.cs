using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(BuyGemViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BuyGemViewModel : BindableBase
    {
        public ICommand BuyGemCommand { get; }

        public IEnumerable<int> GemEntities { get; }

        [ImportingConstructor]
        public BuyGemViewModel(IUserState userState)
        {
            GemEntities = new List<int> {50, 200, 800, 1500};

            BuyGemCommand = new DelegateCommand<int?>(amount => userState.Gem += amount.Value);
        }

        public BuyGemViewModel()
        {
            GemEntities = new List<int> { 50, 200, 800, 1500 };
        }
    }
}