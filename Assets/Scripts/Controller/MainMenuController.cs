using Entitas;
using SemoGames.UI;

namespace SemoGames.Controller
{
    public class MainMenuController : AGameController
    {
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
            
            return new Systems()
                .Add(new InitializeMainMenuSceneSystem())
                .Add(new InstantiateMainMenuSystem(gameContext));
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