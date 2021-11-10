using System.Threading;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.Extensions;
using SemoGames.GameTransition;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.UI
{
    public class MainMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;

        [SerializeField] private Button quitGameButton;

        [SerializeField] private Button speedrunModeButton;

        private void Start()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            quitGameButton.onClick.AddListener(OnQuitGameButtonClicked);
            speedrunModeButton.onClick.AddListener(OnSpeedrunModeButtonClicked);
            startGameButton.Select();
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            quitGameButton.onClick.RemoveListener(OnQuitGameButtonClicked);
            speedrunModeButton.onClick.RemoveListener(OnSpeedrunModeButtonClicked);
        }

        private void OnStartGameClicked()
        {
            Contexts.sharedInstance.gameSettings.isSpeedrun = false;
            
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToTeardownTransition,
                    TransitionComponent = new ControllerToTeardownTransitionComponent
                        {Value = GameControllerType.MainMenu}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToRemove,
                    TransitionComponent = new SceneToRemoveComponent
                        {Value = GameConfigurations.GameSceneConfiguration.MainMenuSceneName}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToAdd,
                    TransitionComponent = new SceneToAddComponent
                        {Value = GameConfigurations.GameSceneConfiguration.LevelSelectionSceneName}
                }
            );

            GameEntity mainMenuEntity = gameObject.GetEntityLink().entity as GameEntity;
            mainMenuEntity?.DestroyEntity();
        }

        private void OnSpeedrunModeButtonClicked()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            gameContext.CreateEntity().AddTeardownController(GameControllerType.MainMenu);
            GameEntity dialogEntity = gameContext.CreateEntity();
            AssetLoaderUtils.InstantiateAssetAsyncTask(
                GameConfigurations.AssetReferenceConfiguration.ExplainSpeedrunDialogReference, dialogEntity,
                gameContext.staticLayer.Value.transform);
            GameEntity mainMenuEntity = gameObject.GetEntityLink().entity as GameEntity;
            mainMenuEntity?.DestroyEntity();
            //gameContext.CreateEntity().AddLeve

            /*Contexts.sharedInstance.gameSettings.isSpeedrun = true;
            Contexts.sharedInstance.saveData.DestroyAllEntities();

            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToTeardownTransition,
                    TransitionComponent = new ControllerToTeardownTransitionComponent
                        {Value = GameControllerType.MainMenu}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToRemove,
                    TransitionComponent = new SceneToRemoveComponent
                        {Value = GameConfigurations.GameSceneConfiguration.MainMenuSceneName}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToAdd,
                    TransitionComponent = new SceneToAddComponent
                        {Value = GameConfigurations.GameSceneConfiguration.GameSceneName,}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.LevelIndexToLoadTransition,
                    TransitionComponent = new LevelIndexToLoadTransitionComponent {Value = 1}
                }
            );
            
            GameEntity mainMenuEntity = gameObject.GetEntityLink().entity as GameEntity;
            mainMenuEntity?.DestroyEntity();*/
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