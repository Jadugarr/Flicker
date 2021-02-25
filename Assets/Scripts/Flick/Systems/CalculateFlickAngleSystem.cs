using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Flick
{
    public class CalculateFlickAngleSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _playerGroup;
        
        public CalculateFlickAngleSystem(IContext<GameEntity> context) : base(context)
        {
            _playerGroup = context.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.CurrentDragLength,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity flickLineEntity in entities)
            {
                LineRenderer lineRenderer = flickLineEntity.flickLine.Value;
                Vector2 dir = (lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized;
                float angle = Vector2.Angle(Vector2.right, dir);
                _playerGroup.GetSingleEntity().ReplaceFlickAngle(angle);
            }
        }
    }
}