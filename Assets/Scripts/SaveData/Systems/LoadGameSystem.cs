using System.Collections.Generic;
using System.IO;
using Entitas;
using Newtonsoft.Json;
using SemoGames.SaveData;

namespace SaveData.Systems
{
    public class LoadGameSystem : ReactiveSystem<SaveDataEntity>
    {
        public LoadGameSystem(IContext<SaveDataEntity> context) : base(context)
        {
        }

        protected override ICollector<SaveDataEntity> GetTrigger(IContext<SaveDataEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<SaveDataEntity>(SaveDataMatcher.LoadGameTrigger, GroupEvent.Added));
        }

        protected override bool Filter(SaveDataEntity entity)
        {
            return true;
        }

        protected override void Execute(List<SaveDataEntity> entities)
        {
            Contexts.sharedInstance.saveData.isLoadGameTrigger = false;
            string saveFilePath = $"{Directory.GetCurrentDirectory()}/SaveData/Save.json";

            if (!File.Exists(saveFilePath)) return;

            string saveJson = File.ReadAllText(saveFilePath);
            GameSaveData gameSaveData = JsonConvert.DeserializeObject<GameSaveData>(saveJson);

            foreach (int collectedId in gameSaveData.CollectedIds)
            {
                SaveDataEntity savedCollectable = Contexts.sharedInstance.saveData.CreateEntity();
                savedCollectable.isCollectable = true;
                savedCollectable.AddCollectableId(collectedId);
            }

            foreach (int beatenLevelIndex in gameSaveData.BeatenLevelIndices)
            {
                SaveDataEntity beatenLevel = Contexts.sharedInstance.saveData.CreateEntity();
                beatenLevel.isLevel = true;
                beatenLevel.AddLevelIndex(beatenLevelIndex);
            }

            if (gameSaveData.BeatenLevelTimes != null)
            {
                foreach (BeatenLevelTimeData beatenLevelTime in gameSaveData.BeatenLevelTimes)
                {
                    SaveDataEntity beatenTime = Contexts.sharedInstance.saveData.CreateEntity();
                    beatenTime.AddLevelIndex(beatenLevelTime.LevelIndex);
                    beatenTime.AddGameTime(beatenLevelTime.FastestTime);
                }
            }
        }
    }
}