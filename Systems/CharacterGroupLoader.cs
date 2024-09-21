using Game;
using Game.Prefabs;
using Unity.Collections;
using Unity.Entities;
using System.Collections.Generic;

namespace CitizenChanger.Systems
{
    public partial class CharacterGroupLoader : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem;
        private EntityQuery _characterGroupQuery;
        private Setting settings = Mod.m_Setting;
        private readonly CitizenChangerSystem CitizenChangerSystem = new();

        private bool started = false;

        public static List<string> CharacterGroupNames = [];

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
                    m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase);
                    CharacterGroupNames.Add(prefabBase.name);
                }
                Mod.log.Info($"{CharacterGroupNames.Count} groups added");
                CitizenChangerSystem.Reload("Adult_Female", "AdultWarm Group");
                CitizenChangerSystem.Reload("Adult_Male", "AdultWarm Group");
                Enabled = false;
            }
        }

        public static int Position(string name)
        {
            return CharacterGroupNames.IndexOf(name);
        }
    }
}
