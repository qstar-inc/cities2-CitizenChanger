using Game;
using Game.Prefabs;
using Unity.Entities;

namespace CitizenModelManager.Systems
{
    public partial class CitizenChangerSystem : GameSystemBase
    {
        private static PrefabSystem m_PrefabSystem;
        private static EntityQuery _humanPrefabQuery;

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
        //public void Reload(string humanPrefab, string group, int characterGroup, string gender)
        //{
        //    if (gender == "male")
        //    {
        //        Reload(humanPrefab, group, CharacterGroupLoader.CharacterGroupMale[characterGroup]);
        //    }
        //    else
        //    {
        //        Reload(humanPrefab, group, CharacterGroupLoader.CharacterGroupFemale[characterGroup]);
        //    }
            
        //}

        public void Reload(string humanPrefab, string group, string characterGroup)
        {
            m_PrefabSystem.TryGetPrefab(new PrefabID("HumanPrefab", humanPrefab), out PrefabBase prefabBase);
            m_PrefabSystem.TryGetEntity(prefabBase, out Entity entity);

            m_PrefabSystem.TryGetPrefab(entity, out ObjectGeometryPrefab objectGeometryPrefab);

            foreach (ObjectMeshInfo meshGroup in objectGeometryPrefab.m_Meshes)
            {
                if (meshGroup.m_RequireState == Game.Objects.ObjectState.Warm && group.Equals("warm"))
                {
                    m_PrefabSystem.TryGetPrefab(new PrefabID("CharacterGroup", characterGroup), out PrefabBase prefab);
                    if (prefab != null)
                    {
                        meshGroup.m_Mesh = (RenderPrefabBase)prefab;
                    }
                }
                if (meshGroup.m_RequireState == Game.Objects.ObjectState.Cold && group.Equals("cold"))
                {
                    m_PrefabSystem.TryGetPrefab(new PrefabID("CharacterGroup", characterGroup), out PrefabBase prefab);
                    if (prefab != null)
                    {
                        meshGroup.m_Mesh = (RenderPrefabBase)prefab;
                    }
                }
                if (meshGroup.m_RequireState == Game.Objects.ObjectState.Homeless && group.Equals("homeless"))
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
