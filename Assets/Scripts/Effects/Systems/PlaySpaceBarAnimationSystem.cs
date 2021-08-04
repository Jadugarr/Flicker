using System.Collections.Generic;
using Entitas;

namespace SemoGames.Effects
{
    public class PlaySpaceBarAnimationSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> spaceBarAnimationGroup;
        
        public PlaySpaceBarAnimationSystem(IContext<GameEntity> context) : base(context)
        {
            spaceBarAnimationGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.SpaceBarAnimation, GameMatcher.Animation));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AllOf(GameMatcher.Flick), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return spaceBarAnimationGroup != null && spaceBarAnimationGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in spaceBarAnimationGroup.GetEntities())
            {
                gameEntity.animation.Value.Play();
            }
        }
    }
}