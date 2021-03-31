using Entitas;
using SemoGames.Extensions;

namespace Bumpers.Systems
{
    public class TeardownBumpersSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> bumperGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Bumper);

            foreach (GameEntity bumperEntity in bumperGroup.GetEntities())
            {
                bumperEntity.DestroyEntity();
            }
        }
    }
}