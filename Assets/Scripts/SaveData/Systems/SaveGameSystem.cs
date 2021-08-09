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

        public SaveGameSystem(IContext<SaveDataEntity> context) : base(context)
        {
            _collectedCollectablesGroup =
                context.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.CollectableId, SaveDataMatcher.Collectable));
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

            foreach (SaveDataEntity saveDataEntity in _collectedCollectablesGroup.GetEntities())
            {
                collectedIds.Add(saveDataEntity.collectableId.Value);
            }

            CollectableSaveData saveData = new CollectableSaveData
            {
                CollectedIds = collectedIds.ToArray()
            };

            string json = JsonConvert.SerializeObject(saveData);
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/SaveData");
            File.WriteAllText($"{Directory.GetCurrentDirectory()}/SaveData/Save.json", json);
            Contexts.sharedInstance.saveData.isSaveGameTrigger = false;
        }
    }
}