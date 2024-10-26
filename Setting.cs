using CitizenModelManager.Systems;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;
using System.Collections.Generic;
using System;
using UnityEngine.Device;

namespace CitizenModelManager
{
    [FileLocation($"ModsSettings\\StarQ\\{nameof(CitizenModelManager)}")]
    [SettingsUITabOrder(MainTab, LoadedTab, AboutTab)]
    [SettingsUIGroupOrder(ButtonGroup, AdultGroup, ChildGroup, ElderlyGroup, TeenGroup, LoadedGroup, InfoGroup)]
    [SettingsUIShowGroupName(AdultGroup, ChildGroup, ElderlyGroup, TeenGroup)]

    public class Setting(IMod mod) : ModSetting(mod)
    {
        private readonly CharacterGroupLoader CharacterGroupLoader = new();
        private readonly CitizenChangerSystem CitizenChangerSystem = new();

        public const string MainTab = "Main";
        public const string ButtonGroup = "Buttons";
        public const string ChildGroup = "Child";
        public const string TeenGroup = "Teen";
        public const string AdultGroup = "Adult";
        public const string ElderlyGroup = "Elderly";

        public const string LoadedTab = "Loaded Packs";
        public const string LoadedGroup = "Loaded Groups";

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";
        public const string ModInfo = "About the Mod";

        [SettingsUIButtonGroup("Button")]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool Reset
        {
            set
            {
                SetDefaults();
                ApplyCitizenChanger();
            }
        }

        [SettingsUIButtonGroup("Button")]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool Load
        {
            set
            {
                ApplyCitizenChanger();
            }
        }

        [SettingsUIHidden]
        public int SettingsVersion = 0;

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, ChildGroup)]
        public string Child_Female_Warm { get; set; } = "ChildrenWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, ChildGroup)]
        public string Child_Male_Warm { get; set; } = "ChildrenWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, ChildGroup)]
        public string Child_Female_Cold { get; set; } = "ChildrenCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, ChildGroup)]
        public string Child_Male_Cold { get; set; } = "ChildrenCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, TeenGroup)]
        public string Teen_Female_Warm { get; set; } = "TeenWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, TeenGroup)]
        public string Teen_Male_Warm { get; set; } = "TeenWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, TeenGroup)]
        public string Teen_Female_Cold { get; set; } = "TeenCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, TeenGroup)]
        public string Teen_Male_Cold { get; set; } = "TeenCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Female_Warm { get; set; } = "AdultWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Male_Warm { get; set; } = "AdultWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Female_Cold { get; set; } = "AdultCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Male_Cold { get; set; } = "AdultCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Female_Homeless { get; set; } = "Homeless Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, AdultGroup)]
        public string Adult_Male_Homeless { get; set; } = "Homeless Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Female_Warm { get; set; } = "SeniorWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Male_Warm { get; set; } = "SeniorWarm Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Female_Cold { get; set; } = "SeniorCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Male_Cold { get; set; } = "SeniorCold Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsFemale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Female_Homeless { get; set; } = "Homeless Group";

        [SettingsUIDropdown(typeof(Setting), nameof(GetDropdownItemsMale))]
        [SettingsUISection(MainTab, ElderlyGroup)]
        public string Elderly_Male_Homeless { get; set; } = "Homeless Group";

        public DropdownItem<string>[] GetDropdownItemsMale()
        {
            var items = new List<DropdownItem<string>>();
            for (int i = 0; i < CharacterGroupLoader.CharacterGroupMale.Count; i++)
            {
                string name = CharacterGroupLoader.CharacterGroupMale[i].ToString();
                items.Add(new DropdownItem<string>()
                {
                    value = name,
                    displayName = name,
                });
            }
            return [.. items];
        }

        public DropdownItem<string>[] GetDropdownItemsFemale()
        {
            var items = new List<DropdownItem<string>>();
            for (int i = 0; i < CharacterGroupLoader.CharacterGroupFemale.Count; i++)
            {
                string name = CharacterGroupLoader.CharacterGroupFemale[i].ToString();
                items.Add(new DropdownItem<string>()
                {
                    value = name,
                    displayName = name,
                });
            }
            return [.. items];
        }

        [SettingsUIMultilineText]
        [SettingsUISection(LoadedTab, LoadedGroup)]
        [SettingsUIDisplayName(typeof(CharacterGroupLoader), nameof(CharacterGroupLoader.LoadedCharacterGroups))]
        public string GroupsLoaded => string.Empty;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => "StarQ";

        [SettingsUISection(AboutTab, InfoGroup)]
        public bool BMaCLink
        {
            set
            {
                try
                {
                    Application.OpenURL($"https://buymeacoffee.com/starq");
                }
                catch (Exception e)
                {
                    Mod.log.Error(e);
                }
            }
        }

        [SettingsUIMultilineText]
        [SettingsUISection(AboutTab, ModInfo)]
        public string AboutTheMod => string.Empty;

        public override void SetDefaults()
        {
            Child_Female_Warm = "ChildrenWarm Group";
            Child_Male_Warm = "ChildrenWarm Group";
            Child_Female_Cold = "ChildrenCold Group";
            Child_Male_Cold = "ChildrenCold Group";
            Teen_Female_Warm = "TeenWarm Group";
            Teen_Male_Warm = "TeenWarm Group";
            Teen_Female_Cold = "TeenCold Group";
            Teen_Male_Cold = "TeenCold Group";
            Adult_Female_Warm = "AdultWarm Group";
            Adult_Male_Warm = "AdultWarm Group";
            Adult_Female_Cold = "AdultCold Group";
            Adult_Male_Cold = "AdultCold Group";
            Adult_Female_Homeless = "Homeless Group";
            Adult_Male_Homeless = "Homeless Group";
            Elderly_Female_Warm = "SeniorWarm Group";
            Elderly_Male_Warm = "SeniorWarm Group";
            Elderly_Female_Cold = "SeniorCold Group";
            Elderly_Male_Cold = "SeniorCold Group";
            Elderly_Female_Homeless = "Homeless Group";
            Elderly_Male_Homeless = "Homeless Group";
            SettingsVersion = 0;
            Mod.log.Info("Applied default");
        }

        public void ApplyCitizenChanger()
        {
            CitizenChangerSystem.Reload("Child_Female", "warm", Child_Female_Warm);
            CitizenChangerSystem.Reload("Child_Male", "warm", Child_Male_Warm);
            CitizenChangerSystem.Reload("Child_Female", "cold", Child_Female_Cold);
            CitizenChangerSystem.Reload("Child_Male", "cold", Child_Male_Cold);
            CitizenChangerSystem.Reload("Teen_Female", "warm", Teen_Female_Warm);
            CitizenChangerSystem.Reload("Teen_Male", "warm", Teen_Male_Warm);
            CitizenChangerSystem.Reload("Teen_Female", "cold", Teen_Female_Cold);
            CitizenChangerSystem.Reload("Teen_Male", "cold", Teen_Male_Cold);
            CitizenChangerSystem.Reload("Adult_Female", "warm", Adult_Female_Warm);
            CitizenChangerSystem.Reload("Adult_Male", "warm", Adult_Male_Warm);
            CitizenChangerSystem.Reload("Adult_Female", "cold", Adult_Female_Cold);
            CitizenChangerSystem.Reload("Adult_Male", "cold", Adult_Male_Cold);
            CitizenChangerSystem.Reload("Adult_Female", "homeless", Adult_Female_Homeless);
            CitizenChangerSystem.Reload("Adult_Male", "homeless", Adult_Male_Homeless);
            CitizenChangerSystem.Reload("Elderly_Female", "warm", Elderly_Female_Warm);
            CitizenChangerSystem.Reload("Elderly_Male", "warm", Elderly_Male_Warm);
            CitizenChangerSystem.Reload("Elderly_Female", "cold", Elderly_Female_Cold);
            CitizenChangerSystem.Reload("Elderly_Male", "cold", Elderly_Male_Cold);
            CitizenChangerSystem.Reload("Elderly_Female", "homeless", Elderly_Female_Homeless);
            CitizenChangerSystem.Reload("Elderly_Male", "homeless", Elderly_Male_Homeless);
            Mod.log.Info("Applied settings");
        }
    }
}
