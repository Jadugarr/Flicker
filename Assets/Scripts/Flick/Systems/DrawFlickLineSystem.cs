using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Flick
{
    public class DrawFlickLineSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _playerGroup;
        private IGroup<GameEntity> _mousePositionGroup;
        private IGroup<GameEntity> _flickLineGroup;

        public DrawFlickLineSystem(IContext<GameEntity> context) : base(context)
        {
            _playerGroup = context.GetGroup(GameMatcher.Player);
            _mousePositionGroup = context.GetGroup(GameMatcher.MousePosition);
            _flickLineGroup = context.GetGroup(GameMatcher.FlickLine);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.MousePosition, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _playerGroup.count > 0 && _mousePositionGroup.count > 0 && _flickLineGroup.count > 0 &&
                   _playerGroup.GetSingleEntity().isStartFlick;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity playerEntity = _playerGroup.GetSingleEntity();
            GameEntity mousePositionEntity = _mousePositionGroup.GetSingleEntity();
            GameEntity flickLineEntity = _flickLineGroup.GetSingleEntity();

            if (playerEntity != null && mousePositionEntity != null && flickLineEntity != null)
            {
                Vector3 lineEndPosition;
                float distance = Vector2.Distance(playerEntity.position.Value, mousePositionEntity.mousePosition.Value);
                flickLineEntity.ReplaceCurrentDragLength(distance);
                if (distance < flickLineEntity.maxDragLength.Value)
                {
                    lineEndPosition = mousePositionEntity.mousePosition.Value;
                }
                else
                {
                    Vector3 dir = ((Vector3) mousePositionEntity.mousePosition.Value - playerEntity.position.Value)
                        .normalized;
                    lineEndPosition = playerEntity.position.Value + dir * flickLineEntity.maxDragLength.Value;
                }
                
                flickLineEntity.flickLine.Value.SetPositions(new[]
                    {playerEntity.position.Value, lineEndPosition});
            }
        }
    }
}