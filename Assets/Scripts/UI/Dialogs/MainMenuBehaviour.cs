using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
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
            GameContext gameContext = Contexts.sharedInstance.game;
            gameContext.isStartLevelTransition = true;
            GameEntity transitionCommandsEntity = gameContext.CreateEntity();
            transitionCommandsEntity.isTransitionCommands = true;
            transitionCommandsEntity.AddSceneToAdd(GameConfigurations.GameSceneConfiguration.GameSceneName);
            transitionCommandsEntity.AddSceneToRemove(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
            transitionCommandsEntity.AddLevelIndexToLoadTransition(0);
            /*IGroup<GameEntity> activeSceneEntities = gameContext.GetGroup(GameMatcher.ActiveSceneName);
            
            gameContext.CreateEntity().AddActiveSceneName(GameConfigurations.GameSceneConfiguration.GameSceneName);
            GameEntity levelEntity = gameContext.CreateEntity();
            levelEntity.isLevel = true;
            levelEntity.AddLevelIndex(0);

            foreach (GameEntity sceneEntity in activeSceneEntities)
            {
                if (sceneEntity.activeSceneName.Value == GameConfigurations.GameSceneConfiguration.MainMenuSceneName)
                {
                    sceneEntity.Destroy();
                    break;
                }
            }*/
            
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