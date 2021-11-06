using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.Utils;
using UnityEngine;

namespace Speedrun.Systems
{
    public class InitializeSpeedrunControllerSystem : ReactiveSystem<GameSettingsEntity>
    {
        public InitializeSpeedrunControllerSystem(IContext<GameSettingsEntity> context) : base(context)
        {
        }

        protected override ICollector<GameSettingsEntity> GetTrigger(IContext<GameSettingsEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameSettingsEntity>(GameSettingsMatcher.Speedrun, GroupEvent.Added));
        }

        protected override bool Filter(GameSettingsEntity entity)
        {
            return true;
        }

        protected override async void Execute(List<GameSettingsEntity> entities)
        {
            GameEntity speedrunControllerEntity = Contexts.sharedInstance.game.CreateEntity();
            await AssetLoaderUtils.InstantiateAssetAsyncTask(
                GameConfigurations.AssetReferenceConfiguration.SpeedrunControllerReference, speedrunControllerEntity,
                Vector3.zero, Quaternion.identity);
            //speedrunControllerEntity.AddController(speedrunControllerEntity.view.Value.GetComponent<SpeedrunController>());
        }
    }
}