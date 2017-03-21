namespace RPG.Model.UserProperties
{
    public class BasicProperty
    {
        public BasicProperty(string name, int absoluteEnhancement, double relativeEnhancement)
        {
            Name = name;
            AbsoluteEnhancement = absoluteEnhancement;
            RelativeEnhancement = relativeEnhancement;
        }

        public string Name { get; }
        public int AbsoluteEnhancement { get; set; }
        public double RelativeEnhancement { get; set; }

        public override string ToString()
        {
            var value = AbsoluteEnhancement == 0 ? RelativeEnhancement * 100 + "%" : AbsoluteEnhancement.ToString();
            return $"{Name} + {value}";
        }
    }
}