using _Project.Develop.Runtime.Gameplay.Logic.TypeStringManagement;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
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