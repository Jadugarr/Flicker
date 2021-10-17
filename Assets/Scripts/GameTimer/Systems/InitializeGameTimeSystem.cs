using Entitas;
using SemoGames.Extensions;

namespace GameTimer.Systems
{
    public class InitializeGameTimeSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _gameTimeGroup;

        public InitializeGameTimeSystem()
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            _gameTimeGroup = gameContext.GetGroup(GameMatcher.GameTime);
        }

        public void Initialize()
        {
            if (_gameTimeGroup.count > 0)
            {
                foreach (GameEntity entity in _gameTimeGroup.GetEntities())
                {
                    entity.DestroyEntity();
                }
            }

            GameEntity timeEntity = Contexts.sharedInstance.game.CreateEntity();
            timeEntity.isActive = true;
            timeEntity.AddGameTime(0f);
        }
    }
}