using Entitas;
using SemoGames.Extensions;

namespace SemoGames.LevelSelection
{
    public class TeardownLevelSelectedSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelSelectedGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelSelected);

            foreach (GameEntity levelSelectedEntity in levelSelectedGroup.GetEntities())
            {
                levelSelectedEntity.DestroyEntity();
            }
        }
    }
}