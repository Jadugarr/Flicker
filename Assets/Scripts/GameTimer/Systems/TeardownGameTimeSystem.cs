using Entitas;
using SemoGames.Extensions;

namespace GameTimer.Systems
{
    public class TeardownGameTimeSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> gameTimeGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.GameTime);

            foreach (GameEntity gameEntity in gameTimeGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}