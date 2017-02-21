﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using Prism.Mvvm;
using RPG.Infrastructure.Interfaces;
using RPG.Model.Interfaces;

namespace RPG.Model.Skills
{
    [Export(typeof(ISkillManager))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SkillManager : BindableBase, ISkillManager
    {
        #region Properties

        public ObservableCollection<ISkill> Skills { get; }

        #endregion

        [ImportingConstructor]
        public SkillManager([ImportMany] IEnumerable<ISkill> skills, IIOService ioService, IUserState userState)
        {
            var skillList = skills.OrderBy(x => x.LevelRequirement).ToList();
            _ioService = ioService;
            _userState = userState;
            _userState.LevelUp += OnUserLevelUp;

            foreach (var skill in skillList)
            {
                if (_userState.CheckedSkills.Contains(skill.Name))
                    skill.IsChecked = true;

                var skillImp = skill as INotifyPropertyChanged;
                if (skillImp != null)
                    skillImp.PropertyChanged += SkillPropertyChanged;
            }

            Skills = new ObservableCollection<ISkill>(skillList);
            RecalculateVisibility();
        }

        private void OnUserLevelUp(object sender, EventArgs e)
        {
            RecalculateVisibility();
        }

        private void RecalculateVisibility()
        {
            foreach (var skill in Skills)
                if (skill.LevelRequirement <= _userState.Level)
                    skill.IsVisible = true;

            OnPropertyChanged(nameof(Skills));
        }

        private void SkillPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ISkill.IsChecked))
                return;

            if (Skills.Count(x => x.IsChecked) <= 3)
                return;

            _ioService.ShowMessage("提示", "最多只能同时装备三个技能");
            var skill = sender as ISkill;
            if (skill != null)
                skill.IsChecked = false;
        }

        #region Fields

        private readonly IIOService _ioService;
        private readonly IUserState _userState;

        #endregion
    }
}