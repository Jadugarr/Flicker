using System.Collections.Generic;
using Entitas;

namespace Bumpers.Systems
{
    public class ProcessBumperCollisionSystem : ReactiveSystem<GameEntity>
    {
        public ProcessBumperCollisionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.BumperCollisionVelocity,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity collidedEntity in entities)
            {
                collidedEntity.ReplaceVelocity(collidedEntity.bumperCollisionVelocity.Value);
                collidedEntity.RemoveBumperCollisionVelocity();
            }
        }
    }
}