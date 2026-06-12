namespace _Project.Develop.Runtime.Gameplay.Logic.GameStateManagement
{
    public interface IGameState
    {
        void OnEnter();
        void OnExit();
        void Update();
    }
}