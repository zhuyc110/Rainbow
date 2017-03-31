using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace RPG.ViewModel
{
    [Export(typeof(BonusViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BonusViewModel : BindableBase
    {
    }
}
