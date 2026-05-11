using System;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Logic.WalletManagment
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
