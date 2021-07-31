using System.Collections.Generic;
using Entitas;

namespace SemoGames.Effects
{
    public class AnimateImpactStarSystem : ReactiveSystem<GameEntity>
    {
        public AnimateImpactStarSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.AllOf(GameMatcher.ImpactStar, GameMatcher.Animation), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity starEntity in entities)
            {
                starEntity.animation.Value.Play();
            }
        }
    }
}