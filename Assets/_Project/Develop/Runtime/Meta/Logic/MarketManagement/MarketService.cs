using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Meta.Logic.WalletManagement;

namespace _Project.Develop.Runtime.Meta.Logic.MarketManagement
{
    public class MarketService
    {
        private readonly WalletService       _wallet;
        private readonly MarketConfig        _config;
        private readonly ProductItemsFactory _productItemsFactory;

        public MarketService(WalletService wallet, MarketConfig config, ProductItemsFactory productItemsFactory)
        {
            _wallet = wallet;
            _config = config;
            _productItemsFactory = productItemsFactory;
        }

        public bool TryBuy(ProductName product)
        {
            int resetPrice = _config.GetPrice(product);

            if (!_wallet.EnoughGold(resetPrice))
                return false;

            _wallet.SpendGold(resetPrice);

            IProductItem item = _productItemsFactory.CreateResetProgressAction();
            if (item is null)
                return false;

            item.Apply();
            return true;
        }

        public int GetPrice(ProductName product) => _config.GetPrice(product);
    }
}