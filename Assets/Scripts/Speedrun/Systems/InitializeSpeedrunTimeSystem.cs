using Entitas;

namespace SemoGames.GameTimer
{
    public class InitializeSpeedrunTimeSystem : IInitializeSystem
    {
        private IGroup<GameEntity> _speedrunTimeGroup;

        public InitializeSpeedrunTimeSystem()
        {
            _speedrunTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.SpeedrunTime);
        }

        public void Initialize()
        {
            if (_speedrunTimeGroup.count > 0) return;
            
            if (Contexts.sharedInstance.gameSettings.isSpeedrun)
            {
                var speedrunTimeEntity = Contexts.sharedInstance.game.CreateEntity();
                speedrunTimeEntity.isActive = true;
                speedrunTimeEntity.AddSpeedrunTime(0f);
            }
        }
    }
}