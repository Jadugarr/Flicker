using System;
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
        [SerializeField] private AssetReference finishLevelDialogReference;

        #endregion

        #region Levels

        [SerializeField] private AssetReference[] levelAssetReferences;

        #endregion

        #region Characters

        [SerializeField] private AssetReference playerAssetReference;

        #endregion
        
        #region Components

        [SerializeField] private AssetReference flickLineRendererReference;
        
        #endregion

        #region Read-only Properties

        public AssetReference MainMenuReference => mainMenuReference;

        public AssetReference[] LevelAssetReferences => levelAssetReferences;

        public AssetReference PlayerAssetReference => playerAssetReference;

        public AssetReference FlickLineRendererReference => flickLineRendererReference;

        public AssetReference FinishLevelDialogReference => finishLevelDialogReference;

        #endregion
    }
}