using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Player
{
    public class StopSimulationOfEntitySystem : ReactiveSystem<GameEntity>
    {
        public StopSimulationOfEntitySystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StopSimulation, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                if (gameEntity.hasVelocity)
                {
                    gameEntity.ReplaceVelocity(Vector3.zero);
                }

                if (gameEntity.hasRigidbody)
                {
                    gameEntity.rigidbody.Value.simulated = false;
                }
            }
        }
    }
}