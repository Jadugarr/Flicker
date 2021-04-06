using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Collectables.Systems
{
    public class TeardownCollectablesSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> collectableGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Collectable);

            foreach (GameEntity collectableEntity in collectableGroup.GetEntities())
            {
                collectableEntity.DestroyEntity();
            }
        }
    }
}