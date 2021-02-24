using Cinemachine;
using SemoGames.Configurations;
using UnityEngine;

namespace SemoGames.Utils
{
    public class InitializeEntityBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _staticLayer;
        [SerializeField] private AssetReferenceConfiguration _assetReferenceConfiguration;
        [SerializeField] private GameSceneConfiguration _gameSceneConfiguration;
        [SerializeField] private Camera _gameCamera;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private CinemachineConfiner _confiner;

        private void Start()
        {
            #region Initialize entities
            GameContext gameContext = Contexts.sharedInstance.game;
            
            gameContext.ReplaceStaticLayer(_staticLayer);
            gameContext.ReplaceCameraConfiner(_confiner);
            gameContext.ReplaceVirtualCamera(_virtualCamera);
            gameContext.ReplaceCamera(_gameCamera);
            #endregion

            #region Add configurations

            GameConfigurations.AssetReferenceConfiguration = _assetReferenceConfiguration;
            GameConfigurations.GameSceneConfiguration = _gameSceneConfiguration;

            #endregion
            
            Destroy(gameObject);
        }
    }
}