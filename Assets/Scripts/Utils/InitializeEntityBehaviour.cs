using SemoGames.Configurations;
using UnityEngine;

namespace SemoGames.Utils
{
    public class InitializeEntityBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _staticLayer;
        [SerializeField] private AssetReferenceConfiguration _assetReferenceConfiguration;
        [SerializeField] private GameSceneConfiguration _gameSceneConfiguration;

        private void Start()
        {
            #region Initialize entities
            GameContext gameContext = Contexts.sharedInstance.game;
            
            gameContext.ReplaceStaticLayer(_staticLayer);
            #endregion

            #region Add configurations

            GameConfigurations.AssetReferenceConfiguration = _assetReferenceConfiguration;
            GameConfigurations.GameSceneConfiguration = _gameSceneConfiguration;

            #endregion
            
            Destroy(gameObject);
        }
    }
}