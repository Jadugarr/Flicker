using Entitas;

namespace SemoGames.GameState
{
    public class InitializeGameStateSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Contexts.sharedInstance.game.ReplaceGameState(GameStates.Undefined);
        }
    }
}