using Prism.Mvvm;
using RPG.Infrastructure.Extension;
using RPG.Model.Interfaces;
using System.ComponentModel.Composition;

namespace RPG.Model.Equipment
{
    [InheritedExport(typeof(EquipmentBase))]
    public abstract class EquipmentBase : BindableBase, IItem
    {
        private int _id;
        public int Id
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

        protected EquipmentPart Part { get; set; }

        public string EquipmentPartString => Part.GetDescription();
    }
}