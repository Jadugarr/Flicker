using Entitas;

namespace SemoGames.UI
{
    public class InitializeMainMenuSceneSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Contexts.sharedInstance.game.CreateEntity().isMainMenu = true;
        }
    }
}