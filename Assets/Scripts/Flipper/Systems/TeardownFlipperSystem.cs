using Entitas;
using SemoGames.Extensions;

namespace SemoGames.Flipper
{
    public class TeardownFlipperSystem : ITearDownSystem
    {
        public void TearDown()
        {
            IGroup<GameEntity> flipperGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.Flipper);
            IGroup<GameEntity> leftFlipperGroup = Contexts.sharedInstance.game.GetGroup(GameMatcher.LeftFlipper);

            foreach (GameEntity flipperEntity in flipperGroup.GetEntities())
            {
                flipperEntity.DestroyEntity();
            }

            foreach (GameEntity leftFlipperEntity in leftFlipperGroup.GetEntities())
            {
                leftFlipperEntity.DestroyEntity();
            }
        }
    }
}