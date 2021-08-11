using Entitas;
using SemoGames.GameCamera;

namespace SemoGames.Controller
{
    public class LevelSelectionController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.LevelSelection;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext) context;
            
            return new Systems()
                .Add(new SetCameraConfinerSystem(gameContext));
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