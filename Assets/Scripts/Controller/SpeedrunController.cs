using Entitas;
using GameTimer.Systems;
using SemoGames.GameTimer;
using SemoGames.Speedrun;

namespace SemoGames.Controller
{
    public class SpeedrunController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Speedrun;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            GameContext gameContext = (GameContext)context;
            GameSettingsContext gameSettingsContext = Contexts.sharedInstance.gameSettings;
            
            return new Systems()
                .Add(new InitializeSpeedrunTimeSystem())
                .Add(new InitializeLevelSpeedrunTimerSystem())
                .Add(new MeasureSpeedrunTimeSystem())
                .Add(new StopSpeedrunTimeSystem(gameContext))
                .Add(new ResumeSpeedrunTimeSystem(gameContext))
                .Add(new ReachedGoalInSpeedrunSystem(gameContext))
                .Add(new RemoveSpeedrunTimeSystem(gameSettingsContext))
                .Add(new UpdateSpeedrunLevelTimerSystem(gameContext))
                .Add(new TeardownSpeedrunLevelTimerSystem())
                .Add(new TeardownSpeedrunTimeSystem());
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