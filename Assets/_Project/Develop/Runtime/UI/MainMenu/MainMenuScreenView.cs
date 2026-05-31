using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;

using UnityEngine;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView      WalletView    { get; private set; }
        [field: SerializeField] public IconTextListView  StatisticView { get; private set; }
        [field: SerializeField] public MainMenuItemsView MenuItemsView { get; private set; }
    }
}