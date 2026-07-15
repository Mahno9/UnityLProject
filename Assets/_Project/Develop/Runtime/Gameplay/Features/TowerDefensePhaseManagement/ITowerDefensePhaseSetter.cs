namespace _Project.Develop.Runtime.Gameplay.Features.TowerDefensePhaseManagement
{
    public interface ITowerDefensePhaseSetter : ITowerDefencePhaseReader
    {
        public void Set(TowerDefensePhase phase);
    }
}