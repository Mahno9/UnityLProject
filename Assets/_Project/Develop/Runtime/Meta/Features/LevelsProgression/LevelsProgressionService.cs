using System.Collections.Generic;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression
{
    public class LevelsProgressionService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private const int FirstLevel = 1;

        private int _winCount;
        private int _defeatCount;

        public LevelsProgressionService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public void CompleteLevel(int _)
        {
            _winCount++;
        }

        public void DefeatLevel(int _)
        {
            _defeatCount++;
        }

        public void ReadFrom(PlayerData data)
        {
            _winCount = data.MovingWins;
            _defeatCount = data.MovingDefeats;
        }

        public void WriteTo(PlayerData data)
        {
            data.MovingWins = _winCount;
            data.MovingDefeats = _defeatCount;
        }
    }
}