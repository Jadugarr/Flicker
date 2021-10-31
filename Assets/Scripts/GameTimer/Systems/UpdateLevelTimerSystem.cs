using System.Collections.Generic;
using Entitas;

namespace GameTimer.Systems
{
    public class UpdateLevelTimerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _gameTimeGroup;
        private IGroup<GameEntity> _levelTimerGroup;

        public UpdateLevelTimerSystem(IContext<GameEntity> context) : base(context)
        {
            _gameTimeGroup = context.GetGroup(GameMatcher.GameTime);
            _levelTimerGroup = context.GetGroup(GameMatcher.LevelTimerBehaviour);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.GameTime, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _gameTimeGroup.count == 1 && _levelTimerGroup.count == 1;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _levelTimerGroup.GetSingleEntity().levelTimerBehaviour.Value
                .SetTimerValue(_gameTimeGroup.GetSingleEntity().gameTime.Value);
        }
    }
}