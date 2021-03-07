using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace SemoGames.GameTransition
{
    public class CheckIfTransitionIsFinishedSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _transitionEntities;
        
        public CheckIfTransitionIsFinishedSystem(IContext<GameEntity> context) : base(context)
        {
            _transitionEntities = context.GetGroup(GameMatcher.TransitionCommands);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AnyOf(GameMatcher.LevelIndexToLoadTransition, GameMatcher.SceneToAdd,
                    GameMatcher.SceneToRemove), GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            bool allTransitionsComplete = true;

            foreach (GameEntity transitionEntity in _transitionEntities.GetEntities())
            {
                IComponent[] transitionComponents = transitionEntity.GetComponents();
                int componentAmount = transitionComponents.Length;
                if (componentAmount > 2) 
                {
                    allTransitionsComplete = false;
                }
            }

            return allTransitionsComplete;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity transitionEntity in _transitionEntities.GetEntities())
            {
                transitionEntity.DestroyEntity();
            }

            Contexts.sharedInstance.game.isEndLevelTransition = true;
        }
    }
}