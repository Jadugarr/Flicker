using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Collectables.Systems
{
    public class CollectableCollectedSystem : ReactiveSystem<GameEntity>
    {
        private static readonly int Collected = Animator.StringToHash("Collected");

        public CollectableCollectedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Collected, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                gameEntity.animator.Value.SetTrigger(Collected);
                gameEntity.isPlaySound = true;
            }
        }
    }
}