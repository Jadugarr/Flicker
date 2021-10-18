using System.Collections.Generic;
using Entitas;
using SemoGames.Configurations;
using SemoGames.Controller;
using SemoGames.GameTransition;

namespace Speedrun.Systems
{
    public class ReachedGoalInSpeedrunSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _levelEntityGroup; 

        public ReachedGoalInSpeedrunSystem(IContext<GameEntity> context) : base(context)
        {
            _levelEntityGroup = context.GetGroup(GameMatcher.Level);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.IsInGoal, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return Contexts.sharedInstance.gameSettings.isSpeedrun;
        }

        protected override async void Execute(List<GameEntity> entities)
        {
            int levelCount = GameConfigurations.AssetReferenceConfiguration.LevelAssetReferences.Length;
            int currentLevelIndex = _levelEntityGroup.GetSingleEntity().levelIndex.Value;
            TransitionUtils.StartTransitionSequence(
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.ControllerToRestartTransition,
                    TransitionComponent = new ControllerToRestartTransitionComponent {Value = GameControllerType.Game}
                },
                new TransitionComponentData
                {
                    Index = GameComponentsLookup.LevelIndexToLoadTransition,
                    TransitionComponent = new LevelIndexToLoadTransitionComponent
                        {Value = currentLevelIndex < levelCount - 1 ? currentLevelIndex+1 : 1}
                }
            );
        }
    }
}