using Entitas;
using SemoGames.GameCamera;
using SemoGames.LevelSelection;

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
                .Add(new InitializeLevelSelectionItemsSystem())
                .Add(new ArrangeLevelItemsOnGridSystem(gameContext))
                .Add(new LevelItemSelectionStatusChangedSystem(gameContext))
                .Add(new LevelSelectedSystem(gameContext))
                .Add(new TeardownLevelGridsSystem())
                .Add(new TeardownLevelSelectionItemsSystem())
                .Add(new TeardownLevelItemConnectorsSystem())
                .Add(new TeardownLevelSelectedSystem());
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