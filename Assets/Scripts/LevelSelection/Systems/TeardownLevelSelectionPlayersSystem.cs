using Entitas;
using SemoGames.Extensions;

namespace SemoGames.LevelSelection
{
    public class TeardownLevelSelectionPlayersSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelSelectionPlayerGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelSelectionPlayer);
            foreach (GameEntity entity in levelSelectionPlayerGroup.GetEntities())
            {
                entity.DestroyEntity();
            }
        }
    }
}