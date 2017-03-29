using System;

namespace RPG.Model.UserProperties
{
    [Serializable]
    public class BasicProperty
    {
        public BasicProperty(string name, int absoluteEnhancement, double relativeEnhancement)
        {
            Name = name;
            AbsoluteEnhancement = absoluteEnhancement;
            RelativeEnhancement = relativeEnhancement;
        }

        public BasicProperty()
        {
            Name = string.Empty;
            AbsoluteEnhancement = 0;
            RelativeEnhancement = 0;
        }

        public string Name { get; set; }
        public int AbsoluteEnhancement { get; set; }
        public double RelativeEnhancement { get; set; }

        public override string ToString()
        {
            var value = AbsoluteEnhancement == 0 ? RelativeEnhancement * 100 + "%" : AbsoluteEnhancement.ToString();
            return $"{Name} + {value}";
        }
    }
}