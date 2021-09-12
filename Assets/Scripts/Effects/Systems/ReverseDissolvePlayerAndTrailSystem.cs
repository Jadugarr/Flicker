using System.Collections.Generic;
using DG.Tweening;
using Entitas;

namespace SemoGames.Effects
{
    public class ReverseDissolvePlayerAndTrailSystem : ReactiveSystem<GameEntity>
    {
        public ReverseDissolvePlayerAndTrailSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Dissolve, GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSpriteRenderer && entity.hasTrailRenderer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                if (gameEntity.hasSpriteRenderer && gameEntity.spriteRenderer != null)
                {
                    gameEntity.spriteRenderer.Value.material.DOFloat(1f, "_DissolveStep", 0.5f);
                }

                if (gameEntity.hasTrailRenderer && gameEntity.trailRenderer != null)
                {
                    gameEntity.trailRenderer.Value.material.DOFloat(1f, "_DissolveStep", 0.5f);
                }
            }
        }
    }
}