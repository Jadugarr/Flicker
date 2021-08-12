using Entitas;
using SemoGames.Extensions;

namespace SemoGames.LevelSelection
{
    public class TeardownLevelGridsSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelGridGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelSelectionGridBehaviour);

            foreach (GameEntity levelGrid in levelGridGroup.GetEntities())
            {
                levelGrid.DestroyEntity();
            }
        }
    }
}