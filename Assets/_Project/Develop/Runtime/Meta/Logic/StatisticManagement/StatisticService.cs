using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Logic.StatisticManagment
{
    public class StatisticService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly ReactiveVariable<int> _wins  = new();
        private readonly ReactiveVariable<int> _loses = new();

        public StatisticService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyVariable<int> GetWins() => _wins;
        public IReadOnlyVariable<int> GetLoses() => _loses;

        public void RegisterWin() => _wins.Value++;

        public void RegisterLose() => _loses.Value++;


        public void ReadFrom(PlayerData data)
        {
            _wins.Value = data.Wins;
            _loses.Value = data.Loses;
        }

        public void WriteTo(PlayerData data)
        {
            data.Wins = _wins.Value;
            data.Loses = _loses.Value;
        }
    }
}