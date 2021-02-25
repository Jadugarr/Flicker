using Entitas;
using SemoGames.Configurations;

namespace SemoGames.Player
{
    public class InitializePlayerSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameEntity playerEntity = Contexts.sharedInstance.game.CreateEntity(); 
            playerEntity.isPlayer = true;
            playerEntity.AddMaxFlickPower(GameConfigurations.GameConstantsConfiguration.MaxFlickPower);
            playerEntity.AddCurrentFlickPower(0f);
        }
    }
}