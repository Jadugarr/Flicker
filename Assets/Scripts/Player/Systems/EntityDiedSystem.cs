using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Player
{
    public class EntityDiedSystem : ReactiveSystem<GameEntity>
    {
        public EntityDiedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}