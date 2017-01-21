using RPG.Model.Interfaces;

namespace RPG.Model
{
    public class AdventureArea : IAdventureArea
    {
        public AdventureArea(string areaName, string icoResource, int minLevel, int maxLevel)
        {
            AreaName = areaName;
            IconResource = icoResource;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
        }

        public string AreaName { get; }
        public string IconResource { get; }
        public int MinLevel { get; }
        public int MaxLevel { get; }
    }
}