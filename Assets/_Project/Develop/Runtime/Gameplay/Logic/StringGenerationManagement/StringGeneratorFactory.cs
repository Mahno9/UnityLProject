using System;

namespace _Project.Develop.Runtime.Gameplay.Logic.StringGenerationManagement
{
    public class StringGeneratorFactory
    {
        public ITypeStringGenerator Create(StringGeneratorType stringGeneratorType)
        {
            return stringGeneratorType switch
            {
                StringGeneratorType.RandomLetters => new RandomLettersStringGeneratorService(),
                StringGeneratorType.RandomNumbers => new RandomNumbersStringGeneratorService(),
                _ => throw new ArgumentOutOfRangeException(nameof(stringGeneratorType), stringGeneratorType, null)
            };
        }
    }
}