using System.Collections.Generic;
using Cinemachine;
using SemoGames.Collectables;
using SemoGames.Configurations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

namespace SemoGames.Utils
{
    public class InitializeEntityBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _staticLayer;
        [SerializeField] private GameObject _overlayLayer;
        [SerializeField] private AssetReferenceConfiguration _assetReferenceConfiguration;
        [SerializeField] private GameSceneConfiguration _gameSceneConfiguration;
        [SerializeField] private GameConstantsConfiguration _gameConstantsConfiguration;
        [SerializeField] private SoundReferencesConfiguration _soundReferencesConfiguration;
        [SerializeField] private LevelCoinMapConfiguration _levelCoinMapConfiguration;
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private CinemachineConfiner _confiner;
        [SerializeField] private Image _levelTransitionOverlay;
        [SerializeField] private Image _pauseOverlay;
        [SerializeField] private float _startingCameraSize;

        private async void Start()
        {
            #region Initialize entities
            GameContext gameContext = Contexts.sharedInstance.game;
            
            gameContext.ReplaceStaticLayer(_staticLayer);
            gameContext.ReplaceOverlayLayer(_overlayLayer);
            gameContext.ReplaceCameraConfiner(_confiner);
            gameContext.ReplaceVirtualCamera(_virtualCamera);
            gameContext.ReplaceCamera(_gameCamera);
            gameContext.ReplaceLevelTransitionOverlay(_levelTransitionOverlay);
            gameContext.ReplacePauseOverlay(_pauseOverlay);
            gameContext.ReplaceCameraOrthographicSize(_startingCameraSize);
            #endregion

            #region Add configurations

            GameConfigurations.AssetReferenceConfiguration = _assetReferenceConfiguration;
            GameConfigurations.GameSceneConfiguration = _gameSceneConfiguration;
            GameConfigurations.GameConstantsConfiguration = _gameConstantsConfiguration;
            GameConfigurations.SoundReferencesConfiguration = _soundReferencesConfiguration;
            GameConfigurations.LevelCoinMapConfiguration = _levelCoinMapConfiguration;

            #endregion
            
            await CreateCollectableInfos();
        }
        private async Task CreateCollectableInfos()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            List<LevelCoinData> levelCoinDatas = GameConfigurations.LevelCoinMapConfiguration.CollectableIds;

            for (var i = 0; i < levelCoinDatas.Count; i++)
            {
                LevelCoinData levelCoinData = levelCoinDatas[i];
                foreach (int collectableId in levelCoinData.CollectableIds)
                {
                    GameEntity collectableInfoEntity = gameContext.CreateEntity();
                    collectableInfoEntity.isCollectableInfo = true;
                    collectableInfoEntity.AddLevelIndex(levelCoinData.LevelIndex);
                    collectableInfoEntity.AddCollectableId(collectableId);
                }
            }
        }
    }
}