﻿using RPG.View.MainView;

namespace RPG.Infrastructure
{
    public static class Constants
    {
        #region Fields

        public const string MAIN_PAGE = nameof(MainPage);
        public const string USER_EQUIPMENT_VIEW = nameof(CharacterView);
        public const string BACKPACK_VIEW = nameof(BackpackView);
        public const string SKILLS_VIEW = nameof(SkillsView);
        public const string ACHIEVEMENTS_VIEW = nameof(AchievementsView);
        public const string ADVENTURE_VIEW = nameof(AdventureView);
        public const string BUYGEM_VIEW = nameof(BuyGemView);
        public const string BONUS_VIEW = nameof(BonusView);
        public const string DUPLICATIONS_VIEW = nameof(DuplicationsView);

        #endregion

        public const string MAIN_REGION = nameof(MAIN_REGION);
        public const string HEADER_REGION = nameof(HEADER_REGION);
        public const string NAVIGATION_REGION = nameof(NAVIGATION_REGION);
    }
}