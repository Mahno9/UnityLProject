using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class DefeatPopupPresenter : PopupPresenterBase
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly DefeatPopupView         _view;
        private readonly SceneSwitcherService _sceneSwitcher;

        public DefeatPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            DefeatPopupView         view,
            SceneSwitcherService sceneSwitcher
        ) : base(coroutinesPerformer)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _view = view;
            _sceneSwitcher = sceneSwitcher;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();
            _view.MenuButtonClicked += OnMenuButtonClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();
            _view.MenuButtonClicked -= OnMenuButtonClicked;
        }

        public override void Dispose()
        {
            base.Dispose();
            _view.MenuButtonClicked -= OnMenuButtonClicked;
        }

        private void OnMenuButtonClicked()
        {
            _coroutinesPerformer.StartPerform(_sceneSwitcher.ProcessSwitchTo(S._Project.Scenes.MainMenu));
            OnCloseRequest();
        }
    }
}