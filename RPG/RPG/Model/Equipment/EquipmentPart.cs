using System.ComponentModel;

namespace RPG.Model.Equipment
{
    public enum EquipmentPart
    {
        [Description("头盔")]
        Helmet,
        [Description("胸甲")]
        Breastplate,
        [Description("护腿")]
        Legging,
        [Description("武器")]
        Weapon,
        [Description("翅膀")]
        Wing,
        [Description("饰品")]
        Accessory,
        [Description("项链")]
        Necklace,
        [Description("手套")]
        Glove,
        [Description("戒指")]
        Ring,
        [Description("战靴")]
        Boot
    }
}