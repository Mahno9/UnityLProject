namespace _Project.Develop.Runtime.Gameplay.Logic.TypeInputManagement
{
    public interface IPlayerTypingSubscriber
    {
        void OnPlayerInput(string typedString);
    }
}