namespace _Project.Develop.Runtime.Gameplay.Features.GameStateManagement.GameStates
{
    public interface IGameState
    {
        void OnEnter();
        void OnExit();
        void Update();
    }
}