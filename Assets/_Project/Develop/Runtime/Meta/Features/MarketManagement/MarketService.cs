using _Project.Develop.Runtime.Configs.Meta.Market;
using _Project.Develop.Runtime.Meta.Logic.MarketManagement.ProductItems;
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
            return TryBuy(product, _productItemsFactory.CreateResetProgressAction());
        }

        public bool TryBuy(ProductName product, IProductItem item)
        {
            if (item is null)
                return false;

            int price = _config.GetPrice(product);

            if (_wallet.EnoughGold(price) == false)
                return false;

            _wallet.SpendGold(price);

            item.Apply();
            return true;
        }

        public int GetPrice(ProductName product) => _config.GetPrice(product);
    }
}