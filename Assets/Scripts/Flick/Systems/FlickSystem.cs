using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Flick
{
    public class FlickSystem : ReactiveSystem<GameEntity>
    {
        public FlickSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public FlickSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Flick, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFlick && entity.hasVelocity;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                gameEntity.ReplaceVelocity(new Vector3(0f, 10f, 0f));
                gameEntity.isFlick = false;
            }
        }
    }
}