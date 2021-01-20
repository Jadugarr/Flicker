using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SemoGames.Configurations
{
    [CreateAssetMenu(fileName = "GameSceneConfiguration", menuName = "Configurations/GameSceneConfiguration")]
    [Serializable]
    public class GameSceneConfiguration : ScriptableObject
    {
        #region SceneNames

        [SerializeField] private string initSceneName;
        [SerializeField] private string mainMenuSceneName;
        [SerializeField] private string gameSceneName;

        #endregion

        #region Read-only Properties

        public string InitSceneName => initSceneName;

        public string MainMenuSceneName => mainMenuSceneName;

        public string GameSceneName => gameSceneName;

        #endregion
    }
}