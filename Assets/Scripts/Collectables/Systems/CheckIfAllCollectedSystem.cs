using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;

namespace SemoGames.Collectables.Systems
{
    public class CheckIfAllCollectedSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly IGroup<GameEntity> _levelGroup;
        private readonly IGroup<SaveDataEntity> _collectedCoinsGroup;

        public CheckIfAllCollectedSystem(IContext<GameEntity> context) : base(context)
        {
            _levelGroup = context.GetGroup(GameMatcher.Level);
            _collectedCoinsGroup =
                Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.Collectable,
                    SaveDataMatcher.CollectableId));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameEntity>(GameMatcher.AnyOf(GameMatcher.Collected, GameMatcher.Level),
                    GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        public void Initialize()
        {
            Contexts.sharedInstance.game.isAllCollectedInLevel = HasCollectedAllCoins();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.game.isAllCollectedInLevel = HasCollectedAllCoins();
        }

        private bool HasCollectedAllCoins()
        {
            if (_levelGroup.count == 0)
            {
                return false;
            }
            
            GameEntity currentLevelEntity = _levelGroup.GetSingleEntity();

            if (GameConfigurations.LevelCoinMapConfiguration.TryGetCoinDataByLevelIndex(
                currentLevelEntity.levelIndex.Value, out LevelCoinData levelCoinData))
            {
                List<int> collectedCoinIds = new List<int>();
                foreach (SaveDataEntity savedCollectedCoins in _collectedCoinsGroup.GetEntities())
                {
                    collectedCoinIds.Add(savedCollectedCoins.collectableId.Value);
                }

                foreach (int collectableId in levelCoinData.CollectableIds)
                {
                    if (!collectedCoinIds.Contains(collectableId))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}