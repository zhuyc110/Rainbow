using System.ComponentModel.Composition;
using Prism.Mvvm;

namespace RPG.Infrastructure.Interfaces
{
    [InheritedExport(typeof(IView<>))]
    public interface IView<T> where T : BindableBase
    {
        T ViewModel { set ; }
    }
}
