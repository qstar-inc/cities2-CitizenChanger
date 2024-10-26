using Game.Prefabs;
using Game;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Colossal.Entities;
using Game.Rendering;
using Colossal.Json;
using System;
using Game.UI.Localization;
using System.Linq;

namespace CitizenModelManager.Systems
{
    public partial class CharacterGroupLoader : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem;
        private EntityQuery _characterGroupQuery;
        private readonly Setting settings = Mod.m_Setting;

        private bool started = false;

        public static List<string> CharacterGroupMale = [];
        public static List<string> CharacterGroupFemale = [];
        public static string LoadedCharacterGroupsList { get; set; } = "";

        protected override void OnCreate()
        {
            base.OnCreate();
            m_PrefabSystem = World.DefaultGameObjectInjectionWorld?.GetOrCreateSystemManaged<PrefabSystem>();
            _characterGroupQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadOnly<CharacterGroupData>()
                    ]
            });
            RequireForUpdate(_characterGroupQuery);
        }

        protected override void OnUpdate()
        {
            if (!started)
            {
                started = true;
                var characterGroups = _characterGroupQuery.ToEntityArray(Allocator.Temp);
                Mod.log.Info($"Found {characterGroups.Length} groups");
                foreach (var entity in characterGroups)
                {
                    m_PrefabSystem.TryGetPrefab(entity, out CharacterGroup characterGroup);

                    if (characterGroup != null)
                    {
                        bool addedToMale = false;
                        bool addedToFemale = false;

                        foreach (var character in characterGroup.m_Characters)
                        {
                            var characterStyle = character.m_Style.m_Gender;

                            if (characterStyle.ToString() == "Male" && !addedToMale)
                            {
                                CharacterGroupMale.Add(characterGroup.name);
                                addedToMale = true;
                            }
                            else if (characterStyle.ToString() == "Female" && !addedToFemale)
                            {
                                CharacterGroupFemale.Add(characterGroup.name);
                                addedToFemale = true;
                            }
                            if (addedToMale && addedToFemale)
                            {
                                break;
                            }
                        }
                    }
                }

                Dictionary<string, string> combinedGroups = [];
                foreach (var group in CharacterGroupMale)
                {
                    if (!combinedGroups.ContainsKey(group))
                        combinedGroups[group] = "Male";
                    else
                        combinedGroups[group] = "Male & Female";
                }
                foreach (var group in CharacterGroupFemale)
                {
                    if (!combinedGroups.ContainsKey(group))
                        combinedGroups[group] = "Female";
                    else
                        combinedGroups[group] = "Male & Female";
                }
                foreach (var item in combinedGroups.OrderBy(g => g.Key))
                {
                    LoadedCharacterGroupsList += $"- {item.Key} <[{item.Value}]>\r\n";
                }

                Mod.log.Info($"{CharacterGroupMale.Count} groups added for males");
                Mod.log.Info($"{CharacterGroupFemale.Count} groups added for females");

                settings.ApplyCitizenChanger();

                Mod.m_Setting.SettingsVersion++;
                Enabled = false;
            }
        }

        public static LocalizedString LoadedCharacterGroups()
        {
            return LocalizedString.Id(LoadedCharacterGroupsList);
        }

        //public static int Position(string name, string gender)
        //{
        //    if (gender == "male")
        //    {
        //        return CharacterGroupMale.IndexOf(name);
        //    }
        //    else
        //    {
        //        return CharacterGroupFemale.IndexOf(name);
        //    }
        //}
    }
}
