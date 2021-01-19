using Entitas;
using GameInput.Systems;
using SemoGames.Controller;

namespace Controller
{
    public class GameInputController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Input;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.input;
        }

        protected override void AfterAwake()
        {
            GetContext().OnEntityCreated += OnEntityCreated;
        }

        private void OnEntityCreated(IContext context, IEntity entity)
        {
            (entity as InputEntity)?.AddId(entity.creationIndex);
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            return new Systems()
                .Add(new CleanupInputActionsSystem());
        }
    }
}