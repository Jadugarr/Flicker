using Entitas;
using Level.Systems;
using SemoGames.Controller;

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
            return new Systems()
                .Add(new InitializeLevelSystem());
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