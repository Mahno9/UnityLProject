using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Logic.MarketManagement
{
    public class ResetProgressProductItem : IProductItem
    {
        private readonly StatisticService     _statisticService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly PlayerDataProvider   _playerDataProvider;

        public ResetProgressProductItem(StatisticService statisticService, SceneSwitcherService sceneSwitcherService, ICoroutinesPerformer coroutinesPerformer, PlayerDataProvider playerDataProvider)
        {
            _statisticService = statisticService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _playerDataProvider = playerDataProvider;
        }

        public void Apply()
        {
            ResetStatistic();
            SaveProgress();
            RestartMenu();
        }

        private void ResetStatistic()
        {
            _statisticService.ResetStatistic();
        }

        private void RestartMenu()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(S._Project.Scenes.MainMenu));
        }

        private void SaveProgress() =>
            _coroutinesPerformer.StartPerform(
                _playerDataProvider.Save()
            );
    }
}