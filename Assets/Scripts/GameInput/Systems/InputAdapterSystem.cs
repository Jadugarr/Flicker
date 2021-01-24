using System.Collections.Generic;
using Entitas;

namespace SemoGames.GameInput
{
    public class InputAdapterSystem : ReactiveSystem<InputEntity>
    {
        public InputAdapterSystem(IContext<InputEntity> context) : base(context)
        {
        }

        public InputAdapterSystem(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<InputEntity>(InputMatcher.InputAdapter,
                GroupEvent.Added));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInputAdapter;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity inputEntity in entities)
            {
                Contexts.sharedInstance.input.CreateEntity().AddInputAction(inputEntity.inputAdapter.Value);
                inputEntity.Destroy();
            }
        }
    }
}