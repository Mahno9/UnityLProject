namespace _Project.Develop.Runtime.Gameplay.Logic.StringMatchingManagment
{
    public class StringMatcherService
    {
        private readonly string _targetString;

        public StringMatcherService(string targetString)
        {
            _targetString = targetString;
        }

        public string GetTargetString() => _targetString;

        public CompareResultType MatchString(string probeString)
        {
            if (probeString.Length > _targetString.Length)
                return CompareResultType.MissMatch;

            int i = 0;
            for (; i < probeString.Length; i++)
            {
                if (_targetString[i] != probeString[i])
                    return CompareResultType.MissMatch;
            }

            return i == _targetString.Length
                ? CompareResultType.FullMatch
                : CompareResultType.PartMatch;
        }
    }
}