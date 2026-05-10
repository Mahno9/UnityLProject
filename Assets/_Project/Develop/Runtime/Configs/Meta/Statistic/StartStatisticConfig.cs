using UnityEngine;

namespace LProject.Assets._Project.Develop.Runtime.Configs.Meta.Statistic
{
    [CreateAssetMenu(menuName = "Configs/Meta/PlayerData/NewStartStatisticConfig", fileName = "StartStatisticConfig")]
    public class StartStatisticConfig : ScriptableObject
    {
        [SerializeField] private int _loses;

        [SerializeField] private int _wins;

        public int GetWins() => _wins;

        public int GetLoses() => _loses;

    }
}