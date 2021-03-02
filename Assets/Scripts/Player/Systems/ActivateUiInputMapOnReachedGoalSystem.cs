using System.Collections.Generic;
using Entitas;

namespace SemoGames.Player
{
    public class ActivateUiInputMapOnReachedGoalSystem : ReactiveSystem<GameEntity>
    {
        public ActivateUiInputMapOnReachedGoalSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.IsInGoal, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("UI");
        }
    }
}