using Entitas;
using SemoGames.GameCamera;

namespace SemoGames.Controller
{
    public class InitController : AGameController
    {
        public override GameControllerType GetGameControllerType()
        {
            return GameControllerType.Init;
        }

        protected override IContext GetContext()
        {
            return Contexts.sharedInstance.game;
        }

        protected override void AfterAwake()
        {
            GetContext().OnEntityCreated += OnEntityCreated;
        }

        private void OnEntityCreated(IContext context, IEntity entity)
        {
            (entity as GameEntity)?.AddId(entity.creationIndex);
        }

        protected override Systems CreateUpdateSystems(IContext context)
        {
            return new Systems()
                .Add(new InitCameraSystem());
        }

        protected override Systems CreateLateUpdateSystems(IContext context)
        {
            return new Systems();
        }

        protected override Systems CreateFixedUpdateSystems(IContext context)
        {
            return new Systems();
        }
    }
}