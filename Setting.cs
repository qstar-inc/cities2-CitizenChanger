using CitizenChanger.Systems;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using Game.UI.Widgets;
using System;
using System.Collections.Generic;
using UnityEngine.Device;

namespace CitizenChanger
{
    [FileLocation($"ModsSettings\\StarQ\\{nameof(CitizenChanger)}")]
    [SettingsUITabOrder(MainTab, AboutTab)]
    [SettingsUIGroupOrder(SelectorGroup)]
    [SettingsUIShowGroupName(SelectorGroup)]

    public class Setting(IMod mod) : ModSetting(mod)
    {
        private readonly CharacterGroupLoader CharacterGroupLoader = new();
        private readonly CitizenChangerSystem CitizenChangerSystem = new();
        public const string MainTab = "Main";

        public const string SelectorGroup = "Dropdown";

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";


        [SettingsUIDropdown(typeof(Setting), nameof(GetIntDropdownItems))]
        [SettingsUISection(MainTab, SelectorGroup)]
        public int Adult_Female_Warm { get; set; } = CharacterGroupLoader.Position("AdultWarm Group");
        [SettingsUIDropdown(typeof(Setting), nameof(GetIntDropdownItems))]
        [SettingsUISection(MainTab, SelectorGroup)]
        public int Adult_Male_Warm { get; set; } = CharacterGroupLoader.Position("AdultWarm Group");
        [SettingsUISection(MainTab, SelectorGroup)]
        public bool Load
        {
            set
            {
                CitizenChangerSystem.Reload("Adult_Female", Adult_Female_Warm);
                CitizenChangerSystem.Reload("Adult_Male", Adult_Male_Warm);
            }
        }

        public DropdownItem<int>[] GetIntDropdownItems()
        {
            Mod.log.Info($"{CharacterGroupLoader.CharacterGroupNames.Count} count in dropdown");
            var items = new List<DropdownItem<int>>();
            for (int i = 0; i < CharacterGroupLoader.CharacterGroupNames.Count; i++)
            {
                string name = CharacterGroupLoader.CharacterGroupNames[i].ToString();
                items.Add(new DropdownItem<int>()
                {
                    value = i,
                    displayName = name,
                });
            }
            return items.ToArray();
        }

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

        public override void SetDefaults()
        {
            Adult_Female_Warm = CharacterGroupLoader.Position("AdultWarm Group");
            Adult_Male_Warm = CharacterGroupLoader.Position("AdultWarm Group");
            CitizenChangerSystem.Reload("Adult_Female", Adult_Female_Warm);
            CitizenChangerSystem.Reload("Adult_Male", Adult_Male_Warm);
        }
    }
}
