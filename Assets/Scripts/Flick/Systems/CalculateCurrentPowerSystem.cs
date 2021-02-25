using System.Collections.Generic;
using Entitas;

namespace SemoGames.Flick
{
    public class CalculateCurrentPowerSystem : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> _playerGroup;
        private IGroup<GameEntity> _flickLineGroup;
        
        public CalculateCurrentPowerSystem(IContext<GameEntity> context) : base(context)
        {
            _playerGroup = context.GetGroup(GameMatcher.Player);
            _flickLineGroup = context.GetGroup(GameMatcher.FlickLine);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.CurrentDragLength, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _playerGroup.count > 0 && _flickLineGroup.count > 0 &&
                   _playerGroup.GetSingleEntity().isStartFlick;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            
            GameEntity playerEntity = _playerGroup.GetSingleEntity();
            GameEntity flickLineEntity = _flickLineGroup.GetSingleEntity();

            if (playerEntity != null && flickLineEntity != null)
            {
                float currentPower = 0f;
                float currentDragLength = flickLineEntity.currentDragLength.Value;
                float maxDragLength = flickLineEntity.maxDragLength.Value;
                if (currentDragLength < maxDragLength)
                {
                    currentPower = (currentDragLength / maxDragLength) * playerEntity.maxFlickPower.Value;
                }
                else
                {
                    currentPower = playerEntity.maxFlickPower.Value;
                }
                
                playerEntity.ReplaceCurrentFlickPower(currentPower);
            }
        }
    }
}