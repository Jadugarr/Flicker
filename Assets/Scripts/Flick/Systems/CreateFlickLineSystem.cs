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

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity lineEntity = Contexts.sharedInstance.game.CreateEntity();
            AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.FlickLineRendererReference, lineEntity,
                resultObject =>
                {
                    GameObject lineRendererObject = Object.Instantiate(resultObject);
                    LineRenderer lineRenderer = lineRendererObject.GetComponent<LineRenderer>();
                    lineRenderer.gameObject.Link(lineEntity);
                    lineEntity.AddFlickLine(lineRenderer);
                    lineEntity.AddView(lineRenderer.gameObject);
                    lineEntity.AddMaxDragLength(GameConfigurations.GameConstantsConfiguration.MaxDragLength);
                    lineEntity.AddCurrentDragLength(0f);
                });
        }
    }
}