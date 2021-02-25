using System.Collections.Generic;
using Entitas;

namespace SemoGames.Flick
{
    public class ActivateInteractInputMapSystem : ReactiveSystem<GameEntity>
    {
        public ActivateInteractInputMapSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Flick, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("Environment");
        }
    }
}