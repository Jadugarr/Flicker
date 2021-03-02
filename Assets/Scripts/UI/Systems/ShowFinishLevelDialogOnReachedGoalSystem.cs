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
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            GameEntity finishLevelDialogEntity = gameContext.CreateEntity();
            AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.FinishLevelDialogReference,
                finishLevelDialogEntity,
                loadedAsset =>
                {
                    GameObject finishLevelDialog = GameObject.Instantiate(loadedAsset, gameContext.staticLayer.Value.transform, false);
                    finishLevelDialogEntity.isFinishLevelDialog = true;
                    finishLevelDialogEntity.AddView(finishLevelDialog);
                    finishLevelDialog.Link(finishLevelDialogEntity);
                });
        }
    }
}