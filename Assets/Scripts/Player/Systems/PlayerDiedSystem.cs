using System.Collections.Generic;
using Entitas;

namespace SemoGames.Player
{
    public class PlayerDiedSystem : ReactiveSystem<GameEntity>
    {
        public PlayerDiedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.isDead;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity playerEntity in entities)
            {
                playerEntity.isStopSimulation = true;
                playerEntity.animation.Value.Play("DissolveAnimation");
            }
        }
    }
}