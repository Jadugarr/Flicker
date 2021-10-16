using System.Collections.Generic;
using Entitas;

namespace GameTimer.Systems
{
    public class StopGameTimeSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _gameTimeGroup;

        public StopGameTimeSystem(IContext<GameEntity> context) : base(context)
        {
            _gameTimeGroup = context.GetGroup(GameMatcher.GameTime);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AnyOf(GameMatcher.Pause, GameMatcher.IsInGoal), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                if (gameEntity.isPause || gameEntity.isIsInGoal)
                {
                    _gameTimeGroup.GetSingleEntity().isActive = false;
                }
            }
        }
    }
}