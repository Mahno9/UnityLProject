using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Logic.LevelPickerService
{
    public class LevelLoaderService
    {
        private readonly DIContainer _container;

        public LevelLoaderService(DIContainer container)
        {
            _container = container;
        }

        public void StartLevel(StringGeneratorType stringStringGeneratorType)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer  = _container.Resolve<ICoroutinesPerformer>();

            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.Level, new GameplayInputArgs(stringStringGeneratorType)));
        }
    }
}