using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.Features.StringGenerationManagement;
using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Logic.LevelStartManagement
{
    public class LevelStarterService
    {
        private readonly SceneSwitcherService   _sceneSwitcherService;
        private readonly ICoroutinesPerformer   _coroutinesPerformer;
        private readonly ConfigsProviderService _configsProviderService;

        public LevelStarterService(
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
                ConfigsProviderService configsProviderService)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _configsProviderService = configsProviderService;
        }

        public void StartLevel(StringGeneratorType stringStringGeneratorType)
            => _coroutinesPerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.Level, new GameplayInputArgs(stringStringGeneratorType))
            );

        public void StartRandomLevelMovingGameplay()
        {
            int levelNumber = GetRandomLevelNum();
            _coroutinesPerformer.StartPerform(
                _sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MovingGameplayScene, new MovingGameplayInputArgs(levelNumber))
            );
        }

        private int GetRandomLevelNum()
        {
            const int indexToNumber = 1;
            return Random.Range(0, _configsProviderService.GetConfig<LevelsListConfig>().Levels.Count) + indexToNumber;
        }

    }
}