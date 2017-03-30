using System.Globalization;

// ReSharper disable InconsistentNaming

namespace RPG.Resource.Localization
{
    public static class StringDefinitions
    {
        public static string MainView_BlackMarket => UiTexts.ResourceManager.GetString(nameof(MainView_BlackMarket), CultureInfo.CurrentCulture);
    }
}