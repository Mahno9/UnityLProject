using System.Collections;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Старт проекта, сетап настроек");

            SetupAppSettings();

            Debug.Log("Процесс регистрации сервисов всего проекта");

            DIContainer projectContainer = new();

            ProjectContextRegistrations.Process(projectContainer);

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen       loadingScreen        = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();

            loadingScreen.Show();
            Debug.Log("Начинается инициализация сервисов");

            yield return LoadConfigs(container);
            yield return LoadPlayerData(container);

            Debug.Log("Завершается инициализация сервисов");
            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu);
        }

        private static IEnumerator LoadPlayerData(DIContainer container)
        {
            PlayerDataProvider playerDataProvider     = container.Resolve<PlayerDataProvider>();
            bool               isPlayerDataSaveExists = false;

            yield return playerDataProvider.Exists(result => isPlayerDataSaveExists = result);

            if (isPlayerDataSaveExists)
                yield return playerDataProvider.Load();
            else
                playerDataProvider.Reset();
        }

        private static IEnumerator LoadConfigs(DIContainer container) => container.Resolve<ConfigsProviderService>().LoadAsync();
    }
}