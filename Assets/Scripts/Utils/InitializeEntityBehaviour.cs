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

            #endregion
            
            await CreateCollectableInfos();
            
            //Destroy(gameObject);
        }
        private async Task CreateCollectableInfos()
        {
            AssetReference[] levelReferences = GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences;

            for (var i = 0; i < levelReferences.Length; i++)
            {
                AssetReference levelReference = levelReferences[i];
                await CreateCollectableInfo(levelReference, i);
            }
        }

        private async Task CreateCollectableInfo(AssetReference levelReference, int levelIndex)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            Addressables.LoadAssetAsync<GameObject>(levelReference).Completed += handle =>
            {
                CollectableSpawnBehaviour[] spawnBehaviour =
                    handle.Result.GetComponentsInChildren<CollectableSpawnBehaviour>();

                foreach (CollectableSpawnBehaviour collectableSpawnBehaviour in spawnBehaviour)
                {
                    GameEntity collectableInfoEntity = gameContext.CreateEntity();
                    collectableInfoEntity.isCollectableInfo = true;
                    collectableInfoEntity.AddLevelIndex(levelIndex);
                    collectableInfoEntity.AddCollectableId(collectableSpawnBehaviour.CollectableId);
                }

                Addressables.Release(handle);
            };
        }
    }
}