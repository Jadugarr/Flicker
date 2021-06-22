using System.Collections.Generic;
using Entitas;

namespace SemoGames.Player
{
    public class HandleTrailRendererEmissionSystem : ReactiveSystem<GameEntity>
    {
        public HandleTrailRendererEmissionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Velocity, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasVelocity && entity.hasTrailRenderer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                gameEntity.trailRenderer.Value.emitting = gameEntity.velocity.Value.magnitude >= 2f;
            }
        }
    }
}