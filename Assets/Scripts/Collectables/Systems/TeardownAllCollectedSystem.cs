using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Collectables.Systems
{
    public class TeardownAllCollectedSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> allCollectedGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.AllCollectedInLevel);

            foreach (GameEntity gameEntity in allCollectedGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}