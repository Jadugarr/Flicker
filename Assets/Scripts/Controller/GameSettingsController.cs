using Entitas;
using SemoGames.Speedrun;
using Speedrun.Systems;

namespace SemoGames.Controller
{
    public class GameSettingsController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.GameSettings;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.gameSettings;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameSettingsContext gameSettingsContext = (GameSettingsContext)context;
            
            return new Systems()
                .Add(new InitializeSpeedrunControllerSystem(gameSettingsContext))
                .Add(new RemoveSpeedrunControllerSystem(gameSettingsContext));
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