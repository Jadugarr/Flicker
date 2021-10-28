using System;
using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace GameTimer.Systems
{
    public class RemoveSpeedrunTimerSystem : ReactiveSystem<GameSettingsEntity>
    {
        private IGroup<GameEntity> _gameTimeGroup;

        public RemoveSpeedrunTimerSystem(IContext<GameSettingsEntity> context) : base(context)
        {
            _gameTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.GameTime);
        }

        protected override ICollector<GameSettingsEntity> GetTrigger(IContext<GameSettingsEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameSettingsEntity>(GameSettingsMatcher.Speedrun, GroupEvent.AddedOrRemoved));
        }

        protected override bool Filter(GameSettingsEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameSettingsEntity> entities)
        {
            foreach (GameEntity gameEntity in _gameTimeGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}