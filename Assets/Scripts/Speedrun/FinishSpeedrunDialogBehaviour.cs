using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.Extensions;
using SemoGames.GameTransition;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.Speedrun
{
    public class FinishSpeedrunDialogBehaviour : MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button quitGameButton;

        private void Awake()
        {
            restartLevelButton.onClick.AddListener(OnRestartClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
            quitGameButton.onClick.AddListener(OnQuitGameClicked);
        }

        private void Start()
        {
            restartLevelButton.Select();
        }

        private void OnDestroy()
        {
            restartLevelButton.onClick.RemoveListener(OnRestartClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuClicked);
            quitGameButton.onClick.RemoveListener(OnQuitGameClicked);
        }

        private void OnQuitGameClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnMainMenuClicked()
        {
            Contexts.sharedInstance.saveData.isSaveGameTrigger = true;
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToTeardownTransition,
                    TransitionComponent = new ControllerToTeardownTransitionComponent
                        {Value = GameControllerType.Game}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToRemove,
                    TransitionComponent = new SceneToRemoveComponent
                        {Value = GameConfigurations.GameSceneConfiguration.GameSceneName}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToAdd,
                    TransitionComponent = new SceneToAddComponent
                        {Value = GameConfigurations.GameSceneConfiguration.MainMenuSceneName}
                }
            );

            GameEntity dialogEntity = gameObject.GetEntityLink().entity as GameEntity;

            gameObject.Unlink();
            dialogEntity?.Destroy();
            Destroy(gameObject);
        }

        private void OnRestartClicked()
        {
            Contexts.sharedInstance.saveData.DestroyAllEntities();
            
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToRestartTransition,
                    TransitionComponent = new ControllerToRestartTransitionComponent {Value = GameControllerType.Game}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.LevelIndexToLoadTransition,
                    TransitionComponent = new LevelIndexToLoadTransitionComponent
                        {Value = 1}
                }
            );

            ((GameEntity) gameObject.GetEntityLink().entity).DestroyEntity();
        }
    }
}