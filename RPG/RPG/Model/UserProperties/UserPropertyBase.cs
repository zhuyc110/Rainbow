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
            SetBasicValue();
            RecaculateFinalValue();
        }

        public int AbsoluteEnhancement
        {
            get { return _absoluteEnhancement; }

            set
            {
                if (SetProperty(ref _absoluteEnhancement, value))
                    RecaculateFinalValue();
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
                if (SetProperty(ref _relativeEnhancement, value))
                    RecaculateFinalValue();
            }
        }

        public int Basic
        {
            get { return _basic; }

            set
            {
                if (SetProperty(ref _basic, value))
                    RecaculateFinalValue();
            }
        }

        private void RecaculateFinalValue()
        {
            FinalValue = (int) ((Basic + AbsoluteEnhancement) * (1 + RelativeEnhancement));
        }

        protected abstract void SetBasicValue();

        public override string ToString()
        {
            return $"{Name}: {FinalValue}";
        }
    }
}