using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model.UserProperties
{
    public abstract class UserPropertyBase : BindableBase, IUserProperty
    {
        private int _absoluteEnhancement;
        private int _basic;
        private double _relativeEnhancement;

        public int AbsoluteEnhancement
        {
            get { return _absoluteEnhancement; }

            set
            {
                SetProperty(ref _absoluteEnhancement, value);
                OnPropertyChanged(nameof(FinalValue));
            }
        }

        public int FinalValue => (int) ((Basic + AbsoluteEnhancement) * RelativeEnhancement);

        public string Name { get; protected set; }

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
    }
}