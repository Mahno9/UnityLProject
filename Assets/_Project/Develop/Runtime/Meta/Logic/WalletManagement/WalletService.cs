using System;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Logic.WalletManagement
{
    public class WalletService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly ReactiveVariable<int> _gold = new();

        public WalletService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> GetGold() => _gold;

        public bool EnoughGold(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            return _gold.Value >= amount;
        }

        public void AddGold(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _gold.Value += amount;
        }

        public void SpendGold(int amount)
        {
            if (EnoughGold(amount) == false)
                throw new InvalidOperationException("Not enough gold");

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _gold.Value -= amount;
        }

        public void ReadFrom(PlayerData data) => _gold.Value = data.Gold;

        public void WriteTo(PlayerData data) => data.Gold = _gold.Value;
    }
}
