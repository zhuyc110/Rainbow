using System;

namespace RPG.Model.Items
{
    [Serializable]
    public class LightItem
    {
        #region Properties

        public int Amount { get; set; }
        public string ItemName { get; set; }

        #endregion
    }
}