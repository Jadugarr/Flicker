using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace Controller
{
    public class RestartControllerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _controllerGroup;
        
        public RestartControllerSystem(IContext<GameEntity> context) : base(context)
        {
            _controllerGroup = context.GetGroup(GameMatcher.Controller);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.RestartController,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity restartEntities in entities)
            {
                foreach (GameEntity controllerEntity in _controllerGroup.GetEntities())
                {
                    if (controllerEntity.controller.Value.GetGameControllerType() == restartEntities.restartController.Value)
                    {
                        controllerEntity.controller.Value.RestartController();
                    }
                }
                
                restartEntities.DestroyEntity();
            }
        }
    }
}