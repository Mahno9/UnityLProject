using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement
{
    // Read-model текущей фазы боя для презентеров: читать Current и подписываться на смену.
    // Пишется ТОЛЬКО из TowerDefenseStatesFactory по событиям Entered стейтов — снаружи Set не звать.
    public class TowerDefensePhaseService
    {
        private readonly ReactiveVariable<TowerDefensePhase> _current = new();

        public IReadOnlyVariable<TowerDefensePhase> Current => _current;

        public void Set(TowerDefensePhase phase) => _current.Value = phase;
    }
}
