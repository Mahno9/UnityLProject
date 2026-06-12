using System;

using _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagement;
using _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement;
using _Project.Develop.Runtime.UI.Core;

namespace _Project.Develop.Runtime.UI.Level
{
    public class LevelInterfacePresenter : IPresenter
    {
        private readonly LevelInterfaceView   _view;
        private readonly TypingInputService   _typingInputService;
        private readonly StringMatcherService _matcherService;

        private          IDisposable              _typeSubscription;

        public LevelInterfacePresenter(
            LevelInterfaceView view,
            TypingInputService typingInputService,
            StringMatcherService matcherService)
        {
            _view = view;
            _typingInputService = typingInputService;
            _matcherService = matcherService;
        }

        public void Initialize()
        {
            _typeSubscription = _typingInputService.TypeString.Subscribe((_, typedString) => _view.UpdateInputText(typedString));

            _view.SetTaskPin(_matcherService.GetTargetString());
        }

        public void Dispose()
        {
            _typeSubscription.Dispose();
        }

        public void ShowResult(bool isWin)
        {
            _view.ShowResult(isWin);
        }
    }
}