using System;
using System.Collections.Generic;

using _Project.Develop.Runtime.Data.PlayerData;
using _Project.Develop.Runtime.Utilities.DataManagement.SaveLoadManagement;

namespace _Project.Develop.Runtime.Utilities.DataManagement.KeysStorage
{
    public class MapDataKeysStorage : IDataKeysStorage
    {
        private readonly Dictionary<Type, string> _keys = new Dictionary<Type, string>()
        {
            {typeof(PlayerData), "PlayerData" },
        };

        public string GetKeyFor<TData>() where TData : ISaveData
            => _keys[typeof(TData)];
    }
}
