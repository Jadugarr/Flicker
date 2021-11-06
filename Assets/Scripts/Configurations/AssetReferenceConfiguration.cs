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
        [SerializeField] private AssetReference finishSpeedrunDialogReference;

        #endregion

        #region Levels

        [SerializeField] private AssetReference[] levelAssetReferences;

        #endregion

        #region Characters

        [SerializeField] private AssetReference playerAssetReference;

        #endregion
        
        #region Components

        [SerializeField] private AssetReference flickLineRendererReference;
        [SerializeField] private AssetReference impactStarReference;
        [SerializeField] private AssetReference collectableReference;
        [SerializeField] private AssetReference levelSelectionItemReference;
        [SerializeField] private AssetReference levelSelectionConnectorReference;
        [SerializeField] private AssetReference levelTimerComponentReference;
        
        #endregion

        #region Controllers

        [SerializeField] private AssetReference _speedrunControllerReference;

        #endregion
        
        #region Read-only Properties

        public AssetReference MainMenuReference => mainMenuReference;

        public AssetReference[] LevelAssetReferences => levelAssetReferences;

        public AssetReference PlayerAssetReference => playerAssetReference;

        public AssetReference FlickLineRendererReference => flickLineRendererReference;

        public AssetReference FinishLevelDialogReference => finishLevelDialogReference;

        public AssetReference ImpactStarReference => impactStarReference;

        public AssetReference CollectableReference => collectableReference;

        public AssetReference LevelSelectionItemReference => levelSelectionItemReference;

        public AssetReference LevelSelectionConnectorReference => levelSelectionConnectorReference;

        public AssetReference LevelTimerComponentReference => levelTimerComponentReference;

        public AssetReference FinishSpeedrunDialogReference => finishSpeedrunDialogReference;

        public AssetReference SpeedrunControllerReference => _speedrunControllerReference;

        #endregion
    }
}