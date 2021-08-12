using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerDiedSystem : ReactiveSystem<GameEntity>
    {
        public PlayerDiedSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Dead));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.isDead;
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