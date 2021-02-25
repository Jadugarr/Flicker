using System;
using UnityEngine;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "GameConstantsConfiguration", menuName = "Configurations/GameConstantsConfiguration")]
    [Serializable]
    public class GameConstantsConfiguration : ScriptableObject
    {
        [SerializeField] private float maxFlickPower;
        [SerializeField] private float maxDragLength;

        #region Read-only properties

        public float MaxFlickPower => maxFlickPower;

        public float MaxDragLength => maxDragLength;

        #endregion
    }
}