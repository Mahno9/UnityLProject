using _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(StringGeneratorType stringGeneratorType)
        {
            StringGeneratorType = stringGeneratorType;
        }

        public StringGeneratorType StringGeneratorType;
    }
}