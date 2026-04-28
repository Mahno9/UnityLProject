using System.Linq;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement
{
    public class RandomNumbersStringGeneratorService : ITypeStringGenerator
    {
        public string Generate(int length = 4)
        {
            return string.Concat(Enumerable.Range(0, length).Select(_ => Random.Range(0, 10).ToString()));
        }
    }
}