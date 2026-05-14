namespace _Project.Develop.Runtime.Gameplay.Logic.TypingInputManagement
{
    public interface IPlayerTypingSubscriber
    {
        void OnPlayerInput(string typedString);
    }
}