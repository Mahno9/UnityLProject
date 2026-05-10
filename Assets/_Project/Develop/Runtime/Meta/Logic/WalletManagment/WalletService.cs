using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

using System;

namespace Assets._Project.Develop.Runtime.Meta.Features.Wallet
{
    public class WalletService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private ReactiveVariable<int> _gold;

        public WalletService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> GetGold() => _gold;

        public bool Enough(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return _gold.Value >= amount;
        }

        public void Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _gold.Value += amount;
        }

        public void Spend(int amount)
        {
            if (Enough(amount) == false)
                throw new InvalidOperationException("Not enough gold");

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _gold.Value -= amount;
        }

        public void ReadFrom(PlayerData data) => _gold.Value = data.Gold;

        public void WriteTo(PlayerData data) => data.Gold = _gold.Value;
    }
}
