using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public abstract class UserPropertyBase : BindableBase, IBattleProperty
    {
        protected readonly IUserState UserState;
        private int _absoluteEnhancement;
        private int _basic;
        private int _finalValue;
        private double _relativeEnhancement;

        protected UserPropertyBase(string name, IUserState userState)
        {
            Name = name;
            UserState = userState;
            SetBasicAndFinalValue();
            FinalValue = (int) ((Basic + AbsoluteEnhancement) * (1 + RelativeEnhancement));
        }

        public int AbsoluteEnhancement
        {
            get { return _absoluteEnhancement; }

            set
            {
                SetProperty(ref _absoluteEnhancement, value);
                OnPropertyChanged(nameof(FinalValue));
            }
        }

        public int FinalValue
        {
            get { return _finalValue; }
            set { SetProperty(ref _finalValue, value); }
        }

        public string Name { get; }

        public double RelativeEnhancement
        {
            get { return _relativeEnhancement; }

            set
            {
                SetProperty(ref _relativeEnhancement, value);
                OnPropertyChanged(nameof(FinalValue));
            }
        }

        public int Basic
        {
            get { return _basic; }

            set
            {
                SetProperty(ref _basic, value);
                OnPropertyChanged(nameof(FinalValue));
            }
        }

        protected abstract void SetBasicAndFinalValue();

        public override string ToString()
        {
            return $"{Name}: {FinalValue}";
        }
    }
}