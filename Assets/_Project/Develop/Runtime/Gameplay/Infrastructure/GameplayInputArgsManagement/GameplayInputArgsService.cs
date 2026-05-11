namespace _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement
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