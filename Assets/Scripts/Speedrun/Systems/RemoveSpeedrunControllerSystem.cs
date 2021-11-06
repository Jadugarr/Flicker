using System.Collections.Generic;
using Entitas;
using SemoGames.Controller;
using SemoGames.Extensions;

namespace SemoGames.Speedrun
{
    public class RemoveSpeedrunControllerSystem : ReactiveSystem<GameSettingsEntity>
    {
        private IGroup<GameEntity> _controllerGroup;

        public RemoveSpeedrunControllerSystem(IContext<GameSettingsEntity> context) : base(context)
        {
            _controllerGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Controller);
        }

        protected override ICollector<GameSettingsEntity> GetTrigger(IContext<GameSettingsEntity> context)
        {
            return context.CreateCollector(
                new TriggerOnEvent<GameSettingsEntity>(GameSettingsMatcher.Speedrun, GroupEvent.Removed));
        }

        protected override bool Filter(GameSettingsEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameSettingsEntity> entities)
        {
            foreach (GameEntity controllerEntity in _controllerGroup.GetEntities())
            {
                if (controllerEntity.controller.Value.GetGameControllerType() == GameControllerType.Speedrun)
                {
                    controllerEntity.controller.Value.Teardown();
                    controllerEntity.DestroyEntity();
                    break;
                }
            }
        }
    }
}