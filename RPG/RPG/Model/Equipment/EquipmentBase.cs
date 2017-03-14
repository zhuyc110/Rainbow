using System.ComponentModel.Composition;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Infrastructure.Extension;
using RPG.Model.Interfaces;

namespace RPG.Model.Equipment
{
    [InheritedExport(typeof(EquipmentBase))]
    public abstract class EquipmentBase : BindableBase, IItem
    {
        public long Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public int Amount => 1;

        public string Content { get; protected set; }

        public string IconResource { get; set; }

        public string ItemName { get; set; }

        public Rarity Rarity { get; protected set; }

        public int Worth { get; protected set; }

        public bool IsEquiped
        {
            get { return _isEquiped; }
            set
            {
                SetProperty(ref _isEquiped, value);
                OnPropertyChanged(nameof(IsNotEquiped));
            }
        }

        public bool IsNotEquiped => !IsEquiped;

        public EquipmentPart Part { get; set; }

        public string EquipmentPartString => Part.GetDescription();

        public ICommand EquipCommand { get; }

        protected EquipmentBase()
        {
            EquipCommand = new DelegateCommand(() => { IsEquiped = !IsEquiped; });
        }

        #region Fields

        private long _id;

        private bool _isEquiped;

        #endregion
    }
}