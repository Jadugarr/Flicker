using System.Collections.Generic;
using Entitas;

namespace GameTimer.Systems
{
    public class ResumeSpeedrunTimeSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _speedrunTimeGroup;

        public ResumeSpeedrunTimeSystem(IContext<GameEntity> context) : base(context)
        {
            _speedrunTimeGroup = context.GetGroup(GameMatcher.SpeedrunTime);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AnyOf(GameMatcher.Pause, GameMatcher.IsInGoal), GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _speedrunTimeGroup.count == 1;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                if (!gameEntity.isPause && !gameEntity.isIsInGoal)
                {
                    _speedrunTimeGroup.GetSingleEntity().isActive = true;
                }
            }
        }
    }
}