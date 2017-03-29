using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using log4net;
using RPG.Model.Interfaces;

namespace RPG.Model.Equipment
{
    [Export(typeof(IEquipmentManager))]
    [Export(typeof(ISavableData))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class EquipmentManager : IEquipmentManager, ISavableData
    {
        public event EventHandler<EquipmentChangedArgs> OnEquipmentChanged;

        public ObservableCollection<EquipmentBase> Equipments { get; }

        public EquipmentBase this[EquipmentPart index]
        {
            get { return Equipments.FirstOrDefault(x => x.IsEquiped && x.Part == index); }
        }

        [ImportingConstructor]
        public EquipmentManager([ImportMany] IEnumerable<EquipmentBase> equipments, IUserState userState)
        {
            _userState = userState;

            var equipmentBases = equipments.ToList();
            foreach (var equipment in equipmentBases)
            {
                equipment.PropertyChanged += EquipmentPropertyChanged;
            }
            Equipments = new ObservableCollection<EquipmentBase>(equipmentBases);
            RecoverEquipments();
        }

        #region ISavableData Members

        public void SaveData()
        {
            _userState.Equipments = Equipments
                .Where(x => x.EnchantmentProperties.Any(property => property.AbsoluteEnhancement > 0 || property.RelativeEnhancement > 0))
                .Select(equipmentBase => new EquipmentExtract(equipmentBase)).ToList();
        }

        #endregion

        #region Private methods

        private void EquipmentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(EquipmentBase.IsEquiped))
            {
                return;
            }

            var equipment = sender as EquipmentBase;
            if (equipment == null)
            {
                return;
            }

            if (!equipment.IsEquiped)
            {
                var handler = OnEquipmentChanged;
                handler?.Invoke(null, new EquipmentChangedArgs(equipment, null));
            }
            else
            {
                var handler = OnEquipmentChanged;
                handler?.Invoke(null, new EquipmentChangedArgs(null, equipment));
            }
        }

        private void RecoverEquipments()
        {
            foreach (var equipmentExtract in _userState.Equipments)
            {
                var equipment = Equipments.FirstOrDefault(x => x.ItemName == equipmentExtract.ItemName);
                if (equipment == null)
                {
                    Log.Error($"Can not find {equipmentExtract.ItemName}");
                    continue;
                }

                equipment.EnchantmentProperties = equipmentExtract.EnchantmentProperties;
                equipment.IsEquiped = equipmentExtract.IsEquiped;
            }
        }

        #endregion

        #region Fields

        private readonly IUserState _userState;
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}