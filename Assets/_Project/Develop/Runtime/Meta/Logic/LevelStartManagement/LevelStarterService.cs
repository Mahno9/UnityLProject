using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure.MovingGameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Logic.LevelStartManagement
{
    public class LevelStarterService
    {
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public LevelStarterService(SceneSwitcherService sceneSwitcherService, ICoroutinesPerformer coroutinesPerformer)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void StartLevel(StringGeneratorType stringStringGeneratorType)
            => _coroutinesPerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.Level, new GameplayInputArgs(stringStringGeneratorType))
            );

        public void StartMovingGameplay()
            => _coroutinesPerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MovingGameplayScene, new MovingGameplayInputArgs())
            );
    }
}