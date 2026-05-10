using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace LProject.Assets._Project.Develop.Runtime.Meta.Logic.StatisticManagment
{
    public class StatisticService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private ReactiveVariable<int> _wins;
        private ReactiveVariable<int> _loses;

        public StatisticService(ReactiveVariable<int> wins, ReactiveVariable<int> loses, PlayerDataProvider playerDataProvider)
        {
            _wins = wins;
            _loses = loses;

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