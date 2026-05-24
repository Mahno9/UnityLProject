using _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement;
using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.UI.Core;

using TMPro;

using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Develop.Runtime.UI.Level
{
    public class LevelInterfaceView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _pinTaskText;
        [SerializeField] private TMP_InputField  _typeInputField;

        [SerializeField] private RectTransform   _resultPanel;
        [SerializeField] private TextMeshProUGUI _resultText;

        [SerializeField] private Color  _winTextColor  = new(0x70, 0xFF, 0x80);
        [SerializeField] private string _winText       = "Поздравляю! Это правильный PIN!";
        [SerializeField] private Color  _loseTextColor = new(0xFF, 0x7F, 0x7F);
        [SerializeField] private string _loseText      = "Одна ошибка и надо пробовать снова.";

        private void OnEnable()
        {
            _resultPanel.gameObject.SetActive(false);
        }

        public void SetTaskPin(string pin) => _pinTaskText.text = pin;

        public void UpdateInputText(string inputText) => _typeInputField.text = inputText;

        public void ShowResult(bool isWin)
        {
            _resultPanel.gameObject.SetActive(true);

            if (isWin)
            {
                _resultText.SetText(_winText);
                _resultText.color = _winTextColor;
            }
            else
            {
                _resultText.SetText(_loseText);
                _resultText.color = _loseTextColor;
            }
        }
    }
}