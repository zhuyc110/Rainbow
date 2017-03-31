using System;
using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.ViewModel
{
    [Export(typeof(HeaderViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HeaderViewModel : BindableBase
    {
        public IUserState UserState { get; }

        public double ExpBarLength
        {
            get { return _expBarLength; }
            set { SetProperty(ref _expBarLength, value); }
        }

        [ImportingConstructor]
        public HeaderViewModel(IUserState userState)
        {
            UserState = userState;

            CalculateExpPercentage();

            UserState.LevelUp += (sender, args) => CalculateExpPercentage();
            UserState.ExpChanged += (sender, args) => CalculateExpPercentage();
        }

        #region Private methods

        private void CalculateExpPercentage()
        {
            var expRequiredOfCurrentLevel = 500 * Math.Pow(1.5, UserState.Level - 1);
            ExpBarLength = UserState.Experience / expRequiredOfCurrentLevel * 100;
        }

        #endregion

        #region Fields

        private double _expBarLength;

        #endregion
    }
}