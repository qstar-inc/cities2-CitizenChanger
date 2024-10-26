using Colossal;
using System.Collections.Generic;

namespace CitizenModelManager
{
    public class LocaleEN(Setting setting) : IDictionarySource
    {
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { setting.GetSettingsLocaleID(), Mod.Name },
                { setting.GetOptionTabLocaleID(Setting.MainTab), Setting.MainTab },
                { setting.GetOptionTabLocaleID(Setting.LoadedTab), Setting.LoadedTab },
                { setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { setting.GetOptionGroupLocaleID(Setting.ChildGroup), Setting.ChildGroup },
                { setting.GetOptionGroupLocaleID(Setting.TeenGroup), Setting.TeenGroup },
                { setting.GetOptionGroupLocaleID(Setting.AdultGroup), Setting.AdultGroup },
                { setting.GetOptionGroupLocaleID(Setting.ElderlyGroup), Setting.ElderlyGroup },

                { setting.GetOptionTabLocaleID(Setting.InfoGroup), Setting.InfoGroup },
                { setting.GetOptionTabLocaleID(Setting.ModInfo), Setting.ModInfo },

                { setting.GetOptionLabelLocaleID(nameof(Setting.Load)), "Apply" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Load)), $"Apply the selected character models as selected below." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Reset)), "Reset" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Reset)), $"Reset to vanilla character models." },

                { setting.GetOptionLabelLocaleID(nameof(Setting.Child_Female_Warm)), "Child Female Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Child_Female_Warm)), SelectCharacters("Female", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Child_Male_Warm)), "Child Male Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Child_Male_Warm)), SelectCharacters("Male", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Child_Female_Cold)), "Child Female Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Child_Female_Cold)), SelectCharacters("Female", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Child_Male_Cold)), "Child Male Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Child_Male_Cold)), SelectCharacters("Male", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Teen_Female_Warm)), "Teen Female Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Teen_Female_Warm)), SelectCharacters("Female", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Teen_Male_Warm)), "Teen Male Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Teen_Male_Warm)), SelectCharacters("Male", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Teen_Female_Cold)), "Teen Female Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Teen_Female_Cold)), SelectCharacters("Female", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Teen_Male_Cold)), "Teen Male Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Teen_Male_Cold)), SelectCharacters("Male", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Female_Warm)), "Adult Female Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Female_Warm)), SelectCharacters("Female", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Male_Warm)), "Adult Male Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Male_Warm)), SelectCharacters("Male", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Female_Cold)), "Adult Female Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Female_Cold)), SelectCharacters("Female", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Male_Cold)), "Adult Male Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Male_Cold)), SelectCharacters("Male", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Female_Homeless)), "Adult Female Homeless" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Female_Homeless)), SelectCharacters("Female", "Homeless") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Adult_Male_Homeless)), "Adult Male Homeless" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Adult_Male_Homeless)), SelectCharacters("Male", "Homeless") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Female_Warm)), "Elderly Female Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Female_Warm)), SelectCharacters("Female", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Male_Warm)), "Elderly Male Warm" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Male_Warm)), SelectCharacters("Male", "Warm") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Female_Cold)), "Elderly Female Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Female_Cold)), SelectCharacters("Female", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Male_Cold)), "Elderly Male Cold" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Male_Cold)), SelectCharacters("Male", "Cold") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Female_Homeless)), "Elderly Female Homeless" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Female_Homeless)), SelectCharacters("Female", "Homeless") },
                { setting.GetOptionLabelLocaleID(nameof(Setting.Elderly_Male_Homeless)), "Elderly Male Homeless" },
                { setting.GetOptionDescLocaleID(nameof(Setting.Elderly_Male_Homeless)), SelectCharacters("Male", "Homeless") },

                { setting.GetOptionLabelLocaleID(nameof(Setting.GroupsLoaded)), "" },
                { setting.GetOptionDescLocaleID(nameof(Setting.GroupsLoaded)), "List of Character Groups loaded in this session." },

                { setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)), "Support the author." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AboutTheMod)), "This mod offers you an option to change the models of the citizens living in your city in Cities: Skylines II:\r\n- When a new model is selected all existing citizen of that group will have the selected model immidiately.\r\n- The mod lists any loaded CharacterGroup prefabs for the correct group.\r\n- You can make your own CharacterGroups in the Editor or check out @SullySkylines's Citizen packs for starter.\r\n- Sully will be publishing detailed tutorials how to make your own CharacterGroups using the existing Didimo models right inside the [BETA] Editor." },
                { setting.GetOptionDescLocaleID(nameof(Setting.AboutTheMod)), "" },

            };
        }

        public string SelectCharacters(string gender, string group)
        {
            string line;
            string nextUp = $" \r\n If you choose a set which doesn't have any models for the selected group, all citizens of that group will become invisible.";
            group = group.ToLower();
            gender = gender.ToLower();
            if (group == "homeless")
            {
                line = $"Select the character models to be used for {gender} homeless characters.";
            }
            else
            {
                line = $"Select the character models to be used for {gender} characters for the {group} seasons.";
            }

            return $"{line}{nextUp}";
        }

        public void Unload()
        {

        }
    }
}
