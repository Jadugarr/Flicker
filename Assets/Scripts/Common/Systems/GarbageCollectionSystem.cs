using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Common
{
    public class GarbageCollectionSystem : ReactiveSystem<GameEntity>
    {
        public GarbageCollectionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Garbage, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity collectedEntity in entities)
            {
                collectedEntity.DestroyEntity();
            }
        }
    }
}