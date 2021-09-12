using System.Collections.Generic;
using Entitas;

namespace SemoGames.Player
{
    public class ResumeSimulationOfEntitySystem : ReactiveSystem<GameEntity>
    {
        public ResumeSimulationOfEntitySystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StopSimulation,
                GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                if (gameEntity.hasRigidbody)
                {
                    gameEntity.rigidbody.Value.simulated = true;
                }
            }
        }
    }
}