using Entitas;
using SemoGames.Extensions;

namespace SemoGames.CheckpointWall
{
    public class TeardownCheckpointWallsSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> checkpointWallEntities =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.CheckpointWall);

            foreach (GameEntity checkpointWallEntity in checkpointWallEntities.GetEntities())
            {
                checkpointWallEntity.DestroyEntity();
            }
        }
    }
}