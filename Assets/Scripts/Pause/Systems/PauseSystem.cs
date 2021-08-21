using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Pause
{
    public class PauseSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _pauseOverlayGroup;
        
        public PauseSystem(IContext<GameEntity> context) : base(context)
        {
            _pauseOverlayGroup = context.GetGroup(GameMatcher.PauseOverlay);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Pause, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override async void Execute(List<GameEntity> entities)
        {
            Physics2D.simulationMode = SimulationMode2D.Script;
            GameContext gameContext = Contexts.sharedInstance.game;
            GameEntity finishLevelDialogEntity = gameContext.CreateEntity();
            _pauseOverlayGroup.GetSingleEntity().pauseOverlay.Value.enabled = true;
           await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.FinishLevelDialogReference, finishLevelDialogEntity, gameContext.overlayLayer.Value.transform);
           finishLevelDialogEntity.isFinishLevelDialog = true;
        }
    }
}