using Entitas;
using Level.Systems;
using SemoGames.Common;
using SemoGames.Flick;
using SemoGames.GameCamera;
using SemoGames.GameInput;
using SemoGames.Player;

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
            
            return new Systems()
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
                .Add(new ActivateInteractInputMapSystem(gameContext))
                .Add(new ActivatePlayerInputMapSystem(gameContext))
                .Add(new ActivateUiInputMapOnReachedGoalSystem(gameContext));
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
                .Add(new ApplyPowerToCharacterSystem(gameContext))
                .Add(new DetectStopMovingSystem(gameContext))
                .Add(new KillVelocityOfPlayerWhenInGoal(gameContext))
                .Add(new RenderVelocitySystem(gameContext))
                .Add(new RenderPositionSystem(gameContext))
                .Add(new CleanupInputActionsSystem());
        }
    }
}