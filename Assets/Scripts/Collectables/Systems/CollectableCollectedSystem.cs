using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Collectables.Systems
{
    public class CollectableCollectedSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;
        private static readonly int Collected = Animator.StringToHash("Collected");

        public CollectableCollectedSystem(IContext<GameEntity> context) : base(context)
        {
            _context = (GameContext) context;
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
                SaveDataEntity savedCollectable = Contexts.sharedInstance.saveData.CreateEntity();
                savedCollectable.isCollectable = true;
                savedCollectable.AddCollectableId(gameEntity.collectableId.Value);
                
                
                gameEntity.animator.Value.SetTrigger(Collected);
            }
        }
    }
}