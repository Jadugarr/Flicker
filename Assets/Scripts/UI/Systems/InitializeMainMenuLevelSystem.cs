using Entitas;

namespace SemoGames.UI
{
    public class InitializeMainMenuLevelSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameEntity levelEntity = Contexts.sharedInstance.game.CreateEntity();
            levelEntity.isLevel = true;
            levelEntity.AddLevelIndex(0);
        }
    }
}