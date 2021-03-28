using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;
using UnityEngine;

namespace SemoGames.Pause
{
    public class UnpauseSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _pauseOverlayGroup;
        private IGroup<GameEntity> _finishLevelDialogGroup;
        private IGroup<GameEntity> _playerGroup;
        public UnpauseSystem(IContext<GameEntity> context) : base(context)
        {
            _pauseOverlayGroup = context.GetGroup(GameMatcher.PauseOverlay);
            _finishLevelDialogGroup = context.GetGroup(GameMatcher.FinishLevelDialog);
            _playerGroup = context.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Pause, GroupEvent.Removed));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
            
            _pauseOverlayGroup.GetSingleEntity().pauseOverlay.Value.enabled = false;

            foreach (GameEntity gameEntity in _finishLevelDialogGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}