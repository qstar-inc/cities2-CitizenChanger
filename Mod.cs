using CitizenModelManager.Systems;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Unity.Entities;

namespace CitizenModelManager
{
    public class Mod : IMod
    {
        public const string Name = "Citizen Model Manager";
        public const string Version = "1.0.0";

        public static ILog log = LogManager.GetLogger($"{nameof(CitizenModelManager)}").SetShowsErrorsInUI(false);
        public static Setting m_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));


            AssetDatabase.global.LoadSettings(nameof(CitizenModelManager), m_Setting, new Setting(this));

            updateSystem.UpdateAfter<CharacterGroupLoader>(SystemUpdatePhase.PrefabUpdate);
            World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<CitizenChangerSystem>();
        }

        public void OnDispose()
        {
            if (m_Setting != null)
            {
                m_Setting.UnregisterInOptionsUI();
                m_Setting.SettingsVersion = 0;
                m_Setting = null;
            }
        }
    }
}
