using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using System;

using Assets._Project.Develop.Runtime.UI.CommonViews;

using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action                         OpenLevelsMenuButtonClicked;
        [field: SerializeField] public IconTextView WalletView { get; private set; }
        [field: SerializeField] public IconTextListView StatisticView { get; private set; }

        // [SerializeField] private Button _openLevelsMenuButton;

        private void OnEnable()
        {
            // _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
        }

        private void OnDisable()
        {
            // _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();
    }
}
