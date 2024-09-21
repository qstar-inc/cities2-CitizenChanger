using Colossal;
using System.Collections.Generic;

namespace CitizenChanger
{
    public class LocaleEN(Setting setting) : IDictionarySource
    {
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { setting.GetSettingsLocaleID(), Mod.Name },
                { setting.GetOptionTabLocaleID(Setting.MainTab), Setting.MainTab },
                { setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { setting.GetOptionGroupLocaleID(Setting.SelectorGroup), Setting.SelectorGroup },


                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Female_Warm)), "Adult Female Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Female_Warm)), SelectCharacters("female", "warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Male_Warm)), "Adult Male Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Male_Warm)), SelectCharacters("male", "warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Load)), "Load" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Load)), $"Load the selected character models." },

                { setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)), "Support the author." },

            };
        }

        public string SelectCharacters(string gender, string season)
        {
            return $"Select the character models to be used for {gender} characters for the {season} seasons.";
        }

        public void Unload()
        {

        }
    }
}
