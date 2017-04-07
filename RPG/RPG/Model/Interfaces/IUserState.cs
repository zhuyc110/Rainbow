using System;
using System.Collections.Generic;
using RPG.Model.Achivements;
using RPG.Model.Bonus;
using RPG.Model.Equipment;

namespace RPG.Model.Interfaces
{
    public interface IUserState
    {
        event EventHandler ExpChanged;

        event EventHandler GemChanged;

        event EventHandler LevelUp;

        long Experience { get; set; }

        long Gem { get; set; }

        long Gold { get; set; }

        IItemManager ItemManager { get; set; }

        int Level { get; set; }

        string Title { get; set; }

        string UserName { get; set; }

        List<string> CheckedSkills { get; set; }

        List<AchievementExtract> Achievements { get; set; }

        List<EquipmentExtract> Equipments { get; set; }

        List<BonusEntity> BonusEntities { get; set; }
    }
}