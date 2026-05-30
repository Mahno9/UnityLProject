using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

using System;

using _Project.Develop.Runtime.UI.CommonViews;

using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView      WalletView    { get; private set; }
        [field: SerializeField] public IconTextListView  StatisticView { get; private set; }
        [field: SerializeField] public MainMenuItemsView MenuItemsView { get; private set; }
    }
}