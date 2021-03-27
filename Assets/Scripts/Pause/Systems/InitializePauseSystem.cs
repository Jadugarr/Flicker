using Entitas;

namespace SemoGames.Pause
{
    public class InitializePauseSystem : IInitializeSystem
    {
        public void Initialize()
        {
            GameContext gameContext = Contexts.sharedInstance.game;

            if (gameContext.isPause)
                gameContext.isPause = false;
        }
    }
}