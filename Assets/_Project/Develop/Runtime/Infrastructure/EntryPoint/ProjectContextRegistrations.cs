using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.AssetManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataRepository;
using _Project.Develop.Runtime.Utilities.DataManagement.KeysStorage;
using _Project.Develop.Runtime.Utilities.DataManagement.SaveLoadManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.Serializers;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle(CreateSaveLoadService);
            container.RegisterAsSingle(CreateWalletService);
            container.RegisterAsSingle(CreatePlayerDataProvider);
            container.RegisterAsSingle(CreateStatisticService);
            container.RegisterAsSingle(CreateViewFactory);
            container.RegisterAsSingle(CreateProjectPresentersFactory);

            container.Initialize();
        }

        private static ProjectPresentersFactory CreateProjectPresentersFactory(DIContainer c)
        {
            return new ProjectPresentersFactory(c);
        }

        private static ViewsFactory CreateViewFactory(DIContainer c)
        {
            ResourcesAssetsLoader resources = c.Resolve<ResourcesAssetsLoader>();
            return new ViewsFactory(resources);
        }

        private static StatisticService CreateStatisticService(DIContainer c)
        {
            return new StatisticService(c.Resolve<PlayerDataProvider>());
        }

        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
        {
            return new(c.Resolve<SaveLoadService>(), c.Resolve<ConfigsProviderService>());
        }

        private static WalletService CreateWalletService(DIContainer c)
        {
            return new(c.Resolve<PlayerDataProvider>());
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer c)
        {
            IDataSerializer dataSerializer = new JsonSerializer();
            IDataKeysStorage keysStorage = new MapDataKeysStorage();

            string saveFolderPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            IDataRepository dataRepository = new LocalFileDataRepository(saveFolderPath, "json");

            return new SaveLoadService(
                dataSerializer, keysStorage, dataRepository
            );
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
        {
            return new SceneSwitcherService(
                c.Resolve<ILoadingScreen>(),
                c);
        }

        private static SceneLoaderService CreateSceneLoaderService(DIContainer c)
            => new SceneLoaderService();

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            ResourcesConfigsLoader resourcesConfigsLoader = new(resourcesAssetsLoader);

            return new ConfigsProviderService(resourcesConfigsLoader);
        }

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer c)
            => new ResourcesAssetsLoader();

        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLoader.Load<CoroutinesPerformer>(R.Utilities.CoroutinesPerformer);

            return Object.Instantiate(coroutinesPerformerPrefab);
        }

        private static StandardLoadingScreen CreateLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            StandardLoadingScreen standardLoadingScreenPrefab = resourcesAssetsLoader.Load<StandardLoadingScreen>(R.Utilities.StandardLoadingScreen);

            return Object.Instantiate(standardLoadingScreenPrefab);
        }
    }
}