using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.GameTransition;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.UI
{
    public class MainMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;

        [SerializeField] private Button quitGameButton;

        private void Start()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            quitGameButton.onClick.AddListener(OnQuitGameButtonClicked);
            startGameButton.Select();
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            quitGameButton.onClick.RemoveListener(OnQuitGameButtonClicked);
        }

        private void OnStartGameClicked()
        {
            GameEntity transitionCommandsEntity = TransitionUtils.StartTransition();
            transitionCommandsEntity.AddSceneToAdd(GameConfigurations.GameSceneConfiguration.GameSceneName);
            transitionCommandsEntity.AddSceneToRemove(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
            transitionCommandsEntity.AddLevelIndexToLoadTransition(0);
            
            GameEntity mainMenuEntity = gameObject.GetEntityLink().entity as GameEntity;
            
            gameObject.Unlink();
            mainMenuEntity?.Destroy();
            Destroy(gameObject);
        }

        private void OnQuitGameButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}