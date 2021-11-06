using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Speedrun
{
    public class TeardownSpeedrunTimeSystem : ITearDownSystem
    {
        private IGroup<GameEntity> _speedrunTimeGroup;

        public TeardownSpeedrunTimeSystem()
        {
            _speedrunTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.SpeedrunTime);
        }

        public void TearDown()
        {
            foreach (GameEntity speedrunTimeEntity in _speedrunTimeGroup.GetEntities())
            {
                speedrunTimeEntity.DestroyEntity();
            }
        }
    }
}