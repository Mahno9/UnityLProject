using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement
{
    // Read-model текущей фазы боя для презентеров: читать Current и подписываться на смену.
    // Использовать только через реализованные интерфейсы ITowerDefensePhaseSetter и ITowerDefencePhaseReader

    public class TowerDefensePhaseService : ITowerDefensePhaseSetter
    {
        private readonly ReactiveVariable<TowerDefensePhase> _current = new();

        public IReadOnlyVariable<TowerDefensePhase> Current => _current;

        public void Set(TowerDefensePhase phase) => _current.Value = phase;
    }
}
