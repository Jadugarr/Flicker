using Entitas;
using SemoGames.Extensions;

namespace SemoGames.CheckpointWall
{
    public class TeardownLastTriggeredCheckpointSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> lastTriggeredCheckpointGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.LastTriggeredCheckpointEntityId);
            foreach (GameEntity gameEntity in lastTriggeredCheckpointGroup.GetEntities())
            {
                gameEntity.DestroyEntity();
            }
        }
    }
}