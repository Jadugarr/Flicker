using Bumpers.Systems;
using Entitas;
using Level.Systems;
using SaveData.Systems;
using SemoGames.Common;
using SemoGames.Effects;
using SemoGames.Flick;
using SemoGames.GameCamera;
using SemoGames.GameInput;
using SemoGames.GameTransition;
using SemoGames.Obstacles.Systems;
using SemoGames.Pause;
using SemoGames.Player;
using SemoGames.SaveData;
using SemoGames.UI;

namespace SemoGames.Controller
{
    public class MainMenuController : AGameController
    {
        protected override void AfterStart()
        {
            GameEntity levelEntity = Contexts.sharedInstance.game.CreateEntity();
            levelEntity.isLevel = true;
            levelEntity.AddLevelIndex(0);
            
            Contexts.sharedInstance.saveData.isLoadGameTrigger = true;
        }

        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.MainMenu;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            SaveDataContext saveDataContext = Contexts.sharedInstance.saveData;
            
            return new Systems()
                .Add(new InitializeMainMenuSceneSystem())
                .Add(new InstantiateMainMenuSystem(gameContext))
                .Add(new InitializeLevelSystem())
                .Add(new InitializePlayerSystem())
                .Add(new SpawnPlayerSystem(gameContext))
                .Add(new SetCameraConfinerSystem(gameContext))
                .Add(new SetCameraFollowPlayerSystem(gameContext))
                .Add(new CreateFlickLineSystem(gameContext))
                .Add(new DrawFlickLineSystem(gameContext))
                .Add(new CalculateCurrentPowerSystem(gameContext))
                .Add(new CalculateFlickAngleSystem(gameContext))
                .Add(new DestroyFlickLineSystem(gameContext))
                .Add(new TeardownPlayerSystem())
                .Add(new LoadLevelSystem(gameContext))
                .Add(new TeardownPlayerSpawnSystem())
                .Add(new PauseSystem(gameContext))
                .Add(new UnpauseSystem(gameContext))
                .Add(new HandleTrailRendererEmissionSystem(gameContext))
                .Add(new LoadGameSystem(saveDataContext))
                .Add(new TeardownObstaclesSystem(gameContext))
                .Add(new TeardownBumpersSystem())
                .Add(new TeardownImpactStarsSystem())
                .Add(new TeardownFlickLineSystem())
                .Add(new TeardownLevelSystem());
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            return new Systems()
                .Add(new SyncVelocitySystem(gameContext))
                .Add(new SyncPositionAndViewSystem(gameContext))
                .Add(new ProcessBumperCollisionSystem(gameContext))
                .Add(new CheckGroundStateSystem(gameContext))
                .Add(new ApplyPowerToCharacterSystem(gameContext))
                .Add(new DetectStopMovingSystem(gameContext))
                .Add(new RenderVelocitySystem(gameContext))
                .Add(new RenderPositionSystem(gameContext))
                .Add(new CleanupInputActionsSystem());
        }
    }
}