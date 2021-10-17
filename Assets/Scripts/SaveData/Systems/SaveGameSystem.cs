using System.Collections.Generic;
using System.IO;
using Entitas;
using Newtonsoft.Json;
using SemoGames.SaveData;

namespace SaveData.Systems
{
    public class SaveGameSystem : ReactiveSystem<SaveDataEntity>
    {
        private IGroup<SaveDataEntity> _collectedCollectablesGroup;
        private IGroup<SaveDataEntity> _beatenLevelsGroup;
        private IGroup<SaveDataEntity> _beatenLevelTimeGroup;

        public SaveGameSystem(IContext<SaveDataEntity> context) : base(context)
        {
            _collectedCollectablesGroup =
                context.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.CollectableId, SaveDataMatcher.Collectable));
            _beatenLevelsGroup =
                context.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.Level, SaveDataMatcher.LevelIndex));
            _beatenLevelTimeGroup =
                context.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.LevelIndex, SaveDataMatcher.GameTime));
        }

        protected override ICollector<SaveDataEntity> GetTrigger(IContext<SaveDataEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<SaveDataEntity>(SaveDataMatcher.SaveGameTrigger, GroupEvent.Added));
        }

        protected override bool Filter(SaveDataEntity entity)
        {
            return true;
        }

        protected override void Execute(List<SaveDataEntity> entities)
        {
            List<int> collectedIds = new List<int>();
            List<int> beatenLevelIndices = new List<int>();
            List<BeatenLevelTimeData> beatenLevelTimes = new List<BeatenLevelTimeData>(); 

            foreach (SaveDataEntity saveDataEntity in _collectedCollectablesGroup.GetEntities())
            {
                collectedIds.Add(saveDataEntity.collectableId.Value);
            }

            foreach (SaveDataEntity beatenLevelEntity in _beatenLevelsGroup.GetEntities())
            {
                beatenLevelIndices.Add(beatenLevelEntity.levelIndex.Value);
            }

            foreach (SaveDataEntity beatenLevelTimeEntity in _beatenLevelTimeGroup.GetEntities())
            {
                beatenLevelTimes.Add(new BeatenLevelTimeData
                {
                    LevelIndex = beatenLevelTimeEntity.levelIndex.Value,
                    FastestTime = beatenLevelTimeEntity.gameTime.Value
                });
            }

            GameSaveData saveData = new GameSaveData
            {
                CollectedIds = collectedIds.ToArray(),
                BeatenLevelIndices = beatenLevelIndices.ToArray(),
                BeatenLevelTimes = beatenLevelTimes.ToArray()
            };

            string json = JsonConvert.SerializeObject(saveData);
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/SaveData");
            File.WriteAllText($"{Directory.GetCurrentDirectory()}/SaveData/Save.json", json);
            Contexts.sharedInstance.saveData.isSaveGameTrigger = false;
        }
    }
}