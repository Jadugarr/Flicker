using System;
using UnityEngine;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "GameConstantsConfiguration", menuName = "Configurations/GameConstantsConfiguration")]
    [Serializable]
    public class GameConstantsConfiguration : ScriptableObject
    {
        [Header("Player")] 
        [SerializeField] private float maxFlickPower;
        [SerializeField] private float maxDragLength;

        [Header("Flipper")] 
        [SerializeField] private float bumperPower;

        [SerializeField] private float speedUpFactor;

        [Header("Audio")] [SerializeField] private float impactSoundFullVolumeVelocityThreshold;

        [Header("Effects")] [SerializeField] private float impactStarEffectVelocityThreshold;
        [SerializeField] private float impatStarCollisionAngleThreshold;

        #region Read-only properties

        public float MaxFlickPower => maxFlickPower;

        public float MaxDragLength => maxDragLength;

        public float BumperPower => bumperPower;

        public float SpeedUpFactor => speedUpFactor;

        public float ImpactSoundFullVolumeVelocityThreshold => impactSoundFullVolumeVelocityThreshold;

        public float ImpactStarEffectVelocityThreshold => impactStarEffectVelocityThreshold;

        public float ImpatStarCollisionAngleThreshold => impatStarCollisionAngleThreshold;

        #endregion
    }
}