using UnityEngine;

namespace LProject.Assets._Project.Develop.Runtime.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/NewStartWalletConfig", fileName = "StartWalletConfig")]
    public class StartWalletConfig : ScriptableObject
    {
        [SerializeField] private int _gold;

        [SerializeField] private int _loses;

        [SerializeField] private int _wins;


        public int GetGold() => _gold;

        public int GetWins() => _wins;

        public int GetLoses() => _loses;

    }
}