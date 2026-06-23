using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement
{
    public class MovingGameplayInputArgs : IInputSceneArgs
    {
        public MovingGameplayInputArgs(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        public int LevelNumber { get; }
    }
}
