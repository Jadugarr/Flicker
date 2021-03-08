using System.Collections.Generic;
using Entitas;

namespace SemoGames.Flick
{
    public class ActivatePlayerInputMapSystem : ReactiveSystem<GameEntity>
    {
        public ActivatePlayerInputMapSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameEntity>(GameMatcher.AnyOf(GameMatcher.Flick, GameMatcher.IsInGoal),
                    GroupEvent.Removed), new TriggerOnEvent<GameEntity>(GameMatcher.Player, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("Player");
        }
    }
}