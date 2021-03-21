using System.Collections.Generic;
using Entitas;
using SemoGames.Common;
using UnityEngine;

namespace SemoGames.Flick
{
    public class DetectStopMovingSystem : ReactiveSystem<GameEntity>
    {
        public DetectStopMovingSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Velocity, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFlick && !entity.isIsInGoal && entity.hasGroundState && entity.groundState.Value == GroundState.Ground;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity characterEntity in entities)
            {
                if (Vector3.Distance(Vector3.zero, characterEntity.velocity.Value) < 0.1f)
                {
                    characterEntity.ReplaceVelocity(Vector3.zero);
                    characterEntity.isFlick = false;
                }
            }
        }
    }
}