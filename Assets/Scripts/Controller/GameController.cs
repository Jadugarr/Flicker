using Entitas;
using Level.Systems;
using SemoGames.Common;
using SemoGames.Flick;
using SemoGames.Flipper;
using SemoGames.GameCamera;
using SemoGames.GameInput;
using SemoGames.GameState;
using SemoGames.Obstacles.Systems;
using SemoGames.Pause;
using SemoGames.Player;
using SemoGames.UI;

namespace SemoGames.Controller
{
    public class GameController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Game;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            InputContext inputContext = Contexts.sharedInstance.input;
            
            return new Systems()
                .Add(new InitializePauseSystem())
                .Add(new InitializeLevelSystem())
                .Add(new InitializePlayerSystem())
                .Add(new InitializeGameStateSystem())
                .Add(new CheckGameStateSystem(gameContext, inputContext.playerInput.Value))
                .Add(new SwitchToPlayerInputMap(gameContext))
                .Add(new SwitchToUiInputMapSystem(gameContext))
                .Add(new SwitchToEnvironmentInputMapSystem(gameContext))
                .Add(new SpawnPlayerSystem(gameContext))
                .Add(new SetCameraConfinerSystem(gameContext))
                .Add(new SetCameraFollowPlayerSystem(gameContext))
                .Add(new CreateFlickLineSystem(gameContext))
                .Add(new DrawFlickLineSystem(gameContext))
                .Add(new CalculateCurrentPowerSystem(gameContext))
                .Add(new CalculateFlickAngleSystem(gameContext))
                .Add(new DestroyFlickLineSystem(gameContext))
                .Add(new ShowFinishLevelDialogOnReachedGoalSystem(gameContext))
                .Add(new TeardownPlayerSystem())
                .Add(new LoadLevelSystem(gameContext))
                .Add(new TeardownLevelSystem())
                .Add(new TeardownPlayerSpawnSystem())
                .Add(new InitializeFlipperSystem(gameContext))
                .Add(new TeardownFlipperSystem())
                .Add(new InteractWithFlipperSystem(inputContext))
                .Add(new StopInteractingWithFlipperSystem(inputContext))
                .Add(new PlayerDiedSystem(gameContext))
                .Add(new EntityDiedSystem(gameContext))
                .Add(new PauseSystem(gameContext))
                .Add(new UnpauseSystem(gameContext))
                .Add(new TeardownObstaclesSystem(gameContext));
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
                .Add(new CheckGroundStateSystem(gameContext))
                .Add(new ApplyPowerToCharacterSystem(gameContext))
                .Add(new DetectStopMovingSystem(gameContext))
                .Add(new KillVelocityOfPlayerWhenInGoal(gameContext))
                .Add(new MoveObstaclesSystem(gameContext))
                .Add(new RenderVelocitySystem(gameContext))
                .Add(new RenderPositionSystem(gameContext))
                .Add(new CleanupInputActionsSystem());
        }
    }
}