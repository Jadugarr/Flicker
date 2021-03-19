using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Flipper
{
    public class TeardownFlipperSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> flipperGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Flipper);

            foreach (GameEntity flipperEntity in flipperGroup.GetEntities())
            {
                flipperEntity.DestroyEntity();
            }
        }
    }
}