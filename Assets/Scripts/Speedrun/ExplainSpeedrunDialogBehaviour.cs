using System;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.Extensions;
using SemoGames.GameTransition;
using SemoGames.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.Speedrun
{
    public class ExplainSpeedrunDialogBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        [SerializeField] private Button _mainMenuButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            gameContext.CreateEntity().AddRestartController(GameControllerType.MainMenu);
            /*GameEntity dialogEntity = gameContext.CreateEntity();
            AssetLoaderUtils.InstantiateAssetAsyncTask(
                GameConfigurations.AssetReferenceConfiguration.ExplainSpeedrunDialogReference, dialogEntity,
                gameContext.staticLayer.Value.transform);*/
            GameEntity mainMenuEntity = gameObject.GetEntityLink().entity as GameEntity;
            mainMenuEntity?.DestroyEntity();
        }

        private void OnStartGameButtonClicked()
        {
            Contexts.sharedInstance.gameSettings.isSpeedrun = true;
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
            
            gameObject.Unlink();
            mainMenuEntity?.Destroy();
            Destroy(gameObject);
        }
    }
}