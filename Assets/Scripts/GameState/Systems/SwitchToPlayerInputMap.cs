using System.Collections.Generic;
using Entitas;

namespace SemoGames.GameState
{
    public class SwitchToPlayerInputMap : ReactiveSystem<GameEntity>
    {
        public SwitchToPlayerInputMap(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.GameState, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.gameState.Value == GameStates.Waiting;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("Player");
        }
    }
}