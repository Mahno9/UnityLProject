using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure.GameplayInputArgsManagement
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(StringGeneratorType stringGeneratorType)
        {
            StringGeneratorType = stringGeneratorType;
        }

        public readonly StringGeneratorType StringGeneratorType;
    }
}