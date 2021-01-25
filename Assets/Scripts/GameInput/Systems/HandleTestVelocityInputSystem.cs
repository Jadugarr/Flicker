using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

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
            InputAction.CallbackContext inputAction = entity.inputAction.Value;
            return inputAction.action.name == "TestVelocity"; // && inputAction.phase == InputActionPhase.Performed;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            Debug.Log($"[TestVelocity] Entity count: {entities.Count}");
            foreach (InputEntity inputEntity in entities)
            {
                Debug.Log($"[TestVelocity] Processed Input phase: {inputEntity.inputAction.Value.phase}; Entity Id: {inputEntity.id.Value}");
            }
            Contexts.sharedInstance.game.GetGroup(GameMatcher.Player).GetSingleEntity().ReplaceVelocity(new Vector3(0f, 10f, 0f));
        }
    }
}