using Entitas;
using UnityEngine;

namespace GameTimer.Systems
{
    public class MeasureSpeedrunTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _speedrunTimeGroup;

        public MeasureSpeedrunTimeSystem()
        {
            _speedrunTimeGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.SpeedrunTime);
        }

        public void Execute()
        {
            if (_speedrunTimeGroup.count > 0)
            {
                GameEntity speedrunTimeEntity = _speedrunTimeGroup.GetSingleEntity();

                if (speedrunTimeEntity != null && speedrunTimeEntity.isActive)
                {
                    speedrunTimeEntity.ReplaceSpeedrunTime(speedrunTimeEntity.speedrunTime.Value + Time.deltaTime);
                }
            }
        }
    }
}