using Game;
using Game.Prefabs;
using Unity.Entities;

namespace CitizenChanger.Systems
{
    public partial class CitizenChangerSystem : GameSystemBase
    {
        private static PrefabSystem m_PrefabSystem;
        private static EntityQuery _humanPrefabQuery;
        private static readonly CharacterGroupLoader CharacterGroupLoader = new();

        protected override void OnCreate()
        {
            base.OnCreate();
            m_PrefabSystem = World.DefaultGameObjectInjectionWorld?.GetOrCreateSystemManaged<PrefabSystem>();
            _humanPrefabQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadWrite<HumanData>()
                    ]
            });
            RequireForUpdate(_humanPrefabQuery);
        }

        protected override void OnUpdate()
        {
        }
        public void Reload(string humanPrefab, int characterGroup)
        {
            Mod.log.Info($"Selections: '{humanPrefab}' & '{characterGroup}: {CharacterGroupLoader.CharacterGroupNames[characterGroup]}'");
            Reload(humanPrefab, CharacterGroupLoader.CharacterGroupNames[characterGroup]);
        }

        public void Reload(string humanPrefab, string characterGroup)
        {
            m_PrefabSystem.TryGetPrefab(new PrefabID("HumanPrefab", humanPrefab), out PrefabBase prefabBase);
            Mod.log.Info($"prefabBase.name: {prefabBase.name}");
            m_PrefabSystem.TryGetEntity(prefabBase, out Entity entity);

            m_PrefabSystem.TryGetPrefab(entity, out ObjectGeometryPrefab objectGeometryPrefab);

            foreach (ObjectMeshInfo meshGroup in objectGeometryPrefab.m_Meshes)
            {
                if (meshGroup.m_RequireState == Game.Objects.ObjectState.Warm)
                {
                    m_PrefabSystem.TryGetPrefab(new PrefabID("CharacterGroup", characterGroup), out PrefabBase prefab);
                    if (prefab != null)
                    {
                        meshGroup.m_Mesh = (RenderPrefabBase)prefab;
                    }
                }
            }

            m_PrefabSystem.UpdatePrefab(prefabBase);
        }
    }
}
