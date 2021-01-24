using System.Collections.Generic;
using Entitas;

namespace SemoGames.Common
{
    public class RenderVelocitySystem : ReactiveSystem<GameEntity>
    {
        public RenderVelocitySystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                Matcher<GameEntity>.AllOf(GameMatcher.Velocity, GameMatcher.View), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasRigidbody && entity.rigidbody.Value != null;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                e.rigidbody.Value.velocity = e.velocity.Value;
            }
        }
    }
}