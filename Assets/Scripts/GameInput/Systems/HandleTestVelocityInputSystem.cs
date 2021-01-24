using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.GameInput
{
    public class HandleTestVelocityInputSystem : ReactiveSystem<InputEntity>
    {
        public HandleTestVelocityInputSystem(IContext<InputEntity> context) : base(context)
        {
        }

        public HandleTestVelocityInputSystem(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<InputEntity>(InputMatcher.InputAction, GroupEvent.Added));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.inputAction.Value.action.name == "TestVelocity";
        }

        protected override void Execute(List<InputEntity> entities)
        {
            Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().ReplaceVelocity(new Vector3(0f, 10f, 0f));
        }
    }
}