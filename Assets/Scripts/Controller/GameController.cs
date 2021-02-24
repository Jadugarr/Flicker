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
                .Add(new DestroyFlickLineSystem(gameContext));
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
                .Add(new FlickSystem(gameContext))
                .Add(new RenderVelocitySystem(gameContext))
                .Add(new RenderPositionSystem(gameContext))
                .Add(new CleanupInputActionsSystem());
        }
    }
}