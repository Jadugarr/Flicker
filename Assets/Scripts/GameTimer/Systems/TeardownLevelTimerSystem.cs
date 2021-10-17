using Entitas;
using SemoGames.Extensions;

namespace GameTimer.Systems
{
    public class TeardownLevelTimerSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelTimerGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelTimer);

            foreach (GameEntity timerEntity in levelTimerGroup.GetEntities())
            {
                timerEntity.DestroyEntity();
            }
        }
    }
}