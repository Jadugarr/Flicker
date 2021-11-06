using System;
using System.Collections.Generic;
using Entitas;
using SemoGames.Extensions;

namespace GameTimer.Systems
{
    public class RemoveSpeedrunTimeSystem : ReactiveSystem<GameSettingsEntity>
    {
        private IGroup<GameEntity> _speedrunTimeGroup;

        public RemoveSpeedrunTimeSystem(IContext<GameSettingsEntity> context) : base(context)
        {
            _speedrunTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.SpeedrunTime);
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
            foreach (GameEntity gameEntity in _speedrunTimeGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}