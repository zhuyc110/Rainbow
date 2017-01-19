using System;

namespace RPG.Model
{
    [Flags]
    public enum MonsterClass
    {
        Normal,
        Elite,
        Variation,
        Boss = 4,
        Rarity = 8
    }
}