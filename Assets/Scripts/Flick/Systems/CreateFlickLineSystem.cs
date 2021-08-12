using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Flick
{
    public class CreateFlickLineSystem : ReactiveSystem<GameEntity>
    {
        public CreateFlickLineSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartFlick, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override async void Execute(List<GameEntity> entities)
        {
            GameEntity lineEntity = Contexts.sharedInstance.game.CreateEntity();
            await AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.FlickLineRendererReference, lineEntity, Vector3.zero, Quaternion.identity);
            LineRenderer lineRenderer = lineEntity.view.Value.GetComponent<LineRenderer>();
            lineEntity.AddFlickLine(lineRenderer);
            lineEntity.AddMaxDragLength(GameConfigurations.GameConstantsConfiguration.MaxDragLength);
            lineEntity.AddCurrentDragLength(0f);
        }
    }
}