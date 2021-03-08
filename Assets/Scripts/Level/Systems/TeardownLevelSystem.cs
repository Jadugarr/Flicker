using Entitas;
using SemoGames.Extensions;

namespace Level.Systems
{
    public class TeardownLevelSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Level);

            foreach (GameEntity levelEntity in levelEntities.GetEntities())
            {
                levelEntity.DestroyEntity();
            }
        }
    }
}