using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.TowerDefense
{
    public class TowerDefenseScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView WalletView     { get; private set; }
        [field: SerializeField] public IconTextView WaveView       { get; private set; }
        [field: SerializeField] public IconTextView HealthView     { get; private set; }
        [field: SerializeField] public IconTextView EnemyCountView { get; private set; }
        [field: SerializeField] public Button       StartButton    { get; private set; }

        [SerializeField] private TMP_Text _startButtonText;

        public TMP_Text StartButtonText => _startButtonText;
    }
}
