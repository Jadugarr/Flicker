using Entitas;
using SemoGames.Extensions;

namespace SemoGames.LevelSelection
{
    public class TeardownLevelSelectionItemsSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> levelItemGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LevelSelectionItemBehaviour);

            foreach (GameEntity levelEntity in levelItemGroup.GetEntities())
            {
                levelEntity.DestroyEntity();
            }
        }
    }
}