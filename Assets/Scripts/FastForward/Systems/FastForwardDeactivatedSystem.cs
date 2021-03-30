using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace FastForward.Systems
{
    public class FastForwardDeactivatedSystem : ReactiveSystem<GameEntity>
    {
        public FastForwardDeactivatedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.FastForward, GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Time.timeScale = 1f;
        }
    }
}