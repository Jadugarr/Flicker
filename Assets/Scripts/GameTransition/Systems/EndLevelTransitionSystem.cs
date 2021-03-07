using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace SemoGames.GameTransition
{
    public class EndLevelTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _levelTransitionOverlayGroup;
        
        public EndLevelTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _levelTransitionOverlayGroup = context.GetGroup(GameMatcher.LevelTransitionOverlay);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.EndLevelTransition,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _levelTransitionOverlayGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity overlayEntity = _levelTransitionOverlayGroup.GetSingleEntity();
            overlayEntity.levelTransitionOverlay.Value.DOFade(0f, 1f).onComplete += () =>
            {
                Contexts.sharedInstance.game.isEndLevelTransition = false;
            };
        }
    }
}