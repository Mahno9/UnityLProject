using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.StagesFeature
{
    // Запрос старта боя со Start-кнопки. PreparationState сбрасывает его на входе,
    // условие prep->combat читает IsStartRequested.
    public class StartBattleService
    {
        private readonly ReactiveVariable<bool> _isStartRequested = new();

        public IReadOnlyVariable<bool> IsStartRequested => _isStartRequested;

        public void Request() => _isStartRequested.Value = true;

        public void Reset() => _isStartRequested.Value = false;
    }
}
