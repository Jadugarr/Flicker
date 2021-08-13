using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.GameTransition;

namespace SemoGames.LevelSelection
{
    public class LevelSelectedSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _transitionGroup;
        
        public LevelSelectedSystem(IContext<GameEntity> context) : base(context)
        {
            _transitionGroup = context.GetGroup(GameMatcher.TransitionCommands);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelected, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _transitionGroup.count == 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToTeardownTransition,
                    TransitionComponent = new ControllerToTeardownTransitionComponent
                        {Value = GameControllerType.LevelSelection}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToRemove,
                    TransitionComponent = new SceneToRemoveComponent
                        {Value = GameConfigurations.GameSceneConfiguration.LevelSelectionSceneName}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.SceneToAdd,
                    TransitionComponent = new SceneToAddComponent
                        {Value = GameConfigurations.GameSceneConfiguration.GameSceneName,}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.LevelIndexToLoadTransition,
                    TransitionComponent = new LevelIndexToLoadTransitionComponent {Value = entities[0].levelSelected.Value}
                }
            );
        }
    }
}