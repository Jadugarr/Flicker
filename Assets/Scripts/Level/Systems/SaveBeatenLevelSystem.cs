using System.Collections.Generic;
using Entitas;

namespace Level.Systems
{
    public class SaveBeatenLevelSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<SaveDataEntity> _beatenLevelGroup;
        private IGroup<GameEntity> _currentLevelGroup;
        
        public SaveBeatenLevelSystem(IContext<GameEntity> context) : base(context)
        {
            _beatenLevelGroup = Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.Level);
            _currentLevelGroup = context.GetGroup(GameMatcher.Level);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameEntity>(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.IsInGoal),
                    GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity currentLevelEntity = _currentLevelGroup.GetSingleEntity();
            foreach (SaveDataEntity savedLevelEntity in _beatenLevelGroup.GetEntities())
            {
                if (savedLevelEntity.levelIndex.Value == currentLevelEntity.levelIndex.Value)
                {
                    return;
                }
            }

            SaveDataEntity newSavedLevelEntity = Contexts.sharedInstance.saveData.CreateEntity();
            newSavedLevelEntity.isLevel = true;
            newSavedLevelEntity.AddLevelIndex(currentLevelEntity.levelIndex.Value);
        }
    }
}