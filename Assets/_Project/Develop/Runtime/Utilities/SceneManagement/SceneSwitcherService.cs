using System;
using System.Collections;

using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.LoadingScreen;

using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Utilities.SceneManagement
{
    public class SceneSwitcherService
    {
        private readonly ILoadingScreen     _loadingScreen;
        private readonly DIContainer        _projectContainer;

        private DIContainer _currentSceneContainer;

        public SceneSwitcherService(
            ILoadingScreen     loadingScreen,
            DIContainer        projectContainer)
        {
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
        }

        public void SwitchToScene(string sceneName)
        {
            SceneSwitcherService sceneSwitcherService = _currentSceneContainer.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _currentSceneContainer.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(sceneName, _currentSceneContainer.Resolve<GameplayInputArgsService>().Get()));
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            _currentSceneContainer?.Dispose();

            yield return SceneLoaderService.LoadAsync(S._Project.Scenes.Empty);
            yield return SceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

            if (sceneBootstrap is null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneContainer = new DIContainer(_projectContainer);

            sceneBootstrap.ProcessRegistrations(_currentSceneContainer, sceneArgs);

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}