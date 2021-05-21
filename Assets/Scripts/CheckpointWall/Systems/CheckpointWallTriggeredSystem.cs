using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace SemoGames.CheckpointWall
{
    public class CheckpointWallTriggeredSystem : ReactiveSystem<GameEntity>
    {
        public CheckpointWallTriggeredSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AllOf(GameMatcher.CheckpointWall, GameMatcher.Triggered), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isCheckpointWall && entity.isTriggered;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity wallEntity in entities)
            {
                Vector2 wallEndMarkerPosition = wallEntity.checkpointEndMarker.Value.localPosition;
                SpriteRenderer wallSpriteRenderer = wallEntity.spriteRenderer.Value;
                Transform wallSpriteRendererTransform = wallSpriteRenderer.transform;
                Vector3 currentWallSpriteRendererPosition = wallSpriteRendererTransform.localPosition;

                DOTween.To(() => wallSpriteRenderer.size, value => wallSpriteRenderer.size = value,
                    new Vector2(Mathf.Max(1f, Mathf.Abs(wallEndMarkerPosition.x)),
                        Mathf.Max(1f, Mathf.Abs(wallEndMarkerPosition.y))),
                    1f);
                DOTween.To(() => wallSpriteRendererTransform.localPosition,
                    value => wallSpriteRendererTransform.localPosition = value, new Vector3(
                        currentWallSpriteRendererPosition.x +
                        (wallEndMarkerPosition.x - currentWallSpriteRendererPosition.x) / 2f,
                        currentWallSpriteRendererPosition.y +
                        (wallEndMarkerPosition.y - currentWallSpriteRendererPosition.y) / 2f, 0f), 1f);

                wallEntity.checkpointTriggerObject.Value.SetActive(false);
            }
        }
    }
}