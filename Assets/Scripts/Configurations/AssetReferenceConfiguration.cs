﻿using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "AssetReferenceConfiguration", menuName = "Configurations/AssetReferenceConfiguration")]
    [Serializable]
    public class AssetReferenceConfiguration : ScriptableObject
    {
        #region Dialogs

        [SerializeField] private AssetReference mainMenuReference;

        #endregion

        #region Read-only Properties

        public AssetReference MainMenuReference => mainMenuReference;

        #endregion
    }
}