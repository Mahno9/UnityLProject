namespace _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement
{
    public interface ITowerDefensePhaseSetter : ITowerDefensePhaseReader
    {
        public void Set(TowerDefensePhase phase);
    }
}