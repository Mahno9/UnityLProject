using System;
using System.Collections.Generic;

using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Meta.Market
{
    [CreateAssetMenu(menuName = "Configs/Meta/Market/MarketConfig", fileName = "MarketConfig")]
    public class MarketConfig : ScriptableObject
    {
        [SerializeField] private List<ProductPrice> _variableName;

        [Serializable]
        private class ProductPrice
        {
            [field: SerializeField] public ProductName Product { get; private set; }
            [field: SerializeField] public int         Price   { get; private set; }
        }
    }
}