using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.Extensions;
using SemoGames.GameTransition;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.UI
{
    public class FinishLevelDialogBehaviour : MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button quitGameButton;

        private void Awake()
        {
            restartLevelButton.onClick.AddListener(OnRestartClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            quitGameButton.onClick.AddListener(OnQuitGameClicked);
        }

        private void Start()
        {
            nextLevelButton.Select();
        }

        private void OnDestroy()
        {
            restartLevelButton.onClick.RemoveListener(OnRestartClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuClicked);
            nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);
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

        private void OnNextLevelClicked()
        {
            
            IGroup<GameEntity> levelEntityGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);
            int levelCount = GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences.Length;
            int currentLevelIndex = levelEntityGroup.GetSingleEntity().levelIndex.Value;
            Contexts.sharedInstance.saveData.isSaveGameTrigger = true;
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
                        {Value = currentLevelIndex < levelCount - 1 ? currentLevelIndex+1 : 1}
                }
            );
            ((GameEntity) gameObject.GetEntityLink().entity).DestroyEntity();
        }

        private void OnMainMenuClicked()
        {
            Contexts.sharedInstance.saveData.isSaveGameTrigger = true;
            Contexts.sharedInstance.gameSettings.isSpeedrun = false;
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
            IGroup<GameEntity> levelEntityGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);
            Contexts.sharedInstance.saveData.isSaveGameTrigger = true;
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
                        {Value = levelEntityGroup.GetSingleEntity().levelIndex.Value}
                }
            );

            ((GameEntity) gameObject.GetEntityLink().entity).DestroyEntity();
        }
    }
}