using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Collectables.Systems
{
    public class CollectableCollectedSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<SaveDataEntity> _savedCollectables;
        private static readonly int Collected = Animator.StringToHash("Collected");

        public CollectableCollectedSystem(IContext<GameEntity> context) : base(context)
        {
            _savedCollectables =
                Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.Collectable,
                    SaveDataMatcher.CollectableId));
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
                if (!HasAlreadyCollected(gameEntity.collectableId.Value))
                {
                    SaveDataEntity savedCollectable = Contexts.sharedInstance.saveData.CreateEntity();
                    savedCollectable.isCollectable = true;
                    savedCollectable.AddCollectableId(gameEntity.collectableId.Value);
                }
                
                gameEntity.animator.Value.SetTrigger(Collected);
            }
        }

        private bool HasAlreadyCollected(int collectableId)
        {
            foreach (SaveDataEntity saveDataEntity in _savedCollectables.GetEntities())
            {
                if (saveDataEntity.collectableId.Value == collectableId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}