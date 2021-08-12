using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class ArrangeLevelItemsOnGridSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _levelSelectionItemGroup;
        private IGroup<GameEntity> _levelSelectionGridGroup;
        
        public ArrangeLevelItemsOnGridSystem(IContext<GameEntity> context) : base(context)
        {
            _levelSelectionItemGroup = context.GetGroup(GameMatcher.LevelSelectionItemBehaviour);
            _levelSelectionGridGroup = context.GetGroup(GameMatcher.LevelSelectionGridBehaviour);
        }

        public ArrangeLevelItemsOnGridSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionItemBehaviour,
                GroupEvent.AddedOrRemoved), new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionGridBehaviour, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            ArrangeItemsOnGrid();
        }

        public void Initialize()
        {
            ArrangeItemsOnGrid();
        }

        private void ArrangeItemsOnGrid()
        {
            List<Transform> itemList = new List<Transform>(_levelSelectionItemGroup.count);
            foreach (GameEntity levelItemEntity in _levelSelectionItemGroup.GetEntities())
            {
                if (levelItemEntity.hasView && levelItemEntity.view.Value != null)
                {
                    itemList.Add(levelItemEntity.view.Value.transform);
                }
            }
            
            foreach (GameEntity gridEntity in _levelSelectionGridGroup.GetEntities())
            {
                gridEntity.levelSelectionGridBehaviour.Value.ArrangeItemsOnGrid(itemList);
            }
        }
    }
}