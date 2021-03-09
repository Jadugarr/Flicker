using System.Collections.Generic;
using Entitas;

namespace SemoGames.GameTransition
{
    public class ProcessLevelIndexToLoadTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _levelIndexToLoadGroup;
        private IGroup<GameEntity> _levelEntities;
        
        public ProcessLevelIndexToLoadTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _levelIndexToLoadGroup = context.GetGroup(GameMatcher.LevelIndexToLoadTransition);
            _levelEntities = context.GetGroup(GameMatcher.Level);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Removed), new TriggerOnEvent<GameEntity>(GameMatcher.LevelIndexToLoadTransition, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _levelIndexToLoadGroup.count > 0 && !Contexts.sharedInstance.game.isStartLevelTransition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelIndexToLoadEntity in _levelIndexToLoadGroup.GetEntities())
            {
                GameEntity levelEntity;
                if (_levelEntities.count > 0)
                {
                    levelEntity = _levelEntities.GetSingleEntity();
                }
                else
                {
                    levelEntity = Contexts.sharedInstance.game.CreateEntity();
                    levelEntity.isLevel = true;
                }
                
                levelEntity.ReplaceLevelIndex(levelIndexToLoadEntity.levelIndexToLoadTransition.Value);
                levelIndexToLoadEntity.RemoveLevelIndexToLoadTransition();
            }
        }
    }
}