using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(HeaderViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HeaderViewModel : BindableBase
    {
        [Import]
        public IUserState UserState { get; private set; }
    }
}
