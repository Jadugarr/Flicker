using System;
using System.Collections.Generic;
using UnityEngine;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "LevelCoinMapConfiguration", menuName = "Configurations/LevelCoinMapConfiguration")]
    [Serializable]
    public class LevelCoinMapConfiguration : ScriptableObject
    {
        [SerializeField] private AssetReferenceConfiguration _assetReferenceConfiguration;
        [SerializeField] private List<LevelCoinData> _collectableIds;

        public List<LevelCoinData> CollectableIds => _collectableIds;

        public bool TryGetCoinDataByLevelIndex(int levelIndex, out LevelCoinData levelCoinData)
        {
            foreach (LevelCoinData coinData in _collectableIds)
            {
                if (coinData.LevelIndex == levelIndex)
                {
                    levelCoinData = coinData;
                    return true;
                }
            }

            levelCoinData = default;
            return false;
        }
    }

    [Serializable]
    public struct LevelCoinData
    {
        [SerializeField] public int LevelIndex;
        [SerializeField] public List<int> CollectableIds;
    }
    
}