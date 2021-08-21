using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class MoveLevelSelectionPlayerSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private IGroup<GameEntity> _levelSelectionPlayerGroup;
        private IGroup<GameEntity> _levelSelectionItemGroup;
        private IGroup<GameEntity> _selectedLevelItemGroup;
        
        public MoveLevelSelectionPlayerSystem(IContext<GameEntity> context) : base(context)
        {
            _levelSelectionPlayerGroup = context.GetGroup(GameMatcher.LevelSelectionPlayer);
            _levelSelectionItemGroup = context.GetGroup(GameMatcher.LevelSelectionItemBehaviour);
            _selectedLevelItemGroup =
                context.GetGroup(GameMatcher.AllOf(GameMatcher.LevelSelectionItemBehaviour, GameMatcher.Selected));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Selected, GroupEvent.Added),
                new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionPlayer, GroupEvent.Added),
                new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionItemBehaviour, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _levelSelectionItemGroup.count > 0 && _levelSelectionPlayerGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            AdjustPlayerPosition();
        }

        public void Initialize()
        {
            if (Filter(null))
            {
                AdjustPlayerPosition();
            }
        }

        private void AdjustPlayerPosition()
        {
            Vector3 firstLevelItemPosition = _levelSelectionItemGroup.GetEntities()[0].position.Value;
            GameEntity playerEntity = _levelSelectionPlayerGroup.GetSingleEntity();
            Vector3 newPosition = new Vector3(firstLevelItemPosition.x,
                firstLevelItemPosition.y + 1f, firstLevelItemPosition.z);
            
            foreach (GameEntity levelItemEntity in _selectedLevelItemGroup.GetEntities())
            {
                newPosition.x = levelItemEntity.position.Value.x;
                newPosition.y = levelItemEntity.position.Value.y + 1;
                newPosition.z = levelItemEntity.position.Value.z;
            }
            
            playerEntity.ReplacePosition(newPosition);
        }
    }
}