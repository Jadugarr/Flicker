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
            GameEntity transitionCommandsEntity = TransitionUtils.StartTransition();
            transitionCommandsEntity.AddSceneToAdd(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
            transitionCommandsEntity.AddSceneToRemove(GameConfigurations.GameSceneConfiguration.GameSceneName);

            GameEntity dialogEntity = gameObject.GetEntityLink().entity as GameEntity;

            gameObject.Unlink();
            dialogEntity?.Destroy();
            Destroy(gameObject);
        }

        private void OnRestartClicked()
        {
            IGroup<GameEntity> levelEntityGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);
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