using System.Collections.Generic;
using Entitas;

namespace SemoGames.GameTransition
{
    public class ProcessControllerToTeardownTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _controllerToTeardownEntityGroup;
        
        public ProcessControllerToTeardownTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _controllerToTeardownEntityGroup = context.GetGroup(GameMatcher.ControllerToTeardownTransition);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Removed), new TriggerOnEvent<GameEntity>(GameMatcher.ControllerToTeardownTransition, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _controllerToTeardownEntityGroup.count > 0 && !Contexts.sharedInstance.game.isStartLevelTransition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            gameContext.OnEntityWillBeDestroyed += OnEntityWillBeDestroyed;
            foreach (GameEntity controllerToTeardownTransitionEntity in _controllerToTeardownEntityGroup.GetEntities())
            {
                gameContext.CreateEntity().AddTeardownController(controllerToTeardownTransitionEntity.controllerToTeardownTransition.Value);
            }
        }

        private void OnEntityWillBeDestroyed(IContext context, IEntity entity)
        {
            GameEntity teardownControllerEntity = entity as GameEntity;

            if (teardownControllerEntity.hasTeardownController)
            {
                foreach (GameEntity controllerToTeardown in _controllerToTeardownEntityGroup.GetEntities())
                {
                    if (controllerToTeardown.controllerToTeardownTransition.Value == teardownControllerEntity.teardownController.Value)
                    {
                        controllerToTeardown.RemoveControllerToTeardownTransition();
                        ((GameContext) context).OnEntityWillBeDestroyed -= OnEntityWillBeDestroyed;
                        break;
                    }
                }
            }
        }
    }
}