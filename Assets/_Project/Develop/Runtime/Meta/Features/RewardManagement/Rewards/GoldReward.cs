using _Project.Develop.Runtime.Meta.Logic.WalletManagement;

namespace _Project.Develop.Runtime.Meta.Logic.RewardManagement.Rewards
{
    // Награда: начислить золото в кошелёк.
    public class GoldReward : IReward
    {
        private readonly int           _amount;
        private readonly WalletService _walletService;

        public GoldReward(int amount, WalletService walletService)
        {
            _amount = amount;
            _walletService = walletService;
        }

        public void Apply() => _walletService.AddGold(_amount);
    }
}
