using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;

namespace Infrastructure.AssetProvider
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private const string MouseStaticDataPath = "StaticData/MouseData";

        private readonly List<MouseType> _allMouseTypes;

        private int _index = 0;

        public StaticDataProvider()
        {
            _allMouseTypes = new List<MouseType>();
            _allMouseTypes = Resources.LoadAll<MouseType>(MouseStaticDataPath).ToList();
        }

        public MouseType GetCurrentMouseType() =>
            _allMouseTypes[_index];

        public void SetIndex(int index) => 
            _index = index;
    }
}