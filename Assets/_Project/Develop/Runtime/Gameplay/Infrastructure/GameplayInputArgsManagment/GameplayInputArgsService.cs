namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgsService
    {
        private readonly GameplayInputArgs _args;

        public GameplayInputArgsService(GameplayInputArgs args)
        {
            _args = args;
        }

        public GameplayInputArgs Get() => _args;
    }
}