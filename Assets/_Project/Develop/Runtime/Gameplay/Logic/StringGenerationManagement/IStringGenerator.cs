using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Logic.TypeStringManagement
{
    public interface ITypeStringGenerator
    {
        string Generate(int length = 4);
    }
}