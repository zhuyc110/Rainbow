using System.ComponentModel.Composition;
using Prism.Mvvm;
using RPG.Model.Interfaces;

namespace RPG.Model
{
    [Export(typeof(IUserState))]
    public class UserState : BindableBase, IUserState
    {
        private long _experience;
        private long _gem;
        private long _gold;
        private int _level;
        private string _title;

        [ImportingConstructor]
        public UserState()
        {
            Level = 1;
            Gold = 1000;
            Gem = 100;
            UserName = "Sky - Han";
            Title = "一个称号";
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string UserName { get; set; }

        public int Level
        {
            get { return _level; }
            set { SetProperty(ref _level, value); }
        }

        public long Gold
        {
            get { return _gold; }
            set { SetProperty(ref _gold, value); }
        }

        public long Gem
        {
            get { return _gem; }
            set { SetProperty(ref _gem, value); }
        }

        public long Experience
        {
            get { return _experience; }
            set { SetProperty(ref _experience, value); }
        }
    }
}