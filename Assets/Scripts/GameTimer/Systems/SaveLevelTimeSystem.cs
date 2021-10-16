using System.Collections.Generic;
using Entitas;

namespace GameTimer.Systems
{
    public class SaveLevelTimeSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _gameTimeGroup;
        private readonly IGroup<GameEntity> _levelGroup;

        private readonly IGroup<SaveDataEntity> _savedGameTimeGroup;

        public SaveLevelTimeSystem(IContext<GameEntity> context) : base(context)
        {
            _gameTimeGroup = context.GetGroup(GameMatcher.GameTime);
            _levelGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.LevelIndex, GameMatcher.Level));
            _savedGameTimeGroup = Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.GameTime, SaveDataMatcher.LevelIndex));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.IsInGoal, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity currentLevel = _levelGroup.GetSingleEntity();
            GameEntity currentTime = _gameTimeGroup.GetSingleEntity();

            if (currentLevel == null || currentTime == null)
            {
                return;
            }

            if (TryGetBeatenLevelTime(currentLevel.levelIndex.Value, out SaveDataEntity savedBeatenTime))
            {
                if (savedBeatenTime.gameTime.Value > currentTime.gameTime.Value)
                {
                    savedBeatenTime.ReplaceGameTime(currentTime.gameTime.Value);
                }
            }
            else
            {
                SaveDataEntity savedTime = Contexts.sharedInstance.saveData.CreateEntity();
                savedTime.AddGameTime(currentTime.gameTime.Value);
                savedTime.AddLevelIndex(currentLevel.levelIndex.Value);
            }
        }

        private bool TryGetBeatenLevelTime(int levelIndex, out SaveDataEntity saveDataEntity)
        {
            foreach (SaveDataEntity savedBeatenTime in _savedGameTimeGroup.GetEntities())
            {
                if (savedBeatenTime.levelIndex.Value ==levelIndex)
                {
                    saveDataEntity = savedBeatenTime;
                    return true;
                }
            }

            saveDataEntity = null;
            return false;
        }
    }
}