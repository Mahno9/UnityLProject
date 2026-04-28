using System.Linq;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement
{
    public class RandomLettersStringGeneratorService : ITypeStringGenerator
    {
        public string Generate(int length = 4)
        {
            return string.Concat(Enumerable.Range(0, length).Select(_ => ((char)Random.Range('a', 'z' + 1)).ToString()));
        }
    }
}