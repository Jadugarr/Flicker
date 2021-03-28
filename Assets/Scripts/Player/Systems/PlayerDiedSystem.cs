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