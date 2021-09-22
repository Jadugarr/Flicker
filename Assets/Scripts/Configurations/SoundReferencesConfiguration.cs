using System;
using UnityEngine;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "SoundReferencesConfiguration", menuName = "Configurations/SoundReferencesConfiguration")]
    [Serializable]
    public class SoundReferencesConfiguration : ScriptableObject
    {
        [SerializeField]
        private AudioClip hitGroundSound;

        [SerializeField]
        private AudioClip deathSound;

        public AudioClip HitGroundSound => hitGroundSound;

        public AudioClip DeathSound => deathSound;
    }
}