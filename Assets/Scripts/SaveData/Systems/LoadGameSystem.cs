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
            CollectableSaveData collectableSaveData = JsonConvert.DeserializeObject<CollectableSaveData>(saveJson);

            foreach (int collectedId in collectableSaveData.CollectedIds)
            {
                SaveDataEntity savedCollectable = Contexts.sharedInstance.saveData.CreateEntity();
                savedCollectable.isCollectable = true;
                savedCollectable.AddCollectableId(collectedId);
            }
        }
    }
}