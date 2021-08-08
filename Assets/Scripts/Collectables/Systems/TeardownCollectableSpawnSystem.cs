using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Collectables.Systems
{
    public class TeardownCollectableSpawnSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> collectableSpawnGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.CollectableSpawn);

            foreach (GameEntity collectableSpawnEntity in collectableSpawnGroup.GetEntities())
            {
                collectableSpawnEntity.DestroyEntity();
            }
        }
    }
}