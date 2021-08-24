using System;

namespace SemoGames.SaveData
{
    [Serializable]
    public struct GameSaveData
    {
        public int[] CollectedIds;
        public int[] BeatenLevelIndices;
    }
}