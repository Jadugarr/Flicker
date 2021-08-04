using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace Controller
{
    public class TeardownControllerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _controllerGroup;
        
        public TeardownControllerSystem(IContext<GameEntity> context) : base(context)
        {
            _controllerGroup = context.GetGroup(GameMatcher.Controller);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.TeardownController,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity teardownEntities in entities)
            {
                foreach (GameEntity controllerEntity in _controllerGroup.GetEntities())
                {
                    if (controllerEntity.controller.Value.GetGameControllerType() == teardownEntities.teardownController.Value)
                    {
                        controllerEntity.controller.Value.Teardown();
                    }
                }
                
                teardownEntities.DestroyEntity();
            }
        }
    }
}