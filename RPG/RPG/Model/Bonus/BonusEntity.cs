using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.Bonus
{
    [Serializable]
    public class BonusEntity : BindableBase
    {
        [XmlIgnore]
        public IEnumerable<IItem> BonusItems { get; }

        public int RequiredGem { get; set; }

        public bool IsGotten
        {
            get { return _isGotten; }
            set
            {
                if (SetProperty(ref _isGotten, value))
                {
                    OnPropertyChanged(nameof(CanGetBonus));
                }
            }
        }

        [XmlIgnore]
        public bool CanGetBonus => _userState.Gem >= RequiredGem && !IsGotten;

        public BonusEntity(int requiredGem, IEnumerable<IItem> bonusItems, IUserState userState)
        {
            RequiredGem = requiredGem;
            BonusItems = bonusItems;
            _userState = userState;
            _userState.GemChanged += (sender, args) => { OnPropertyChanged(nameof(CanGetBonus)); };
        }

        /// <summary>
        /// This is for Serializer
        /// </summary>
        public BonusEntity()
        {
        }

        #region Fields

        private readonly IUserState _userState;
        private bool _isGotten;

        #endregion
    }
}