using Entitas;
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
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            quitGameButton.onClick.RemoveListener(OnQuitGameButtonClicked);
        }

        private void OnStartGameClicked()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            IGroup<GameEntity> activeSceneEntities = gameContext.GetGroup(GameMatcher.ActiveSceneName);
            
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
            }
            
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