using System;
using System.Collections.Generic;
using Entitas;

namespace SemoGames.Effects
{
    public class PlayFlipperTutorialAnimationSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> flipperAnimationGroup;
        
        public PlayFlipperTutorialAnimationSystem(IContext<GameEntity> context) : base(context)
        {
            flipperAnimationGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.FlipperAnimation, GameMatcher.Animation));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(
                GameMatcher.AllOf(GameMatcher.Flick), GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return flipperAnimationGroup != null && flipperAnimationGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in flipperAnimationGroup.GetEntities())
            {
                gameEntity.animation.Value.Play();
            }
        }
    }
}