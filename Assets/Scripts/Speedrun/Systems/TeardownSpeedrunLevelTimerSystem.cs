using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Speedrun
{
    public class TeardownSpeedrunLevelTimerSystem : ITearDownSystem
    {
        private IGroup<GameEntity> _speedrunLevelTimerGroup;
        
        public TeardownSpeedrunLevelTimerSystem()
        {
            _speedrunLevelTimerGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.SpeedrunLevelTimer);
        }

        public void TearDown()
        {
            foreach (GameEntity speedrunLevelTimerEntity in _speedrunLevelTimerGroup.GetEntities())
            {
                speedrunLevelTimerEntity.DestroyEntity();
            }
        }
    }
}