using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Logic.StatisticManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Logic.MarketManagement
{
    public class ProductItemsFactory
    {
        private readonly DIContainer _container;

        public ProductItemsFactory(DIContainer container)
        {
            _container = container;
        }

        public ResetProgressProductItem CreateResetProgressAction()
        {
            return new ResetProgressProductItem(
                _container.Resolve<StatisticService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<PlayerDataProvider>());
        }
    }
}