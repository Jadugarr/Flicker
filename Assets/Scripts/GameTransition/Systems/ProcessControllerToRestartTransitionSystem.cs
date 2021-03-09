﻿using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace SemoGames.GameTransition
{
    public class ProcessControllerToRestartTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _controllerToRestartEntityGroup;
        
        public ProcessControllerToRestartTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _controllerToRestartEntityGroup = context.GetGroup(GameMatcher.ControllerToRestartTransition);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _controllerToRestartEntityGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameContext gameContext = Contexts.sharedInstance.game;
            gameContext.OnEntityWillBeDestroyed += OnEntityWillBeDestroyed;
            foreach (GameEntity controllerToRestartTransitionEntity in _controllerToRestartEntityGroup.GetEntities())
            {
                gameContext.CreateEntity().AddRestartController(controllerToRestartTransitionEntity.controllerToRestartTransition.Value);
            }
        }

        private void OnEntityWillBeDestroyed(IContext context, IEntity entity)
        {
            GameEntity restartControllerEntity = entity as GameEntity;

            if (restartControllerEntity.hasRestartController)
            {
                foreach (GameEntity controllerToRestart in _controllerToRestartEntityGroup.GetEntities())
                {
                    if (controllerToRestart.controllerToRestartTransition.Value == restartControllerEntity.restartController.Value)
                    {
                        controllerToRestart.AddLevelIndexToLoadTransition(0);
                        controllerToRestart.RemoveControllerToRestartTransition();
                        ((GameContext) context).OnEntityWillBeDestroyed -= OnEntityWillBeDestroyed;
                        break;
                    }
                }
            }
        }
    }
}