using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.UI
{
    public class ShowFinishLevelDialogOnReachedGoalSystem : ReactiveSystem<GameEntity>
    {
        public ShowFinishLevelDialogOnReachedGoalSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.IsInGoal, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return !Contexts.sharedInstance.gameSettings.isSpeedrun;
        }

        protected override async void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            GameEntity finishLevelDialogEntity = gameContext.CreateEntity();
            await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.FinishLevelDialogReference, finishLevelDialogEntity, gameContext.staticLayer.Value.transform);
            finishLevelDialogEntity.isFinishLevelDialog = true;
        }
    }
}