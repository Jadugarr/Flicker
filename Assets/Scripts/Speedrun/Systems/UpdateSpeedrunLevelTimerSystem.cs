using System.Collections.Generic;
using Entitas;

namespace GameTimer.Systems
{
    public class UpdateSpeedrunLevelTimerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _speedrunTimeGroup;
        private IGroup<GameEntity> _speedrunLevelTimerGroup;

        public UpdateSpeedrunLevelTimerSystem(IContext<GameEntity> context) : base(context)
        {
            _speedrunTimeGroup = context.GetGroup(GameMatcher.SpeedrunTime);
            _speedrunLevelTimerGroup =
                context.GetGroup(GameMatcher.AllOf(GameMatcher.SpeedrunLevelTimer, GameMatcher.LevelTimerBehaviour));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.SpeedrunTime, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _speedrunTimeGroup.count == 1 && _speedrunLevelTimerGroup.count == 1;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _speedrunLevelTimerGroup.GetSingleEntity().levelTimerBehaviour.Value
                .SetTimerValue(_speedrunTimeGroup.GetSingleEntity().speedrunTime.Value);
        }
    }
}