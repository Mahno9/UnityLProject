using System;

using _Project.Develop.Runtime.UI.Core;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuItemsView : MonoBehaviour, IView
    {
        [SerializeField] private Button _startLettersGameButton;
        [SerializeField] private Button _startNumbersGameButton;
        [SerializeField] private Button _resetStatisticButton;

        [SerializeField] private string _resetStatisticButtonPrefix = "Сбросить статистику за ";
        [SerializeField] private string _resetStatisticButtonPostfix = " деняк";

        public event Action StartLettersGameClicked;
        public event Action StartNumbersGameClicked;
        public event Action ResetStatisticClicked;

        public void SetResetPrice(int price)
        {
            TextMeshProUGUI text = _resetStatisticButton.transform.GetComponentInChildren<TextMeshProUGUI>();

            if (text is not null)
                text.SetText(_resetStatisticButtonPrefix + price + _resetStatisticButtonPostfix);
            else
                Debug.LogWarning($"Can't find a text component on button {_resetStatisticButton.name}");
        }

        private void OnEnable()
        {
            _startLettersGameButton.onClick.AddListener(OnStartLettersGameClicked);
            _startNumbersGameButton.onClick.AddListener(OnStartNumbersGameClicked);
            _resetStatisticButton.onClick.AddListener(OnResetStatisticClicked);
        }

        private void OnDisable()
        {
            _startLettersGameButton.onClick.RemoveListener(OnStartLettersGameClicked);
            _startNumbersGameButton.onClick.RemoveListener(OnStartNumbersGameClicked);
            _resetStatisticButton.onClick.RemoveListener(OnResetStatisticClicked);
        }

        private void OnStartLettersGameClicked() => StartLettersGameClicked?.Invoke();
        private void OnStartNumbersGameClicked() => StartNumbersGameClicked?.Invoke();
        private void OnResetStatisticClicked()   => ResetStatisticClicked?.Invoke();
    }
}