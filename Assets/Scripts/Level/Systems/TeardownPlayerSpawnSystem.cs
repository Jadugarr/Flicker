using Entitas;
using SemoGames.Extensions;

namespace Level.Systems
{
    public class TeardownPlayerSpawnSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> playerSpawnEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.PlayerSpawn);

            foreach (GameEntity playerSpawnEntity in playerSpawnEntities.GetEntities())
            {
                playerSpawnEntity.DestroyEntity();
            }
        }
    }
}