using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;
using UnityEngine;

namespace SemoGames.Flick
{
    public class ApplyPowerToCharacterSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _playerGroup;
        
        public ApplyPowerToCharacterSystem(IContext<GameEntity> context) : base(context)
        {
            _playerGroup = context.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartFlick, GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity playerEntity = _playerGroup.GetSingleEntity();

            if (playerEntity != null && playerEntity.hasCurrentFlickPower && playerEntity.hasFlickAngle)
            {
                Vector2 forceToApply =
                    (Vector2.right * playerEntity.currentFlickPower.Value).Rotate(playerEntity.flickAngle.Value);
                playerEntity.ReplaceVelocity(forceToApply);
            }
        }
    }
}