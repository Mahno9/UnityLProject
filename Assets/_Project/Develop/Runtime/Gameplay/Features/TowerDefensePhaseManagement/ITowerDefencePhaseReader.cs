using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement
{
    public interface ITowerDefencePhaseReader
    {
        public IReadOnlyVariable<TowerDefensePhase> Current { get; }
    }
}