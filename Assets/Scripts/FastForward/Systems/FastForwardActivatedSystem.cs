using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace FastForward.Systems
{
    public class FastForwardActivatedSystem : ReactiveSystem<GameEntity>
    {
        public FastForwardActivatedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.FastForward, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Time.timeScale = 5f;
        }
    }
}