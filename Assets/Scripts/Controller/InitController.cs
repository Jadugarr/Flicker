using Controller;
using Entitas;
using SaveData.Systems;
using SemoGames.Common;
using SemoGames.Configurations;
using SemoGames.GameCamera;
using SemoGames.GameScene;
using SemoGames.GameTransition;

namespace SemoGames.Controller
{
    public class InitController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Init;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override void AfterAwake()
        {
            GetContext().OnEntityCreated += OnEntityCreated;
        }

        protected override void AfterStart()
        {
            Contexts.sharedInstance.game.CreateEntity().AddActiveSceneName(GameConfigurations.GameSceneConfiguration.MainMenuSceneName);
            Contexts.sharedInstance.saveData.isLoadGameTrigger = true;
        }

        private void OnEntityCreated(IContext context, IEntity entity)
        {
            (entity as GameEntity)?.AddId(entity.creationIndex);
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            SaveDataContext saveDataContext = Contexts.sharedInstance.saveData;

            return new Systems()
                .Add(new InitCurrentSceneSystem())
                .Add(new TeardownControllerSystem(gameContext))
                .Add(new LoadNewSceneSystem(gameContext))
                .Add(new UnloadSceneSystem(gameContext))
                .Add(new RestartControllerSystem(gameContext))
                .Add(new SetCameraConfinerSystem(gameContext))
                .Add(new SetCameraSizeSystem(gameContext))
                .Add(new StartLevelTransitionSystem(gameContext))
                .Add(new EndLevelTransitionSystem(gameContext))
                .Add(new ProcessSceneToAddTransitionSystem(gameContext))
                .Add(new ProcessSceneToRemoveTransitionSystem(gameContext))
                .Add(new ProcessControllerToRestartTransitionSystem(gameContext))
                .Add(new ProcessControllerToTeardownTransitionSystem(gameContext))
                .Add(new ProcessLevelIndexToLoadTransitionSystem(gameContext))
                .Add(new CheckIfTransitionIsFinishedSystem(gameContext))
                .Add(new GarbageCollectionSystem(gameContext))
                .Add(new LoadGameSystem(saveDataContext));
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            return new Systems();
        }
    }
}