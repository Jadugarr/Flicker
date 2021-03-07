using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace SemoGames.GameTransition
{
    public class StartLevelTransitionSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _levelTransitionOverlayGroup;
        
        public StartLevelTransitionSystem(IContext<GameEntity> context) : base(context)
        {
            _levelTransitionOverlayGroup = context.GetGroup(GameMatcher.LevelTransitionOverlay);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.StartLevelTransition,
                GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _levelTransitionOverlayGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity overlayEntity = _levelTransitionOverlayGroup.GetSingleEntity();
            overlayEntity.levelTransitionOverlay.Value.DOFade(1f, 1f).onComplete += () =>
            {
                Debug.Log("Done!");
                Contexts.sharedInstance.game.isStartLevelTransition = false;
                Contexts.sharedInstance.game.isEndLevelTransition = true;
            };
        }
    }
}