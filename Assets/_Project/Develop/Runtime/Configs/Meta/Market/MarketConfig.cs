using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Develop.Runtime.Configs.Meta.Market
{
    [CreateAssetMenu(menuName = "Configs/Meta/Market/MarketConfig", fileName = "MarketConfig")]
    public class MarketConfig : ScriptableObject
    {
        [SerializeField] private List<ProductPrice> _productPrices;

        public int GetPrice(ProductName product)
        {
            return (from productPrice in _productPrices where productPrice.Product == product select productPrice.Price).FirstOrDefault();
        }

        [Serializable]
        private class ProductPrice
        {
            [field: SerializeField] public ProductName Product { get; private set; }
            [field: SerializeField] public int         Price   { get; private set; }
        }
    }
}