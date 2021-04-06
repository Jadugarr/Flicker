using Cinemachine;
using SemoGames.Configurations;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.Utils
{
    public class InitializeEntityBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _staticLayer;
        [SerializeField] private GameObject _overlayLayer;
        [SerializeField] private AssetReferenceConfiguration _assetReferenceConfiguration;
        [SerializeField] private GameSceneConfiguration _gameSceneConfiguration;
        [SerializeField] private GameConstantsConfiguration _gameConstantsConfiguration;
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private CinemachineConfiner _confiner;
        [SerializeField] private Image _levelTransitionOverlay;
        [SerializeField] private Image _pauseOverlay;

        private void Start()
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
            gameContext.ReplaceCollectedAmount(0);
            #endregion

            #region Add configurations

            GameConfigurations.AssetReferenceConfiguration = _assetReferenceConfiguration;
            GameConfigurations.GameSceneConfiguration = _gameSceneConfiguration;
            GameConfigurations.GameConstantsConfiguration = _gameConstantsConfiguration;

            #endregion
            
            Destroy(gameObject);
        }
    }
}