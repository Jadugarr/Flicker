using System.Collections.Generic;
using Entitas;

namespace SemoGames.Obstacles.Systems
{
    public class AdjustObstacleMoveTimerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _movingObstacleGroup;
        private GameContext _gameContext;

        public AdjustObstacleMoveTimerSystem(IContext<GameEntity> context) : base(context)
        {
            _movingObstacleGroup = context.GetGroup(GameMatcher.Obstacle);
            _gameContext = (GameContext) context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.PauseTimeEnded,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity obstacleEntity in _movingObstacleGroup.GetEntities())
            {
                obstacleEntity.ReplaceTimeWhenMovementStarted(obstacleEntity.timeWhenMovementStarted.Value +
                                                              (_gameContext.pauseTimeEnded.Value -
                                                               _gameContext.pauseTimeStarted.Value));
            }
        }
    }
}