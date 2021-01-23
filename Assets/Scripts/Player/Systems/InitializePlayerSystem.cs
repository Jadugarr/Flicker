using Entitas;

namespace SemoGames.Player
{
    public class InitializePlayerSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Contexts.sharedInstance.game.CreateEntity().isPlayer = true;
        }
    }
}