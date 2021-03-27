using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace SemoGames.Pause
{
    public class PauseSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _pauseOverlayGroup;
        
        public PauseSystem(IContext<GameEntity> context) : base(context)
        {
            _pauseOverlayGroup = context.GetGroup(GameMatcher.PauseOverlay);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Pause, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Physics2D.simulationMode = SimulationMode2D.Script;
            Contexts.sharedInstance.input.playerInput.Value.SwitchCurrentActionMap("UI");
            _pauseOverlayGroup.GetSingleEntity().pauseOverlay.Value.enabled = true;
        }
    }
}